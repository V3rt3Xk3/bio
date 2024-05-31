using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bio;
using Bio.IO;
using Bio.IO.FastQ;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Bio.Properties;

namespace Bio.Tests.IO.FastQ
{
    /// <summary>
    /// FASTQ format parser and formatter.
    /// </summary>
    [TestFixture]
    public class FastQTests
    {

        /// <summary>
        /// Verifies that the parser doesn't throw an exception when Parsing first sequence on a file
        /// containing more than one sequence.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestFastQWhenParsingOneOfMany()
        {
            string filepath = @"TestUtils\FastQ\SRR002012_5.fastq".TestDir();
            
            // Parse
            ISequence seq = new FastQParser().ParseOne(filepath);
            ClassicAssert.IsNotNull(seq);

            FastQParser fqParser = new FastQParser
            {
                FormatType = FastQFormatType.Sanger, 
                Alphabet = Alphabets.DNA
            };
            using (fqParser.Open(filepath))
            {
                var qualSeq = fqParser.Parse().First() as QualitativeSequence;
                ClassicAssert.IsNotNull(qualSeq);
            }
        }

        /// <summary>
        /// Test formatter - by reading the multisequence FASTQ file SRR002012_5.fastq,
        /// writing it back to disk using the formatter, then reading the new file
        /// and confirming that the data has been written correctly.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastQFormatter()
        {
            string FilepathOriginal = @"TestUtils\FastQ\SRR002012_5.fastq".TestDir();
            ClassicAssert.IsTrue(File.Exists(FilepathOriginal));
            
            IList<IQualitativeSequence> seqsOriginal;
            string filepathTmp = Path.GetTempFileName();

            FastQParser parser = new FastQParser();
            using (parser.Open(FilepathOriginal))
            {
                // Read the original file
                seqsOriginal = parser.Parse().ToList();
                ClassicAssert.IsNotNull(seqsOriginal);

                // Use the formatter to write the original sequences to a temp file
                new FastQFormatter()
                    .Format(seqsOriginal, filepathTmp);
            }

            // Read the new file, then compare the sequences
            using (parser.Open(filepathTmp))
            {
                IList<IQualitativeSequence> seqsNew = parser.Parse().ToList();
                ClassicAssert.IsNotNull(seqsNew);

                // Now compare the sequences.
                int countOriginal = seqsOriginal.Count;
                int countNew = seqsNew.Count;
                ClassicAssert.AreEqual(countOriginal, countNew);

                int i;
                for (i = 0; i < countOriginal; i++)
                {
                    var orgSequence = seqsOriginal[i];
                    var sequence = seqsNew[i];

                    ClassicAssert.AreEqual(seqsOriginal[i].ID, sequence.ID);
                    string orgSeq = Encoding.ASCII.GetString(orgSequence.ToArray());
                    string newSeq = Encoding.ASCII.GetString(sequence.ToArray());
                    string orgscores = Encoding.ASCII.GetString(orgSequence.GetEncodedQualityScores());
                    string newscores = Encoding.ASCII.GetString(sequence.GetEncodedQualityScores());
                    ClassicAssert.AreEqual(orgSeq, newSeq);
                    ClassicAssert.AreEqual(orgscores, newscores);
                }
            }

            // Passed all the tests, delete the tmp file. If we failed an Assert,
            // the tmp file will still be there in case we need it for debugging.
            File.Delete(filepathTmp);

        }

        /// <summary>
        /// Test formatter - by reading the multi-sequence FASTQ file SRR002012_5.fastq,
        /// writing it back to disk using the ISequenceFormatter interface, then reading the new file
        /// and confirming that the data has been written correctly.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastQFormatterUsingInterface()
        {
            string FilepathOriginal = @"TestUtils\FastQ\SRR002012_5.fastq".TestDir();
            ClassicAssert.IsTrue(File.Exists(FilepathOriginal));

            string filepathTmp = Path.GetTempFileName();

            IList<QualitativeSequence> seqsOriginal = new FastQParser()
                .Parse(FilepathOriginal)
                .Cast<QualitativeSequence>()
                .ToList();

            // Use the formatter to write the original sequences to a temp file
            new FastQFormatter()
                .Format(seqsOriginal, filepathTmp);

            // Read the new file, then compare the sequences
            IList<QualitativeSequence> seqsNew = new FastQParser()
                .Parse(filepathTmp)
                .Cast<QualitativeSequence>()
                .ToList();

            // Now compare the sequences.
            int countOriginal = seqsOriginal.Count;
            int countNew = seqsNew.Count;
            ClassicAssert.AreEqual(countOriginal, countNew);

            int i;
            for (i = 0; i < countOriginal; i++)
            {
                ClassicAssert.AreEqual(seqsOriginal[i].ID, seqsNew[i].ID);
                string orgSeq = Encoding.ASCII.GetString(seqsOriginal[i].ToArray());
                string newSeq = Encoding.ASCII.GetString(seqsNew[i].ToArray());
                string orgscores = Encoding.ASCII.GetString(seqsOriginal[i].GetEncodedQualityScores());
                string newscores = Encoding.ASCII.GetString(seqsNew[i].GetEncodedQualityScores());
                ClassicAssert.AreEqual(orgSeq, newSeq);
                ClassicAssert.AreEqual(orgscores, newscores);
            }

            // Passed all the tests, delete the tmp file. If we failed an Assert,
            // the tmp file will still be there in case we need it for debugging.
            File.Delete(filepathTmp);
        }

        /// <summary>
        /// Verify that the parser can read many files without exceptions.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastQParserForManyFiles()
        {
            string Path = @"TestUtils\FastQ".TestDir();
            ClassicAssert.IsTrue(Directory.Exists(Path));
            int count = 0;
           
            var di = new DirectoryInfo(Path);

            foreach (QualitativeSequence seq in 
                di.GetFiles("*.fastq")
                    .SelectMany(fi => new FastQParser()
                            .Parse(fi.FullName)
                            .Cast<QualitativeSequence>()))
            {
                ClassicAssert.IsNotNull(seq);
                count++;
            }

            ClassicAssert.IsTrue(count >= 3);
        }

        /// <summary>
        /// Tests the name,description and file extension property of 
        /// Fasta formatter and parser.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastQProperties()
        {
            FastQParser parser = new FastQParser();
            ClassicAssert.AreEqual(parser.Name, Resource.FastQName);
            ClassicAssert.AreEqual(parser.Description, Resource.FASTQPARSER_DESCRIPTION);
            ClassicAssert.AreEqual(parser.SupportedFileTypes, Resource.FASTQ_FILEEXTENSION);

            FastQFormatter formatter = new FastQFormatter();
            ClassicAssert.AreEqual(formatter.Name, Resource.FastQName);
            ClassicAssert.AreEqual(formatter.Description, Resource.FASTQFORMATTER_DESCRIPTION);
            ClassicAssert.AreEqual(formatter.SupportedFileTypes, Resource.FASTQ_FILEEXTENSION);
        }

        /// <summary>
        /// Tests the default FastQ format type.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestDefaultFastQFormatType()
        {
            FastQParser parser = new FastQParser();
            ClassicAssert.AreEqual(parser.FormatType, FastQFormatType.Illumina_v1_8);
        }
    }
}

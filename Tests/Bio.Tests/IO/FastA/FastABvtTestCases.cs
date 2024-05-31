/****************************************************************************
 * FastABvtTestCases.cs
 * 
 *   This file contains the Fasta - Parsers and Formatters Bvt test cases.
 * 
***************************************************************************/

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Bio.IO.FastA;
using Bio.TestAutomation.Util;
using Bio.Tests;
using Bio.Util.Logging;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.TestAutomation.IO.FastA
{
    /// <summary>
    ///     FASTA Bvt parser and formatter Test case implementation.
    /// </summary>
    [TestFixture]
    public class FastABvtTestCases
    {
        #region Global Variables

        private readonly Utility utilityObj = new Utility(@"TestUtils\TestsConfig.xml");

        #endregion Global Variables

        #region FastA Parser Bvt Test cases

        /// <summary>
        ///     Parse a valid FastA file (Small size sequence less than 35 kb) and convert the
        ///     same to one sequence using Parse(file-name) method and validate with the
        ///     expected sequence.
        ///     Input : FastA File
        ///     Validation : Expected sequence, Sequence Length, Sequence Alphabet, Sequence ID.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAParserValidateParse()
        {
            // Gets the expected sequence from the Xml
            string filePath = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                              Constants.FilePathNode).TestDir();

            ClassicAssert.IsTrue(File.Exists(filePath));

            // Logs information to the log file            
            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: File Exists in the Path '{0}'.", filePath));

            var parser = new FastAParser();
            {
                parser.Alphabet = Alphabets.Protein;
                IEnumerable<ISequence> seqsList = parser.Parse(filePath);

                ClassicAssert.IsNotNull(seqsList);
                ClassicAssert.AreEqual(1, seqsList.Count());

                ApplicationLog.WriteLine(string.Format("FastA Parser BVT: Number of Sequences found are '{0}'.",
                                                       seqsList.Count()));

                string expectedSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                          Constants.ExpectedSequenceNode);

                var seq = (Sequence) seqsList.ElementAt(0);
                char[] seqString = seqsList.ElementAt(0).Select(a => (char) a).ToArray();
                var newSequence = new string(seqString);

                ClassicAssert.IsNotNull(seq);
                ClassicAssert.AreEqual(expectedSequence, newSequence);

                ApplicationLog.WriteLine(string.Format(null,
                                                       "FastA Parser BVT: The FASTA sequence '{0}' validation after Parse() is found to be as expected.",
                                                       newSequence));

                var tmpEncodedSeq = new byte[seq.Count];
                (seq).ToArray().CopyTo(tmpEncodedSeq, 0);

                ClassicAssert.AreEqual(expectedSequence.Length, tmpEncodedSeq.Length);
                ApplicationLog.WriteLine(string.Format(null,
                                                       "FastA Parser BVT: The FASTA Length sequence '{0}' is as expected.",
                                                       expectedSequence.Length));

                ClassicAssert.IsNotNull(seq.Alphabet);
                ClassicAssert.AreEqual(seq.Alphabet.Name.ToLower(CultureInfo.CurrentCulture),
                                utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                Constants.AlphabetNameNode)
                                          .ToLower(CultureInfo.CurrentCulture));
                ApplicationLog.WriteLine(string.Format(null,
                                                       "FastA Parser BVT: The Sequence Alphabet is '{0}' and is as expected.",
                                                       seq.Alphabet.Name));

                ClassicAssert.AreEqual(utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                Constants.SequenceIdNode), seq.ID);
                ApplicationLog.WriteLine(string.Format(null,
                                                       "FastA Parser BVT: The Sequence ID is '{0}' and is as expected.",
                                                       seq.ID));
            }
        }

        /// <summary>
        ///     Validates the movenext method
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAParserValidateMoveNext()
        {
            string filePath = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                              Constants.FilePathNode).TestDir();
            ClassicAssert.IsTrue(File.Exists(filePath));
            // Logs information to the log file            
            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: File Exists in the Path '{0}'.", filePath));
            IEnumerable<ISequence> seqsList = null;
            var parser = new FastAParser();
            {
                parser.Alphabet = Alphabets.Protein;
                seqsList = parser.Parse(filePath);
                ClassicAssert.IsNotNull(seqsList);
                ClassicAssert.AreEqual(1, seqsList.Count());
                ApplicationLog.WriteLine(string.Format(null,
                                                       "FastA Parser BVT: Number of Sequences found are '{0}'.",
                                                       seqsList.Count()));
                string expectedSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                          Constants.ExpectedSequenceNode);
                ClassicAssert.IsNotNull(seqsList.ElementAt(0));
                ClassicAssert.AreEqual(expectedSequence, new string(seqsList.ElementAt(0).Select(a => (char) a).ToArray()));
            }
        }

        /// <summary>
        ///     Parse a valid FastA file (Small size sequence less than 35 kb) and convert the
        ///     same to one sequence using Parse(Stream) method and validate with the
        ///     expected sequence.
        ///     Input : FastA File
        ///     Validation : Expected sequence,Sequence Alphabet, Sequence ID.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAParserValidateParseWithStream()
        {
            List<ISequence> seqsList;
            // Gets the expected sequence from the Xml
            string filePath = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                              Constants.FilePathNode).TestDir();

            ClassicAssert.IsTrue(File.Exists(filePath));

            // Logs information to the log file            
            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: File Exists in the Path '{0}'.", filePath));

            using (var reader = File.OpenRead(filePath))
            {
                IEnumerable<ISequence> seq = null;

                var parser = new FastAParser();
                {
                    parser.Alphabet = Alphabets.Protein;
                    seq = parser.Parse(reader);

                    //Create a list of sequences.
                    seqsList = seq.ToList();
                }
            }

            ClassicAssert.IsNotNull(seqsList);

            string expectedSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                      Constants.ExpectedSequenceNode);

            var seqString = new string(seqsList[0].Select(a => (char) a).ToArray());
            ClassicAssert.AreEqual(expectedSequence, seqString);

            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: The FASTA sequence '{0}' validation after Parse(Stream) is found to be as expected.",
                                                   seqString));

            //Validate Alphabet type for a sequence.
            ClassicAssert.IsNotNull(seqsList[0].Alphabet);
            ClassicAssert.AreEqual(seqsList[0].Alphabet.Name.ToLower(CultureInfo.CurrentCulture),
                            utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                            Constants.AlphabetNameNode)
                                      .ToLower(CultureInfo.CurrentCulture));
            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: The Sequence Alphabet is '{0}' and is as expected.",
                                                   seqsList[0].Alphabet.Name));

            //Validate ID for the sequence.
            ClassicAssert.AreEqual(utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                            Constants.SequenceIdNode), seqsList[0].ID);
            ApplicationLog.WriteLine(string.Format(null,
                                                   "FastA Parser BVT: The Sequence ID is '{0}' and is as expected.",
                                                   seqsList[0].ID));
        }

        #endregion FastA Parser BVT Test cases

        #region FastA Formatter Bvt Test cases

        /// <summary>
        ///     Format a valid Single Sequence (Small size sequence less than 35 kb) to a
        ///     FastA file Write() method with Sequence and Writer as parameter
        ///     and validate the same.
        ///     Input : FastA Sequence
        ///     Validation : Read the FastA file to which the sequence was formatted and
        ///     validate Sequence, Sequence Count
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateWrite()
        {
            var formatter = new FastAFormatter();
            {
                // Gets the actual sequence and the alphabet from the Xml
                string actualSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                        Constants.ExpectedSequenceNode);
                string alpName = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                 Constants.AlphabetNameNode);
                // Logs information to the log file
                ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Validating with Sequence '{0}' and Alphabet '{1}'.",
                                                       actualSequence, alpName));
                var seqOriginal = new Sequence(Utility.GetAlphabet(alpName),
                                               actualSequence);
                seqOriginal.ID = "";
                ClassicAssert.IsNotNull(seqOriginal);
                // Use the formatter to write the original sequences to a temp file            
                ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Creating the Temp file '{0}'.",
                                                       Constants.FastaTempFileName));
                formatter.Format(seqOriginal, Constants.FastaTempFileName);
                IEnumerable<ISequence> seqsNew = null;

                // Read the new file, then compare the sequences            
                var parser = new FastAParser();
                {
                    parser.Alphabet = Alphabets.Protein;
                    seqsNew = parser.Parse(Constants.FastaTempFileName);
                    char[] seqString = seqsNew.ElementAt(0).Select(a => (char) a).ToArray();
                    var newSequence = new string(seqString);
                    ClassicAssert.IsNotNull(seqsNew);

                    ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: New Sequence is '{0}'.",
                                                           newSequence));

                    // Now compare the sequences.
                    int countNew = seqsNew.Count();
                    ClassicAssert.AreEqual(1, countNew);
                    ApplicationLog.WriteLine("The Number of sequences are matching.");
                    ClassicAssert.AreEqual(seqOriginal.ID, seqsNew.ElementAt(0).ID);
                    var orgSeq = new string(seqsNew.ElementAt(0).Select(a => (char) a).ToArray());

                    ClassicAssert.AreEqual(orgSeq, newSequence);

                    ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: The FASTA sequences '{0}' are matching with Format() method.",
                                                           newSequence));
                }

                // Passed all the tests, delete the tmp file. If we failed an Assert,
                // the tmp file will still be there in case we need it for debugging.
                File.Delete(Constants.FastaTempFileName);
                ApplicationLog.WriteLine("Deleted the temp file created.");
            }
        }

        /// <summary>
        ///     Validate the get for Name property
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateGetName()
        {
            var formatter = new FastAFormatter();
            string name = formatter.Name;
            ClassicAssert.IsNotNull(name);
            ClassicAssert.AreEqual(name, "FastA");
        }

        /// <summary>
        ///     Validate get for supported file types property
        ///     Should contain .fa,.mpfa,.fna,.faa,.fsa,.fas,.fasta
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateGetSupportedFileTypes()
        {
            var formatter = new FastAFormatter();
            string supportedFileType = formatter.SupportedFileTypes;
            ClassicAssert.IsNotNull(supportedFileType);
            ClassicAssert.IsTrue(supportedFileType.Contains(".fa"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".mpfa"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".fna"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".faa"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".fsa"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".fas"));
            ClassicAssert.IsTrue(supportedFileType.Contains(".fasta"));
        }

        /// <summary>
        ///     validate get for the description property
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateGetDescription()
        {
            var formatter = new FastAFormatter();
            string desc = formatter.Description;
            ClassicAssert.IsNotNull(desc);
        }

        /// <summary>
        ///     Validate the write method
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateWrite1()
        {
            var formatter = new FastAFormatter();
            using (formatter.Open(Constants.FastaTempFileName))
            {
                // Gets the actual sequence and the alphabet from the Xml
                string actualSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                        Constants.ExpectedSequenceNode);
                string alpName = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                 Constants.AlphabetNameNode);

                // Logs information to the log file
                ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Validating with Sequence '{0}' and Alphabet '{1}'.",
                                                       actualSequence, alpName));
                var seqOriginal = new Sequence(Utility.GetAlphabet(alpName),
                                               actualSequence) { ID = "" };
                ClassicAssert.IsNotNull(seqOriginal);

                // Use the formatter to write the original sequences to a temp file            
                ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Creating the Temp file '{0}'.",
                                                       Constants.FastaTempFileName));
                var seqList = new List<ISequence> { seqOriginal, seqOriginal, seqOriginal };
                formatter.Format(seqList);
                formatter.Close();

                IEnumerable<ISequence> seqsNew = null;
                // Read the new file, then compare the sequences            
                var parser = new FastAParser();
                {
                    parser.Alphabet = Alphabets.Protein;
                    seqsNew = parser.Parse(Constants.FastaTempFileName);
                    char[] seqString = seqsNew.ElementAt(0).Select(a => (char) a).ToArray();
                    var newSequence = new string(seqString);
                    ClassicAssert.IsNotNull(seqsNew);
                    ApplicationLog.WriteLine(string.Format(null,
                                                           "FastA Formatter BVT: New Sequence is '{0}'.",
                                                           newSequence));

                    // Now compare the sequences.
                    int countNew = seqsNew.Count();
                    ClassicAssert.AreEqual(3, countNew);
                    ApplicationLog.WriteLine("The Number of sequences are matching.");
                    ClassicAssert.AreEqual(seqOriginal.ID, seqsNew.ElementAt(0).ID);
                    ClassicAssert.AreEqual(new string(seqsNew.ElementAt(0).Select(a => (char) a).ToArray()), newSequence);

                    ApplicationLog.WriteLine(string.Format(null,
                                                           "FastA Formatter BVT: The FASTA sequences '{0}' are matching with Format() method.",
                                                           newSequence));

                    // Passed all the tests, delete the tmp file. If we failed an Assert,
                    // the tmp file will still be there in case we need it for debugging.
                    File.Delete(Constants.FastaTempFileName);
                    ApplicationLog.WriteLine("Deleted the temp file created.");
                }
            }
        }

        /// <summary>
        ///     Format a valid Single Sequence (Small size sequence less than 35 kb) to a
        ///     FastA file Write() method with Sequence and Writer as parameter
        ///     and validate the same.
        ///     Input : FastA Sequence
        ///     Validation : Read the FastA file to which the sequence was formatted and
        ///     validate Sequence, Sequence Count
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void FastAFormatterValidateWriteWithStream()
        {
            string actualSequence = string.Empty;

            var formatter = new FastAFormatter();
            {
                using (formatter.Open(Constants.FastaTempFileName))
                {
                    // Gets the actual sequence and the alphabet from the Xml
                    actualSequence = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                     Constants.ExpectedSequenceNode);
                    string alpName = utilityObj.xmlUtil.GetTextValue(Constants.SimpleFastaNodeName,
                                                                     Constants.AlphabetNameNode);

                    // Logs information to the log file
                    ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Validating with Sequence '{0}' and Alphabet '{1}'.",
                                                           actualSequence, alpName));
                    var seqOriginal = new Sequence(Utility.GetAlphabet(alpName), actualSequence);

                    seqOriginal.ID = "";
                    ClassicAssert.IsNotNull(seqOriginal);
                    // Use the formatter to write the original sequences to a stream.
                    ApplicationLog.WriteLine(string.Format("FastA Formatter BVT: Creating the Temp file '{0}'.",
                                                           Constants.FastaTempFileName));
                    formatter.Format(seqOriginal);
                    formatter.Close();
                }
                IEnumerable<ISequence> seq = null;

                using (var reader = File.OpenRead(Constants.FastaTempFileName))
                {
                    // Read the new file, then compare the sequences            
                    var parser = new FastAParser();
                    {
                        parser.Alphabet = Alphabets.Protein;
                        seq = parser.Parse(reader);

                        //Create a list of sequences.
                        List<ISequence> seqsList = seq.ToList();
                        ClassicAssert.IsNotNull(seqsList);

                        var seqString = new string(seqsList[0].Select(a => (char) a).ToArray());
                        ClassicAssert.AreEqual(actualSequence, seqString);
                    }
                }

                // Passed all the tests, delete the tmp file. If we failed an Assert,
                // the tmp file will still be there in case we need it for debugging.
                File.Delete(Constants.FastaTempFileName);
                ApplicationLog.WriteLine("Deleted the temp file created.");
            }
        }

        #endregion FastA Formatter Bvt Test cases
    }
}
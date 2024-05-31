using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Bio.Algorithms.Alignment;
using Bio.IO;
using Bio.IO.SAM;
using Bio.Util.ArgumentParser;

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests.IO.SAM
{
    /// <summary>
    /// Test SAM format parser and formatter.
    /// </summary>
    [TestFixture]
    public class SAMTests
    {
        /// <summary>
        /// Test the SAM Parser.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestParser()
        {
            string filePath = @"TestUtils\SAM\SeqAlignment1.sam".TestDir();
            ISequenceAlignmentParser parser = new SAMParser();
            IList<ISequenceAlignment> alignments = parser.Parse(filePath).ToList();
            ClassicAssert.IsTrue(alignments != null);
            ClassicAssert.AreEqual(alignments.Count, 1);
            ClassicAssert.AreEqual(alignments[0].AlignedSequences.Count, 2);
        }

        /// <summary>
        /// Test the SAM Formatter.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestFormatter()
        {
            string filePath = @"TestUtils\SAM\SeqAlignment1.sam".TestDir();
            string outputfilePath = "samtest.sam";
            ISequenceAlignmentParser parser = new SAMParser();
            IList<ISequenceAlignment> alignments = parser.Parse(filePath).ToList();

            ClassicAssert.IsTrue(alignments != null);
            ClassicAssert.AreEqual(alignments.Count, 1);
            ClassicAssert.AreEqual(alignments[0].AlignedSequences.Count, 2);

            try
            {
                SAMFormatter formatter = new SAMFormatter();
                formatter.Format(alignments[0], outputfilePath);

                alignments = parser.Parse(outputfilePath).ToList();

                ClassicAssert.IsTrue(alignments != null);
                ClassicAssert.AreEqual(alignments.Count, 1);
                ClassicAssert.AreEqual(alignments[0].AlignedSequences.Count, 2);
            }
            finally
            {
                File.Delete(outputfilePath);
            }
        }

        /// <summary>
        /// Tests the name,description and file extension property of 
        /// SAM formatter and parser.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void SAMProperties()
        {
            ISequenceAlignmentParser parser = new SAMParser();

            ClassicAssert.AreEqual(parser.Name, Properties.Resource.SAM_NAME);
            ClassicAssert.AreEqual(parser.Description, Properties.Resource.SAMPARSER_DESCRIPTION);
            ClassicAssert.AreEqual(parser.SupportedFileTypes, Properties.Resource.SAM_FILEEXTENSION);

            ISequenceAlignmentFormatter formatter = new SAMFormatter();

            ClassicAssert.AreEqual(formatter.Name, Properties.Resource.SAM_NAME);
            ClassicAssert.AreEqual(formatter.Description, Properties.Resource.SAMFORMATTER_DESCRIPTION);
            ClassicAssert.AreEqual(formatter.SupportedFileTypes, Properties.Resource.SAM_FILEEXTENSION);
        }
    }
}

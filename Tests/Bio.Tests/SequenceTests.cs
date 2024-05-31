using Bio;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    /// PatternConverter Test cases
    /// </summary>
    [TestFixture]
    public class SequenceTests
    {
        /// <summary>
        /// Find pattern test.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestMultipleFindOneOutputPattern()
        {
            byte[] b = new byte[6];
            b[0] = (byte)'C';
            b[1] = (byte)'A';
            b[2] = (byte)'A';
            b[3] = (byte)'G';
            b[4] = (byte)'C';
            b[5] = (byte)'T';

            string expectedSequence = "CAAGCT";
            ISequence sequence = new Sequence(Alphabets.DNA, b);

            string actual = "";
            foreach (byte bt in sequence)
            {
                actual += (char)bt;
            }
            ClassicAssert.AreEqual(expectedSequence, actual);

            ClassicAssert.AreEqual(sequence.Alphabet, Alphabets.DNA);
            ClassicAssert.AreEqual(sequence.Count, 6);
            // 
            // Test for indexer
            ClassicAssert.AreEqual(sequence[0], (byte)'C');
            ClassicAssert.AreEqual(sequence[1], (byte)'A');
            ClassicAssert.AreEqual(sequence[2], (byte)'A');
            ClassicAssert.AreEqual(sequence[3], (byte)'G');
            ClassicAssert.AreEqual(sequence[4], (byte)'C');
            ClassicAssert.AreEqual(sequence[5], (byte)'T');

        }

        /// <summary>
        /// Find pattern test.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSequenceCTor()
        {
            byte[] b = new byte[6];
            b[0] = (byte)'C';
            b[1] = (byte)'A';
            b[2] = (byte)'A';
            b[3] = (byte)'G';
            b[4] = (byte)'C';
            b[5] = (byte)'T';

            string expectedSequence = "CAAGCT";
           ISequence sequence = new Sequence(Alphabets.DNA, b);

            string actual = "";
            foreach (byte bt in sequence)
            {
                actual += (char)bt;
            }
            ClassicAssert.AreEqual(expectedSequence, actual);

            ClassicAssert.AreEqual(sequence.Alphabet,Alphabets.DNA);
            ClassicAssert.AreEqual(sequence.Count, 6);
            // 
            // Test for indexer
            ClassicAssert.AreEqual(sequence[0], (byte)'C');
            ClassicAssert.AreEqual(sequence[1], (byte)'A');
            ClassicAssert.AreEqual(sequence[2], (byte)'A');
            ClassicAssert.AreEqual(sequence[3], (byte)'G');
            ClassicAssert.AreEqual(sequence[4], (byte)'C');
            ClassicAssert.AreEqual(sequence[5], (byte)'T');

        }
   }
}

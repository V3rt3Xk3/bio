using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    /// Sequence statistics tests
    /// </summary>
    [TestFixture]
    public class SequenceStatisticsTests
    {
        /// <summary>
        /// Create a SequenceStatistics object with no Sequence.
        /// </summary>
        [Test]
        public void CreateStatsWithNullSequence()
        {
            ISequence seq = null;
            Assert.Throws<ArgumentNullException>( ()=> new SequenceStatistics(seq));
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateSimpleStatsWithSingleLetterSequence()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "A");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(1, stats.GetCount('A'));
            ClassicAssert.AreEqual(1, stats.GetCount(65));
            ClassicAssert.AreEqual(0, stats.GetCount('C'));
            ClassicAssert.AreEqual(0, stats.GetCount('G'));
            ClassicAssert.AreEqual(0, stats.GetCount('T'));

            ClassicAssert.AreEqual(1.0, stats.GetFraction('A'));
            ClassicAssert.AreEqual(1.0, stats.GetFraction(65));
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateSimpleStatsAndVerifyAlphabetIsReturned()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "A");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(Alphabets.DNA, stats.Alphabet);
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateSimpleStatsAndVerifyCount()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "ACGT--ACGT--ACGT--");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(18, stats.TotalCount);
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateSimpleStatsWithSingleLowercaseLetterSequence()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "a");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(1, stats.GetCount('A'));
            ClassicAssert.AreEqual(1, stats.GetCount(65));
            ClassicAssert.AreEqual(1, stats.GetCount('a'));
            ClassicAssert.AreEqual(0, stats.GetCount('C'));
            ClassicAssert.AreEqual(0, stats.GetCount('G'));
            ClassicAssert.AreEqual(0, stats.GetCount('T'));

            ClassicAssert.AreEqual(1.0, stats.GetFraction('A'));
            ClassicAssert.AreEqual(1.0, stats.GetFraction(65));
            ClassicAssert.AreEqual(1.0, stats.GetFraction('a'));
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateStatsWithMixedcaseLetterSequence()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "aAaAaAaA");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(8, stats.GetCount('A'));
            ClassicAssert.AreEqual(8, stats.GetCount(65));
            ClassicAssert.AreEqual(8, stats.GetCount('a'));

            ClassicAssert.AreEqual(1.0, stats.GetFraction('A'));
            ClassicAssert.AreEqual(1.0, stats.GetFraction(65));
            ClassicAssert.AreEqual(1.0, stats.GetFraction('a'));
        }

        /// <summary>
        /// Create a SequenceStatistics object with all four primary values
        /// </summary>
        [Test]
        public void CreateStatsWithSeveralMixedcaseLetterSequence()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "a-c-g-t-A-C-G-T-");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            ClassicAssert.AreEqual(2, stats.GetCount('A'));
            ClassicAssert.AreEqual(2, stats.GetCount('a'));
            ClassicAssert.AreEqual(2, stats.GetCount('C'));
            ClassicAssert.AreEqual(2, stats.GetCount('c'));
            ClassicAssert.AreEqual(2, stats.GetCount('G'));
            ClassicAssert.AreEqual(2, stats.GetCount('g'));
            ClassicAssert.AreEqual(2, stats.GetCount('T'));
            ClassicAssert.AreEqual(2, stats.GetCount('t'));
            ClassicAssert.AreEqual(8, stats.GetCount('-'));

            ClassicAssert.AreEqual(2.0 / 16.0, stats.GetFraction('A'));
            ClassicAssert.AreEqual(2.0 / 16.0, stats.GetFraction('C'));
            ClassicAssert.AreEqual(2.0 / 16.0, stats.GetFraction('G'));
            ClassicAssert.AreEqual(2.0 / 16.0, stats.GetFraction('T'));
            ClassicAssert.AreEqual(.5, stats.GetFraction('-'));
            ClassicAssert.AreEqual(.5, stats.GetFraction(45));
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateStatsAndConsumeEnumerable()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "ACGT--ACGT--ACGT--");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            int loopCounts = 0;
            foreach (var value in stats.SymbolCounts)
            {
                ClassicAssert.AreEqual(value.Item2, stats.GetCount(value.Item1));
                loopCounts++;
            }

            ClassicAssert.AreEqual(5,loopCounts);
        }

        /// <summary>
        /// Create a SequenceStatistics object with a single-letter sequence
        /// </summary>
        [Test]
        public void CreateStatsAndCheckToString()
        {
            ISequence sequence = new Sequence(Alphabets.DNA, "ACGT--ACGT--ACGT--");
            SequenceStatistics stats = new SequenceStatistics(sequence);

            string expectedValue = "- - 6\r\nA - 3\r\nC - 3\r\nG - 3\r\nT - 3\r\n".Replace("\r\n", Environment.NewLine);
            string actualValue = stats.ToString();

            ClassicAssert.AreEqual(expectedValue, actualValue);
        }
    }
}

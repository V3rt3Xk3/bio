namespace Bio.Tests
{
    using System;
    using System.Collections.Generic;
    using Bio;
    using NUnit.Framework;
using NUnit.Framework.Legacy;

    /// <summary>
    /// Class to test SparseSequence.
    /// </summary>
    [TestFixture]
    public class SparseSequenceTests
    {
        /// <summary>
        /// Test sparse sequence class Constructors.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceConstructor()
        {
            // Send invalid parameters to the constructors.
            ValidateSparseSequenceCtorInvalidParameters();

            // Test constructors with valid parameters.
            ValidateSparseSequenceCtor();
        }

        /// <summary>
        /// Test sparse sequence class Enumerator.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceEnumerator()
        {
            int i = 0;
            ISequence seq = new Sequence(Alphabets.DNA, "ATGC");
            var sparseSeq = new SparseSequence(Alphabets.DNA, 0, seq);
            foreach (byte item in sparseSeq)
            {
                ClassicAssert.AreEqual(sparseSeq[i++], item);
            }
        }

        /// <summary>
        /// Test sparse sequence class indexers.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceIndexers()
        {
            SparseSequence sparseSeq = null;
            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 0, Alphabets.DNA.A);
                byte sequence = sparseSeq[-1];
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            // Zero index.
            sparseSeq = new SparseSequence(Alphabets.DNA, 0, Alphabets.DNA.A);
            ClassicAssert.AreEqual(Alphabets.DNA.A, sparseSeq[0]);

            // Non Zero index.
            sparseSeq = new SparseSequence(Alphabets.DNA, 2, Alphabets.DNA.A);
            ClassicAssert.AreEqual(Alphabets.DNA.A, sparseSeq[2]);
            ClassicAssert.AreEqual(0, sparseSeq[0]);

            sparseSeq = new SparseSequence(Alphabets.DNA, 2);
            ClassicAssert.AreEqual(0, sparseSeq[0]);

            // Zero index.
            ISequence seq = new Sequence(Alphabets.DNA, "ATGC");
            sparseSeq = new SparseSequence(Alphabets.DNA, 0, seq);
            ClassicAssert.AreEqual(Alphabets.DNA.A, sparseSeq[0]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, sparseSeq[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, sparseSeq[2]);
            ClassicAssert.AreEqual(Alphabets.DNA.C, sparseSeq[3]);

            // Non Zero index.
            sparseSeq = new SparseSequence(Alphabets.DNA, 2, seq);
            ClassicAssert.AreEqual(0, sparseSeq[0]);
            ClassicAssert.AreEqual(0, sparseSeq[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.A, sparseSeq[2]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, sparseSeq[3]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, sparseSeq[4]);
            ClassicAssert.AreEqual(Alphabets.DNA.C, sparseSeq[5]);

            sparseSeq = new SparseSequence(Alphabets.DNA, 0, seq);
            sparseSeq[0] = Alphabets.DNA.C;
            ClassicAssert.AreEqual(Alphabets.DNA.C, sparseSeq[0]);
            ClassicAssert.AreEqual(4, sparseSeq.Count);

            sparseSeq = new SparseSequence(Alphabets.DNA, 10);
            sparseSeq[6] = Alphabets.DNA.C;
            ClassicAssert.AreEqual(Alphabets.DNA.C, sparseSeq[6]);

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 10);
                sparseSeq[6] = Alphabets.RNA.U;
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 1);
                sparseSeq[6] = Alphabets.DNA.C;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        /// <summary>
        /// Test sparse sequence class GetKnownSequenceItems method.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceGetKnownSequenceItems()
        {
            ISequence seq = new Sequence(Alphabets.DNA, "ATGC");
            var sparseSeq = new SparseSequence(Alphabets.DNA, 0, seq);

            var knownItems = sparseSeq.GetKnownSequenceItems();
            ClassicAssert.AreEqual(knownItems.Count, 4);
            ClassicAssert.AreEqual(0, knownItems[0].Index);
            ClassicAssert.AreEqual(Alphabets.DNA.A, knownItems[0].Item);
            ClassicAssert.AreEqual(1, knownItems[1].Index);
            ClassicAssert.AreEqual(Alphabets.DNA.T, knownItems[1].Item);
            ClassicAssert.AreEqual(2, knownItems[2].Index);
            ClassicAssert.AreEqual(Alphabets.DNA.G, knownItems[2].Item);
            ClassicAssert.AreEqual(3, knownItems[3].Index);
            ClassicAssert.AreEqual(Alphabets.DNA.C, knownItems[3].Item);
        }

        /// <summary>
        /// Test sparse sequence class GetKnownSequenceItems method.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceComplementMethods()
        {
            ISequence seq = new Sequence(Alphabets.DNA, "ATGC");
            var sparseSeq = new SparseSequence(Alphabets.DNA, 1, seq);

            ISequence compSeq = sparseSeq.GetComplementedSequence();

            ClassicAssert.AreEqual(5, compSeq.Count);
            ClassicAssert.AreEqual(0, compSeq[0]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, compSeq[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.A, compSeq[2]);
            ClassicAssert.AreEqual(Alphabets.DNA.C, compSeq[3]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, compSeq[4]);

            compSeq = sparseSeq.GetReversedSequence();
            ClassicAssert.AreEqual(5, compSeq.Count);
            ClassicAssert.AreEqual(0, compSeq[4]);
            ClassicAssert.AreEqual(Alphabets.DNA.A, compSeq[3]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, compSeq[2]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, compSeq[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.C, compSeq[0]);

            compSeq = sparseSeq.GetReverseComplementedSequence();
            ClassicAssert.AreEqual(5, compSeq.Count);
            ClassicAssert.AreEqual(0, compSeq[4]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, compSeq[3]);
            ClassicAssert.AreEqual(Alphabets.DNA.A, compSeq[2]);
            ClassicAssert.AreEqual(Alphabets.DNA.C, compSeq[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, compSeq[0]);
        }

         /// <summary>
        /// Test sparse sequence class Constructors.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceIndexOfNonGap()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.G);
            byteList.Add(Alphabets.DNA.A);
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.T);
            byteList.Add(Alphabets.DNA.C);
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.Gap);

            SparseSequence sparseSeq = new SparseSequence(Alphabets.DNA, 0, byteList);

            long result = sparseSeq.IndexOfNonGap();
            ClassicAssert.AreEqual(1, result);

            result = sparseSeq.IndexOfNonGap(1);
            ClassicAssert.AreEqual(1, result);

            result = sparseSeq.IndexOfNonGap(6);
            ClassicAssert.AreEqual(-1, result);

            result = sparseSeq.LastIndexOfNonGap();
            ClassicAssert.AreEqual(5, result);

            result = sparseSeq.LastIndexOfNonGap(6);
            ClassicAssert.AreEqual(5, result);

            result = sparseSeq.LastIndexOfNonGap(1);
            ClassicAssert.AreEqual(1, result);

            result = sparseSeq.LastIndexOfNonGap(0);
            ClassicAssert.AreEqual(-1, result);

            // Alphabet with no gaps.
            SparseSequence tempSeq = new SparseSequence(NoGapAlphabet.Instance, 0, byteList);
            result = tempSeq.IndexOfNonGap(3);
            ClassicAssert.AreEqual(3, result);

            result = tempSeq.IndexOfNonGap(0);
            ClassicAssert.AreEqual(0, result);

            result = tempSeq.LastIndexOfNonGap(4);
            ClassicAssert.AreEqual(4, result);

            // Zero length sequences
            SparseSequence sparseSeqZeroLen = new SparseSequence(Alphabets.DNA);

            long zeroResult = sparseSeqZeroLen.IndexOfNonGap();
            ClassicAssert.AreEqual(-1, zeroResult);

            zeroResult = sparseSeqZeroLen.LastIndexOfNonGap();
            ClassicAssert.AreEqual(-1, zeroResult);

            // Invalid argument inputs.
            try
            {
                result = sparseSeq.IndexOfNonGap(-1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            try
            {
                result = sparseSeq.IndexOfNonGap(100);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            try
            {
                result = sparseSeq.LastIndexOfNonGap(-1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }

            try
            {
                result = sparseSeq.LastIndexOfNonGap(100);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        /// <summary>
        /// Test sparse sequence class Constructors.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestSparseSequenceGetSubsequence()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.G);
            byteList.Add(Alphabets.DNA.A);
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.T);
            byteList.Add(Alphabets.DNA.C);
            byteList.Add(Alphabets.DNA.Gap);
            byteList.Add(Alphabets.DNA.Gap);

            SparseSequence sparseSeq = new SparseSequence(Alphabets.DNA, 0, byteList);

            ISequence result = sparseSeq.GetSubSequence(0, 3);
            ClassicAssert.AreEqual(3, result.Count);
            ClassicAssert.AreEqual(Alphabets.DNA.Gap, result[0]);
            ClassicAssert.AreEqual(Alphabets.DNA.G, result[1]);
            ClassicAssert.AreEqual(Alphabets.DNA.A, result[2]);

            result = sparseSeq.GetSubSequence(0, 0);
            ClassicAssert.AreEqual(0, result.Count);

            result = sparseSeq.GetSubSequence(3, 2);
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual(Alphabets.DNA.Gap, result[0]);
            ClassicAssert.AreEqual(Alphabets.DNA.T, result[1]);

            // Invalid Argument tests.
            try
            {
                sparseSeq.GetSubSequence(10, 10);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                sparseSeq.GetSubSequence(0, 9);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            try
            {
                sparseSeq.GetSubSequence(1, 8);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
        #region Helper Methods

        /// <summary>
        /// Invalidate Sparse sequence constructor
        /// </summary>
        private static void ValidateSparseSequenceCtorInvalidParameters()
        {
            SparseSequence sparseSeq = null;
            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 0, Alphabets.RNA.U);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.RNA, 0, Alphabets.DNA.T);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                ISequence seq = new Sequence(Alphabets.RNA, "AUGC");
                sparseSeq = new SparseSequence(Alphabets.DNA, 0, seq);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, -1, Alphabets.DNA.A);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, int.MaxValue, Alphabets.DNA.A);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 0, byte.MinValue);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(Alphabets.DNA, 0, null as ISequence);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(
                    Alphabets.DNA,
                    -1,
                    new List<byte>() { 
                        Alphabets.DNA.A, 
                        Alphabets.DNA.C });

                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(
                   Alphabets.DNA,
                   int.MaxValue,
                   new List<byte>() { 
                        Alphabets.DNA.A, 
                        Alphabets.DNA.C });
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(
                    null,
                    0);

                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }

            try
            {
                sparseSeq = new SparseSequence(
                    Alphabets.DNA,
                    -1);

                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException)
            {
                ClassicAssert.IsNull(sparseSeq);
            }
        }

        /// <summary>
        /// Validate the SparseSequence constructor.
        /// </summary>
        private static void ValidateSparseSequenceCtor()
        {
            SparseSequence sparseSeq = null;

            // Test for index 0.
            sparseSeq = new SparseSequence(Alphabets.DNA, 0, Alphabets.DNA.A);

            ClassicAssert.AreEqual(1, sparseSeq.Count);
            ClassicAssert.AreEqual(Alphabets.DNA, sparseSeq.Alphabet);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            // Test for non zero index.
            sparseSeq = new SparseSequence(Alphabets.DNA, 3, Alphabets.DNA.A);

            ClassicAssert.AreEqual(4, sparseSeq.Count);

            // Test for size.
            sparseSeq = new SparseSequence(Alphabets.DNA, 10);
            ClassicAssert.AreEqual(10, sparseSeq.Count);
            ClassicAssert.AreEqual(Alphabets.DNA, sparseSeq.Alphabet);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            // Sequence constructor tests.
            ISequence seq = new Sequence(Alphabets.RNA, "AUGC");
            sparseSeq = new SparseSequence(Alphabets.RNA, 0, seq);
            ClassicAssert.AreEqual(4, sparseSeq.Count);
            ClassicAssert.AreEqual(Alphabets.RNA, sparseSeq.Alphabet);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            sparseSeq = new SparseSequence(Alphabets.RNA, 2, seq);
            ClassicAssert.AreEqual(2 + seq.Count, sparseSeq.Count);
            ClassicAssert.AreEqual(Alphabets.RNA, sparseSeq.Alphabet);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);
        }
        #endregion Helper Methods
    }

    class NoGapAlphabet : DnaAlphabet
    {
        /// <summary>
        /// Initializes static members of the DnaAlphabet class.
        /// </summary>
        static NoGapAlphabet()
        {
            Instance = new NoGapAlphabet();
        }

        /// <summary>
        /// Initializes a new instance of the NoGapAlphabet class.
        /// </summary>
        protected NoGapAlphabet()
            : base()
        {
            this.HasGaps = false;
        }

        /// <summary>
        /// Static instance of this class.
        /// </summary>
        public static new readonly NoGapAlphabet Instance;

        public override bool TryGetGapSymbols(out HashSet<byte> gapSymbols)
        {
            gapSymbols = null;
            return false;
        }
    }
}

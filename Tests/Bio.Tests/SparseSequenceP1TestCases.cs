﻿using System;
using System.Collections.Generic;
using System.Text;

using Bio.Util.Logging;

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    ///     Test Automation code for Bio Sparse Sequence P1 level validations
    /// </summary>
    [TestFixture]
    public class SparseSequenceP1TestCases
    {
        #region Test Cases

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSparseSequenceConstAlp()
        {
            var sparseSeq = new SparseSequence(Alphabets.RNA);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.AreEqual(0, sparseSeq.Count);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSparseSequenceConstAlpIndex()
        {
            var sparseSeq = new SparseSequence(Alphabets.RNA, 0);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.AreEqual(0, sparseSeq.Count);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index, byte.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSparseSequenceConstAlpIndexByte()
        {
            byte[] byteArrayObj = Encoding.ASCII.GetBytes("AGCU");
            var sparseSeq = new SparseSequence(Alphabets.DNA, 1, byteArrayObj[0]);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);
            SequenceStatistics seqStatObj = sparseSeq.Statistics;
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('A'));

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index, byte) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index, byte.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSparseSequenceConstAlpIndexByteList()
        {
            byte[] byteArrayObj = Encoding.ASCII.GetBytes("AGCU");

            IEnumerable<byte> seqItems =
                new List<Byte> {byteArrayObj[0], byteArrayObj[1], byteArrayObj[2], byteArrayObj[3]};

            var sparseSeq = new SparseSequence(Alphabets.RNA, 4, seqItems);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);
            ClassicAssert.AreEqual(8, sparseSeq.Count);
            SequenceStatistics seqStatObj = sparseSeq.Statistics;
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('A'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('G'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('C'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('U'));

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index, seq items) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSparseSequenceConstAlp()
        {
            var sparseSeq = new SparseSequence(Alphabets.Protein);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.AreEqual(0, sparseSeq.Count);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSparseSequenceConstAlpIndex()
        {
            var sparseSeq = new SparseSequence(Alphabets.Protein, 0);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.AreEqual(0, sparseSeq.Count);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index, byte.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSparseSequenceConstAlpIndexByte()
        {
            byte[] byteArrayObj = Encoding.ASCII.GetBytes("KIEG");
            var sparseSeq = new SparseSequence(Alphabets.Protein, 1, byteArrayObj[0]);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);
            SequenceStatistics seqStatObj = sparseSeq.Statistics;
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('K'));

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index, byte) constructor is completed");
        }

        /// <summary>
        ///     Creates sparse sequence object and validates the constructor with Index, byte.
        ///     Validates if all items are present in sparse sequence instance.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSparseSequenceConstAlpIndexByteList()
        {
            byte[] byteArrayObj = Encoding.ASCII.GetBytes("KIEG");

            IEnumerable<byte> seqItems =
                new List<Byte> {byteArrayObj[0], byteArrayObj[1], byteArrayObj[2], byteArrayObj[3]};

            var sparseSeq = new SparseSequence(Alphabets.Protein, 4, seqItems);
            ClassicAssert.IsNotNull(sparseSeq);
            ClassicAssert.IsNotNull(sparseSeq.Statistics);
            ClassicAssert.AreEqual(8, sparseSeq.Count);
            SequenceStatistics seqStatObj = sparseSeq.Statistics;
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('K'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('I'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('E'));
            ClassicAssert.AreEqual(1, seqStatObj.GetCount('G'));

            ApplicationLog.WriteLine("SparseSequence P1: Validation of SparseSequence(alp, index, seq items) constructor is completed");
        }

        #endregion
    }
}
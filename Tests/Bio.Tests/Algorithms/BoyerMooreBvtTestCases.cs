﻿using System;
using System.Collections.Generic;
using Bio.Algorithms.StringSearch;
using Bio.TestAutomation.Util;
using Bio.Util.Logging;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.TestAutomation.Algorithms
{
    /// <summary>
    ///     Boyer Moore BVT Test case implementation.
    /// </summary>
    [TestFixture]
    public class BoyerMooreBvtTestCases
    {
        #region Global Variables

        private readonly Utility utilityObj = new Utility(@"TestUtils\BoyerMooreTestConfig.xml");

        #endregion Global Variables

        #region Constructor

        /// <summary>
        ///     Static constructor to open log and make other settings needed for test
        /// </summary>
        static BoyerMooreBvtTestCases()
        {
            Trace.Set(Trace.SeqWarnings);
        }

        #endregion Constructor

        #region BoyerMoore Align Test Cases

        /// <summary>
        ///     Validate FindMatch(sequence, searchpattern) method with 1000 BP Dna sequence
        ///     and validate the matches
        ///     Input : Dna sequence with 1000 BP.
        ///     Validation : Validate the matches.
        /// </summary>
        [Test]
        public void BoyerMooreAlignDnaSequenceWith1000BP()
        {
            var boyerMoore = new BoyerMoore();
            string boyerMooreSequence =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.SequenceNode);
            string referenceSequence =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.SearchSequenceNode);
            string expectedMatch =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.ExpectedMatch);
            ISequence boyerMooreSeq = new Sequence(Alphabets.DNA, boyerMooreSequence);

            IList<int> indexList = boyerMoore.FindMatch(boyerMooreSeq,
                                                        referenceSequence);

            ClassicAssert.AreEqual(expectedMatch, indexList[0].ToString((IFormatProvider) null));
        }

        /// <summary>
        ///     Validate FindMatch(sequence, searchpatterns) method with 1000 BP Dna sequence
        ///     and validate the matches
        ///     Input : Dna sequence with 1000 BP.
        ///     Validation : Validate the matches.
        /// </summary>
        [Test]
        public void BoyerMooreAlignDnaSequenceListWith1000BP()
        {
            var boyerMoore = new BoyerMoore();
            string boyerMooreSequence =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.SequenceNode);
            string referenceSequence =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.SearchSequenceNode);
            string expectedMatch =
                utilityObj.xmlUtil.GetTextValue(Constants.BoyerMooreSequence, Constants.ExpectedMatch);
            ISequence boyerMooreSeq = new Sequence(Alphabets.DNA, boyerMooreSequence);

            IList<string> referenceSeqs = new List<string> {referenceSequence};

            IDictionary<string, IList<int>> indexList = boyerMoore.FindMatch(boyerMooreSeq, referenceSeqs);

            ClassicAssert.AreEqual(expectedMatch, indexList[referenceSequence][0].ToString((IFormatProvider) null));
        }

        #endregion BoyerMoore Align Test Cases
    }
}
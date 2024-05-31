using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Bio;

namespace Bio.Tests
{
    /// <summary>
    /// Tests the AmbiguousRnaAlphabet class.
    /// </summary>
    [TestFixture]
    public class AmbiguousAmbiguousRnaAlphabetTests
    {
        /// <summary>
        /// Tests the AmbiguousRNAAlphabet class.
        /// </summary>
        [Test]
        public void TestAmbiguousRnaAlphabetCompareSymbols()
        {
            AmbiguousRnaAlphabet ambiguousRnaAlphabet = AmbiguousRnaAlphabet.Instance;
            ClassicAssert.AreEqual(false, ambiguousRnaAlphabet.CompareSymbols((byte)'A', (byte)'M'));
            ClassicAssert.AreEqual(true, ambiguousRnaAlphabet.CompareSymbols((byte)'A', (byte)'A'));
        }
    }
}

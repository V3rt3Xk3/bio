using System.Collections.Generic;
using System.Linq;
using Bio;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    /// Tests DnaAlphabet class.
    /// </summary>
    [TestFixture]
    public class DnaAlphabetTests
    {
        #region DnaAlphabet Test Cases

        /// <summary>
        /// Test TryGetComplementSymbol method
        /// </summary>
        [Test]
        public void TestDnaAlphabetTryGetComplementSymbol()
        {
            byte basicSymbols;
            DnaAlphabet dnaAlphabet = DnaAlphabet.Instance;
            
            ClassicAssert.AreEqual(true, dnaAlphabet.TryGetComplementSymbol((byte)'A', out basicSymbols));            
            ClassicAssert.AreEqual('T', (char)basicSymbols);

            ClassicAssert.AreEqual(true, dnaAlphabet.TryGetComplementSymbol((byte)'T', out basicSymbols));
            ClassicAssert.AreEqual('A', (char)basicSymbols);

            ClassicAssert.AreEqual(true, dnaAlphabet.TryGetComplementSymbol((byte)'G', out basicSymbols));
            ClassicAssert.AreEqual('C', (char)basicSymbols);

            ClassicAssert.AreEqual(true, dnaAlphabet.TryGetComplementSymbol((byte)'C', out basicSymbols));
            ClassicAssert.AreEqual('G', (char)basicSymbols);
            ClassicAssert.AreEqual('G', (char)dnaAlphabet.GetSymbolValueMap()[(byte)'g']);
            ClassicAssert.IsTrue(dnaAlphabet.CompareSymbols((byte)'T', (byte)'t'));
            ClassicAssert.IsTrue(dnaAlphabet.CompareSymbols((byte)'t', (byte)'T'));
            ClassicAssert.AreEqual(dnaAlphabet.GetAmbiguousSymbols().Count, 0);
        }

        /// <summary>
        /// Test TryGetBasicSymbols method
        /// </summary>
        [Test]
        public void TestDnaAlphabetTryGetBasicSymbols()
        {
            HashSet<byte> basicSymbols;
            AmbiguousDnaAlphabet dnaAlphabet = AmbiguousDnaAlphabet.Instance;
            
            ClassicAssert.AreEqual(true, dnaAlphabet.TryGetBasicSymbols((byte)'M', out basicSymbols));
            ClassicAssert.IsTrue(basicSymbols.All(sy => (sy == (byte)'A' || sy == (byte) 'C')));            
        }

        #endregion DnaAlphabet Test Cases
    }
}

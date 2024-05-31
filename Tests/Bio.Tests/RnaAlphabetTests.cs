using Bio;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    /// Tests for the RNA alphabet class.
    /// </summary>
    [TestFixture]
    public class RnaAlphabetTests
    {
        /// <summary>
        /// Test TryGetComplementSymbol of RnaAlphabet
        /// </summary>
        [Test]
        public void TestRnaAlphabetTryGetComplementSymbol()
        {
            byte basicSymbols;
            RnaAlphabet rnaAlphabet = RnaAlphabet.Instance;

            ClassicAssert.AreEqual(true, rnaAlphabet.TryGetComplementSymbol((byte)'A', out basicSymbols));
            ClassicAssert.AreEqual('U', (char)basicSymbols);

            ClassicAssert.AreEqual(true, rnaAlphabet.TryGetComplementSymbol((byte)'U', out basicSymbols));
            ClassicAssert.AreEqual('A', (char)basicSymbols);

            ClassicAssert.AreEqual(true, rnaAlphabet.TryGetComplementSymbol((byte)'G', out basicSymbols));
            ClassicAssert.AreEqual('C', (char)basicSymbols);

            ClassicAssert.AreEqual(true, rnaAlphabet.TryGetComplementSymbol((byte)'C', out basicSymbols));
            ClassicAssert.AreEqual('G', (char)basicSymbols);
        }

        /// <summary>
        /// Test CompareSymbols method of RnaAlphabet
        /// </summary>
        [Test]
        public void TestRnaAlphabetCompareSymbols()
        {
            RnaAlphabet rnaAlphabet = RnaAlphabet.Instance;

            ClassicAssert.AreEqual(true, rnaAlphabet.CompareSymbols((byte)'A', (byte)'A'));

            ClassicAssert.AreEqual(true, rnaAlphabet.CompareSymbols((byte)'U', (byte)'U'));

            ClassicAssert.AreEqual(true, rnaAlphabet.CompareSymbols((byte)'G', (byte)'G'));

            ClassicAssert.AreEqual(true, rnaAlphabet.CompareSymbols((byte)'C', (byte)'C'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'A', (byte)'U'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'A', (byte)'G'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'A', (byte)'C'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'U', (byte)'A'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'U', (byte)'G'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'U', (byte)'C'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'G', (byte)'A'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'G', (byte)'U'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'G', (byte)'C'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'C', (byte)'A'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'C', (byte)'U'));

            ClassicAssert.AreEqual(false, rnaAlphabet.CompareSymbols((byte)'C', (byte)'G'));
        }
    }
}

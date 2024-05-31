using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests.Framework
{
    /// <summary>
    /// Tests the AmbiguousRnaAlphabet class.
    /// </summary>
    [TestFixture]
    public class AlphabetsFriendlyNameTest
    {
        /// <summary>
        /// Tests the AmbiguousRNAAlphabet class.
        /// </summary>
        [Test]
        public void TestFriendlyNames()
        {
            // DNA
            ClassicAssert.AreEqual(DnaAlphabet.Instance.GetFriendlyName(DnaAlphabet.Instance.A), "Adenine");
            ClassicAssert.AreEqual(DnaAlphabet.Instance.GetFriendlyName(DnaAlphabet.Instance.C), "Cytosine");
            ClassicAssert.AreEqual(DnaAlphabet.Instance.GetFriendlyName(DnaAlphabet.Instance.G), "Guanine");
            ClassicAssert.AreEqual(DnaAlphabet.Instance.GetFriendlyName(DnaAlphabet.Instance.T), "Thymine");
            ClassicAssert.AreEqual(DnaAlphabet.Instance.GetFriendlyName(DnaAlphabet.Instance.Gap), "Gap");

            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.AC), "Adenine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GA), "Guanine or Adenine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GC), "Guanine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.AT), "Adenine or Thymine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.TC), "Thymine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GT), "Guanine or Thymine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GCA), "Guanine or Cytosine or Adenine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.ACT), "Adenine or Cytosine or Thymine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GAT), "Guanine or Adenine or Thymine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.GTC), "Guanine or Thymine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousDnaAlphabet.Instance.GetFriendlyName(AmbiguousDnaAlphabet.Instance.Any), "Any");

            // RNA
            ClassicAssert.AreEqual(RnaAlphabet.Instance.GetFriendlyName(RnaAlphabet.Instance.A), "Adenine");
            ClassicAssert.AreEqual(RnaAlphabet.Instance.GetFriendlyName(RnaAlphabet.Instance.C), "Cytosine");
            ClassicAssert.AreEqual(RnaAlphabet.Instance.GetFriendlyName(RnaAlphabet.Instance.G), "Guanine");
            ClassicAssert.AreEqual(RnaAlphabet.Instance.GetFriendlyName(RnaAlphabet.Instance.U), "Uracil");
            ClassicAssert.AreEqual(RnaAlphabet.Instance.GetFriendlyName(RnaAlphabet.Instance.Gap), "Gap");

            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.Any), "Any");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.AC), "Adenine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GA), "Guanine or Adenine");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GC), "Guanine or Cytosine");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.AU), "Adenine or Uracil");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.UC), "Uracil or Cytosine");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GU), "Guanine or Uracil");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GCA), "Guanine or Cytosine or Adenine");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.ACU), "Adenine or Cytosine or Uracil");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GAU), "Guanine or Adenine or Uracil");
            ClassicAssert.AreEqual(AmbiguousRnaAlphabet.Instance.GetFriendlyName(AmbiguousRnaAlphabet.Instance.GUC), "Guanine or Uracil or Cytosine");

            // Protein
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.A), "Alanine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.C), "Cysteine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.D), "Aspartic");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.E), "Glutamic");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.F), "Phenylalanine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.G), "Glycine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.H), "Histidine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.I), "Isoleucine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.K), "Lysine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.L), "Leucine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.M), "Methionine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.N), "Asparagine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.O), "Pyrrolysine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.P), "Proline");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.Q), "Glutamine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.R), "Arginine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.S), "Serine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.T), "Threoine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.U), "Selenocysteine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.V), "Valine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.W), "Tryptophan");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.Y), "Tyrosine");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.Gap), "Gap");
            ClassicAssert.AreEqual(ProteinAlphabet.Instance.GetFriendlyName(ProteinAlphabet.Instance.Ter), "Termination");

            ClassicAssert.AreEqual(AmbiguousProteinAlphabet.Instance.GetFriendlyName(AmbiguousProteinAlphabet.Instance.X), "Undetermined or atypical");
            ClassicAssert.AreEqual(AmbiguousProteinAlphabet.Instance.GetFriendlyName(AmbiguousProteinAlphabet.Instance.Z), "Glutamic or Glutamine");
            ClassicAssert.AreEqual(AmbiguousProteinAlphabet.Instance.GetFriendlyName(AmbiguousProteinAlphabet.Instance.B), "Aspartic or Asparagine");
            ClassicAssert.AreEqual(AmbiguousProteinAlphabet.Instance.GetFriendlyName(AmbiguousProteinAlphabet.Instance.J), "Leucine or Isoleucine");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

using Bio;
using Bio.Variant;
using Bio.Algorithms.Alignment;
using Bio.Extensions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    [TestFixture]
    [Category("VariantCalls")]
    public static class VariantCallTests
    {        
        /// <summary>
        /// Converts the Sequence to a QualitativeSequence in the alignment.
        /// </summary>
        /// <param name="aln">Aln.</param>
        /// <param name="qualScores">Qual scores.</param>
        public static void ConvertAlignedSequenceToQualSeq(IPairwiseSequenceAlignment aln, int[] qualScores) {
            var q = aln.PairwiseAlignedSequences [0].SecondSequence as Sequence;
            var qvs = new int[q.Count];
            int queryPos = 0;
            for (int i = 0; i < qvs.Length; i++) {
                if (q [i] == '-') {
                    qvs [i] = 0;
                } else {
                    qvs [i] = qualScores[queryPos++];
                }            
            }
            var qseq = new QualitativeSequence (DnaAlphabet.Instance, FastQFormatType.Sanger, q.ToArray (), qvs, false);

            aln.PairwiseAlignedSequences [0].SecondSequence = qseq;

        }

        [Test]

        public static void Test1BPInsertionCall()
        {
            string seq1seq = "ATA-CCCTT".Replace("-", String.Empty);
            string seq2seq = "ATACCCCTT";
            int[] seq2qual = new int[] { 30, 30, 30, 4, 30, 30, 30, 30, 30 };
            var refseq = new Sequence(AmbiguousDnaAlphabet.Instance, seq1seq, false);
            var query = new Sequence (AmbiguousDnaAlphabet.Instance, seq2seq, false);
            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            // Need to add in the QV Values.
            ConvertAlignedSequenceToQualSeq(aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (4, variant.QV);
            ClassicAssert.AreEqual (2, variant.StartPosition);
            ClassicAssert.AreEqual (VariantType.INDEL, variant.Type);
            var vi = variant as IndelVariant;
            ClassicAssert.AreEqual ("C", vi.InsertedOrDeletedBases);
            ClassicAssert.AreEqual ('C', vi.HomopolymerBase);
            ClassicAssert.AreEqual (3, vi.HomopolymerLengthInReference);
            ClassicAssert.AreEqual (true, vi.InHomopolymer);
            ClassicAssert.AreEqual (vi.InsertionOrDeletion, IndelType.Insertion);
        }

        [Test]
        public static void Test1BPDeletionCall()
        {
            string seq1seq = "ATACCCCTT";
            string seq2seq = "ATA-CCCTT".Replace("-", String.Empty);
            int[] seq2qual = new int[] { 30, 30, 30, 2, 30, 30, 30, 30 };
            var refseq = new Sequence(AmbiguousDnaAlphabet.Instance, seq1seq, false);
            var query = new Sequence (AmbiguousDnaAlphabet.Instance, seq2seq, false);
            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            // Need to add in the QV Values.
            ConvertAlignedSequenceToQualSeq(aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (2, variant.QV);
            ClassicAssert.AreEqual (2, variant.StartPosition);
            ClassicAssert.AreEqual (VariantType.INDEL, variant.Type);
            var vi = variant as IndelVariant;
            ClassicAssert.AreEqual ("C", vi.InsertedOrDeletedBases);
            ClassicAssert.AreEqual ('C', vi.HomopolymerBase);
            ClassicAssert.AreEqual (4, vi.HomopolymerLengthInReference);
            ClassicAssert.AreEqual (true, vi.InHomopolymer);
            ClassicAssert.AreEqual (vi.InsertionOrDeletion, IndelType.Deletion);
        }

        [Test]
        public static void TestSNPCall()
        {
            string seq1seq = "ATCCCCCTT";
            string seq2seq = "ATCCCTCTT";
            int[] seq2qual = new int[] { 30, 30, 30, 30, 5, 3, 30, 30, 30 };
            var refseq = new Sequence(DnaAlphabet.Instance, seq1seq);
            var query = new Sequence (DnaAlphabet.Instance, seq2seq);

            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            ConvertAlignedSequenceToQualSeq (aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (3, variant.QV);
            ClassicAssert.AreEqual (5, variant.StartPosition);
            ClassicAssert.AreEqual (variant.Type, VariantType.SNP);
            var vi = variant as SNPVariant;
            ClassicAssert.AreEqual (1, vi.Length);
            ClassicAssert.AreEqual ('T', vi.AltBP);
            ClassicAssert.AreEqual ('C', vi.RefBP);
            ClassicAssert.AreEqual (VariantType.SNP, vi.Type);
            ClassicAssert.AreEqual (false, vi.AtEndOfAlignment);
        } 

        [Test]
        public static void TestSNPCallAtEnd()
        {
            string seq1seq = "ATCCCCCTC";
            string seq2seq = "ATCCCCCTT";
            int[] seq2qual = new int[] { 30, 30, 30, 30, 5, 3, 30, 30, 10 };
            var refseq = new Sequence(DnaAlphabet.Instance, seq1seq);
            var query = new Sequence (DnaAlphabet.Instance, seq2seq);

            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            ConvertAlignedSequenceToQualSeq (aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (10, variant.QV);
            ClassicAssert.AreEqual (8, variant.StartPosition);
            ClassicAssert.AreEqual (variant.Type, VariantType.SNP);
            var vi = variant as SNPVariant;
            ClassicAssert.AreEqual (1, vi.Length);
            ClassicAssert.AreEqual ('T', vi.AltBP);
            ClassicAssert.AreEqual ('C', vi.RefBP);
            ClassicAssert.AreEqual (VariantType.SNP, vi.Type);
            ClassicAssert.AreEqual (true, vi.AtEndOfAlignment);
        } 

        [Test]
        public static void TestSNPCallAtStart()
        {
            string seq1seq = "CTCCCCCTT";
            string seq2seq = "TTCCCCCTT";
            int[] seq2qual = new int[] { 10, 30, 30, 30, 5, 3, 30, 30, 10 };
            var refseq = new Sequence(DnaAlphabet.Instance, seq1seq);
            var query = new Sequence (DnaAlphabet.Instance, seq2seq);

            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            ConvertAlignedSequenceToQualSeq (aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (10, variant.QV);
            ClassicAssert.AreEqual (0, variant.StartPosition);
            ClassicAssert.AreEqual (variant.Type, VariantType.SNP);
            var vi = variant as SNPVariant;
            ClassicAssert.AreEqual (1, vi.Length);
            ClassicAssert.AreEqual ('T', vi.AltBP);
            ClassicAssert.AreEqual ('C', vi.RefBP);
            ClassicAssert.AreEqual (VariantType.SNP, vi.Type);
            ClassicAssert.AreEqual (true, vi.AtEndOfAlignment);
        } 

        [Test]
        public static void TestLeftAlignmentStep() {
            var refseq =   "ACAATAAAAGCGCGCGCGCGTTACGTATAT--ATGGATAT";
            var queryseq = "ACAATAA-AGC--GCGC--GTTACGTATATATATGGATAT";

            var r = new Sequence (DnaAlphabet.Instance, refseq);
            var q = new Sequence (DnaAlphabet.Instance, queryseq);
            var aln = new PairwiseSequenceAlignment (r, q);
            var pas = new PairwiseAlignedSequence ();
            pas.FirstSequence = r;
            pas.SecondSequence = q;
            aln.Add (pas);
            var tpl = VariantCaller.LeftAlignIndelsAndCallVariants (aln, true);

            // Check the left alignment
            aln = tpl.Item1 as PairwiseSequenceAlignment;
            var lar = aln.PairwiseAlignedSequences [0].FirstSequence.ConvertToString();
            var laq = aln.PairwiseAlignedSequences [0].SecondSequence.ConvertToString();
            var exprefseq =   "ACAATAAAAGCGCGCGCGCGTTACG--TATATATGGATAT";
            var expqueryseq = "ACAAT-AAA----GCGCGCGTTACGTATATATATGGATAT";
            ClassicAssert.AreEqual (exprefseq, lar);
            ClassicAssert.AreEqual (expqueryseq, laq);

            // And it's hard, so we might as well check the variants
            var variants = tpl.Item2;
            ClassicAssert.AreEqual (3, variants.Count);
            string[] bases = new string[] { "A", "GCGC", "TA" };
            char[] hpbases = new char[] { 'A', 'G', 'T' };
            bool[] inHp = new bool[] { true, false, false };
            int[] lengths = new int[] { 1, 4, 2 };
            int[] starts = new int[] { 4, 8, 24 };
            IndelType[] types = new IndelType[] { IndelType.Deletion, IndelType.Deletion, IndelType.Insertion };
            for (int i = 0; i < 3; i++) {
                ClassicAssert.AreEqual (VariantType.INDEL, variants [i].Type);
                var vi = variants [i] as IndelVariant;
                ClassicAssert.AreEqual (hpbases[i], vi.HomopolymerBase);
                ClassicAssert.AreEqual (starts [i], vi.StartPosition);
                ClassicAssert.AreEqual (lengths [i], vi.Length);
                ClassicAssert.AreEqual (bases [i], vi.InsertedOrDeletedBases);
                ClassicAssert.AreEqual (inHp [i], vi.InHomopolymer);
                ClassicAssert.AreEqual (types [i], vi.InsertionOrDeletion);

            }
        
        }

        [Test]
        public static void TestReverseComplement1BPIndelCall() {

            string seq1seq = "ATACCCCTTGCGC";
            string seq2seq = "ATA-CCCTTGCGC".Replace("-", String.Empty);
            int[] seq2qual = new int[] { 30, 30, 30, 2, 30, 30, 30, 30, 30, 30, 30, 30 };
            var refseq = new Sequence(DnaAlphabet.Instance, seq1seq);
            var query = new Sequence (DnaAlphabet.Instance, seq2seq);

            var s1rc = refseq.GetReverseComplementedSequence ();
            var s2rc = query.GetReverseComplementedSequence ();

            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (s1rc, s2rc).First();
            VariantCallTests.ConvertAlignedSequenceToQualSeq (aln, seq2qual.Reverse ().ToArray ());
            aln.PairwiseAlignedSequences [0].Sequences [1].MarkAsReverseComplement ();
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (2, variant.QV);
            ClassicAssert.AreEqual (5, variant.StartPosition);
            ClassicAssert.AreEqual (VariantType.INDEL, variant.Type);
            var vi = variant as IndelVariant;
            ClassicAssert.AreEqual (IndelType.Deletion, vi.InsertionOrDeletion);
            ClassicAssert.AreEqual ('G', vi.HomopolymerBase);
            ClassicAssert.AreEqual (1, vi.Length);
            ClassicAssert.AreEqual (4, vi.HomopolymerLengthInReference);
            ClassicAssert.AreEqual (true, vi.InHomopolymer);
            ClassicAssert.AreEqual ("G", vi.InsertedOrDeletedBases);
            ClassicAssert.AreEqual (false, vi.AtEndOfAlignment);
            ClassicAssert.AreEqual (6, vi.EndPosition);
        }


        [Test]
        public static void TestTrickyQVInversions() {
            // This will be hard because normally flip the QV value for a homopolymer, but in this case we won't. 
            // Note the whole notion of flipping is poorly defined.
            string seq1seq = "ATTGC";
            string seq2seq = "ATAGC";
            int[] seq2qual = new int[] { 30, 30, 2, 30, 30 };
            var refseq = new Sequence(DnaAlphabet.Instance, seq1seq);
            var query = new Sequence (DnaAlphabet.Instance, seq2seq);

            var s1rc = refseq.GetReverseComplementedSequence ();
            var s2rc = query.GetReverseComplementedSequence ();

            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (s1rc, s2rc).First();
            VariantCallTests.ConvertAlignedSequenceToQualSeq (aln, seq2qual.Reverse ().ToArray ());
            aln.PairwiseAlignedSequences [0].Sequences [1].MarkAsReverseComplement ();
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (1, variants.Count);
            var variant = variants.First ();
            ClassicAssert.AreEqual (VariantType.SNP, variant.Type);
            ClassicAssert.AreEqual (2, variant.QV);

            var vs = variant as SNPVariant; 
            ClassicAssert.AreEqual ('T', vs.AltBP);
            ClassicAssert.AreEqual ('A', vs.RefBP);
        }

        [Test]
        public static void TestInsertionAtEndofHP() {
            string seq1seq = "ATA-CCC".Replace("-", String.Empty);
            string seq2seq = "ATACCCC";
            int[] seq2qual = new int[] { 30, 30, 30, 4, 30, 30, 30 };
            var refseq = new Sequence(AmbiguousDnaAlphabet.Instance, seq1seq, false);
            var query = new Sequence (AmbiguousDnaAlphabet.Instance, seq2seq, false);
            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            // Need to add in the QV Values.
            ConvertAlignedSequenceToQualSeq(aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (4, variant.QV);
            ClassicAssert.AreEqual (2, variant.StartPosition);
            ClassicAssert.AreEqual (VariantType.INDEL, variant.Type);
            var vi = variant as IndelVariant;
            ClassicAssert.AreEqual ("C", vi.InsertedOrDeletedBases);
            ClassicAssert.AreEqual ('C', vi.HomopolymerBase);
            ClassicAssert.AreEqual (true, vi.AtEndOfAlignment);
            ClassicAssert.AreEqual (3, vi.HomopolymerLengthInReference);
            ClassicAssert.AreEqual (true, vi.InHomopolymer);
            ClassicAssert.AreEqual (vi.InsertionOrDeletion, IndelType.Insertion);
        }


        [Test]
        public static void TestDeletionAtEndofHP() {
            string seq1seq = "ATACCCC";
            string seq2seq = "ATA-CCC".Replace("-", String.Empty);
            int[] seq2qual = new int[] { 30, 30, 30, 4, 30, 30 };
            var refseq = new Sequence(AmbiguousDnaAlphabet.Instance, seq1seq, false);
            var query = new Sequence (AmbiguousDnaAlphabet.Instance, seq2seq, false);
            NeedlemanWunschAligner aligner = new NeedlemanWunschAligner ();
            var aln = aligner.Align (refseq, query).First();
            // Need to add in the QV Values.
            ConvertAlignedSequenceToQualSeq(aln, seq2qual);
            var variants = VariantCaller.CallVariants (aln);
            ClassicAssert.AreEqual (variants.Count, 1);
            var variant = variants.First ();
            ClassicAssert.AreEqual (4, variant.QV);
            ClassicAssert.AreEqual (2, variant.StartPosition);
            ClassicAssert.AreEqual (VariantType.INDEL, variant.Type);
            var vi = variant as IndelVariant;
            ClassicAssert.AreEqual ("C", vi.InsertedOrDeletedBases);
            ClassicAssert.AreEqual ('C', vi.HomopolymerBase);
            ClassicAssert.AreEqual (true, vi.AtEndOfAlignment);
            ClassicAssert.AreEqual (4, vi.HomopolymerLengthInReference);
            ClassicAssert.AreEqual (true, vi.InHomopolymer);
            ClassicAssert.AreEqual (vi.InsertionOrDeletion, IndelType.Deletion);
        }

        [Test]
        public static void TestExceptionThrownForUnclippedAlignment() {
            var refseq =   "ACAATATA";
            var queryseq = "ACAATAT-";

            var r = new Sequence (DnaAlphabet.Instance, refseq);
            var q = new Sequence (DnaAlphabet.Instance, queryseq);
            var aln = new PairwiseSequenceAlignment (r, q);
            var pas = new PairwiseAlignedSequence ();
            pas.FirstSequence = r;
            pas.SecondSequence = q;
            aln.Add (pas);
            Assert.Throws<FormatException> (() => VariantCaller.LeftAlignIndelsAndCallVariants (aln, true));

            refseq =   "AAACAATATA";
            queryseq = "AA-CAATATA";

            r = new Sequence (DnaAlphabet.Instance, refseq);
            q = new Sequence (DnaAlphabet.Instance, queryseq);
            aln = new PairwiseSequenceAlignment (r, q);
            pas = new PairwiseAlignedSequence ();
            pas.FirstSequence = r;
            pas.SecondSequence = q;
            aln.Add (pas);
            Assert.Throws<FormatException> (() => VariantCaller.LeftAlignIndelsAndCallVariants (aln, true));
        }
    }
}


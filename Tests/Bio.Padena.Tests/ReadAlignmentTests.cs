using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Assembly;
using Bio.Algorithms.Assembly.Padena.Utility;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Padena.Tests
{
    /// <summary>
    /// Test for alignment utility for PaDeNA. 
    /// </summary>
    [TestFixture]
    public class ReadAlignmentTests
    {
        /// <summary>
        /// Maps to read to contig.
        /// </summary>
        [Test]
        public void MapReadToContig()
        {
            IList<ISequence> contigs = new List<ISequence>();
            IList<ISequence> reads = new List<ISequence>();
            Sequence seq = new Sequence(Alphabets.DNA, "TCTGATAAGG".Select(a => (byte)a).ToArray());
            seq.ID = "1";
            contigs.Add(seq);
            Sequence read = new Sequence(Alphabets.DNA, "CTGATAAGG".Select(a => (byte)a).ToArray());
            read.ID = "2";
            reads.Add(read);
            const int kmerLength = 6;
            IList<Contig> alignment = ReadAlignment.ReadContigAlignment(contigs, reads, kmerLength);
            ClassicAssert.AreEqual(alignment.Count, contigs.Count);
            Contig contig = alignment.First();
            Contig.AssembledSequence sequence = contig.Sequences.First();
            ClassicAssert.AreEqual(sequence.Length, 9);
            ClassicAssert.AreEqual(sequence.Position, 1);
            ClassicAssert.AreEqual(sequence.ReadPosition, 0);
            ClassicAssert.AreEqual(sequence.Sequence, reads.First());
            ClassicAssert.AreEqual(sequence.IsComplemented, false);
            ClassicAssert.AreEqual(sequence.IsReversed, false);
        }

        /// <summary>
        /// Map reverse complementary read to contig.
        /// </summary>
        [Test]
        public void MapContigToReverseComplementOfRead()
        {
            IList<ISequence> contigs = new List<ISequence>();
            IList<ISequence> reads = new List<ISequence>();
            Sequence seq = new Sequence(Alphabets.DNA, "TCTGATAAGG".Select(a => (byte)a).ToArray());
            seq.ID = "1";
            contigs.Add(seq);
            Sequence read = new Sequence(Alphabets.DNA, "CCTTATCAG".Select(a => (byte)a).ToArray());
            read.ID = "2";
            reads.Add(read);
            const int kmerLength = 6;
            IList<Contig> alignment = ReadAlignment.ReadContigAlignment(contigs, reads, kmerLength);
            ClassicAssert.AreEqual(alignment.Count, contigs.Count);
            Contig contig = alignment.First();
            Contig.AssembledSequence sequence = contig.Sequences.First();
            ClassicAssert.AreEqual(sequence.Length, 9);
            ClassicAssert.AreEqual(sequence.Position, 1);
            ClassicAssert.AreEqual(sequence.ReadPosition, 0);
            ClassicAssert.AreEqual(sequence.Sequence, reads.First());
            ClassicAssert.AreEqual(sequence.IsComplemented, true);
            ClassicAssert.AreEqual(sequence.IsReversed, true);
        }

        /// <summary>
        /// Test for Contig Read mapping using single contig.
        /// </summary>
        [Test]
        public void MapReadsToSingleContig()
        {
            const int kmerLength = 6;

            IList<ISequence> readSeqs = new List<ISequence>();
            Sequence read = new Sequence(Alphabets.DNA, "GATGCCTC".Select(a => (byte)a).ToArray());
            read.ID = "0";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "CCTCCTAT".Select(a => (byte)a).ToArray());
            read.ID = "1";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TCCTATC".Select(a => (byte)a).ToArray());
            read.ID = "2";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "GCCTCCTAT".Select(a => (byte)a).ToArray());
            read.ID = "3";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TGCCTCCT".Select(a => (byte)a).ToArray());
            read.ID = "4";
            readSeqs.Add(read);

            IList<ISequence> contigs = new List<ISequence> { new Sequence(Alphabets.DNA, 
                "GATGCCTCCTATC".Select(a => (byte)a).ToArray()) };

            IList<Contig> maps = ReadAlignment.ReadContigAlignment(contigs, readSeqs, kmerLength);
            Contig contig = maps.First();
            ClassicAssert.AreEqual(contig.Consensus, contigs.First());
            IList<Contig.AssembledSequence> readMap = Sort(contig.Sequences);
            ClassicAssert.AreEqual(readMap[0].Length, 8);
            ClassicAssert.AreEqual(readMap[0].Position, 4);
            ClassicAssert.AreEqual(readMap[0].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[0].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[0].IsReversed, false);

            ClassicAssert.AreEqual(readMap[1].Length, 8);
            ClassicAssert.AreEqual(readMap[1].Position, 0);
            ClassicAssert.AreEqual(readMap[1].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[1].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[1].IsReversed, false);

            ClassicAssert.AreEqual(readMap[2].Length, 9);
            ClassicAssert.AreEqual(readMap[2].Position, 3);
            ClassicAssert.AreEqual(readMap[2].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[2].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[2].IsReversed, false);

            ClassicAssert.AreEqual(readMap[3].Length, 7);
            ClassicAssert.AreEqual(readMap[3].Position, 6);
            ClassicAssert.AreEqual(readMap[3].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[3].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[3].IsReversed, false);

            ClassicAssert.AreEqual(readMap[4].Length, 8);
            ClassicAssert.AreEqual(readMap[4].Position, 2);
            ClassicAssert.AreEqual(readMap[4].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[3].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[3].IsReversed, false);
        }

        /// <summary>
        /// Test for Contig Read mapping having two contigs.
        /// </summary>
        [Test]
        public void MapReadsWithTwoContig()
        {
            const int kmerLength = 6;
            IList<ISequence> readSeqs = new List<ISequence>();
            Sequence read = new Sequence(Alphabets.DNA, "GATCTGATAA".Select(a => (byte)a).ToArray());
            read.ID = "0";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "ATCTGATAAG".Select(a => (byte)a).ToArray());
            read.ID = "1";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TCTGATAAGG".Select(a => (byte)a).ToArray());
            read.ID = "2";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TTTTTGATGG".Select(a => (byte)a).ToArray());
            read.ID = "3";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TTTTGATGGC".Select(a => (byte)a).ToArray());
            read.ID = "4";
            readSeqs.Add(read);
            read = new Sequence(Alphabets.DNA, "TTTGATGGCA".Select(a => (byte)a).ToArray());
            read.ID = "5";
            readSeqs.Add(read);

            IList<ISequence> contigs = new List<ISequence> { 
                new Sequence(Alphabets.DNA, "GATCTGATAAGG".Select(a => (byte)a).ToArray()), 
                new Sequence(Alphabets.DNA, "TTTTTGATGGCA".Select(a => (byte)a).ToArray()) };

            IList<Contig> maps = 
                ReadAlignment.ReadContigAlignment(contigs, readSeqs, kmerLength).OrderBy(t => t.Consensus.ToString()).ToList();
            ClassicAssert.AreEqual(maps.Count, contigs.Count);
            IList<Contig.AssembledSequence> readMap = Sort(maps.First().Sequences);

            ClassicAssert.AreEqual(readMap[0].Length, 10);
            ClassicAssert.AreEqual(readMap[0].Position, 1);
            ClassicAssert.AreEqual(readMap[0].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[0].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[0].IsReversed, false);

            ClassicAssert.AreEqual(readMap[1].Length, 10);
            ClassicAssert.AreEqual(readMap[1].Position, 0);
            ClassicAssert.AreEqual(readMap[1].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[1].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[1].IsReversed, false);

            ClassicAssert.AreEqual(readMap[2].Length, 10);
            ClassicAssert.AreEqual(readMap[2].Position, 2);
            ClassicAssert.AreEqual(readMap[2].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[2].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[2].IsReversed, false);

            readMap = Sort(maps[1].Sequences);
            ClassicAssert.AreEqual(readMap[0].Length, 10);
            ClassicAssert.AreEqual(readMap[0].Position, 2);
            ClassicAssert.AreEqual(readMap[0].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[0].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[0].IsReversed, false);

            ClassicAssert.AreEqual(readMap[1].Length, 10);
            ClassicAssert.AreEqual(readMap[1].Position, 1);
            ClassicAssert.AreEqual(readMap[1].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[1].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[1].IsReversed, false);

            ClassicAssert.AreEqual(readMap[2].Length, 10);
            ClassicAssert.AreEqual(readMap[2].Position, 0);
            ClassicAssert.AreEqual(readMap[2].ReadPosition, 0);
            ClassicAssert.AreEqual(readMap[2].IsComplemented, false);
            ClassicAssert.AreEqual(readMap[2].IsReversed, false);
        }

        /// <summary>
        /// Method to read sequences aligned to contigs.
        /// </summary>
        /// <param name="sequence">Assembled Sequences.</param>
        /// <returns>Sorted List of Assembled Sequences.</returns>
        private static IList<Contig.AssembledSequence> Sort(IList<Contig.AssembledSequence> sequence)
        {
            return sequence.OrderBy(t => new string(t.Sequence.Select(a => (char)a).ToArray())).ToList();
        }
    }
}

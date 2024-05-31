using System.Collections.Generic;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Pamsam.Tests
{
    /// <summary>
    /// Test for Profile class
    /// </summary>
    [TestFixture]
    public class ProfileTests
    {
        /// <summary>
        /// Test Profile class
        /// </summary>
        [Test]
        public void TestProfile()
        {
            ISequence templateSequence = new Sequence(Alphabets.AmbiguousDNA, "ATGCSWRYKMBVHDN-");
            Dictionary<byte, int> itemSet = new Dictionary<byte, int>();
            for (int i = 0; i < templateSequence.Count; ++i)
            {
                itemSet.Add(templateSequence[i], i);

                if (char.IsLetter((char)templateSequence[i]))
                    itemSet.Add((byte)char.ToLower((char)templateSequence[i]), i);
            }
            Profiles.ItemSet = itemSet;

            ISequence seqA = new Sequence(Alphabets.DNA, "GGGAAAAATCAGATT");
            ISequence seqB = new Sequence(Alphabets.DNA, "GGGAATCAAAATCAG");

            List<ISequence> sequences = new List<ISequence>();
            sequences.Add(seqA);
            sequences.Add(seqB);

            // Test GenerateProfiles
            IProfiles profileA = Profiles.GenerateProfiles(sequences[0]);
            ClassicAssert.AreEqual(16, profileA.ColumnSize);
            ClassicAssert.AreEqual(sequences[0].Count, profileA.RowSize);

            // Test ProfileMatrix
            ClassicAssert.AreEqual(1, profileA.ProfilesMatrix[0][2]);
            ClassicAssert.AreEqual(0, profileA.ProfilesMatrix[0][3]);

            // Test ProfileAlignment
            IProfileAlignment profileAlignmentA = ProfileAlignment.GenerateProfileAlignment(sequences[0]);
            ClassicAssert.AreEqual(1, profileAlignmentA.ProfilesMatrix[0][2]);
            ClassicAssert.AreEqual(0, profileAlignmentA.ProfilesMatrix[0][3]);
            ClassicAssert.AreEqual(1, profileAlignmentA.NumberOfSequences);

            IProfileAlignment profileAlignmentB = ProfileAlignment.GenerateProfileAlignment(sequences);
            ClassicAssert.AreEqual(1, profileAlignmentB.ProfilesMatrix[0][2]);
            ClassicAssert.AreEqual(0, profileAlignmentB.ProfilesMatrix[0][3]);
            ClassicAssert.AreEqual(2, profileAlignmentB.NumberOfSequences);

            ClassicAssert.AreEqual(0.5, profileAlignmentB.ProfilesMatrix[5][0]);
            ClassicAssert.AreEqual(0.5, profileAlignmentB.ProfilesMatrix[5][1]);
            ClassicAssert.AreEqual(0, profileAlignmentB.ProfilesMatrix[5][2]);
        }
    }
}

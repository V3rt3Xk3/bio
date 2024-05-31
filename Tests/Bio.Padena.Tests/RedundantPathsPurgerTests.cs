﻿using System.Collections.Generic;
using System.Linq;
using Bio;
using Bio.Algorithms.Assembly.Padena;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Padena.Tests
{
    /// <summary>
    /// Test for Step 4 in Parallel De Novo Assembly
    /// This step performs error correction on the input graph.
    /// It removes redundant paths in the graph.
    /// </summary>
    [TestFixture]
    public class RedundantPathsPurgerTests : ParallelDeNovoAssembler
    {
        /// <summary>
        /// Test Step 4 - Redundant Paths Purger class
        /// </summary>
        [Test]
        public void TestRedundantPathsPurger()
        {
            const int KmerLength = 5;
            const int RedundantThreshold = 10;

            List<ISequence> readSeqs = TestInputs.GetRedundantPathReads();
            this.SequenceReads.Clear();
            this.SetSequenceReads(readSeqs);
            this.KmerLength = KmerLength;
            this.RedundantPathLengthThreshold = RedundantThreshold;
            this.RedundantPathsPurger = new RedundantPathsPurger(RedundantThreshold);

            this.CreateGraph();
            long graphCount = this.Graph.NodeCount;
            long graphEdges = this.Graph.GetNodes().Select(n => n.ExtensionsCount).Sum();

            this.RemoveRedundancy();
            long redundancyRemovedGraphCount = this.Graph.NodeCount;
            long redundancyRemovedGraphEdge = this.Graph.GetNodes().Select(n => n.ExtensionsCount).Sum();

            // Compare the two graphs
            ClassicAssert.AreEqual(5, graphCount - redundancyRemovedGraphCount);
            ClassicAssert.AreEqual(12, graphEdges - redundancyRemovedGraphEdge);
        }
    }
}

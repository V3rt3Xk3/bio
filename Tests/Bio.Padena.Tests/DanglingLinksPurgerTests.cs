﻿using System.Collections.Generic;
using System.Linq;
using Bio.Algorithms.Assembly.Padena;
using Bio.Extensions;
using Bio.Tests.Framework;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Padena.Tests
{
    /// <summary>
    /// Test for Step 3 in Parallel De Novo Assembly
    /// This step performs error correction on the input graph.
    /// It removes dangling links in the graph.
    /// </summary>
    [TestFixture]
    public class DanglingLinksPurgerTests : ParallelDeNovoAssembler
    {
        /// <summary>
        /// Test Step 3 - Dangling Link Purger class
        /// </summary>
        [Test]
        public void TestDanglingLinksPurger()
        {
            const int KmerLength = 11;
            const int DangleThreshold = 3;

            List<ISequence> readSeqs = TestInputs.GetDanglingReads();
            SequenceReads.Clear();
            this.SetSequenceReads(readSeqs);
            this.KmerLength = KmerLength;
            DanglingLinksThreshold = DangleThreshold;
            DanglingLinksPurger = new DanglingLinksPurger(DangleThreshold);

            CreateGraph();
            long graphCount = Graph.NodeCount;

            long graphEdges = Graph.GetNodes().Select(n => n.ExtensionsCount).Sum();
            var graphNodes = Graph.GetNodes().Select(n => Graph.GetNodeSequence(n)).ToList();

            DanglingLinksThreshold = DangleThreshold;
            UnDangleGraph();

            long dangleRemovedGraphCount = Graph.NodeCount;
            long dangleRemovedGraphEdge = Graph.GetNodes().Select(n => n.ExtensionsCount).Sum();
            var dangleRemovedGraphNodes = Graph.GetNodes().Select(n => Graph.GetNodeSequence(n)).ToList();

            // Compare the two graphs
            ClassicAssert.AreEqual(2, graphCount - dangleRemovedGraphCount);
            ClassicAssert.AreEqual(4, graphEdges - dangleRemovedGraphEdge);
            var checkList = graphNodes.Except(dangleRemovedGraphNodes, new SequenceEqualityComparer());

            HashSet<string> expected = new HashSet<string> { "ATCGAACGATG","TCGAACGATGA" };
            AlignmentHelpers.CompareSequenceLists(expected, checkList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bio;
using Bio.Algorithms.Alignment.MultipleSequenceAlignment;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Linq;

namespace Bio.Pamsam.Tests
{
    /// <summary>
    /// Test for BinaryGuideTree class
    /// </summary>
    [TestFixture]
    public class BinaryGuideTreeTests
    {
        /// <summary>
        /// Test BinaryGuideTree class
        /// </summary>
        [Test]
        public void TestBinaryGuideTree()
        {
            int numberOfNodes = 5;
            var nodes = Enumerable.Range(0, numberOfNodes)
                .Select(n => new BinaryGuideTreeNode(n))
                .ToList();

            nodes[3].LeftChildren = nodes[0];
            nodes[3].RightChildren = nodes[1];
            nodes[4].LeftChildren = nodes[3];
            nodes[4].RightChildren = nodes[2];

            nodes[0].Parent = nodes[3];
            nodes[1].Parent = nodes[3];
            nodes[2].Parent = nodes[4];
            nodes[3].Parent = nodes[4];


            ClassicAssert.IsFalse(nodes[0].IsRoot);
            ClassicAssert.IsTrue(nodes[0].IsLeaf);

            ClassicAssert.IsFalse(nodes[1].IsRoot);
            ClassicAssert.IsTrue(nodes[1].IsLeaf);

            ClassicAssert.IsFalse(nodes[2].IsRoot);
            ClassicAssert.IsTrue(nodes[2].IsLeaf);

            ClassicAssert.IsFalse(nodes[3].IsRoot);
            ClassicAssert.IsFalse(nodes[3].IsLeaf);

            ClassicAssert.IsTrue(nodes[4].IsRoot);
            ClassicAssert.IsFalse(nodes[4].IsLeaf);

            ClassicAssert.AreEqual(nodes[3], nodes[0].Parent);

            int numberOfEdges = 4;
            var edges = Enumerable.Range(0, numberOfEdges)
                .Select(n => new BinaryGuideTreeEdge(n)).ToList();

            edges[0].ParentNode = nodes[3];
            edges[0].ChildNode = nodes[0];
            edges[1].ParentNode = nodes[3];
            edges[1].ChildNode = nodes[1];

            edges[2].ParentNode = nodes[4];
            edges[2].ChildNode = nodes[2];
            edges[3].ParentNode = nodes[4];
            edges[3].ChildNode = nodes[3];

            int dimension = 4;
            IDistanceMatrix distanceMatrix = new SymmetricDistanceMatrix(dimension);
            for (int i = 0; i < distanceMatrix.Dimension - 1; ++i)
            {
                for (int j = i + 1; j < distanceMatrix.Dimension; ++j)
                {
                    distanceMatrix[i, j] = i + j;
                    distanceMatrix[j, i] = i + j;
                }
            }

            PAMSAMMultipleSequenceAligner.ParallelOption = new ParallelOptions { MaxDegreeOfParallelism = 2 };
            IHierarchicalClustering hierarchicalClustering = new HierarchicalClusteringParallel(distanceMatrix);
            BinaryGuideTree binaryGuideTree = new BinaryGuideTree(hierarchicalClustering);

            ClassicAssert.AreEqual(7, binaryGuideTree.NumberOfNodes);
            ClassicAssert.AreEqual(6, binaryGuideTree.NumberOfEdges);
            ClassicAssert.AreEqual(4, binaryGuideTree.NumberOfLeaves);

            ClassicAssert.IsTrue(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1].IsRoot);

            for (int i = 0; i < binaryGuideTree.Nodes.Count; ++i)
            {
                Console.WriteLine(binaryGuideTree.Nodes[i].ID);
            }

            // Test ExtractSubTreeNodes
            Console.WriteLine("binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[4]).Count : {0}", binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[4]).Count);
            Console.WriteLine("binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Count : {0}", binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Count);
            Console.WriteLine("binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[0]).Count : {0}", binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[0]).Count);
            ClassicAssert.AreEqual(3, binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[4]).Count);
            ClassicAssert.AreEqual(7, binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Count);
            ClassicAssert.AreEqual(1, binaryGuideTree.ExtractSubTreeNodes(binaryGuideTree.Nodes[0]).Count);

            // Test ExtractSubTreeLeafNodes
            Console.WriteLine("binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[4]).Count : {0}", binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[4]).Count);
            Console.WriteLine("binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Coun : {0}", binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Count);
            Console.WriteLine("binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[0]).Count : {0}", binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[0]).Count);
            ClassicAssert.AreEqual(2, binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[4]).Count);
            ClassicAssert.AreEqual(4, binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1]).Count);
            ClassicAssert.AreEqual(1, binaryGuideTree.ExtractSubTreeLeafNodes(binaryGuideTree.Nodes[0]).Count);


            // Test FindSmallestTreeDifference
            BinaryGuideTree binaryGuideTreeB = new BinaryGuideTree(hierarchicalClustering);
            BinaryGuideTreeNode node = BinaryGuideTree.FindSmallestTreeDifference(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1], binaryGuideTreeB.Nodes[binaryGuideTreeB.Nodes.Count - 1]);
            ClassicAssert.IsNull(node);
            node = BinaryGuideTree.FindSmallestTreeDifference(binaryGuideTree.Nodes[binaryGuideTree.Nodes.Count - 1], binaryGuideTreeB.Nodes[0]);
            ClassicAssert.IsNotNull(node);

            // Test CompareTwoTrees

            for (int i = 0; i < binaryGuideTree.Nodes.Count; ++i)
            {
                Console.Write(binaryGuideTree.Nodes[i].ID);
            }
            for (int i = 0; i < binaryGuideTreeB.Nodes.Count; ++i)
            {
                Console.Write(binaryGuideTreeB.Nodes[i].ID);
            }

            BinaryGuideTree.CompareTwoTrees(binaryGuideTree, binaryGuideTreeB);

            for (int i = 0; i < binaryGuideTree.Nodes.Count; ++i)
            {
                Console.Write(binaryGuideTree.Nodes[i].ID);
                Console.Write(binaryGuideTree.Nodes[i].NeedReAlignment);
                binaryGuideTree.Nodes[i].NeedReAlignment = false;
            }
            for (int i = 0; i < binaryGuideTreeB.Nodes.Count; ++i)
            {
                Console.Write(binaryGuideTreeB.Nodes[i].ID);
                Console.Write(binaryGuideTreeB.Nodes[i].NeedReAlignment);
                binaryGuideTreeB.Nodes[i].NeedReAlignment = false;
            }
            ClassicAssert.IsFalse(binaryGuideTree.Nodes[4].NeedReAlignment);
            ClassicAssert.IsFalse(binaryGuideTree.Nodes[5].NeedReAlignment);
            ClassicAssert.IsFalse(binaryGuideTree.Nodes[6].NeedReAlignment);

            for (int i = binaryGuideTree.NumberOfLeaves; i < binaryGuideTree.NumberOfNodes; ++i)
            {
                ClassicAssert.IsFalse(binaryGuideTree.Nodes[i].NeedReAlignment);
            }

            binaryGuideTreeB.Root.ID = 7;
            BinaryGuideTree.CompareTwoTrees(binaryGuideTree, binaryGuideTreeB);

            ClassicAssert.IsFalse(binaryGuideTree.Root.NeedReAlignment);

            binaryGuideTreeB.Nodes[5].ID = 8;
            BinaryGuideTree.CompareTwoTrees(binaryGuideTree, binaryGuideTreeB);

            for (int i = 0; i < binaryGuideTree.Nodes.Count; ++i)
            {
                Console.WriteLine(binaryGuideTree.Nodes[i].ID);
                Console.WriteLine(binaryGuideTree.Nodes[i].NeedReAlignment);
            }
            for (int i = 0; i < binaryGuideTreeB.Nodes.Count; ++i)
            {
                Console.WriteLine(binaryGuideTreeB.Nodes[i].ID);
                Console.WriteLine(binaryGuideTreeB.Nodes[i].NeedReAlignment);
            }

            ClassicAssert.IsFalse(binaryGuideTree.Nodes[5].NeedReAlignment);
            ClassicAssert.IsFalse(binaryGuideTree.Root.NeedReAlignment);

            binaryGuideTreeB.Nodes[5].LeftChildren = binaryGuideTreeB.Nodes[3];
            BinaryGuideTree.CompareTwoTrees(binaryGuideTree, binaryGuideTreeB);
            //ClassicAssert.IsTrue(binaryGuideTree.Nodes[5].NeedReAlignment);
            //ClassicAssert.IsTrue(binaryGuideTree.Root.NeedReAlignment);
            //ClassicAssert.IsFalse(binaryGuideTree.Nodes[4].NeedReAlignment);

            // Test SeparateSequencesByCuttingTree
            List<int>[] newSequences = binaryGuideTree.SeparateSequencesByCuttingTree(3);
            ClassicAssert.AreEqual(1, newSequences[0].Count);
            ClassicAssert.AreEqual(3, newSequences[1].Count);
            Console.WriteLine("newSequences[0].Count: {0}", newSequences[0].Count);
            Console.WriteLine("newSequences[1].Count: {0}", newSequences[1].Count);


            List<int>[] newSequencesB = binaryGuideTree.SeparateSequencesByCuttingTree(2);
            ClassicAssert.AreEqual(2, newSequencesB[0].Count);
            ClassicAssert.AreEqual(2, newSequencesB[1].Count);
            Console.WriteLine("newSequences[0].Count: {0}", newSequencesB[0].Count);
            Console.WriteLine("newSequences[1].Count: {0}", newSequencesB[1].Count);

            // Cut tree test
            ISequence seq1 = new Sequence(Alphabets.DNA, "GGGAAAAATCAGATT");
            ISequence seq2 = new Sequence(Alphabets.DNA, "GGGAATCAAAATCAG");
            ISequence seq3 = new Sequence(Alphabets.DNA, "GGGAATCAAAATCAG");
            ISequence seq4 = new Sequence(Alphabets.DNA, "GGGAAATCG");
            ISequence seq5 = new Sequence(Alphabets.DNA, "GGGAATCAATCAG");
            ISequence seq6 = new Sequence(Alphabets.DNA, "GGGACAAAATCAG");
            ISequence seq7 = new Sequence(Alphabets.DNA, "GGGAATCTTATCAG");

            List<ISequence> sequences = new List<ISequence>
            {
                seq1,
                seq2,
                seq3,
                seq4,
                seq5,
                seq6,
                seq7
            };

            // Generate DistanceMatrix
            KmerDistanceMatrixGenerator kmerDistanceMatrixGenerator =
                new KmerDistanceMatrixGenerator(sequences, 2, Alphabets.AmbiguousDNA, DistanceFunctionTypes.EuclideanDistance);

            // Hierarchical clustering
            IHierarchicalClustering hierarcicalClustering = new HierarchicalClusteringParallel(kmerDistanceMatrixGenerator.DistanceMatrix, UpdateDistanceMethodsTypes.Average);

            //// Generate Guide Tree
            binaryGuideTree = new BinaryGuideTree(hierarcicalClustering);

            // CUT Tree
            BinaryGuideTree[] subtrees = binaryGuideTree.CutTree(3);

            ClassicAssert.IsNotNull(subtrees);
        }
    }
}

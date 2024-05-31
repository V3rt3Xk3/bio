using Bio.Algorithms.Alignment.MultipleSequenceAlignment;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Pamsam.Tests
{
    /// <summary>
    /// Test for DistanceMatrix Class
    /// </summary>
    [TestFixture]
    public class DistanceMatrixTests
    {
        /// <summary>
        /// Test DistanceMatrix Class
        /// </summary>
        [Test]
        public void TestDistanceMatrix()
        {
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

            ClassicAssert.AreEqual(dimension, distanceMatrix.Dimension);
            ClassicAssert.AreEqual(dimension, distanceMatrix.NearestNeighbors.Length);
            ClassicAssert.AreEqual(dimension, distanceMatrix.NearestDistances.Length);

            // Test elements
            for (int i = 0; i < distanceMatrix.Dimension - 1; ++i)
            {
                for (int j = i + 1; j < distanceMatrix.Dimension; ++j)
                {
                    ClassicAssert.AreEqual(i + j, distanceMatrix[i, j]);
                    ClassicAssert.AreEqual(i + j, distanceMatrix[j, i]);
                }
            }

            // Test NearestNeighbors
            ClassicAssert.AreEqual(1, distanceMatrix.NearestNeighbors[0]);
            ClassicAssert.AreEqual(0, distanceMatrix.NearestNeighbors[1]);
            ClassicAssert.AreEqual(0, distanceMatrix.NearestNeighbors[2]);
            ClassicAssert.AreEqual(0, distanceMatrix.NearestNeighbors[3]);

            ClassicAssert.AreEqual(1, distanceMatrix.NearestDistances[0]);
            ClassicAssert.AreEqual(1, distanceMatrix.NearestDistances[1]);
            ClassicAssert.AreEqual(2, distanceMatrix.NearestDistances[2]);
            ClassicAssert.AreEqual(3, distanceMatrix.NearestDistances[3]);
        }
    }
}

using System.Text;

using Bio.Util.Logging;

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests
{
    /// <summary>
    /// Test Automation code for Bio IndexedItem BVT level validations.
    /// </summary>
    [TestFixture]
    public class IndexedItemBvtTestCases
    {
        #region IndexedItem Bvt TestCases

        /// <summary>
        /// Validate a CompareTo() method in IndexedItem.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void ValidateIndexedItemCompareTo()
        {
            IndexedItem<byte> indexedObj = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj2 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj3 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            ClassicAssert.AreEqual(0, indexedObj.CompareTo(indexedObj2));
            ClassicAssert.AreEqual(0, indexedObj.CompareTo((object)indexedObj3));
            ClassicAssert.AreEqual(1, indexedObj.CompareTo(null));

            ApplicationLog.WriteLine(
                "IndexedItem BVT: Successfully validated the CompareTo() method.");
        }

        /// <summary>
        /// Validate a Equals() method in IndexedItem.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void ValidateIndexedItemEquals()
        {
            IndexedItem<byte> indexedObj = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj2 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj3 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            ClassicAssert.IsTrue(indexedObj.Equals(indexedObj2));
            ClassicAssert.IsTrue(indexedObj.Equals((object)indexedObj3));

            ApplicationLog.WriteLine(
                "IndexedItem BVT: Successfully validated the Equals() method.");
        }

        /// <summary>
        /// Validate the operators in IndexedItem.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void ValidateIndexedItemOperators()
        {
            IndexedItem<byte> indexedObj = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj1 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("A")[0]);
            IndexedItem<byte> indexedObj2 = new IndexedItem<byte>(0, Encoding.ASCII.GetBytes("G")[0]);

            ClassicAssert.IsTrue(indexedObj == indexedObj1);
            ClassicAssert.IsFalse(indexedObj == indexedObj2);
            ClassicAssert.IsFalse(indexedObj < indexedObj2);
            ClassicAssert.IsTrue(indexedObj <= indexedObj2);
            ClassicAssert.IsFalse(indexedObj2 > indexedObj);
            ClassicAssert.IsTrue(indexedObj2 >= indexedObj);
            ClassicAssert.IsTrue(indexedObj1 != indexedObj2);

            ApplicationLog.WriteLine(
                "IndexedItem BVT: Successfully validated all the properties.");
        }

        #endregion IndexedItem Bvt TestCases
    }
}


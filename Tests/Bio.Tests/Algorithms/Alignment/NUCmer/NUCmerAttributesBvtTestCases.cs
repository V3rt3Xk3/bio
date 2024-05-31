using System.Collections.Generic;
using Bio.Algorithms.Alignment;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests.Algorithms.Alignment.NUCmer
{
    /// <summary>
    /// Test Automation code for Bio Sequences and BVT level validations.
    /// </summary>
    [TestFixture]
    public class NUCmerAttributesBvtTestCases
    {
        /// <summary>
        /// Validate the attributes in NUCmerAttributes.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void ValidateNUCmerAttributes()
        {
            NUCmerAttributes nucAttrib = new NUCmerAttributes();
            Dictionary<string, AlignmentInfo> attributes = nucAttrib.Attributes;

            ClassicAssert.AreEqual(9, attributes.Count);

            // Validating all the NUCmer attributes
            AlignmentInfo similarityMatrixObj = attributes["SIMILARITYMATRIX"];
            AlignmentInfo gapOpenCostObj = attributes["GAPOPENCOST"];
            AlignmentInfo gapExtensionCostObj = attributes["GAPEXTENSIONCOST"];

            AlignmentInfo lenOfMumObj = attributes["LENGTHOFMUM"];
            AlignmentInfo fixedSepObj = attributes["FIXEDSEPARATION"];
            AlignmentInfo maxSepObj = attributes["MAXIMUMSEPARATION"];

            AlignmentInfo minScoreObj = attributes["MINIMUMSCORE"];
            AlignmentInfo sepFactorObj = attributes["SEPARATIONFACTOR"];
            AlignmentInfo breakLengthObj = attributes["BREAKLENGTH"];

            ClassicAssert.AreEqual("Similarity Matrix", similarityMatrixObj.Name);
            ClassicAssert.AreEqual("Gap Cost", gapOpenCostObj.Name);
            ClassicAssert.AreEqual("Gap Extension Cost", gapExtensionCostObj.Name);

            ClassicAssert.AreEqual("Length of MUM", lenOfMumObj.Name);
            ClassicAssert.AreEqual("Fixed Separation", fixedSepObj.Name);
            ClassicAssert.AreEqual("Maximum Separation", maxSepObj.Name);

            ClassicAssert.AreEqual("Minimum Score", minScoreObj.Name);
            ClassicAssert.AreEqual("Separation Factor", sepFactorObj.Name);
            ClassicAssert.AreEqual("Break Length", breakLengthObj.Name);
        }
    }
}


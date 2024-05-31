/****************************************************************************
 * GenBankFeaturesP1TestCases.cs
 * 
 *   This file contains the GenBank Features P1 test cases.
 * 
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bio.IO;
using Bio.IO.GenBank;
using Bio.TestAutomation.Util;
using Bio.Tests;
using Bio.Util.Logging;
using NUnit.Framework;
using NUnit.Framework.Legacy;

#if (SILVERLIGHT == false)
namespace Bio.TestAutomation.IO.GenBank
#else
namespace Bio.Silverlight.TestAutomation.IO.GenBank
#endif
{
    /// <summary>
    ///     GenBank Features P1 test case implementation.
    /// </summary>
    [TestFixture]
    public class GenBankFeaturesP1TestCases
    {
        #region Enums

        /// <summary>
        ///     GenBank Feature parameters which are used for different test cases
        ///     based on which the test cases are executed.
        /// </summary>
        private enum FeatureGroup
        {
            CDS,
            Exon,
            Intron,
            mRNA,
            Enhancer,
            Promoter,
            miscDifference,
            variation,
            MiscStructure,
            TrnsitPeptide,
            StemLoop,
            ModifiedBase,
            PrecursorRNA,
            PolySite,
            MiscBinding,
            GCSignal,
            LTR,
            Operon,
            UnsureSequenceRegion,
            NonCodingRNA,
            RibosomeBindingSite,
            Default
        };

        /// <summary>
        ///     GenBank Feature location operators used for different test cases.
        /// </summary>
        private enum FeatureOperator
        {
            Join,
            Complement,
            Order,
            Default
        };

        #endregion Enums

        #region Global Variables

        private readonly Utility utilityObj = new Utility(@"TestUtils\GenBankFeaturesTestConfig.xml");

        #endregion Global Variables

        #region GenBank P1 TestCases

        /// <summary>
        ///     Parse a valid medium size DNA GenBank file.
        ///     and validate GenBank features.
        ///     Input : DNA medium size Sequence
        ///     Output : Validate GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMediumSizeDnaSequence()
        {
            ValidateGenBankFeatures(Constants.MediumSizeDNAGenBankFeaturesNode,
                                    "DNA");
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate GenBank features.
        ///     Input : Protein medium size Sequence
        ///     Output : Validate GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMediumSizeProteinSequence()
        {
            ValidateGenBankFeatures(Constants.MediumSizePROTEINGenBankFeaturesNode,
                                    "Protein");
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank features.
        ///     Input : RNA medium size Sequence
        ///     Output : Validate GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMediumSizeRnaSequence()
        {
            ValidateGenBankFeatures(Constants.MediumSizeRNAGenBankFeaturesNode,
                                    "RNA");
        }

        /// <summary>
        ///     Parse a valid medium size DNA GenBank file.
        ///     and validate cloned GenBank features.
        ///     Input : DNA medium size Sequence
        ///     Output : alidate cloned GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateClonedGenBankFeaturesForMediumSizeDnaSequence()
        {
            ValidateCloneGenBankFeatures(Constants.MediumSizeDNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate cloned GenBank features.
        ///     Input : Protein medium size Sequence
        ///     Output : validate cloned GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateClonedGenBankFeaturesForMediumSizeProteinSequence()
        {
            ValidateCloneGenBankFeatures(Constants.MediumSizePROTEINGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank features.
        ///     Input : RNA medium size Sequence
        ///     Output : Validate GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateClonedGenBankFeaturesForMediumSizeRnaSequence()
        {
            ValidateCloneGenBankFeatures(Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid medium size DNA GenBank file.
        ///     and validate GenBank DNA sequence standard features.
        ///     Input : Valid DNA sequence.
        ///     Output : Validation of GenBank standard Features
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMediumSizeDnaSequenceStandardFeatures()
        {
            ValidateGenBankStandardFeatures(Constants.MediumSizeDNAGenBankFeaturesNode,
                                            "DNA");
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate GenBank Protein seq standard features.
        ///     Input : Valid Protein sequence.
        ///     Output : Validation of GenBank standard Features
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMediumSizeProteinSequenceStandardFeatures()
        {
            ValidateGenBankStandardFeatures(Constants.MediumSizePROTEINGenBankFeaturesNode,
                                            "Protein");
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank RNA seq standard features.
        ///     Input : Valid RNA sequence.
        ///     Output : Validation of GenBank standard Features
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMediumSizeRNaSequenceStandardFeatures()
        {
            ValidateGenBankStandardFeatures(Constants.MediumSizeRNAGenBankFeaturesNode,
                                            "RNA");
        }

        /// <summary>
        ///     Parse a valid multiSequence Protein GenBank file.
        ///     validate GenBank Features.
        ///     Input : MultiSequence GenBank Protein file.
        ///     Validation : Validate GenBank Features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMultipleProteinSequence()
        {
            ValidateGenBankFeatures(Constants.MultiSeqGenBankProteinNode,
                                    null);
        }

        /// <summary>
        ///     Parse a valid multiSequence RNA GenBank file.
        ///     validate GenBank Features.
        ///     Input : MultiSequence GenBank RNA file.
        ///     Validation : Validate GenBank Features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMultipleRnaSequence()
        {
            ValidateGenBankFeatures(Constants.MulitSequenceGenBankRNANode,
                                    "RNA");
        }


        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validate of GenBank Gene feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankGeneFeatureQualifiers()
        {
            ValidateGenBankGeneFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validate of GenBank tRNA feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBanktRNAFeatureQualifiers()
        {
            ValidateGenBanktRNAFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validate of GenBank tRNA feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBanktRNAFeatureQualifiers()
        {
            ValidateGenBanktRNAFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validate of GenBank Gene feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankGeneFeatureQualifiers()
        {
            ValidateGenBankGeneFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validate of GenBank mRNA feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankmRNAFeatureQualifiers()
        {
            ValidateGenBankmRNAFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validate of GenBank mRNA feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankmRNAFeatureQualifiers()
        {
            ValidateGenBankmRNAFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid Protein GenBank file.
        ///     and validate GenBank Gene feature qualifiers
        ///     Input : Protein medium size Sequence
        ///     Output : Validate of GenBank mRNA feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankmRNAFeatureQualifiers()
        {
            ValidateGenBankmRNAFeatureQualifiers(
                Constants.ProteinGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate addition of GenBank features.
        ///     Input : RNA medium size Sequence
        ///     Output : validate addition of GenBank features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateAdditionGenBankFeatures()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FilePathNode).TestDir();
            string addFirstKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstKey);
            string addSecondKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondKey);
            string addFirstLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstLocation);
            string addSecondLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondLocation);

            // Parse a GenBank file.
            var locBuilder = new LocationBuilder();
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

            // Add a new features to Genbank features list.
            metadata.Features = new SequenceFeatures();
            var feature = new FeatureItem(addFirstKey, addFirstLocation);
            metadata.Features.All.Add(feature);
            feature = new FeatureItem(addSecondKey, addSecondLocation);
            metadata.Features.All.Add(feature);

            // Validate added GenBank features.
            ClassicAssert.AreEqual(metadata.Features.All[0].Key.ToString(null), addFirstKey);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(metadata.Features.All[0].Location),
                            addFirstLocation);
            ClassicAssert.AreEqual(metadata.Features.All[1].Key.ToString(null), addSecondKey);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(metadata.Features.All[1].Location),
                            addSecondLocation);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate addition of GenBank qualifiers.
        ///     Input : RNA medium size Sequence
        ///     Output : validate addition of GenBank qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateAdditionGenBankQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FilePathNode).TestDir();
            string addFirstKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstKey);
            string addSecondKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondKey);
            string addFirstLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstLocation);
            string addSecondLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondLocation);
            string addFirstQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstQualifier);
            string addSecondQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondQualifier);

            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

            var locBuilder = new LocationBuilder();

            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

            // Add a new features to Genbank features list.
            metadata.Features = new SequenceFeatures();
            var feature = new FeatureItem(addFirstKey,
                                          addFirstLocation);
            var qualifierValues = new List<string>();
            qualifierValues.Add(addFirstQualifier);
            qualifierValues.Add(addFirstQualifier);
            feature.Qualifiers.Add(addFirstQualifier, qualifierValues);
            metadata.Features.All.Add(feature);

            feature = new FeatureItem(addSecondKey, addSecondLocation);
            qualifierValues = new List<string>();
            qualifierValues.Add(addSecondQualifier);
            qualifierValues.Add(addSecondQualifier);
            feature.Qualifiers.Add(addSecondQualifier, qualifierValues);
            metadata.Features.All.Add(feature);

            // Validate added GenBank features.
            ClassicAssert.AreEqual(metadata.Features.All[0].Key.ToString(null),
                            addFirstKey);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.All[0].Location),
                            addFirstLocation);
            ClassicAssert.AreEqual(metadata.Features.All[1].Key.ToString(null),
                            addSecondKey);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.All[1].Location),
                            addSecondLocation);
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and Validate CDS Qualifiers
        ///     Input : Protein medium size Sequence
        ///     Output : validate CDS Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMediumSizePROTEINSequenceCDSQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.FilePathNode).TestDir();
            string expectedCDSException = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.CDSException);
            string expectedCDSLabel = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.CDSLabel);
            string expectedCDSDBReference = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.CDSDBReference);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            ISequence sequence = parserObj.Parse(filePath).FirstOrDefault();

            var metadata =
                sequence.Metadata[Constants.GenBank] as GenBankMetadata;

            // Get CDS qaulifier.value.
            List<CodingSequence> cdsQualifiers = metadata.Features.CodingSequences;
            List<string> dbReferenceValue = cdsQualifiers[0].DatabaseCrossReference;
            ClassicAssert.AreEqual(cdsQualifiers[0].Label, expectedCDSLabel);
            ClassicAssert.AreEqual(cdsQualifiers[0].Exception.ToString(null), expectedCDSException);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(cdsQualifiers[0].Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(cdsQualifiers[0].Citation.ToString()));
            ClassicAssert.AreEqual(dbReferenceValue[0], expectedCDSDBReference);
            ClassicAssert.AreEqual(cdsQualifiers[0].GeneSymbol, expectedGeneSymbol);
        }

        /// <summary>
        ///     Parse a valid GenBank file.
        ///     and Validate Clearing feature list
        ///     Input : Dna medium size Sequence
        ///     Output : validate clear() featre list.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRemoveFeatureItem()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankDnaNodeName, Constants.FilePathNode).TestDir();
            string allFeaturesCount = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankDnaNodeName, Constants.GenBankFeaturesCount);

            // Parse a file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> sequenceList = parserObj.Parse(filePath);

                // GenBank metadata.
                var metadata =
                    sequenceList.ElementAt(0).Metadata[Constants.GenBank] as GenBankMetadata;

                // Validate GenBank features before removing feature item.
                ClassicAssert.AreEqual(metadata.Features.All.Count,
                                Convert.ToInt32(allFeaturesCount, null));
                IList<FeatureItem> featureList = metadata.Features.All;

                // Remove feature items from feature list.
                featureList.Clear();

                // Validate feature list after clearing featureList.
                ClassicAssert.AreEqual(featureList.Count, 0);

                ApplicationLog.WriteLine("GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Parse a Protein valid GenBank file.
        ///     and Validate Clearing feature list
        ///     Input : Protein medium size Sequence
        ///     Output : validate clear() featre list.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRemoveFeatureItemForProteinSequence()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.FilePathNode).TestDir();
            string allFeaturesCount = utilityObj.xmlUtil.GetTextValue(
                Constants.SimpleGenBankProNodeName, Constants.GenBankFeaturesCount);

            // Parse a file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> sequenceList = parserObj.Parse(filePath);

                // GenBank metadata.
                var metadata =
                    sequenceList.ElementAt(0).Metadata[Constants.GenBank] as GenBankMetadata;

                // Validate GenBank features before removing feature item.
                ClassicAssert.AreEqual(metadata.Features.All.Count, Convert.ToInt32(allFeaturesCount, null));
                IList<FeatureItem> featureList = metadata.Features.All;

                // Remove feature items from feature list.
                featureList.Clear();

                // Validate feature list after clearing featureList.
                ClassicAssert.AreEqual(featureList.Count, 0);

                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Parse a Valid medium size Dna Sequence and Validate Features
        ///     within specified range.
        ///     Input : Valid medium size Dna Sequence and specified range.
        ///     Ouput : Validate features within specified range.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateFeaturesWithinRangeForMediumSizeDnaSequence()
        {
            ValidateGetFeatures(Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a Valid medium size Rna Sequence and Validate Features
        ///     within specified range.
        ///     Input : Valid medium size Rna Sequence and specified range.
        ///     Ouput : Validate features within specified range.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateFeaturesWithinRangeForMediumSizeRnaSequence()
        {
            ValidateGetFeatures(Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a Valid medium size Protein Sequence and Validate Features
        ///     within specified range.
        ///     Input : Valid medium size Protein Sequence and specified range.
        ///     Ouput : Validate features within specified range.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateFeaturesWithinRangeForMediumSizeProteinSequence()
        {
            ValidateGetFeatures(Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a Valid DNA Sequence and validate citation referenced
        ///     present in CDS GenBank Feature.
        ///     Input : Valid DNA Sequence
        ///     Ouput : Validation of citation referneced for CDS feature.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCitationReferencedForCDSFeature()
        {
            ValidateCitationReferenced(
                Constants.DNAStandardFeaturesKeyNode, FeatureGroup.CDS);
        }

        /// <summary>
        ///     Parse a Valid DNA Sequence and validate citation referenced
        ///     present in mRNA GenBank Feature.
        ///     Input : Valid DNA Sequence
        ///     Ouput : Validation of citation referneced for mRNA feature.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCitationReferencedFormRNAFeature()
        {
            ValidateCitationReferenced(
                Constants.DNAStandardFeaturesKeyNode, FeatureGroup.mRNA);
        }

        /// <summary>
        ///     Parse a Valid DNA Sequence and validate citation referenced
        ///     present in Exon GenBank Feature.
        ///     Input : Valid DNA Sequence
        ///     Ouput : Validation of citation referneced for Exon feature.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCitationReferencedForhExonFeature()
        {
            ValidateCitationReferenced(
                Constants.DNAStandardFeaturesKeyNode, FeatureGroup.Exon);
        }

        /// <summary>
        ///     Parse a Valid DNA Sequence and validate citation referenced
        ///     present in Intron GenBank Feature.
        ///     Input : Valid DNA Sequence
        ///     Ouput : Validation of citation referneced for Intron feature.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCitationReferencedForIntronFeature()
        {
            ValidateCitationReferenced(
                Constants.DNAStandardFeaturesKeyNode, FeatureGroup.Intron);
        }

        /// <summary>
        ///     Parse a Valid DNA Sequence and validate citation referenced
        ///     present in Promoter GenBank Feature.
        ///     Input : Valid DNA Sequence
        ///     Ouput : Validation of citation referneced for Promoter feature.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCitationReferencedForEnhancerFeature()
        {
            ValidateCitationReferenced(
                Constants.DNAStandardFeaturesKeyNode, FeatureGroup.Promoter);
        }

        /// <summary>
        ///     Parse a valid medium size multiSequence RNA GenBank file.
        ///     validate GenBank Features.
        ///     Input : Medium size MultiSequence GenBank RNA file.
        ///     Validation : Validate GenBank Features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFeaturesForMediumSizeMultipleRnaSequence()
        {
            ValidateGenBankFeatures(Constants.MediumSizeMulitSequenceGenBankRNANode,
                                    "RNA");
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate addition of single GenBank feature.
        ///     Input : RNA medium size Sequence
        ///     Output : validate addition of single GenBank  features.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateAdditionSingleGenBankFeature()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FilePathNode).TestDir();
            string addFirstKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstKey);
            string addFirstLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata = (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

                // Add a new features to Genbank features list.
                metadata.Features = new SequenceFeatures();
                var feature = new FeatureItem(addFirstKey, addFirstLocation);
                metadata.Features.All.Add(feature);

                // Validate added GenBank features.
                ClassicAssert.AreEqual(metadata.Features.All[0].Key.ToString(null),
                                addFirstKey);
                ClassicAssert.AreEqual(
                    locBuilder.GetLocationString(metadata.Features.All[0].Location),
                    addFirstLocation);
            }
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate addition of single GenBank qualifier.
        ///     Input : RNA medium size Sequence
        ///     Output : validate addition of single GenBank qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateAdditionSingleGenBankQualifier()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FilePathNode).TestDir();
            string addFirstKey = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstKey);
            string addFirstLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstLocation);
            string addFirstQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.FirstQualifier);
            string addSecondQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.MediumSizeRNAGenBankFeaturesNode, Constants.SecondQualifier);

            // Parse a GenBank file.            
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

                // Add a new features to Genbank features list.
                metadata.Features = new SequenceFeatures();
                var feature = new FeatureItem(addFirstKey, addFirstLocation);
                var qualifierValues = new List<string>();
                qualifierValues.Add(addFirstQualifier);
                qualifierValues.Add(addFirstQualifier);
                feature.Qualifiers.Add(addFirstQualifier, qualifierValues);
                metadata.Features.All.Add(feature);

                qualifierValues = new List<string>();
                qualifierValues.Add(addSecondQualifier);
                qualifierValues.Add(addSecondQualifier);
                feature.Qualifiers.Add(addSecondQualifier, qualifierValues);
                metadata.Features.All.Add(feature);

                // Validate added GenBank features.
                ClassicAssert.AreEqual(
                    metadata.Features.All[0].Key.ToString(null), addFirstKey);
                ClassicAssert.AreEqual(
                    locBuilder.GetLocationString(metadata.Features.All[0].Location),
                    addFirstLocation);
            }
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Misc feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Misc feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankMiscFeatureQualifiers()
        {
            ValidateGenBankMiscFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Misc feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Misc feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankMiscFeatureQualifiers()
        {
            ValidateGenBankMiscFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Exon feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Exon feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankExonFeatureQualifiers()
        {
            ValidateGenBankExonFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Exon feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Exon feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankExonFeatureQualifiers()
        {
            ValidateGenBankExonFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Intron feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Intron feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankIntronFeatureQualifiers()
        {
            ValidateGenBankIntronFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Intron feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Intron feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankIntronFeatureQualifiers()
        {
            ValidateGenBankIntronFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Promoter feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Promoter feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankPromoterFeatureQualifiers()
        {
            ValidateGenBankPromoterFeatureQualifiers(
                Constants.DNAStandardFeaturesKeyNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Promoter feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Promoter feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankPromoterFeatureQualifiers()
        {
            ValidateGenBankPromoterFeatureQualifiers(
                Constants.MediumSizeRNAGenBankFeaturesNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Variation feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Variation feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankVariationFeatureQualifiers()
        {
            ValidateGenBankVariationFeatureQualifiers(
                Constants.DNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Variation feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Variation feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankVariationFeatureQualifiers()
        {
            ValidateGenBankVariationFeatureQualifiers(
                Constants.RNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate GenBank Variation feature qualifiers
        ///     Input : Protein medium size Sequence
        ///     Output : Validation of GenBank Variation feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankVariationFeatureQualifiers()
        {
            ValidateGenBankVariationFeatureQualifiers(
                Constants.ProteinGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Misc Difference feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Misc Difference feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankMiscDiffFeatureQualifiers()
        {
            ValidateGenBankMiscDiffFeatureQualifiers(
                Constants.DNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Misc Difference feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Misc Difference feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankMiscDiffFeatureQualifiers()
        {
            ValidateGenBankMiscDiffFeatureQualifiers(
                Constants.RNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate GenBank Misc Difference feature qualifiers
        ///     Input : Protein medium size Sequence
        ///     Output : Validation of GenBank Misc Difference feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankMiscDiffFeatureQualifiers()
        {
            ValidateGenBankMiscDiffFeatureQualifiers(
                Constants.ProteinGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid DNA GenBank file.
        ///     and validate GenBank Protein Binding feature qualifiers
        ///     Input : DNA medium size Sequence
        ///     Output : Validation of GenBank Protein Binding feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankProteinBindingFeatureQualifiers()
        {
            ValidateGenBankProteinBindingFeatureQualifiers(
                Constants.DNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size RNA GenBank file.
        ///     and validate GenBank Protein Binding feature qualifiers
        ///     Input : RNA medium size Sequence
        ///     Output : Validation of GenBank Protein Binding feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankProteinBindingFeatureQualifiers()
        {
            ValidateGenBankProteinBindingFeatureQualifiers(
                Constants.RNAGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid medium size Protein GenBank file.
        ///     and validate GenBank Protein Binding feature qualifiers
        ///     Input : Protein medium size Sequence
        ///     Output : Validation of GenBank Protein Binding feature qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankProteinBindingFeatureQualifiers()
        {
            ValidateGenBankProteinBindingFeatureQualifiers(
                Constants.ProteinGenBankVariationNode);
        }

        /// <summary>
        ///     Parse a valid Dna GenBank file.
        ///     and validate GenBank Exon feature clonning.
        ///     Input : Dna medium size Sequence
        ///     Output : validate GenBank Exon feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankExonFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.DNAStandardFeaturesKeyNode,
                                            FeatureGroup.Exon);
        }

        /// <summary>
        ///     Parse a valid Rna GenBank file.
        ///     and validate GenBank Exon feature clonning.
        ///     Input : Rna medium size Sequence
        ///     Output : validate GenBank Exon feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankExonFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.MediumSizeRNAGenBankFeaturesNode,
                                            FeatureGroup.Exon);
        }

        /// <summary>
        ///     Parse a valid Protein GenBank file.
        ///     and validate GenBank Exon feature clonning.
        ///     Input : Protein medium size Sequence
        ///     Output : validate GenBank Exon feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankExonFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.ProteinGenBankVariationNode,
                                            FeatureGroup.Exon);
        }

        /// <summary>
        ///     Parse a valid Dna GenBank file.
        ///     and validate GenBank Misc Difference feature clonning.
        ///     Input : Dna Sequence
        ///     Output : validate GenBank Misc Difference feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankMiscDiffFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.DNAGenBankVariationNode,
                                            FeatureGroup.miscDifference);
        }

        /// <summary>
        ///     Parse a valid Rna GenBank file.
        ///     and validate GenBank Misc Difference feature clonning.
        ///     Input : Rna Sequence
        ///     Output : validate GenBank Misc Difference feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankMiscDiffFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.RNAGenBankVariationNode,
                                            FeatureGroup.miscDifference);
        }

        /// <summary>
        ///     Parse a valid Protein GenBank file.
        ///     and validate GenBank Misc Difference feature clonning.
        ///     Input : Protein Sequence
        ///     Output : Validate GenBank Misc Difference feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankMiscDiffFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.ProteinGenBankVariationNode,
                                            FeatureGroup.miscDifference);
        }

        /// <summary>
        ///     Parse a valid Dna GenBank file.
        ///     and validate GenBank Intron feature clonning.
        ///     Input : Dna Sequence
        ///     Output : validate GenBank Intron feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankIntronFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.DNAStandardFeaturesKeyNode,
                                            FeatureGroup.Intron);
        }

        /// <summary>
        ///     Parse a valid Rna GenBank file.
        ///     and validate GenBank Intron feature clonning.
        ///     Input : Rna Sequence
        ///     Output : validate GenBank Intron feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankIntronFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.MediumSizeRNAGenBankFeaturesNode,
                                            FeatureGroup.Intron);
        }

        /// <summary>
        ///     Parse a valid Protein GenBank file.
        ///     and validate GenBank Intron feature clonning.
        ///     Input : Protein Sequence
        ///     Output : Validate GenBank Intron feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankIntronFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.ProteinGenBankVariationNode,
                                            FeatureGroup.Intron);
        }

        /// <summary>
        ///     Parse a valid Dna GenBank file.
        ///     and validate GenBank Variation feature clonning.
        ///     Input : Dna Sequence
        ///     Output : validate GenBank Variation feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateDnaSequenceGenBankVariationFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.DNAGenBankVariationNode,
                                            FeatureGroup.variation);
        }

        /// <summary>
        ///     Parse a valid Rna GenBank file.
        ///     and validate GenBank Variation feature clonning.
        ///     Input : Rna Sequence
        ///     Output : validate GenBank Variation feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRnaSequenceGenBankVariationFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.RNAGenBankVariationNode,
                                            FeatureGroup.variation);
        }

        /// <summary>
        ///     Parse a valid Protein GenBank file.
        ///     and validate GenBank Variation feature clonning.
        ///     Input : Protein Sequence
        ///     Output : Validate GenBank Variation feature clonning.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateProteinSequenceGenBankVariationFeatureClonning()
        {
            ValidateGenBankFeaturesClonning(Constants.ProteinGenBankVariationNode,
                                            FeatureGroup.variation);
        }

        /// <summary>
        ///     Validate GenBank MaturePeptide feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank MaturePeptide feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMPeptideFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMPeptideQualifiersNode,
                Constants.FilePathNode).TestDir();
            string mPeptideCount = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMPeptideQualifiersNode,
                Constants.MiscPeptideCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMPeptideQualifiersNode,
                Constants.GeneSymbol);
            string mPeptideLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMPeptideQualifiersNode,
                Constants.Location);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            // Validate Minus35Signal feature all qualifiers.
            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
            List<MaturePeptide> mPeptideList = metadata.Features.MaturePeptides;

            // Create a clone and validate all qualifiers.
            MaturePeptide clonemPeptide = mPeptideList[0].Clone();
            ClassicAssert.AreEqual(mPeptideList.Count.ToString((IFormatProvider) null), mPeptideCount);
            ClassicAssert.AreEqual(clonemPeptide.GeneSymbol.ToString(null), geneSymbol);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(clonemPeptide.Allele.ToString(null)));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.Citation.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.Experiment.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.Function.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.GeneSynonym.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(clonemPeptide.GenomicMapPosition));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.Inference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(clonemPeptide.Label));
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.MaturePeptides[0].Location), mPeptideLocation);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(clonemPeptide.Note.ToString()));
            ClassicAssert.IsFalse(mPeptideList[0].Pseudo);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(mPeptideList[0].OldLocusTag.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(mPeptideList[0].EnzymeCommissionNumber.ToString(null)));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(mPeptideList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(mPeptideList[0].LocusTag.ToString()));

            // Log VSTest GUI.
            ApplicationLog.WriteLine("GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank Attenuator feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Attenuator feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankAttenuatorFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankAttenuatorQualifiers, Constants.FilePathNode).TestDir();
            string attenuatorLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankAttenuatorQualifiers, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankAttenuatorQualifiers, Constants.QualifierCount);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

            List<Attenuator> attenuatorList = metadata.Features.Attenuators;

            // Create a clone of attenuator feature.
            Attenuator attenuatorClone = attenuatorList[0].Clone();
            ClassicAssert.AreEqual(attenuatorList.Count.ToString((IFormatProvider) null), featureCount);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorList[0].GeneSymbol));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorClone.DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorClone.Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorClone.Experiment.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorList[0].GenomicMapPosition));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].GeneSynonym.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].Inference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorList[0].Label));
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.Attenuators[0].Location), attenuatorLocation);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].Note.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorList[0].Operon));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].OldLocusTag.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].Phenotype.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].LocusTag.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(attenuatorList[0].OldLocusTag.ToString()));

            // Create a new Attenuator and validate the same.
            var attenuator = new Attenuator(attenuatorLocation);
            var attenuatorWithILoc = new Attenuator(
                metadata.Features.Attenuators[0].Location);

            // Set qualifiers and validate them.
            attenuator.Allele = attenuatorLocation;
            attenuator.GeneSymbol = string.Empty;
            attenuatorWithILoc.GenomicMapPosition = string.Empty;
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuator.GeneSymbol));
            ClassicAssert.AreEqual(attenuator.Allele, attenuatorLocation);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(attenuatorWithILoc.GenomicMapPosition));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank Minus35Signal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Minus35Signal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMinus35SignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMinus35SignalNode, Constants.FilePathNode).TestDir();
            string minus35Location = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMinus35SignalNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMinus35SignalNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMinus35SignalNode, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Minus35Signal> minus35Signal = metadata.Features.Minus35Signals;

                // Create a clone of Minus35Signal feature feature.
                Minus35Signal cloneMinus35Signal = minus35Signal[0].Clone();
                ClassicAssert.AreEqual(minus35Signal.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMinus35Signal.GeneSymbol));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMinus35Signal.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus35Signal[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus35Signal[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus35Signal[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.Minus35Signals[0].Location), minus35Location);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].Note.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus35Signal[0].Operon));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].OldLocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus35Signal[0].StandardName));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus35Signal[0].LocusTag.ToString()));

                // Create a new Minus35Signal and validate the same.
                var minus35 = new Minus10Signal(minus35Location);
                var minus35WithILoc = new Minus10Signal(
                    metadata.Features.Minus35Signals[0].Location);

                // Set qualifiers and validate them.
                minus35.GeneSymbol = geneSymbol;
                minus35WithILoc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(minus35.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(minus35WithILoc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Minus10Signal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Minus10Signal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMinus10SignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMInus10SignalNode, Constants.FilePathNode).TestDir();
            string minus10Location = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMInus10SignalNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMInus10SignalNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMInus10SignalNode, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Minus10Signal> minus10Signal = metadata.Features.Minus10Signals;

                // Create a clone of Minus10Signalfeature feature.
                Minus10Signal cloneMinus10Signal = minus10Signal[0].Clone();
                ClassicAssert.AreEqual(minus10Signal.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMinus10Signal.GeneSymbol));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMinus10Signal.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus10Signal[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus10Signal[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus10Signal[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.Minus10Signals[0].Location), minus10Location);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].Note.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus10Signal[0].Operon));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].OldLocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(minus10Signal[0].StandardName));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(minus10Signal[0].LocusTag.ToString()));

                // Create a new Minus10Signal and validate the same.
                var minus10 = new Minus10Signal(minus10Location);
                var minus10WithILoc = new Minus10Signal(
                    metadata.Features.Minus10Signals[0].Location);

                // Set qualifiers and validate them.
                minus10.GeneSymbol = geneSymbol;
                minus10WithILoc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(minus10.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(minus10WithILoc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank PolyASignal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank PolyASignal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankPolyASignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankPolyASignalNode, Constants.FilePathNode).TestDir();
            string polyALocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankPolyASignalNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankPolyASignalNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankPolyASignalNode, Constants.GeneSymbol);

            // Parse a GenBank file.            
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<PolyASignal> polyASignalList = metadata.Features.PolyASignals;

                // Create a clone of PolyASignal feature feature.
                PolyASignal cloneMinus10Signal = polyASignalList[0].Clone();
                ClassicAssert.AreEqual(polyASignalList.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.AreEqual(cloneMinus10Signal.GeneSymbol, geneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMinus10Signal.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(polyASignalList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(polyASignalList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(polyASignalList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.PolyASignals[0].Location), polyALocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(polyASignalList[0].LocusTag.ToString()));

                // Create a new PolyA signal and validate the same.
                var polyASignal = new PolyASignal(polyALocation);
                var polyASignalWithILoc = new PolyASignal(
                    metadata.Features.Minus10Signals[0].Location);

                // Set qualifiers and validate them.
                polyASignal.GeneSymbol = geneSymbol;
                polyASignalWithILoc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(polyASignal.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(polyASignalWithILoc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Terminator feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Terminator feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankTerminatorFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankTerminatorNode, Constants.FilePathNode).TestDir();
            string terminatorLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankTerminatorNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankTerminatorNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankTerminatorNode, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Terminator> terminatorList = metadata.Features.Terminators;

                // Create a clone of Terminator feature feature.
                Terminator cloneTerminator = terminatorList[0].Clone();
                ClassicAssert.AreEqual(terminatorList.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.AreEqual(cloneTerminator.GeneSymbol, geneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneTerminator.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(terminatorList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(terminatorList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(terminatorList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.Terminators[0].Location), terminatorLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(terminatorList[0].LocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(terminatorList[0].StandardName));

                // Create a new Terminator signal and validate the same.
                var terminator = new Terminator(terminatorLocation);
                var terminatorWithILoc = new Terminator(
                    metadata.Features.Terminators[0].Location);

                // Set qualifiers and validate them.
                terminator.GeneSymbol = geneSymbol;
                terminatorWithILoc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(terminator.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(terminatorWithILoc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Misc Signal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Misc Signal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMiscSignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.FilePathNode).TestDir();
            string miscSignalLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.GeneSymbol);
            string function = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.FunctionNode);
            string dbReferenceNode = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankMiscSignalNode, Constants.DbReferenceNode);

            // Parse a GenBank file.            
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<MiscSignal> miscSignalList = metadata.Features.MiscSignals;

                // Create a clone of MiscSignal feature feature.
                MiscSignal cloneMiscSignal = miscSignalList[0].Clone();
                ClassicAssert.AreEqual(miscSignalList.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.AreEqual(cloneMiscSignal.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(cloneMiscSignal.DatabaseCrossReference[0], dbReferenceNode);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscSignalList[0].Allele.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscSignalList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscSignalList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.MiscSignals[0].Location), miscSignalLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscSignalList[0].LocusTag.ToString()));
                ClassicAssert.AreEqual(miscSignalList[0].Function[0], function);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscSignalList[0].Operon.ToString(null)));

                // Create a new MiscSignal signal and validate the same.
                var miscSignal = new MiscSignal(miscSignalLocation);
                var miscSignalWithIloc = new MiscSignal(
                    metadata.Features.MiscSignals[0].Location);

                // Set qualifiers and validate them.
                miscSignal.GeneSymbol = geneSymbol;
                miscSignalWithIloc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(miscSignal.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(miscSignalWithIloc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank DisplacementLoop feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank DisplacementLoop feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankDLoopFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankDLoopNode, Constants.FilePathNode).TestDir();
            string dLoopLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankDLoopNode, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankDLoopNode, Constants.QualifierCount);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankDLoopNode, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<DisplacementLoop> dLoopList = metadata.Features.DisplacementLoops;

                // Create a clone of DLoop feature feature.
                DisplacementLoop cloneDLoop = dLoopList[0].Clone();
                ClassicAssert.AreEqual(dLoopList.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.AreEqual(cloneDLoop.GeneSymbol, geneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneDLoop.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(dLoopList[0].Allele.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(dLoopList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(dLoopList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.DisplacementLoops[0].Location), dLoopLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].LocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(dLoopList[0].OldLocusTag.ToString()));

                // Create a new DLoop signal and validate the same.
                var dLoop = new DisplacementLoop(dLoopLocation);
                var dLoopWithIloc = new DisplacementLoop(
                    metadata.Features.DisplacementLoops[0].Location);

                // Set qualifiers and validate them.
                dLoop.GeneSymbol = geneSymbol;
                dLoopWithIloc.GeneSymbol = geneSymbol;
                ClassicAssert.AreEqual(dLoop.GeneSymbol, geneSymbol);
                ClassicAssert.AreEqual(dLoopWithIloc.GeneSymbol, geneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Intervening DNA feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Intervening feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankInterveningDNAFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankInterveningDNA, Constants.FilePathNode).TestDir();
            string iDNALocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankInterveningDNA, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankInterveningDNA, Constants.QualifierCount);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<InterveningDna> iDNAList = metadata.Features.InterveningDNAs;

                // Create a clone copy and validate.
                InterveningDna iDNAClone = iDNAList[0].Clone();
                ClassicAssert.AreEqual(iDNAList.Count.ToString((IFormatProvider) null), featureCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAClone.GeneSymbol.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAClone.DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAClone.Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].Experiment.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].GeneSynonym.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.InterveningDNAs[0].Location), iDNALocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].LocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(iDNAList[0].Function.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAList[0].Number));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(iDNAList[0].StandardName));

                // Create a new Intervening DNA signal and validate the same.
                var iDNA = new InterveningDna(iDNALocation);
                var iDNAWithIloc = new InterveningDna(
                    metadata.Features.DisplacementLoops[0].Location);

                // Set qualifiers and validate them.
                iDNA.GeneSymbol = iDNALocation;
                iDNAWithIloc.GeneSymbol = iDNALocation;
                ClassicAssert.AreEqual(iDNA.GeneSymbol, iDNALocation);
                ClassicAssert.AreEqual(iDNAWithIloc.GeneSymbol, iDNALocation);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Misc Recombination feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Misc Recombination feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMiscRecombinationFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRecombinationQualifiersNode,
                Constants.FilePathNode).TestDir();
            string miscCombinationCount = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRecombinationQualifiersNode,
                Constants.FeaturesCount);
            string miscCombinationLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRecombinationQualifiersNode,
                Constants.Location);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
            List<MiscRecombination> miscRecombinationList =
                metadata.Features.MiscRecombinations;

            ClassicAssert.AreEqual(miscRecombinationList.Count.ToString((IFormatProvider) null),
                            miscCombinationCount);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.MiscRecombinations[0].Location),
                            miscCombinationLocation);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRecombinationList[0].GeneSymbol));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRecombinationList[0].Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].Citation.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].Experiment.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].GeneSynonym.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRecombinationList[0].GenomicMapPosition));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].Inference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRecombinationList[0].Label));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].OldLocusTag.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRecombinationList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].LocusTag.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRecombinationList[0].OldLocusTag.ToString()));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank Misc RNA feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Misc RNA feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankMiscRNAFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRNAQualifiersNode,
                Constants.FilePathNode).TestDir();
            string miscRnaCount = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRNAQualifiersNode,
                Constants.FeaturesCount);
            string miscRnaLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.ProteinGenBankMiscRNAQualifiersNode,
                Constants.Location);

            // Parse a GenBank file.            
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            // Validate MiscRNA feature all qualifiers.
            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
            List<MiscRna> miscRnaList = metadata.Features.MiscRNAs;

            // Create a clone of MiscRNA feature and validate
            MiscRna cloneMiscRna = miscRnaList[0].Clone();
            ClassicAssert.AreEqual(miscRnaList.Count.ToString((IFormatProvider) null), miscRnaCount);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.MiscRNAs[0].Location), miscRnaLocation);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(cloneMiscRna.GeneSymbol));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMiscRna.DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRnaList[0].Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].Citation.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].Experiment.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].GeneSynonym.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRnaList[0].GenomicMapPosition));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRnaList[0].Label));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].OldLocusTag.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRnaList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].LocusTag.ToString()));
            ClassicAssert.IsFalse(miscRnaList[0].Pseudo);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(miscRnaList[0].Function.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscRnaList[0].Operon));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank Ribosomal RNA feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Ribosomal RNA feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankRibosomalRNAFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string rRnaCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FeaturesCount);
            string rRnaLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.Location);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            // Validate RibosomalRNA feature all qualifiers.
            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
            List<RibosomalRna> ribosomalRnaList =
                metadata.Features.RibosomalRNAs;

            ClassicAssert.AreEqual(ribosomalRnaList.Count.ToString((IFormatProvider) null), rRnaCount);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.RibosomalRNAs[0].Location), rRnaLocation);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(ribosomalRnaList[0].GeneSymbol));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(ribosomalRnaList[0].Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].Citation.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].Experiment.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].GeneSynonym.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(ribosomalRnaList[0].GenomicMapPosition));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(ribosomalRnaList[0].Label));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].OldLocusTag.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(ribosomalRnaList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].LocusTag.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(ribosomalRnaList[0].OldLocusTag.ToString()));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank Repeat Origin feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank Repeat Origin feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankRepeatOriginFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string rOriginCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.ROriginCount);
            string rOriginLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.ROriginLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
            var locBuilder = new LocationBuilder();

            // Validate Repeat Origin feature all qualifiers.
            var metadata =
                (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
            List<ReplicationOrigin> repeatOriginList =
                metadata.Features.ReplicationOrigins;

            ClassicAssert.AreEqual(repeatOriginList.Count.ToString((IFormatProvider) null), rOriginCount);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                metadata.Features.ReplicationOrigins[0].Location), rOriginLocation);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatOriginList[0].GeneSymbol));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].DatabaseCrossReference.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatOriginList[0].Allele));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].Citation.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].Experiment.ToString()));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].GeneSynonym.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatOriginList[0].GenomicMapPosition));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatOriginList[0].Label));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].OldLocusTag.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatOriginList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatOriginList[0].LocusTag.ToString()));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate GenBank CaatSignal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank CaatSignal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankCaatSignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string caatSignalCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.CaatSignalCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.CaatSignalGene);
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.CaatSignalLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate CaatSignal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<CaatSignal> caatSignalList = metadata.Features.CAATSignals;
                ClassicAssert.AreEqual(caatSignalList.Count.ToString((IFormatProvider) null), caatSignalCount);
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.CAATSignals[0].Location), expectedLocation);
                ClassicAssert.AreEqual(caatSignalList[0].GeneSymbol, expectedGeneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(caatSignalList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(caatSignalList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(caatSignalList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].LocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(caatSignalList[0].OldLocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank TataSignal feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank TataSignal feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankTataSignalFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string tataSignalCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.TataSignalCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.TataSignalGene);
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.TataSignalLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate TataSignal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<TataSignal> tataSignalList = metadata.Features.TATASignals;
                ClassicAssert.AreEqual(tataSignalList.Count.ToString((IFormatProvider) null), tataSignalCount);
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.TATASignals[0].Location), expectedLocation);
                ClassicAssert.AreEqual(tataSignalList[0].GeneSymbol, expectedGeneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tataSignalList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tataSignalList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tataSignalList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tataSignalList[0].LocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank 3'UTRs  feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank 3'UTRs feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankThreePrimeUTRsFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string threePrimeUTRCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.ThreePrimeUTRCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.ThreePrimeUTRGene);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate 3'UTRs feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<ThreePrimeUtr> threeprimeUTRsList =
                    metadata.Features.ThreePrimeUTRs;
                ClassicAssert.AreEqual(threeprimeUTRsList.Count.ToString((IFormatProvider) null), threePrimeUTRCount);
                ClassicAssert.AreEqual(threeprimeUTRsList[0].GeneSymbol, expectedGeneSymbol);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(threeprimeUTRsList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(threeprimeUTRsList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(threeprimeUTRsList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(threeprimeUTRsList[0].LocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank 5'UTRs  feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank 5'UTRs feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankFivePrimeUTRsFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FilePathNode).TestDir();
            string fivePrimeUTRCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.ThreePrimeUTRCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FivePrimeUTRGene);
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode, Constants.FivePrimeUTRLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate 5'UTRs feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<FivePrimeUtr> fivePrimeUTRsList =
                    metadata.Features.FivePrimeUTRs;
                ClassicAssert.AreEqual(fivePrimeUTRsList.Count.ToString((IFormatProvider) null), fivePrimeUTRCount);
                ClassicAssert.AreEqual(fivePrimeUTRsList[0].GeneSymbol, expectedGeneSymbol);
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.FivePrimeUTRs[0].Location), expectedLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(fivePrimeUTRsList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(fivePrimeUTRsList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(fivePrimeUTRsList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(fivePrimeUTRsList[0].LocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank SignalPeptide feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank SignalPeptide feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankSignalPeptideFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode,
                Constants.FilePathNode).TestDir();
            string signalPeptideCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode,
                Constants.ThreePrimeUTRCount);
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankrRNAQualifiersNode,
                Constants.SignalPeptideLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate SignalPeptide feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<SignalPeptide> signalPeptideQualifiersList =
                    metadata.Features.SignalPeptides;
                ClassicAssert.AreEqual(signalPeptideQualifiersList.Count.ToString((IFormatProvider) null),
                                signalPeptideCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(signalPeptideQualifiersList[0].GeneSymbol));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.SignalPeptides[0].Location),
                                expectedLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(signalPeptideQualifiersList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(signalPeptideQualifiersList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(signalPeptideQualifiersList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(signalPeptideQualifiersList[0].LocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank RepeatRegion feature Qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank RepeatRegion feature Qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankRepeatRegionFeatureQualifiers()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.FilePathNode).TestDir();
            string repeatRegionCount = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.ThreePrimeUTRCount);
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.RepeatRegionLocation);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate RepeatRegion feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<RepeatRegion> repeatRegionsList =
                    metadata.Features.RepeatRegions;
                ClassicAssert.AreEqual(repeatRegionsList.Count.ToString((IFormatProvider) null),
                                repeatRegionCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatRegionsList[0].GeneSymbol));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.RepeatRegions[0].Location),
                                expectedLocation);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].Note.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatRegionsList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatRegionsList[0].GenomicMapPosition));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(repeatRegionsList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(repeatRegionsList[0].LocusTag.ToString()));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Location resolver subsequence of Repeat region feature.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank feature sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankSubSequence()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.FilePathNode).TestDir();
            string expectedSubSequence = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.ExpectedFeatureSubSequence);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                ISequence sequence = parserObj.ParseOne(filePath);
                ILocationResolver locResolver = new LocationResolver();

                // Get repeatregion subsequence.
                var metadata =
                    (GenBankMetadata) sequence.Metadata[Constants.GenBank];
                ISequence subSeq = locResolver.GetSubSequence(
                    metadata.Features.RepeatRegions[0].Location, sequence);
                var sequenceString = new string(subSeq.Select(a => (char) a).ToArray());

                // Validate repeat region subsequence.
                ClassicAssert.AreEqual(sequenceString, expectedSubSequence);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank subSequence");
            }
        }

        /// <summary>
        ///     Validate GenBank IsInStart,IsInEnd and IsInRange
        ///     methods of location resolver.
        ///     Input : GenBank file.
        ///     Output : Validation of GenBank feature sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankLocationStartAndEndRange()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.GenBankRepeatRegionQualifiersNode,
                Constants.FilePathNode).TestDir();
            bool startLocResult = false;
            bool endLocResult = false;
            bool rangeLocResult = false;

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                ISequence sequence = parserObj.ParseOne(filePath);
                ILocationResolver locResolver = new LocationResolver();

                // Validate Start,End and Range of Gene feature location.
                var metadata =
                    (GenBankMetadata) sequence.Metadata[Constants.GenBank];
                startLocResult =
                    locResolver.IsInStart(metadata.Features.Genes[0].Location, 289);
                endLocResult =
                    locResolver.IsInEnd(metadata.Features.Genes[0].Location, 1647);
                rangeLocResult =
                    locResolver.IsInRange(metadata.Features.Genes[0].Location, 300);

                ClassicAssert.IsTrue(startLocResult);
                ClassicAssert.IsTrue(endLocResult);
                ClassicAssert.IsTrue(rangeLocResult);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the location resolver Gene feature start End and IsInRange methods");
            }
        }

        /// <summary>
        ///     Validate LocationRange creation.
        ///     Input : GenBank file.
        ///     Output : Validation of created location range.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateLocationRangeWithAccession()
        {
            // Get Values from XML node.
            string acessionNumber = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationRangesNode, Constants.Accession);
            string startLoc = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationRangesNode, Constants.LoocationStartNode);
            string endLoc = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationRangesNode, Constants.LoocationEndNode);

            // Create a Location Range.
            var locRangeObj = new LocationRange(acessionNumber,
                                                Convert.ToInt32(startLoc, null), Convert.ToInt32(endLoc, null));

            // Validate created location Range.
            ClassicAssert.AreEqual(acessionNumber, locRangeObj.Accession.ToString(null));
            ClassicAssert.AreEqual(startLoc, locRangeObj.StartPosition.ToString((IFormatProvider) null));
            ClassicAssert.AreEqual(endLoc, locRangeObj.EndPosition.ToString((IFormatProvider) null));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the creation of location range");
        }

        /// <summary>
        ///     Validate LocationRange creation with empty accession ID.
        ///     Input : GenBank file.
        ///     Output : Validation of created location range.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateLocationRanges()
        {
            // Get Values from XML node.
            string startLoc = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationRangesNode, Constants.LoocationStartNode);
            string endLoc = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationRangesNode, Constants.LoocationEndNode);

            // Create a Location Range.
            var locRangeObj = new LocationRange(Convert.ToInt32(startLoc, null),
                                                Convert.ToInt32(endLoc, null));

            // Validate created location Range.
            ClassicAssert.AreEqual(startLoc, locRangeObj.StartPosition.ToString((IFormatProvider) null));
            ClassicAssert.AreEqual(endLoc, locRangeObj.EndPosition.ToString((IFormatProvider) null));

            // Log VSTest GUI.
            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the creation of location range");
        }

        /// <summary>
        ///     Validate Misc Structure qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Misc Structure qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMiscStructureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankMiscStructureNode, FeatureGroup.MiscStructure);
        }

        /// <summary>
        ///     Validate GenBank RibosomeBindingSite qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of RibosomeBindingSite qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateRibosomeBindingSiteQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankRibosomeSiteBindingNode, FeatureGroup.RibosomeBindingSite);
        }

        /// <summary>
        ///     Validate TransitPeptide feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of TransitPeptide qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateTransitPeptideQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankTransitPeptideNode, FeatureGroup.TrnsitPeptide);
        }

        /// <summary>
        ///     Validate Stem Loop feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Stem Loop qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateStemLoopQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankStemLoopNode, FeatureGroup.StemLoop);
        }

        /// <summary>
        ///     Validate Modified base feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Modified base qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateModifiedBaseQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankModifiedBaseNode, FeatureGroup.ModifiedBase);
        }

        /// <summary>
        ///     Validate Precursor RNA feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Precursor RNA qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidatePrecursorRNAQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankPrecursorRNANode, FeatureGroup.PrecursorRNA);
        }

        /// <summary>
        ///     Validate Poly Site feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Poly Site qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidatePolySiteQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankPolySiteNode, FeatureGroup.PolySite);
        }

        /// <summary>
        ///     Validate Misc Binding feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Misc Binding qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateMiscBindingQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankMiscBindingNode,
                FeatureGroup.MiscBinding);
        }

        /// <summary>
        ///     Validate Enhancer feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Enhancer qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateEnhancerQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankEnhancerNode, FeatureGroup.Enhancer);
        }

        /// <summary>
        ///     Validate GC_Signal feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of GC_Signal qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGCSignalQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankGCSignalNode, FeatureGroup.GCSignal);
        }

        /// <summary>
        ///     Validate Long Terminal Repeat feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Long Terminal Repeat qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateLTRFeatureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankLongTerminalRepeatNode, FeatureGroup.LTR);
        }

        /// <summary>
        ///     Validate Operon region feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Operon region qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateOperonFeatureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankOperonFeatureNode, FeatureGroup.Operon);
        }

        /// <summary>
        ///     Validate Unsure Sequence region feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of Unsure Sequence region qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateUnsureSeqRegionFeatureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankUnsureSequenceRegionNode,
                FeatureGroup.UnsureSequenceRegion);
        }

        /// <summary>
        ///     Validate NonCoding RNA feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of NonCoding RNA qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateNonCodingRNAFeatureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankNonCodingRNANode,
                FeatureGroup.NonCodingRNA);
        }

        /// <summary>
        ///     Validate CDS feature qualifiers.
        ///     Input : GenBank file.
        ///     Output : Validation of CDS qualifiers.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCDSFeatureQualifiers()
        {
            ValidateGeneralGenBankFeatureQualifiers(
                Constants.GenBankCDSNode, FeatureGroup.CDS);
        }

        /// <summary>
        ///     Validate Standard Feature qualifier names.
        ///     Input : GenBank file.
        ///     Output : Validation of Standard Qaulifier names.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateStandardQualifierNames()
        {
            // Get Values from XML node.
            string expectedAlleleQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.StandardQualifierNamesNode, Constants.AlleleQualifier);
            string expectedGeneSymbolQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.StandardQualifierNamesNode, Constants.GeneQualifier);
            string expectedDbReferenceQualifier = utilityObj.xmlUtil.GetTextValue(
                Constants.StandardQualifierNamesNode, Constants.DBReferenceQualifier);
            string allQualifiersCount = utilityObj.xmlUtil.GetTextValue(
                Constants.StandardQualifierNamesNode, Constants.QualifierCount);

            // Validate GenBank feature standard qualifier names.
            ClassicAssert.AreEqual(StandardQualifierNames.Allele,
                            expectedAlleleQualifier);
            ClassicAssert.AreEqual(StandardQualifierNames.GeneSymbol,
                            expectedGeneSymbolQualifier);
            ClassicAssert.AreEqual(StandardQualifierNames.DatabaseCrossReference,
                            expectedDbReferenceQualifier);
            ClassicAssert.AreEqual(StandardQualifierNames.All.Count.ToString((IFormatProvider) null),
                            allQualifiersCount);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     compliment operator.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithComplimentOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithComplementOperator,
                FeatureOperator.Complement, true);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     join operator.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithJoinOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithJoinOperatorNode,
                FeatureOperator.Join, true);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     order operator.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithOrderOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithJoinOperatorNode,
                FeatureOperator.Order, true);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     dot operator.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithDotOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithDotOperatorNode,
                FeatureOperator.Complement, false);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     compliment operator with sub location.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithSubLocationComplimentOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithOutComplementOperatorNode,
                FeatureOperator.Complement, false);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     join operator with sub location.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithSubLocationJoinOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithOutJoinOperatorNode,
                FeatureOperator.Join, false);
        }

        /// <summary>
        ///     Validate subsequence from GenBank sequence with location using
        ///     order operator with sub location.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of expected sub sequence.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateSubSequenceWithSubLocationOrderOperator()
        {
            ValidateGenBankLocationResolver(
                Constants.LocationWithOutOrderOperatorNode,
                FeatureOperator.Order, false);
        }

        /// <summary>
        ///     Validate GenBank location EndData.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of location end data.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankLocationEndData()
        {
            ValidateLocationEndData(Constants.LocationWithEndDataNode);
        }

        /// <summary>
        ///     Validate GenBank location EndData with "^" operator.
        ///     Input : GenBank sequence,location.
        ///     Output : Validation of location end data.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankLocationEndDataWithOperator()
        {
            ValidateLocationEndData(Constants.LocationWithEndDataUsingOperatorNode);
        }

        /// <summary>
        ///     Validate compare GenBank locations.
        ///     Input : Two instances of GenBank locations.
        ///     Output : Validate compare two instance of the locations object.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateCompareGenBankLocationsObject()
        {
            // Get Values from XML node.
            string locationFirstInput = utilityObj.xmlUtil.GetTextValue(
                Constants.CompareLocationsNode, Constants.Location1Node);
            string locationSecondInput = utilityObj.xmlUtil.GetTextValue(
                Constants.CompareLocationsNode, Constants.Location2Node);
            string locationThirdInput = utilityObj.xmlUtil.GetTextValue(
                Constants.CompareLocationsNode, Constants.Location3Node);

            // Create two location instance.
            ILocationBuilder locBuilder = new LocationBuilder();
            ILocation loc1 = locBuilder.GetLocation(locationFirstInput);
            object loc2 = locBuilder.GetLocation(locationSecondInput);
            object loc3 = locBuilder.GetLocation(locationThirdInput);

            // Compare first and second location instances.
            ClassicAssert.AreEqual(0, loc1.CompareTo(loc2));

            // Compare first and third location which are not identical.
            ClassicAssert.AreEqual(-1, loc1.CompareTo(loc3));

            // Compare first and null location.
            ClassicAssert.AreEqual(1, loc1.CompareTo(null));

            ApplicationLog.WriteLine(
                "GenBank Features P1: Successfully validated the GenBank Features");
        }

        /// <summary>
        ///     Validate leaf location of GenBank locations.
        ///     Input : GenBank File
        ///     Output : Validation of GenBank leaf locations.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankLeafLocations()
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                Constants.RNAGenBankFeaturesNode, Constants.FilePathNode).TestDir();
            string expectedLeafLocation = utilityObj.xmlUtil.GetTextValue(
                Constants.RNAGenBankFeaturesNode,
                Constants.LeafLocationCountNode);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];

                List<CodingSequence> cdsList = metadata.Features.CodingSequences;

                ILocation newLoc = cdsList[0].Location;
                List<ILocation> leafsList = newLoc.GetLeafLocations();

                ClassicAssert.AreEqual(expectedLeafLocation, leafsList.Count.ToString((IFormatProvider) null));
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank locations positions.
        ///     Input : GenBank File
        ///     Output : Validation of GenBank location positions.
        /// </summary>
        [Test]
        [Category("Priority1")]
        public void ValidateGenBankLocationPositions()
        {
            // Get Values from XML node.
            string location = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationWithEndDataUsingOperatorNode,
                Constants.Location);
            string expectedEndData = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationWithEndDataUsingOperatorNode,
                Constants.EndData);
            string expectedStartData = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationWithEndDataUsingOperatorNode,
                Constants.StartData);
            string position = utilityObj.xmlUtil.GetTextValue(
                Constants.LocationWithEndDataUsingOperatorNode,
                Constants.Position);

            bool result = false;

            // Build a location.
            var locResolver = new LocationResolver();
            ILocationBuilder locBuilder = new LocationBuilder();

            var loc = (Location) locBuilder.GetLocation(location);
            loc.EndData = expectedEndData;
            loc.StartData = expectedStartData;

            // Validate whether mentioned end data is present in the location
            // or not.
            result = locResolver.IsInEnd(loc, Int32.Parse(position, null));
            ClassicAssert.IsTrue(result);

            // Validate whether mentioned start data is present in the location
            // or not.
            result = locResolver.IsInStart(loc, Int32.Parse(position, null));
            ClassicAssert.IsTrue(result);

            // Validate whether mentioned data is present in the location
            // or not.
            result = locResolver.IsInRange(loc, Int32.Parse(position, null));
            ClassicAssert.IsTrue(result);

            // Log to VSTest GUI.
            ApplicationLog.WriteLine(string.Format(null,
                                                   "GenBankFeatures P1 : Expected sequence is verified"));
        }

        #endregion GenBank P1 TestCases

        #region Supporting Methods

        /// <summary>
        ///     Validate GenBank Gene features.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankGeneFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string GenesCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneCount);
            string GenesDBCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCodonStart);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneFeatureGeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Minus35Signal feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Gene> genesList = metadata.Features.Genes;
                ClassicAssert.AreEqual(genesList.Count.ToString((IFormatProvider) null), GenesCount);
                ClassicAssert.AreEqual(genesList[0].GeneSymbol.ToString(null),
                                geneSymbol);
                ClassicAssert.AreEqual(genesList[0].DatabaseCrossReference.Count,
                                Convert.ToInt32(GenesDBCount, null));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(genesList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(genesList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(genesList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Note.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(genesList[0].Operon.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Phenotype.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(genesList[0].Product.ToString()));
                ClassicAssert.IsFalse(genesList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(genesList[0].StandardName));
                ClassicAssert.IsFalse(genesList[0].TransSplicing);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank tRNA features.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBanktRNAFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string tRNAsCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.tRNACount);
            string tRNAGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.TRNAGeneSymbol);
            string tRNAComplement = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.TRNAComplement);
            string tRNADBCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCodonStart);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<TransferRna> tRANsList =
                    metadata.Features.TransferRNAs;
                ClassicAssert.AreEqual(tRANsList.Count.ToString((IFormatProvider) null),
                                tRNAsCount);
                ClassicAssert.AreEqual(tRANsList[0].GeneSymbol.ToString(null),
                                tRNAGeneSymbol);
                ClassicAssert.AreEqual(tRANsList[0].DatabaseCrossReference.Count,
                                Convert.ToInt32(tRNADBCount, null));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tRANsList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tRANsList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tRANsList[0].Label));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.TransferRNAs[0].Location),
                                tRNAComplement);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].Note.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(tRANsList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(tRANsList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(tRANsList[0].StandardName));
                ClassicAssert.IsFalse(tRANsList[0].TransSplicing);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank mRNA features.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankmRNAFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string mRNAGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.MRNAGeneSymbol);
            string mRNAComplement = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.MRNAComplement);
            string mRNADBCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCodonStart);
            string mRNAStart = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.MRNAComplementStart);
            string mRNAStdName = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.StandardNameNode);
            string mRNAAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCodonStart);
            string mRNAOperon = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate tRNA feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<MessengerRna> mRANsList =
                    metadata.Features.MessengerRNAs;

                // Create a copy of mRNA list
                MessengerRna mRNAClone = mRANsList[0].Clone();
                ClassicAssert.AreEqual(mRANsList[0].GeneSymbol.ToString(null),
                                mRNAGeneSymbol);
                ClassicAssert.AreEqual(mRANsList[0].DatabaseCrossReference.Count,
                                Convert.ToInt32(mRNADBCount, null));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRNAClone.Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRANsList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRANsList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].LocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRANsList[0].Operon.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Product.ToString()));
                ClassicAssert.AreEqual(mRANsList[0].Location.Operator.ToString(),
                                mRNAComplement);
                ClassicAssert.IsNull(mRANsList[0].Location.Separator);
                ClassicAssert.AreEqual(mRANsList[0].Location.LocationStart,
                                Convert.ToInt32(mRNAStart, null));
                ClassicAssert.IsNull(mRANsList[0].Location.StartData);
                ClassicAssert.IsNull(mRANsList[0].Location.EndData);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(mRANsList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRANsList[0].StandardName));
                ClassicAssert.IsFalse(mRANsList[0].TransSplicing);
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].LocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(mRANsList[0].Operon.ToString(null)));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(mRANsList[0].Product.ToString()));

                // Create a new mRNA feature using constructor.
                var mRNA = new MessengerRna(
                    metadata.Features.MessengerRNAs[0].Location);

                // Set and validate qualifiers.
                mRNA.GeneSymbol = mRNAGeneSymbol;
                mRNA.Allele = mRNAAllele;
                mRNA.Operon = mRNAOperon;
                mRNA.StandardName = mRNAStdName;

                // Validate properties.
                ClassicAssert.AreEqual(mRNA.GeneSymbol, mRNAGeneSymbol);
                ClassicAssert.AreEqual(mRNA.Allele, mRNAAllele);
                ClassicAssert.AreEqual(mRNA.Operon, mRNAOperon);
                ClassicAssert.AreEqual(mRNA.StandardName, mRNAStdName);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank features for medium size sequences.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        /// <param name="methodName">DNA,RNA or Protein method</param>
        private void ValidateGenBankFeatures(string nodeName, string methodName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string mRNAFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.mRNACount);
            string exonFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonCount);
            string intronFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronCount);
            string cdsFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCount);
            string allFeaturesCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenBankFeaturesCount);
            string expectedCDSKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSKey);
            string expectedIntronKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronKey);
            string expectedExonKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonKey);
            string mRNAKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.mRNAKey);
            string sourceKeyName = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.SourceKey);

            // Parse a file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> sequenceList = parserObj.Parse(filePath);

                // GenBank metadata.
                var metadata = new GenBankMetadata();
                if (1 == sequenceList.Count())
                {
                    metadata =
                        sequenceList.ElementAt(0).Metadata[Constants.GenBank] as GenBankMetadata;
                }
                else
                {
                    metadata =
                        sequenceList.ElementAt(1).Metadata[Constants.GenBank] as GenBankMetadata;
                }

                // Validate GenBank Features.
                ClassicAssert.AreEqual(metadata.Features.All.Count,
                                Convert.ToInt32(allFeaturesCount, null));
                ClassicAssert.AreEqual(metadata.Features.CodingSequences.Count,
                                Convert.ToInt32(cdsFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Exons.Count,
                                Convert.ToInt32(exonFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Introns.Count,
                                Convert.ToInt32(intronFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.MessengerRNAs.Count,
                                Convert.ToInt32(mRNAFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Attenuators.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.CAATSignals.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.DisplacementLoops.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.Enhancers.Count, 0);

                // Validate GenBank feature list.
                if ((0 == string.Compare(methodName, "DNA",
                                         CultureInfo.CurrentCulture, CompareOptions.IgnoreCase))
                    || (0 == string.Compare(methodName, "RNA",
                                            CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)))
                {
                    IList<FeatureItem> featureList = metadata.Features.All;
                    ClassicAssert.AreEqual(featureList[0].Key.ToString(null), sourceKeyName);
                    ClassicAssert.AreEqual(featureList[1].Key.ToString(null), expectedCDSKey);
                    ClassicAssert.AreEqual(featureList[2].Key.ToString(null), expectedCDSKey);
                    ClassicAssert.AreEqual(featureList[10].Key.ToString(null), mRNAKey);
                    ClassicAssert.AreEqual(featureList[12].Key.ToString(null), expectedExonKey);
                    ClassicAssert.AreEqual(featureList[18].Key.ToString(null), expectedIntronKey);
                    ApplicationLog.WriteLine(
                        "GenBank Features P1: Successfully validated the GenBank Features");
                }
                else if ((0 == string.Compare(methodName, "Protein", CultureInfo.CurrentCulture,
                                              CompareOptions.IgnoreCase)))
                {
                    IList<FeatureItem> featureList = metadata.Features.All;
                    ClassicAssert.AreEqual(featureList[10].Key.ToString(null), expectedIntronKey);
                    ClassicAssert.AreEqual(featureList[18].Key.ToString(null), expectedExonKey);
                    ApplicationLog.WriteLine(
                        "GenBank Features P1: Successfully validated the GenBank Features");
                }
            }
        }

        /// <summary>
        ///     Validate GenBank features for medium size sequences.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateCloneGenBankFeatures(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string mRNAFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.mRNACount);
            string exonFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonCount);
            string intronFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronCount);
            string cdsFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCount);
            string allFeaturesCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenBankFeaturesCount);

            // Parse a file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> sequenceList = parserObj.Parse(filePath);

                var metadata =
                    sequenceList.ElementAt(0).Metadata[Constants.GenBank] as GenBankMetadata;

                // Validate GenBank Features before Cloning.
                ClassicAssert.AreEqual(metadata.Features.All.Count,
                                Convert.ToInt32(allFeaturesCount, null));
                ClassicAssert.AreEqual(metadata.Features.CodingSequences.Count,
                                Convert.ToInt32(cdsFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Exons.Count,
                                Convert.ToInt32(exonFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Introns.Count,
                                Convert.ToInt32(intronFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.MessengerRNAs.Count,
                                Convert.ToInt32(mRNAFeatureCount, null));
                ClassicAssert.AreEqual(metadata.Features.Attenuators.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.CAATSignals.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.DisplacementLoops.Count, 0);
                ClassicAssert.AreEqual(metadata.Features.Enhancers.Count, 0);

                // Clone GenBank Features.
                GenBankMetadata CloneGenBankMetadat = metadata.Clone();

                // Validate cloned GenBank Metadata.
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.All.Count,
                                Convert.ToInt32(allFeaturesCount, null));
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.CodingSequences.Count,
                                Convert.ToInt32(cdsFeatureCount, null));
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.Exons.Count,
                                Convert.ToInt32(exonFeatureCount, null));
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.Introns.Count,
                                Convert.ToInt32(intronFeatureCount, null));
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.MessengerRNAs.Count,
                                Convert.ToInt32(mRNAFeatureCount, null));
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.Attenuators.Count, 0);
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.CAATSignals.Count, 0);
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.DisplacementLoops.Count, 0);
                ClassicAssert.AreEqual(CloneGenBankMetadat.Features.Enhancers.Count, 0);
            }
        }

        /// <summary>
        ///     Validate GenBank standard features key for medium size sequences..
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        /// <param name="methodName">DNA,RNA or Protein method</param>
        private void ValidateGenBankStandardFeatures(string nodeName,
                                                     string methodName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedCondingSeqCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSCount);
            string expectedCDSKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSKey);
            string expectedIntronKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronKey);
            string mRNAKey = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.mRNAKey);
            string allFeaturesCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.StandardFeaturesCount);

            // Parse a file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seq = parserObj.Parse(filePath);

                var metadata =
                    seq.ElementAt(0).Metadata[Constants.GenBank] as GenBankMetadata;

                if ((0 == string.Compare(methodName, "DNA",
                                         CultureInfo.CurrentCulture, CompareOptions.IgnoreCase))
                    || (0 == string.Compare(methodName, "RNA",
                                            CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)))
                {
                    ClassicAssert.AreEqual(StandardFeatureKeys.CodingSequence.ToString(null),
                                    expectedCDSKey);
                    ClassicAssert.AreEqual(StandardFeatureKeys.Intron.ToString(null),
                                    expectedIntronKey);
                    ClassicAssert.AreEqual(StandardFeatureKeys.MessengerRna.ToString(null),
                                    mRNAKey);
                    ClassicAssert.AreEqual(StandardFeatureKeys.All.Count.ToString((IFormatProvider) null),
                                    allFeaturesCount);
                }
                else
                {
                    ClassicAssert.AreEqual(metadata.Features.CodingSequences.Count.ToString((IFormatProvider) null),
                                    expectedCondingSeqCount);
                    ClassicAssert.AreEqual(StandardFeatureKeys.CodingSequence.ToString(null),
                                    expectedCDSKey);
                    ClassicAssert.AreEqual(StandardFeatureKeys.All.Count.ToString((IFormatProvider) null),
                                    allFeaturesCount);
                }
            }
        }


        /// <summary>
        ///     Validate GenBank features with specified range.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGetFeatures(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedFirstRangeStartPoint = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FirstRangeStartPoint);
            string expectedSecondRangeStartPoint = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.SecondRangeStartPoint);
            string expectedFirstRangeEndPoint = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FirstRangeEndPoint);
            string expectedSecondRangeEndPoint = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.SecondRangeEndPoint);
            string expectedCountWithinSecondRange = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.SecondRangeCount);
            string expectedCountWithinFirstRange = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FirstRangeCount);
            string expectedQualifierName = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CDSKey);
            string expectedQualifiers = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifiersCount);
            string firstFeaturesCount = string.Empty;
            string secodFeaturesCount = string.Empty;

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                ISequence seq = parserObj.ParseOne(filePath);
                var metadata = seq.Metadata[Constants.GenBank] as GenBankMetadata;

                // Validate GetFeature within specified range.
                List<FeatureItem> features =
                    metadata.GetFeatures(Convert.ToInt32(
                        expectedFirstRangeStartPoint, null), Convert.ToInt32(
                            expectedFirstRangeEndPoint, null));

                firstFeaturesCount = metadata.GetFeatures(Convert.ToInt32(
                    expectedFirstRangeStartPoint, null), Convert.ToInt32(
                        expectedFirstRangeEndPoint, null)).Count.ToString((IFormatProvider) null);
                secodFeaturesCount = metadata.GetFeatures(Convert.ToInt32(
                    expectedSecondRangeStartPoint, null), Convert.ToInt32(
                        expectedSecondRangeEndPoint, null)).Count.ToString((IFormatProvider) null);

                // Validate GenBank features count within specified range.
                ClassicAssert.AreEqual(firstFeaturesCount, expectedCountWithinFirstRange);
                ClassicAssert.AreEqual(secodFeaturesCount, expectedCountWithinSecondRange);
                ClassicAssert.AreEqual(features.Count.ToString((IFormatProvider) null), firstFeaturesCount);
                ClassicAssert.AreEqual(features[1].Qualifiers.Count.ToString((IFormatProvider) null),
                                expectedQualifiers);
                ClassicAssert.AreEqual(features[1].Key.ToString(null), expectedQualifierName);
            }
        }

        /// <summary>
        ///     Validate GenBank Citation referenced present in GenBank Metadata.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        /// <param name="featureName">Feature Name</param>
        private void ValidateCitationReferenced(string nodeName,
                                                FeatureGroup featureName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedCitationReferenced = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.citationReferencedCount);
            string expectedmRNACitationReferenced = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.citationReferencedCount);
            string expectedExonACitationReferenced = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonCitationReferencedCount);
            string expectedIntronCitationReferenced = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronCitationReferencedCount);
            string expectedpromoterCitationReferenced = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.PromotersCitationReferencedCount);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                ISequence seq = parserObj.ParseOne(filePath);

                var metadata =
                    seq.Metadata[Constants.GenBank] as GenBankMetadata;

                List<CitationReference> citationReferenceList;

                // Get a list citationReferenced present in GenBank file.
                switch (featureName)
                {
                    case FeatureGroup.CDS:
                        FeatureItem cds =
                            metadata.Features.CodingSequences[0];
                        citationReferenceList =
                            metadata.GetCitationsReferredInFeature(cds);

                        // Validate citation referenced present in CDS features.
                        ClassicAssert.AreEqual(citationReferenceList.Count.ToString((IFormatProvider) null),
                                        expectedCitationReferenced);
                        break;
                    case FeatureGroup.mRNA:
                        FeatureItem mRNA = metadata.Features.MessengerRNAs[0];
                        citationReferenceList = metadata.GetCitationsReferredInFeature(mRNA);

                        // Validate citation referenced present in mRNA features.
                        ClassicAssert.AreEqual(citationReferenceList.Count.ToString((IFormatProvider) null),
                                        expectedmRNACitationReferenced);
                        break;
                    case FeatureGroup.Exon:
                        FeatureItem exon = metadata.Features.Exons[0];
                        citationReferenceList =
                            metadata.GetCitationsReferredInFeature(exon);

                        // Validate citation referenced present in Exons features.
                        ClassicAssert.AreEqual(citationReferenceList.Count.ToString((IFormatProvider) null),
                                        expectedExonACitationReferenced);
                        break;
                    case FeatureGroup.Intron:
                        FeatureItem introns = metadata.Features.Introns[0];
                        citationReferenceList =
                            metadata.GetCitationsReferredInFeature(introns);

                        // Validate citation referenced present in Introns features.
                        ClassicAssert.AreEqual(citationReferenceList.Count.ToString((IFormatProvider) null),
                                        expectedIntronCitationReferenced);
                        break;
                    case FeatureGroup.Promoter:
                        FeatureItem promoter = metadata.Features.Promoters[0];
                        citationReferenceList =
                            metadata.GetCitationsReferredInFeature(promoter);

                        // Validate citation referenced present in Promoters features.
                        ClassicAssert.AreEqual(citationReferenceList.Count.ToString((IFormatProvider) null),
                                        expectedpromoterCitationReferenced);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///     Validate GenBank miscFeatures features.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankMiscFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string miscFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.MiscFeatureCount);
            string location = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Misc feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<MiscFeature> miscFeatureList = metadata.Features.MiscFeatures;
                var locBuilder = new LocationBuilder();

                // Create copy of misc feature and validate all qualifiers
                MiscFeature cloneMiscFeatureList =
                    miscFeatureList[0].Clone();
                ClassicAssert.AreEqual(miscFeatureList.Count.ToString((IFormatProvider) null),
                                miscFeatureCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(cloneMiscFeatureList.Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMiscFeatureList.Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMiscFeatureList.Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMiscFeatureList.Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(miscFeatureList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscFeatureList[0].StandardName));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscFeatureList[0].Product.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscFeatureList[0].Number));
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.MiscFeatures[0].Location), location);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Exon feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankExonFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedExonFeatureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonCount);
            string expectedExonGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonGeneSymbol);
            string expectedExonNumber = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExonNumber);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Misc feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Exon> exonFeatureList = metadata.Features.Exons;
                ClassicAssert.AreEqual(exonFeatureList.Count.ToString((IFormatProvider) null),
                                expectedExonFeatureCount);
                ClassicAssert.AreEqual(exonFeatureList[0].GeneSymbol,
                                expectedExonGeneSymbol);
                ClassicAssert.AreEqual(exonFeatureList[0].Number,
                                expectedExonNumber);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(exonFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(exonFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(exonFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(exonFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(exonFeatureList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(exonFeatureList[0].StandardName));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Intron feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankIntronFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedIntronGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronGeneSymbol);
            string expectedIntronComplement = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronComplement);
            string expectedIntronNumber = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.IntronNumber);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Misc feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Intron> intronFeatureList =
                    metadata.Features.Introns;
                ClassicAssert.AreEqual(intronFeatureList[0].GeneSymbol,
                                expectedIntronGeneSymbol);
                ClassicAssert.AreEqual(intronFeatureList[0].Location.Operator.ToString(),
                                expectedIntronComplement);
                ClassicAssert.AreEqual(intronFeatureList[0].Number,
                                expectedIntronNumber);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(intronFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(intronFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(intronFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(intronFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(intronFeatureList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(intronFeatureList[0].StandardName));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Promoter feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankPromoterFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedPromoterComplement = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.PromoterComplement);
            string expectedPromoterCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.PromoterCount);

            // Parse a GenBank file.            
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);
                var locBuilder = new LocationBuilder();

                // Validate Misc feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Promoter> promotersFeatureList =
                    metadata.Features.Promoters;
                ClassicAssert.AreEqual(locBuilder.GetLocationString(
                    metadata.Features.Promoters[0].Location),
                                expectedPromoterComplement);
                ClassicAssert.AreEqual(promotersFeatureList.Count.ToString((IFormatProvider) null),
                                expectedPromoterCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(promotersFeatureList[0].GeneSymbol));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(promotersFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].Function.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(promotersFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(promotersFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(promotersFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(promotersFeatureList[0].Pseudo);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(promotersFeatureList[0].StandardName));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Variation feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankVariationFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedVariationCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.VarationCount);
            string expectedVariationReplace = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.VariationReplace);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Misc feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                List<Variation> variationFeatureList =
                    metadata.Features.Variations;
                ClassicAssert.AreEqual(variationFeatureList.Count.ToString((IFormatProvider) null),
                                expectedVariationCount);
                ClassicAssert.AreEqual(variationFeatureList[0].Replace,
                                expectedVariationReplace);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(variationFeatureList[0].GeneSymbol));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(variationFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(variationFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(variationFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(variationFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(variationFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(variationFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(variationFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(variationFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(variationFeatureList[0].StandardName));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Misc difference feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankMiscDiffFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedMiscDiffCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.MiscDiffCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate Protein feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(1).Metadata[Constants.GenBank];
                List<MiscDifference> miscDifferenceFeatureList =
                    metadata.Features.MiscDifferences;
                ClassicAssert.AreEqual(miscDifferenceFeatureList.Count.ToString((IFormatProvider) null),
                                expectedMiscDiffCount);
                ClassicAssert.AreEqual(miscDifferenceFeatureList[0].GeneSymbol,
                                expectedGeneSymbol);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].StandardName));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Replace));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Phenotype.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].LocusTag.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].Compare.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(miscDifferenceFeatureList[0].DatabaseCrossReference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(miscDifferenceFeatureList[0].ClonedFrom));


                // Create a new MiscDiff feature using constructor.
                var miscDiffWithLoc = new MiscDifference(
                    metadata.Features.MiscDifferences[0].Location);

                // Set and validate qualifiers.
                miscDiffWithLoc.GeneSymbol = expectedGeneSymbol;
                ClassicAssert.AreEqual(miscDiffWithLoc.GeneSymbol,
                                expectedGeneSymbol);

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Protein binding feature qualifiers.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateGenBankProteinBindingFeatureQualifiers(string nodeName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();
            string expectedProteinBindingCount =
                utilityObj.xmlUtil.GetTextValue(
                    nodeName, Constants.ProteinBindingCount);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate ProteinBinding feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(1).Metadata[Constants.GenBank];
                List<ProteinBindingSite> proteinBindingFeatureList =
                    metadata.Features.ProteinBindingSites;
                ClassicAssert.AreEqual(proteinBindingFeatureList.Count.ToString((IFormatProvider) null),
                                expectedProteinBindingCount);
                ClassicAssert.IsTrue(string.IsNullOrEmpty(proteinBindingFeatureList[0].GeneSymbol));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(proteinBindingFeatureList[0].Allele));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(proteinBindingFeatureList[0].Citation.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(proteinBindingFeatureList[0].Experiment.ToString()));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(proteinBindingFeatureList[0].GeneSynonym.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(proteinBindingFeatureList[0].GenomicMapPosition));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(proteinBindingFeatureList[0].Inference.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(proteinBindingFeatureList[0].Label));
                ClassicAssert.IsFalse(string.IsNullOrEmpty(proteinBindingFeatureList[0].OldLocusTag.ToString()));
                ClassicAssert.IsTrue(string.IsNullOrEmpty(proteinBindingFeatureList[0].StandardName));

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate GenBank Features clonning.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        /// <param name="featureName">Name of the GenBank feature</param>
        private void ValidateGenBankFeaturesClonning(string nodeName, FeatureGroup featureName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.FilePathNode).TestDir();
            string expectedExonFeatureCount = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.ExonCount);
            string expectedExonGeneSymbol = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.ExonGeneSymbol);
            string expectedExonNumber = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.ExonNumber);
            string expectedMiscDiffCount = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.MiscQualifiersCount);
            string expectedGeneSymbol = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.GeneSymbol);
            string expectedIntronGeneSymbol = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.IntronGeneSymbol);
            string expectedIntronNumber = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.IntronNumber);
            string expectedVariationReplace = utilityObj.xmlUtil.GetTextValue(nodeName, Constants.VariationReplace);

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                ISequence seq = parserObj.ParseOne(filePath);
                ClassicAssert.IsNotNull(seq);

                var metadata = seq.Metadata[Constants.GenBank] as GenBankMetadata;
                ClassicAssert.IsNotNull(metadata);

                // Validate cloned GenBank feature.
                switch (featureName)
                {
                    case FeatureGroup.Exon:
                        List<Exon> exonFeatureList = metadata.Features.Exons;

                        // Validate Exon feature before clonning.
                        ClassicAssert.AreEqual(exonFeatureList.Count.ToString((IFormatProvider) null), expectedExonFeatureCount);
                        ClassicAssert.AreEqual(exonFeatureList[0].GeneSymbol, expectedExonGeneSymbol);
                        ClassicAssert.AreEqual(exonFeatureList[0].Number, expectedExonNumber);

                        // Clone Exon feature.
                        Exon clonedExons = exonFeatureList[0].Clone();

                        // Validate Exon feature after clonning.
                        ClassicAssert.AreEqual(clonedExons.GeneSymbol, expectedExonGeneSymbol);
                        ClassicAssert.AreEqual(clonedExons.Number, expectedExonNumber);
                        break;
                    case FeatureGroup.miscDifference:
                        // Validate Misc Difference feature before clonning.
                        List<MiscDifference> miscDifferenceFeatureList = metadata.Features.MiscDifferences;
                        ClassicAssert.AreEqual(miscDifferenceFeatureList.Count.ToString((IFormatProvider) null), expectedMiscDiffCount);
                        ClassicAssert.AreEqual(miscDifferenceFeatureList[0].GeneSymbol, expectedGeneSymbol);

                        // Clone Misc Difference feature 
                        MiscDifference clonedMiscDifferences = miscDifferenceFeatureList[0].Clone();

                        // Validate Misc Difference feature  after clonning.
                        ClassicAssert.AreEqual(clonedMiscDifferences.GeneSymbol, expectedGeneSymbol);
                        break;
                    case FeatureGroup.Intron:
                        // Validate Intron feature before clonning.
                        List<Intron> intronFeatureList = metadata.Features.Introns;
                        ClassicAssert.AreEqual(intronFeatureList[0].GeneSymbol, expectedIntronGeneSymbol);
                        ClassicAssert.AreEqual(intronFeatureList[0].Number, expectedIntronNumber);

                        // Clone Intron feature.
                        Intron clonedIntrons = intronFeatureList[0].Clone();

                        // Validate Intron feature after clonning.
                        ClassicAssert.AreEqual(clonedIntrons.GeneSymbol, expectedIntronGeneSymbol);
                        ClassicAssert.AreEqual(clonedIntrons.Number, expectedIntronNumber);
                        break;
                    case FeatureGroup.variation:
                        // Validate Variation feature before clonning.
                        List<Variation> variationFeatureList = metadata.Features.Variations;
                        ClassicAssert.AreEqual(variationFeatureList[0].Replace, expectedVariationReplace);

                        // Clone Variation feature.
                        Variation clonedVariations = variationFeatureList[0].Clone();

                        // Validate Intron feature after clonning.
                        ClassicAssert.AreEqual(clonedVariations.Replace, expectedVariationReplace);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///     Validate General GenBank Features
        /// </summary>
        /// <param name="nodeName">xml node name for different feature.</param>
        /// <param name="featureName">Name of the GenBank feature</param>
        private void ValidateGeneralGenBankFeatureQualifiers(string nodeName, FeatureGroup featureName)
        {
            // Get Values from XML node.
            string filePath = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FilePathNode).TestDir();

            // Parse a GenBank file.
            ISequenceParser parserObj = new GenBankParser();
            {
                IEnumerable<ISequence> seqList = parserObj.Parse(filePath);

                // Validate ProteinBinding feature all qualifiers.
                var metadata =
                    (GenBankMetadata) seqList.ElementAt(0).Metadata[Constants.GenBank];
                switch (featureName)
                {
                    case FeatureGroup.MiscStructure:
                        ValidateGenBankMiscStructureFeature(nodeName,
                                                            metadata);
                        break;
                    case FeatureGroup.TrnsitPeptide:
                        ValidateGenBankTrnsitPeptideFeature(nodeName,
                                                            metadata);
                        break;
                    case FeatureGroup.StemLoop:
                        ValidateGenBankStemLoopFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.ModifiedBase:
                        ValidateGenBankModifiedBaseFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.PrecursorRNA:
                        ValidateGenBankPrecursorRNAFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.PolySite:
                        ValidateGenBankPolySiteFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.MiscBinding:
                        ValidateGenBankMiscBindingFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.Enhancer:
                        ValidateGenBankEnhancerFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.GCSignal:
                        ValidateGenBankGCSignalFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.LTR:
                        ValidateGenBankLTRFeature(nodeName, metadata);
                        break;
                    case FeatureGroup.Operon:
                        ValidateGenBankOperon(nodeName, metadata);
                        break;
                    case FeatureGroup.UnsureSequenceRegion:
                        ValidateGenBankUnsureSequenceRegion(nodeName,
                                                            metadata);
                        break;
                    case FeatureGroup.NonCodingRNA:
                        ValidateGenBankNonCodingRNA(nodeName, metadata);
                        break;
                    case FeatureGroup.CDS:
                        ValidateGenBankCDSFeatures(nodeName, metadata);
                        break;
                    case FeatureGroup.RibosomeBindingSite:
                        ValidateGenBankRibosomeBindingSite(nodeName, metadata);
                        break;
                    default:
                        break;
                }

                // Log VSTest GUI.
                ApplicationLog.WriteLine(
                    "GenBank Features P1: Successfully validated the GenBank Features");
            }
        }

        /// <summary>
        ///     Validate MiscStructure features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankMiscStructureFeature(string nodeName,
                                                         GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedFunction = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FunctionNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<MiscStructure> miscStrFeatureList =
                genMetadata.Features.MiscStructures;
            var locBuilder = new LocationBuilder();

            // Create a copy of Misc structure.
            MiscStructure cloneMiscStr = miscStrFeatureList[0].Clone();

            // Validate MiscStructure qualifiers.
            ClassicAssert.AreEqual(miscStrFeatureList.Count.ToString((IFormatProvider) null), featureCount);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(cloneMiscStr.GeneSymbol));
            ClassicAssert.AreEqual(cloneMiscStr.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(miscStrFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(miscStrFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.MiscStructures[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(miscStrFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(miscStrFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.AreEqual(miscStrFeatureList[0].Function[0],
                            expectedFunction);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(miscStrFeatureList[0].StandardName));

            // Create a new MiscStructure and validate the same.
            var miscStructure = new MiscStructure(expectedLocation);
            var miscStructureWithILoc = new MiscStructure(
                genMetadata.Features.TransitPeptides[0].Location);

            // Set qualifiers and validate them.
            miscStructure.Allele = expectedAllele;
            miscStructure.GeneSymbol = geneSymbol;
            miscStructureWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(miscStructure.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(miscStructure.Allele, expectedAllele);
            ClassicAssert.AreEqual(miscStructureWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate TrnsitPeptide features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankTrnsitPeptideFeature(string nodeName,
                                                         GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedFunction = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FunctionNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<TransitPeptide> tansitPeptideFeatureList =
                genMetadata.Features.TransitPeptides;
            var locBuilder = new LocationBuilder();

            // Create a copy of transit peptide features.
            TransitPeptide cloneTransit = tansitPeptideFeatureList[0].Clone();

            // Validate transit peptide qualifiers.
            ClassicAssert.AreEqual(tansitPeptideFeatureList.Count.ToString((IFormatProvider) null), featureCount);
            ClassicAssert.AreEqual(cloneTransit.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(cloneTransit.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.TransitPeptides[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.AreEqual(tansitPeptideFeatureList[0].Function[0],
                            expectedFunction);

            // Create a new TransitPeptide and validate the same.
            var tPeptide = new TransitPeptide(expectedLocation);
            var tPeptideWithILoc = new TransitPeptide(
                genMetadata.Features.TransitPeptides[0].Location);

            // Set qualifiers and validate them.
            tPeptide.Allele = expectedAllele;
            tPeptide.GeneSymbol = geneSymbol;
            tPeptideWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(tPeptide.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(tPeptide.Allele, expectedAllele);
            ClassicAssert.AreEqual(tPeptideWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate StemLoop features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankStemLoopFeature(string nodeName,
                                                    GenBankMetadata genMetadata)
        {
            // Get Values from XML node.
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedFunction = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FunctionNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<StemLoop> sLoopFeatureList = genMetadata.Features.StemLoops;
            var locBuilder = new LocationBuilder();

            // Create a copy of StemLoop feature.
            StemLoop cloneSLoop = sLoopFeatureList[0].Clone();

            // Validate transit peptide qualifiers.
            ClassicAssert.AreEqual(sLoopFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneSLoop.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(cloneSLoop.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(sLoopFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(sLoopFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.StemLoops[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(sLoopFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(sLoopFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.AreEqual(sLoopFeatureList[0].Function[0],
                            expectedFunction);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(sLoopFeatureList[0].Operon));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(sLoopFeatureList[0].StandardName));

            // Create a new StemLoop and validate the same.
            var stemLoop = new StemLoop(expectedLocation);
            var stemLoopWithILoc = new StemLoop(
                genMetadata.Features.StemLoops[0].Location);

            // Set qualifiers and validate them.
            stemLoop.Allele = expectedAllele;
            stemLoop.GeneSymbol = geneSymbol;
            stemLoopWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(stemLoop.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(stemLoop.Allele, expectedAllele);
            ClassicAssert.AreEqual(stemLoopWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate ModifiedBase features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankModifiedBaseFeature(string nodeName,
                                                        GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<ModifiedBase> modifiedBaseFeatureList =
                genMetadata.Features.ModifiedBases;
            var locBuilder = new LocationBuilder();

            // Create a copy of Modified base feature.
            ModifiedBase cloneModifiedBase = modifiedBaseFeatureList[0].Clone();

            // Validate Modified Base qualifiers.
            ClassicAssert.AreEqual(modifiedBaseFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneModifiedBase.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(cloneModifiedBase.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.ModifiedBases[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(modifiedBaseFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(modifiedBaseFeatureList[0].ModifiedNucleotideBase.ToString()));

            // Create a new ModifiedBase and validate the same.
            var modifiedBase = new ModifiedBase(expectedLocation);
            var modifiedBaseWithILoc = new ModifiedBase(
                genMetadata.Features.ModifiedBases[0].Location);

            // Set qualifiers and validate them.
            modifiedBase.Allele = expectedAllele;
            modifiedBase.GeneSymbol = geneSymbol;
            modifiedBaseWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(modifiedBase.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(modifiedBase.Allele, expectedAllele);
            ClassicAssert.AreEqual(modifiedBaseWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate PrecursorRNA features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankPrecursorRNAFeature(string nodeName,
                                                        GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedFunction = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FunctionNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<PrecursorRna> precursorRNAFeatureList =
                genMetadata.Features.PrecursorRNAs;
            var locBuilder = new LocationBuilder();

            // Create a copy of Precursor RNA feature.
            PrecursorRna clonePrecursorRNA =
                precursorRNAFeatureList[0].Clone();

            // Validate Precursor RNA qualifiers.
            ClassicAssert.AreEqual(precursorRNAFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(clonePrecursorRNA.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(clonePrecursorRNA.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Label, expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.PrecursorRNAs[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.AreEqual(precursorRNAFeatureList[0].Function[0],
                            expectedFunction);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(precursorRNAFeatureList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(precursorRNAFeatureList[0].Product.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(precursorRNAFeatureList[0].Operon));
            ClassicAssert.IsFalse(precursorRNAFeatureList[0].TransSplicing);

            // Create a new Precursor RNA and validate the same.
            var precursorRNA = new PrecursorRna(expectedLocation);
            var precursorRNAWithILoc = new PrecursorRna(
                genMetadata.Features.PrecursorRNAs[0].Location);

            // Set qualifiers and validate them.
            precursorRNA.Allele = expectedAllele;
            precursorRNA.GeneSymbol = geneSymbol;
            precursorRNAWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(precursorRNA.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(precursorRNA.Allele, expectedAllele);
            ClassicAssert.AreEqual(precursorRNAWithILoc.GenomicMapPosition, expectedMap);
        }

        /// <summary>
        ///     Validate PolySite features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankPolySiteFeature(string nodeName,
                                                    GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<PolyASite> polySiteFeatureList = genMetadata.Features.PolyASites;
            var locBuilder = new LocationBuilder();

            // Create a copy of Poly site feature.
            PolyASite clonePolySite = polySiteFeatureList[0].Clone();

            // Validate Poly site qualifiers.
            ClassicAssert.AreEqual(polySiteFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(clonePolySite.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(clonePolySite.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(polySiteFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(polySiteFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.PolyASites[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(polySiteFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(polySiteFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(polySiteFeatureList[0].LocusTag[0],
                            expectedLocusTag);

            // Create a new PolySite and validate the same.
            var polySite = new PolyASite(expectedLocation);
            var polySiteWithILoc = new PolyASite(
                genMetadata.Features.PolyASites[0].Location);

            // Set qualifiers and validate them.
            polySite.Allele = expectedAllele;
            polySite.GeneSymbol = geneSymbol;
            polySiteWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(polySite.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(polySite.Allele, expectedAllele);
            ClassicAssert.AreEqual(polySiteWithILoc.GenomicMapPosition, expectedMap);
        }

        /// <summary>
        ///     Validate MiscBinding features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankMiscBindingFeature(string nodeName,
                                                       GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<MiscBinding> miscBindingFeatureList = genMetadata.Features.MiscBindings;
            var locBuilder = new LocationBuilder();

            // Create a copy of Misc Binding feature.
            MiscBinding cloneMiscBinding = miscBindingFeatureList[0].Clone();

            // Validate Misc Binding qualifiers.
            ClassicAssert.AreEqual(miscBindingFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneMiscBinding.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(cloneMiscBinding.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.MiscBindings[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(miscBindingFeatureList[0].LocusTag[0],
                            expectedLocusTag);

            // Create a new MiscBinding and validate the same.
            var miscBinding = new MiscBinding(expectedLocation);
            var miscBindingWithILoc = new MiscBinding(
                genMetadata.Features.MiscBindings[0].Location);

            // Set qualifiers and validate them.
            miscBinding.Allele = expectedAllele;
            miscBinding.GeneSymbol = geneSymbol;
            miscBindingWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(miscBinding.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(miscBinding.Allele, expectedAllele);
            ClassicAssert.AreEqual(miscBindingWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate GenBank Enhancer features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankEnhancerFeature(string nodeName,
                                                    GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<Enhancer> enhancerFeatureList = genMetadata.Features.Enhancers;

            // Create a copy of Enhancer feature.
            Enhancer cloneEnhancer = enhancerFeatureList[0].Clone();
            var locBuilder = new LocationBuilder();

            // Validate Enhancer qualifiers.
            ClassicAssert.AreEqual(enhancerFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneEnhancer.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(cloneEnhancer.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(enhancerFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(enhancerFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.Enhancers[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(enhancerFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(enhancerFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(enhancerFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(enhancerFeatureList[0].StandardName));

            // Create a new Enhancer and validate the same.
            var enhancer = new Enhancer(expectedLocation);
            var enhancerWithILoc = new GcSingal(
                genMetadata.Features.Enhancers[0].Location);

            // Set qualifiers and validate them.
            enhancer.Allele = expectedAllele;
            enhancer.GeneSymbol = geneSymbol;
            enhancerWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(enhancer.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(enhancer.Allele, expectedAllele);
            ClassicAssert.AreEqual(enhancerWithILoc.GenomicMapPosition, expectedMap);
        }

        /// <summary>
        ///     Validate GenBank GCSignal features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankGCSignalFeature(string nodeName,
                                                    GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<GcSingal> gcSignalFeatureList = genMetadata.Features.GCSignals;
            var locBuilder = new LocationBuilder();

            // Create a copy of GC_Signal feature.
            GcSingal cloneGCSignal = gcSignalFeatureList[0].Clone();

            // Validate GC_Signal qualifiers.
            ClassicAssert.AreEqual(gcSignalFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneGCSignal.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(cloneGCSignal.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.GCSignals[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(gcSignalFeatureList[0].LocusTag[0],
                            expectedLocusTag);

            // Create a new GCSignal and validate the same.
            var gcSignal = new GcSingal(expectedLocation);
            var gcSignalWithILoc = new GcSingal(
                genMetadata.Features.GCSignals[0].Location);

            // Set qualifiers and validate them.
            gcSignal.Allele = expectedAllele;
            gcSignal.GeneSymbol = geneSymbol;
            gcSignalWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(gcSignal.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(gcSignal.Allele, expectedAllele);
            ClassicAssert.AreEqual(gcSignalWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate GenBank LTR features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankLTRFeature(string nodeName,
                                               GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedFunction = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.FunctionNode);
            string expectedGeneSynonym = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSynonymNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LocusTagNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedOldLocusTag = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.OldLocusTagNode);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<LongTerminalRepeat> LTRFeatureList =
                genMetadata.Features.LongTerminalRepeats;
            var locBuilder = new LocationBuilder();

            // Create a copy of Long Terminal Repeat feature.
            LongTerminalRepeat cloneLTR = LTRFeatureList[0].Clone();

            // Validate Long Terminal Repeat qualifiers.
            ClassicAssert.AreEqual(LTRFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneLTR.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(cloneLTR.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(LTRFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(LTRFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(LTRFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(LTRFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(LTRFeatureList[0].GeneSynonym[0],
                            expectedGeneSynonym);
            ClassicAssert.AreEqual(LTRFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(LTRFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.LongTerminalRepeats[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(LTRFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(LTRFeatureList[0].OldLocusTag[0],
                            expectedOldLocusTag);
            ClassicAssert.AreEqual(LTRFeatureList[0].LocusTag[0],
                            expectedLocusTag);
            ClassicAssert.AreEqual(LTRFeatureList[0].Function[0],
                            expectedFunction);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(LTRFeatureList[0].StandardName));

            // Create a new LTR and validate.
            var ltr =
                new LongTerminalRepeat(expectedLocation);
            var ltrWithILoc = new LongTerminalRepeat(
                genMetadata.Features.LongTerminalRepeats[0].Location);

            // Set qualifiers and validate them.
            ltr.Allele = expectedAllele;
            ltr.GeneSymbol = geneSymbol;
            ltrWithILoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(ltr.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(ltr.Allele, expectedAllele);
            ClassicAssert.AreEqual(ltrWithILoc.GenomicMapPosition,
                            expectedMap);
        }

        /// <summary>
        ///     Validate GenBank Operon features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankOperon(string nodeName,
                                           GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<OperonRegion> operonFeatureList =
                genMetadata.Features.OperonRegions;
            var locBuilder = new LocationBuilder();

            // Create a copy of Long Terminal Repeat feature.
            OperonRegion cloneOperon = operonFeatureList[0].Clone();

            // Validate Operon region qualifiers.
            ClassicAssert.AreEqual(operonFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneOperon.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(operonFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(operonFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(operonFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(operonFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(operonFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(operonFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.OperonRegions[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(operonFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(operonFeatureList[0].Function.ToString()));
            ClassicAssert.AreEqual(operonFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(operonFeatureList[0].Operon));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(operonFeatureList[0].Phenotype.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(operonFeatureList[0].StandardName));
            ClassicAssert.IsFalse(operonFeatureList[0].Pseudo);

            // Create a new Operon feature using constructor.
            var operonRegion =
                new OperonRegion(expectedLocation);
            var operonRegionWithLoc = new OperonRegion(
                genMetadata.Features.OperonRegions[0].Location);

            // Set and validate qualifiers.
            operonRegion.Allele = expectedAllele;
            operonRegionWithLoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(operonRegionWithLoc.GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(operonRegion.Allele, expectedAllele);
        }

        /// <summary>
        ///     Validate GenBank UnsureSequenceRegion features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankUnsureSequenceRegion(string nodeName,
                                                         GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<UnsureSequenceRegion> unsureSeqRegionFeatureList =
                genMetadata.Features.UnsureSequenceRegions;

            // Create a copy of Unsure Seq Region feature.
            UnsureSequenceRegion cloneUnSureSeqRegion =
                unsureSeqRegionFeatureList[0].Clone();
            var locBuilder = new LocationBuilder();

            // Validate Unsure Seq Region qualifiers.
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList.Count.ToString((IFormatProvider) null)
                            , featureCount);
            ClassicAssert.AreEqual(cloneUnSureSeqRegion.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(cloneUnSureSeqRegion.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.UnsureSequenceRegions[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(unsureSeqRegionFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(unsureSeqRegionFeatureList[0].Compare.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(unsureSeqRegionFeatureList[0].Replace));

            // Create a new Unsure feature using constructor.
            var unsureRegion =
                new UnsureSequenceRegion(expectedLocation);
            var unsureRegionWithLoc =
                new UnsureSequenceRegion(
                    genMetadata.Features.UnsureSequenceRegions[0].Location);

            // Set and validate qualifiers.
            unsureRegion.Allele = expectedAllele;
            unsureRegionWithLoc.GeneSymbol = geneSymbol;
            unsureRegionWithLoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(unsureRegionWithLoc.GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(unsureRegion.Allele, expectedAllele);
            ClassicAssert.AreEqual(unsureRegionWithLoc.GeneSymbol,
                            geneSymbol);
        }

        /// <summary>
        ///     Validate GenBank RibosomeBindingSite features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankRibosomeBindingSite(string nodeName,
                                                        GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);

            List<RibosomeBindingSite> ribosomeSite =
                genMetadata.Features.RibosomeBindingSites;

            // Create a copy of RibosomeBindigSite  Region feature.
            RibosomeBindingSite cloneRibosomeSite =
                ribosomeSite[0].Clone();
            var locBuilder = new LocationBuilder();

            // Validate RibosomeBindigSite qualifiers.
            ClassicAssert.AreEqual(ribosomeSite.Count.ToString((IFormatProvider) null)
                            , featureCount);
            ClassicAssert.AreEqual(cloneRibosomeSite.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(cloneRibosomeSite.GeneSymbol,
                            geneSymbol);
            ClassicAssert.AreEqual(ribosomeSite[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(ribosomeSite[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(ribosomeSite[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(ribosomeSite[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(ribosomeSite[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.RibosomeBindingSites[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(ribosomeSite[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(ribosomeSite[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.IsNotNull(ribosomeSite[0].OldLocusTag[0]);
            ClassicAssert.IsNotNull(ribosomeSite[0].LocusTag[0]);
            ClassicAssert.IsNotNull(ribosomeSite[0].StandardName);

            // Create a new RibosomeBindingSite feature using constructor.
            var ribosomeBindingSite =
                new RibosomeBindingSite(expectedLocation);
            var ribosomeBindingSiteLoc =
                new RibosomeBindingSite(
                    genMetadata.Features.RibosomeBindingSites[0].Location);

            // Set and validate qualifiers.
            ribosomeBindingSite.Allele = expectedAllele;
            ribosomeBindingSiteLoc.GeneSymbol = geneSymbol;
            ribosomeBindingSiteLoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(ribosomeBindingSiteLoc.GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(ribosomeBindingSite.Allele, expectedAllele);
            ClassicAssert.AreEqual(ribosomeBindingSiteLoc.GeneSymbol,
                            geneSymbol);
        }

        /// <summary>
        ///     Validate GenBank Non Coding RNA features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankNonCodingRNA(string nodeName,
                                                 GenBankMetadata genMetadata)
        {
            // Get Values from XML node.           
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedNonCodingRnaClass = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.NonCodingRnaClassNode);

            List<NonCodingRna> nonCodingRNAFeatureList =
                genMetadata.Features.NonCodingRNAs;
            var locBuilder = new LocationBuilder();

            // Create a copy of Non coding RNA feature.
            NonCodingRna cloneNonCodingRNA =
                nonCodingRNAFeatureList[0].Clone();

            // Validate Non Coding RNA Region qualifiers.
            ClassicAssert.AreEqual(nonCodingRNAFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(nonCodingRNAFeatureList[0].NonCodingRnaClass,
                            expectedNonCodingRnaClass);
            ClassicAssert.AreEqual(cloneNonCodingRNA.Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.NonCodingRNAs[0].Location),
                            expectedLocation);

            // Create a non Coding RNA and validate the same.
            var nRNA =
                new NonCodingRna(genMetadata.Features.NonCodingRNAs[0].Location);
            var nRNAWithLocation =
                new NonCodingRna(expectedLocation);

            // Set properties 
            nRNA.NonCodingRnaClass = expectedNonCodingRnaClass;
            nRNAWithLocation.NonCodingRnaClass = expectedNonCodingRnaClass;

            // Validate created nRNA.
            ClassicAssert.AreEqual(nRNA.NonCodingRnaClass,
                            expectedNonCodingRnaClass);
            ClassicAssert.AreEqual(nRNAWithLocation.NonCodingRnaClass,
                            expectedNonCodingRnaClass);
        }

        /// <summary>
        ///     Validate GenBank CDS features
        /// </summary>
        /// <param name="nodeName">XML node name</param>
        /// <param name="genMetadata">GenBank Metadata</param>
        private void ValidateGenBankCDSFeatures(string nodeName,
                                                GenBankMetadata genMetadata)
        {
            // Get Values from XML node.            
            string expectedLocation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedAllele = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlleleNode);
            string featureCount = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.QualifierCount);
            string expectedDbReference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.DbReferenceNode);
            string geneSymbol = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GeneSymbol);
            string expectedCitation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CitationNode);
            string expectedExperiment = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExperimentNode);
            string expectedInference = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.InferenceNode);
            string expectedLabel = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.LabelNode);
            string expectedNote = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Note);
            string expectedMap = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankMapNode);
            string expectedTranslation = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.GenbankTranslationNode);
            string expectedCodonStart = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.CodonStartNode);

            List<CodingSequence> codingSequenceFeatureList =
                genMetadata.Features.CodingSequences;
            var locBuilder = new LocationBuilder();

            // Create a copy of Coding Seq Region feature.
            CodingSequence cloneCDS = codingSequenceFeatureList[0].Clone();

            // Validate Unsure Seq Region qualifiers.
            ClassicAssert.AreEqual(codingSequenceFeatureList.Count.ToString((IFormatProvider) null),
                            featureCount);
            ClassicAssert.AreEqual(cloneCDS.DatabaseCrossReference[0],
                            expectedDbReference);
            ClassicAssert.AreEqual(cloneCDS.GeneSymbol, geneSymbol);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Allele,
                            expectedAllele);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Citation[0],
                            expectedCitation);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Experiment[0],
                            expectedExperiment);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Inference[0],
                            expectedInference);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Label,
                            expectedLabel);
            ClassicAssert.AreEqual(locBuilder.GetLocationString(
                genMetadata.Features.CodingSequences[0].Location),
                            expectedLocation);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Note[0],
                            expectedNote);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].GenomicMapPosition,
                            expectedMap);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].CodonStart[0],
                            expectedCodonStart);
            ClassicAssert.AreEqual(codingSequenceFeatureList[0].Translation,
                            expectedTranslation);
            ClassicAssert.IsFalse(string.IsNullOrEmpty(codingSequenceFeatureList[0].Codon.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].EnzymeCommissionNumber));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].Number));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].Operon));
            ClassicAssert.IsFalse(codingSequenceFeatureList[0].Pseudo);
            ClassicAssert.IsFalse(codingSequenceFeatureList[0].RibosomalSlippage);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].StandardName));
            ClassicAssert.IsFalse(string.IsNullOrEmpty(codingSequenceFeatureList[0].TranslationalExcept.ToString()));
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].TranslationTable));
            ClassicAssert.IsFalse(codingSequenceFeatureList[0].TransSplicing);
            ClassicAssert.IsTrue(string.IsNullOrEmpty(codingSequenceFeatureList[0].Exception));

            // Create a new CDS feature using constructor.
            var cds = new CodingSequence(expectedLocation);
            var cdsWithLoc = new CodingSequence(
                genMetadata.Features.CodingSequences[0].Location);
            Sequence seq = cds.GetTranslation();
            ClassicAssert.IsNotNull(seq);

            // Set and validate qualifiers.
            cds.Allele = expectedAllele;
            cdsWithLoc.GeneSymbol = geneSymbol;
            cdsWithLoc.GenomicMapPosition = expectedMap;
            ClassicAssert.AreEqual(cdsWithLoc.GenomicMapPosition, expectedMap);
            ClassicAssert.AreEqual(cds.Allele, expectedAllele);
            ClassicAssert.AreEqual(cdsWithLoc.GeneSymbol, geneSymbol);
        }


        /// <summary>
        ///     Validate Location builder and location resolver.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        /// <param name="FeatureOperator">Name of the operator used in a location</param>
        /// <param name="isOperator">
        ///     True if location resolver validation with
        ///     operator
        /// </param>
        private void ValidateGenBankLocationResolver(string nodeName,
                                                     FeatureOperator operatorName, bool isOperator)
        {
            // Get Values from XML node.
            string sequence = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExpectedSequence);
            string location = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string alphabet = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.AlphabetNameNode);
            string expectedSeq = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.ExpSequenceWithOperator);

            // Create a sequence object.
            ISequence seqObj = new Sequence(Utility.GetAlphabet(alphabet),
                                            sequence);
            ISequence expectedSeqWithLoc;

            // Build a location.
            ILocationBuilder locBuilder = new LocationBuilder();
            ILocation loc = locBuilder.GetLocation(location);

            if (isOperator)
            {
                switch (operatorName)
                {
                    case FeatureOperator.Complement:
                        loc.Operator = LocationOperator.Complement;
                        break;
                    case FeatureOperator.Join:
                        loc.Operator = LocationOperator.Join;
                        break;
                    case FeatureOperator.Order:
                        loc.Operator = LocationOperator.Order;
                        break;
                    default:
                        break;
                }
            }

            // Get sequence using location of the sequence with operator.
            expectedSeqWithLoc = loc.GetSubSequence(seqObj);

            var sequenceString = new string(expectedSeqWithLoc.Select(a => (char) a).ToArray());
            ClassicAssert.AreEqual(expectedSeq, sequenceString);

            // Log to VSTest GUI.
            ApplicationLog.WriteLine(string.Format(null,
                                                   "GenBankFeatures P1 : Expected sequence is verfied '{0}'.",
                                                   sequenceString));
        }

        /// <summary>
        ///     Validate location resolver end data.
        /// </summary>
        /// <param name="nodeName">xml node name.</param>
        private void ValidateLocationEndData(string nodeName)
        {
            // Get Values from XML node.
            string location = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Location);
            string expectedEndData = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.EndData);
            string position = utilityObj.xmlUtil.GetTextValue(
                nodeName, Constants.Position);

            bool result = false;

            // Build a location.
            var locResolver = new LocationResolver();
            ILocationBuilder locBuilder = new LocationBuilder();
            ILocation loc = locBuilder.GetLocation(location);
            loc.EndData = expectedEndData;

            // Validate whether mentioned end data is present in the location
            // or not.
            result = locResolver.IsInEnd(loc, Int32.Parse(position, null));
            ClassicAssert.IsTrue(result);

            // Log to VSTest GUI.
            ApplicationLog.WriteLine(string.Format(null,
                                                   "GenBankFeatures P1 : Expected sequence is verified"));
        }

        #endregion Supporting Methods
    }
}
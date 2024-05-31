using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Bio.IO.Wiggle;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bio.Tests.IO.Wiggle
{
    /// <summary>
    /// Wiggle format parser and formatter.
    /// </summary>
    [TestFixture]
    public class WiggleTests
    {
        /// <summary>
        /// Tests creating an annotation object from scratch.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestAnnotationObject()
        {
            WiggleAnnotation an = CreateDummyAnnotation();
            VerifyDummyAnnotation(an);
        }

        /// <summary>
        /// Verifies an annotation object against a pre-defined set of values.
        /// </summary>
        /// <param name="an"></param>
        private static void VerifyDummyAnnotation(WiggleAnnotation an)
        {
            ClassicAssert.IsTrue(an.Chromosome == "chromeee");
            ClassicAssert.IsTrue(an.Span == 100);

            try
            {
                an.GetValueArray(0, 3);
                Assert.Fail();
            }
            catch(NotSupportedException)
            { }

            var x = an.GetEnumerator();
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 100); ClassicAssert.IsTrue(x.Current.Value == 10);
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 200); ClassicAssert.IsTrue(x.Current.Value == 20);
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 300); ClassicAssert.IsTrue(x.Current.Value == 30);
        }

        /// <summary>
        /// Creates a new annotation object.
        /// </summary>
        /// <returns>Dummy annotation object.</returns>
        private static WiggleAnnotation CreateDummyAnnotation()
        {
            return new WiggleAnnotation(new[] {
                new KeyValuePair<long, float>(100,10),
                new KeyValuePair<long, float>(200,20),
                new KeyValuePair<long, float>(300,30)
            }, "chromeee", 100);
        }

        /// <summary>
        /// Verifies the parser.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestWiggleParser()
        {
            string filepath = Path.Combine("TestUtils", "Wiggle", "variable.wig").TestDir();

            TestParserVariableStep(filepath);

            filepath = Path.Combine("TestUtils", "Wiggle", "fixed.wig").TestDir();

            TestParserFixedStep(filepath);
        }

        /// <summary>
        /// Verifies the formatter.
        /// </summary>
        [Test]
        [Category("Priority0")]
        public void TestWiggleFormatter()
        {
            string filepathTmp = Path.GetTempFileName();
            WiggleFormatter formatter = new WiggleFormatter();

            using (formatter.Open(filepathTmp))
            {
                formatter.Format(CreateDummyAnnotation());
            }

            WiggleParser parser = new WiggleParser();
            VerifyDummyAnnotation(parser.Parse(filepathTmp).First());
        }

        // Test wiggle fixed step
        private static WiggleAnnotation TestParserFixedStep(string filename)
        {
            WiggleParser p = new WiggleParser();
            WiggleAnnotation an = p.Parse(filename).First();

            ClassicAssert.IsTrue(an.Chromosome == "chr19");
            ClassicAssert.IsTrue(an.BasePosition == 59307401);
            ClassicAssert.IsTrue(an.Step == 300);
            ClassicAssert.IsTrue(an.Span == 200);
            
            ClassicAssert.IsTrue(an.Metadata["type"] == "wiggle_0");
            ClassicAssert.IsTrue(an.Metadata["name"] == "ArrayExpt1");
            ClassicAssert.IsTrue(an.Metadata["description"] == "20 degrees, 2 hr");

            float[] values = an.GetValueArray(0, 3);
            ClassicAssert.IsTrue(values[0] == 1000);
            ClassicAssert.IsTrue(values[1] == 900);
            ClassicAssert.IsTrue(values[2] == 800);

            values = an.GetValueArray(7, 3);
            ClassicAssert.IsTrue(values[0] == 300);
            ClassicAssert.IsTrue(values[1] == 200);
            ClassicAssert.IsTrue(values[2] == 100);

            return an;
        }

        // Test wiggle variable step
        private static WiggleAnnotation TestParserVariableStep(string filename)
        {
            WiggleParser p = new WiggleParser();
            WiggleAnnotation an = p.Parse(filename).First();

            ClassicAssert.IsTrue(an.Chromosome == "chr19");
            ClassicAssert.IsTrue(an.Step == 0);
            ClassicAssert.IsTrue(an.BasePosition == 0);
            ClassicAssert.IsTrue(an.Span == 150);
            
            ClassicAssert.IsTrue(an.Metadata["type"] == "wiggle_0");
            ClassicAssert.IsTrue(an.Metadata["name"] == "ArrayExpt1");
            ClassicAssert.IsTrue(an.Metadata["description"] == "20 degrees, 2 hr");

            var x = an.GetEnumerator();
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 59304701); ClassicAssert.IsTrue(x.Current.Value == 10.0);
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 59304901); ClassicAssert.IsTrue(x.Current.Value == 12.5);
            x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 59305401); ClassicAssert.IsTrue(x.Current.Value == 15.0);
            x.MoveNext(); x.MoveNext(); x.MoveNext(); x.MoveNext(); x.MoveNext(); x.MoveNext();
            ClassicAssert.IsTrue(x.Current.Key == 59307871); ClassicAssert.IsTrue(x.Current.Value == 10.0);

            return an;
        }
    }
}


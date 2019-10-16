﻿using System;
using System.IO;
using NUnit.Framework;

namespace Trivia.Tests
{
    [TestFixture]
    public class Tests
    {
        private static readonly string ProjectDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        private static readonly string PathToReference = Path.Combine(ProjectDir, "reference.txt");
        private static readonly string PathToActual = Path.Combine(ProjectDir, "actual.txt");

        [Test]
        public void TestBasile()
        {
            Assert.That(1, Is.EqualTo(1));
        }
        
        [SetUp]
        public void CreateReferenceFirstTime()
        {
            if (!File.Exists(PathToReference))
            {
                runAndCaptureOutputTo(PathToReference);
                Assert.Fail("Please re-run tests. Reference created: " + PathToReference);
            }
        }
        [Test]
        public void Test1()
        {
            runAndCaptureOutputTo(PathToActual);

            string actual = File.ReadAllText(PathToActual);
            string reference = File.ReadAllText(PathToReference);
            Assert.AreEqual(reference, actual);
        }

        private static void runAndCaptureOutputTo(string capturePath)
        {
            var oldOut = Console.Out;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                for (int i = 1; i < 42; i++)
                {
                    var runner = new GameRunner(new Random(i));
                    runner.DoMain(new string[] { });
                }
                File.WriteAllText(capturePath, sw.ToString());
            }

            Console.SetOut(oldOut);
        }
    }
}
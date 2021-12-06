using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Common.Services;
using Common.IO;
using Day2;

namespace Tests.Day2
{
    public class Day2CalculatorTests
    {
        private Day2Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay2Mapper mapper;
        private ContentBreaker<LineContentDay2> contentBreaker;

        [SetUp]
        public void Setup()
        {
            calculator = new();
            contentSplitter = new();
            mapper = new();
            contentBreaker = new(mapper);
        }

        [Test]
        public void Calculate1_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay2.txt");

            var position = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(15, position.Horizontal);
            Assert.AreEqual(10, position.Depth);
            Assert.AreEqual(150, position.Compute());
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay2.txt");

            var position = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(15, position.Horizontal);
            Assert.AreEqual(60, position.Depth);
            Assert.AreEqual(900, position.Compute());
        }

        private List<LineContentDay2> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
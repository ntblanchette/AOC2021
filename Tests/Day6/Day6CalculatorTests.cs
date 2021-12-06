using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day6;

namespace Tests.Day6
{
    public class Day6CalculatorTests
    {
        private Day6Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay6Mapper mapper;
        private ContentBreaker<LineContentDay6> contentBreaker;

        [SetUp]
        public void Setup()
        {
            calculator = new();
            contentSplitter = new();
            mapper = new();
            contentBreaker = new(mapper);
        }

        [Test]
        public void Calculate1_18days_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay6.txt");

            var result = calculator.Calculate1(listOfInputs, 18);

            Assert.AreEqual(26, result);
        }

        [Test]
        public void Calculate1_80days_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay6.txt");

            var result = calculator.Calculate1(listOfInputs, 80);

            Assert.AreEqual(5934, result);
        }

        [Test]
        public void Calculate2_256days_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay6.txt");

            var result = calculator.Calculate1(listOfInputs, 256);

            Assert.AreEqual(26984457539, result);
        }

        private List<LineContentDay6> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
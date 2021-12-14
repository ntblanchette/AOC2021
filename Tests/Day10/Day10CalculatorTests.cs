using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day10;

namespace Tests.Day10
{
    public class Day9CalculatorTests
    {
        private Day10Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay10Mapper mapper;
        private ContentBreaker<LineContentDay10> contentBreaker;

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
            var listOfInputs = GetInput("Inputs/DemoDay10.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(26397, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay10.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(288957, result);
        }

        private List<LineContentDay10> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day9;

namespace Tests.Day9
{
    public class Day9CalculatorTests
    {
        private Day9Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay9Mapper mapper;
        private ContentBreaker<LineContentDay9> contentBreaker;

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
            var listOfInputs = GetInput("Inputs/DemoDay9.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay9.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(1134, result);
        }

        private List<LineContentDay9> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
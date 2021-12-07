using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day8;

namespace Tests.Day8
{
    public class Day8CalculatorTests
    {
        private Day8Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay8Mapper mapper;
        private ContentBreaker<LineContentDay8> contentBreaker;

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
            var listOfInputs = GetInput("Inputs/DemoDay8.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(26, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay8.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(0, result);
        }

        private List<LineContentDay8> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
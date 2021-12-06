using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day4;

namespace Tests.Day4
{
    public class Day4CalculatorTests
    {
        private Day4Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay4Mapper mapper;
        private ContentBreaker<LineContentDay4> contentBreaker;

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
            var listOfInputs = GetInput("Inputs/DemoDay4.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(4512, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay4.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(1924, result);
        }

        private List<LineContentDay4> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
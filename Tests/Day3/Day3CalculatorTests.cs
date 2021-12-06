using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Day3;

namespace Tests.Day3
{
    public class Day3CalculatorTests
    {
        private Day3Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay3Mapper mapper;
        private ContentBreaker<LineContentDay3> contentBreaker;

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
            var listOfInputs = GetInput("Inputs/DemoDay3.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(198, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Inputs/DemoDay3.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(230, result);
        }

        private List<LineContentDay3> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
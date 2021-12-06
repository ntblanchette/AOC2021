using Common.IO;
using Common.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Day7.Tests
{
    public class Day7CalculatorTests
    {
        private Day7Calculator calculator;
        private ContentSplitter contentSplitter;
        private LineContentDay7Mapper mapper;
        private ContentBreaker<LineContentDay7> contentBreaker;

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
            var listOfInputs = GetInput("Demo.txt");

            var result = calculator.Calculate1(listOfInputs);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput("Demo.txt");

            var result = calculator.Calculate2(listOfInputs);

            Assert.AreEqual(0, result);
        }

        private List<LineContentDay7> GetInput(string fileName)
        {
            var inputText = File.ReadAllText(fileName);
            var lines = contentSplitter.SplitIntoStrings(inputText);
            return contentBreaker.BreakIntoObject(lines);
        }
    }
}
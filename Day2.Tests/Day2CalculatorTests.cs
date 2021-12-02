using NUnit.Framework;
using System.Collections.Generic;
using Common.Enums;

namespace Day2.Tests
{
    public class Day2CalculatorTests
    {
        private Day2Calculator _calculator = new();

        [SetUp]
        public void Setup()
        {
            _calculator = new Day2Calculator();
        }

        [Test]
        public void Calculate1_IsValid()
        {
            var listOfInputs = GetInput();

            var position = _calculator.Calculate1(listOfInputs);

            Assert.AreEqual(15, position.Horizontal);
            Assert.AreEqual(10, position.Depth);
            Assert.AreEqual(150, position.Compute());
        }

        [Test]
        public void Calculate2_IsValid()
        {
            var listOfInputs = GetInput();

            var position = _calculator.Calculate2(listOfInputs);

            Assert.AreEqual(15, position.Horizontal);
            Assert.AreEqual(60, position.Depth);
            Assert.AreEqual(900, position.Compute());
        }

        private List<LineContentDay2> GetInput()
        {
            return new List<LineContentDay2>() {
                new LineContentDay2() { Direction = EnumDirections.forward, Movement = 5 },
                new LineContentDay2() { Direction = EnumDirections.down, Movement = 5 },
                new LineContentDay2() { Direction = EnumDirections.forward, Movement = 8 },
                new LineContentDay2() { Direction = EnumDirections.up, Movement = 3 },
                new LineContentDay2() { Direction = EnumDirections.down, Movement = 8 },
                new LineContentDay2() { Direction = EnumDirections.forward, Movement = 2 }};
        }
    }
}
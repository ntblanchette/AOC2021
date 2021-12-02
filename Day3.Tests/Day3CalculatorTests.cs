using NUnit.Framework;

namespace Day3.Tests
{
    public class Tests
    {
        private Day3Calculator _calculator = new();

        [SetUp]
        public void Setup()
        {
            _calculator = new Day3Calculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
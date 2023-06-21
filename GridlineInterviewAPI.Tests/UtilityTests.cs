using GridlineInterviewAPI.Core;
using NUnit.Framework;

namespace GridlineInterviewAPI.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringReverseTest()
        {
            Assert.That(Utility.Reverse("Testing"), Is.EqualTo("gnitseT"));
        }
    }
}
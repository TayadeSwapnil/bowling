using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BowlingBall.Tests
{
    [TestClass]
    public class SpareFrameTest
    {
        Frame _standardFrame;

        [TestInitialize]
        public void TestInitialize()
        {
            _standardFrame = new StanderdFrame();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _standardFrame = null;
        }

        [TestMethod]
        public void TestSpareFrameScoreTen()
        {
            // Arrange
            // Act
            var frame = _standardFrame.Roll(4).Roll(6);
            // Assert
            Assert.AreEqual(10, frame.GetScore());
        }

        [TestMethod]
        public void TestSpareFrameCompletedOnTwoRoles()
        {
            // Arrange
            // Act
            var frame = _standardFrame.Roll(4).Roll(6);
            // Assert
            Assert.IsTrue(frame.IsCompleted);
        }
    }
}

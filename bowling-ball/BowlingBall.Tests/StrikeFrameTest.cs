using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BowlingBall.Tests
{
    [TestClass]
    public class StrikeFrameTest
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
        public void TestStrikeFrameScoreTen()
        {
            // Arrange
            // Act
            var frame = _standardFrame.Roll(10);
            // Assert
            Assert.AreEqual(10, frame.GetScore());
        }

        [TestMethod]
        public void TestStrikeFrameCompletedAfterFirstAttempt()
        {
            // Arrange
            // Act
            var frame = _standardFrame.Roll(10);
            // Assert
            Assert.IsTrue(frame.IsCompleted);
        }
    }
}

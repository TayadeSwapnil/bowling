using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BowlingBall;

namespace BowlingBall.Tests
{
    [TestClass]
    public class StanderdFrameTest
    {
        Frame _standerdFrame;

        [TestInitialize]
        public void TestInitialize()
        {
            _standerdFrame = new StanderdFrame();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _standerdFrame = null;
        }

        [TestMethod]
        public void TestStandardFrameBecomesStrikeFrame()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(10);
            // Assert
            Assert.IsInstanceOfType(frame, typeof(StrikeFrame));
        }

        [TestMethod]
        public void TestStandardFrameBecomesSpareFrame()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(5);
            frame = frame.Roll(5);
            // Assert
            Assert.IsInstanceOfType(frame, typeof(SpareFrame));
        }

        [TestMethod]
        public void TestStandardFrameRemainsStandardFrame()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(9).Roll(0);
            // Assert
            Assert.IsInstanceOfType(frame, typeof(StanderdFrame));
        }

        [TestMethod]
        public void TestStandardFrameReturnScoreFromBothRoles()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(9);
            frame = frame.Roll(0);
            // Assert
            Assert.AreEqual(9, frame.GetScore());
        }

        [TestMethod]
        public void TestStandardFrameNotCompletedOnFirstRole()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(9);
            // Assert
            Assert.IsFalse(frame.IsCompleted);
        }

        [TestMethod]
        public void TestStandardFrameCompletedOnSecondRole()
        {
            // Arrange
            // Act
            var frame = _standerdFrame.Roll(0).Roll(0);
            // Assert
            Assert.IsTrue(frame.IsCompleted);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FinalFrameTest
    {
        FinalFrame _finalFrame;

        [TestInitialize]
        public void TestInitialize()
        {
            _finalFrame = new FinalFrame();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _finalFrame = null;
        }

        [TestMethod]
        public void TestFinalFrameAllowThirdRoleIfAllPinsAreDownInFirstAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(10);
            _finalFrame.Roll(5);
            _finalFrame.Roll(5);
            // Assert
            Assert.AreEqual(5, _finalFrame.Role3);
        }

        [TestMethod]
        public void TestFinalFrameAllowThirdRoleIfAllPinsAreDownInSecondAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(5);
            _finalFrame.Roll(5);
            _finalFrame.Roll(2);
            // Assert
            Assert.AreEqual(2, _finalFrame.Role3);
        }

        [TestMethod]
        public void TestFinalFrameCompletedIfAllPinsAreNotDownInSecondAttemptsAndRolledFinalBall()
        {
            // Arrange
            // Act
            _finalFrame.Roll(5);
            _finalFrame.Roll(5);
            _finalFrame.Roll(2);
            // Assert
            Assert.IsTrue(_finalFrame.IsCompleted);
        }

        [TestMethod]
        public void TestFinalFrameCompletedIfAllPinsAreNotDownInFirstAttemptAndRolledFinalBall()
        {
            // Arrange
            // Act
            _finalFrame.Roll(10);
            _finalFrame.Roll(2);
            _finalFrame.Roll(2);
            // Assert
            Assert.IsTrue(_finalFrame.IsCompleted);
        }

        [TestMethod]
        public void TestFinalFrameNotCompletedIfAllPinsAreDownInFirstAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(10);
            // Assert
            Assert.IsFalse(_finalFrame.IsCompleted);
        }

        [TestMethod]
        public void TestFinalFrameNotCompletedIfAllPinsAreDownInSecondAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(5);
            _finalFrame.Roll(5);
            // Assert
            Assert.IsFalse(_finalFrame.IsCompleted);
        }

        [TestMethod]
        public void TestFinalFrameScoreConsiderFirstTwoRolesForScoreIfAllPinsNotDownInTwoAttempts()
        {
            // Arrange
            // Act
            _finalFrame.Roll(5);
            _finalFrame.Roll(1);
            // Assert
            Assert.AreEqual(6, _finalFrame.Role1 + _finalFrame.Role2);
        }

        [TestMethod]
        public void TestFinalFrameScoreConsiderFirstThreeRolesForScoreIfAllPinsNotDownInFirstAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(10);// all pins down in first attempt
            _finalFrame.Roll(5);
            _finalFrame.Roll(2);
            // Assert
            Assert.AreEqual(17, _finalFrame.Role1 + _finalFrame.Role2 + _finalFrame.Role3);
        }

        [TestMethod]
        public void TestFinalFrameScoreConsiderFirstThreeRolesForScoreIfAllPinsNotDownInSecondAttempt()
        {
            // Arrange
            // Act
            _finalFrame.Roll(5);
            _finalFrame.Roll(5); // all pins down in second attemp
            _finalFrame.Roll(2);
            // Assert
            Assert.AreEqual(12, _finalFrame.Role1 + _finalFrame.Role2 + _finalFrame.Role3);
        }

        [TestMethod]
        public void TestFinalFrameScoreThirtyForAllStrike()
        {
            // Arrange
            // Act
            _finalFrame.Roll(10);
            _finalFrame.Roll(10);
            _finalFrame.Roll(10);
            // Assert
            Assert.AreEqual(30, _finalFrame.Role1 + _finalFrame.Role2 + _finalFrame.Role3);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameTest
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
        public void TestFrameAddValueToRoleOneOnFirstRole()
        {
            // Arrange
            // Act
            _standardFrame.Roll(2);
            // Assert
            Assert.AreEqual(2, _standardFrame.Role1);
            Assert.IsNull(_standardFrame.Role2);
        }

        [TestMethod]
        public void TestFrameAddValueToRoleTwoOnSecondRole()
        {
            // Arrange
            // Act
            _standardFrame.Roll(2).Roll(2);
            // Assert
            Assert.AreEqual(2, _standardFrame.Role2);
            Assert.IsNotNull(_standardFrame.Role2);
        }
    }
}

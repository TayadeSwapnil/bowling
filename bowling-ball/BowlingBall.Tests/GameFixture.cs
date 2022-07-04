using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game _game;

        [TestInitialize]
        public void TestInitialize()
        {
            _game = new Game();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _game = null;
        }

        [TestMethod]
        public void TestAllGutter()
        {
            // Arrange
            Roll(0, 20);

            // Act
            var score = _game.GetScore();

            //Assert
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void TestAllStanderdFrame()
        {
            // Arrange
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);
            Roll(2, times: 2);

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(40, score);
        }

        [TestMethod]
        public void TestAllStrikeFrame()
        {
            // Arrange
            RollStrike(times: 12);

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void TestAllSpareFrame()
        {
            // Arrange
            RollSpare(role1: 8, times: 10);          
            Roll(0); // Last role in final frame

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(172, score);
        }
       
        [TestMethod]
        public void TestAleternateStrikesFrames()
        {
            // Arrange
            RollStrike();
            RollGutter(times: 2);
            RollStrike();
            RollGutter(times: 2);
            RollStrike();
            RollGutter(times: 2);
            RollStrike();
            RollGutter(times: 2);
            RollStrike();           
            RollSpare(5); //Final Frame started
            RollStrike();

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(80, _game.GetScore());
        }

        [TestMethod]
        public void TestAleternateSpareFrames()
        {
            // Arrange
            RollSpare(5);
            RollGutter(times: 2);
            RollSpare(5);
            RollGutter(times: 2);
            RollSpare(5);
            RollGutter(times: 2);
            RollSpare(5);
            RollGutter(times: 2);
            RollSpare(5);          
            RollSpare(5); //Final Frame Started
            RollStrike();

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(75, score);
        }

        [TestMethod]
        public void TestAleternateStanderdFrames()
        {
            // Arrange
            Roll(3);
            Roll(3);
            RollGutter(times: 2);
            Roll(3);
            Roll(3);
            RollGutter(times: 2);
            Roll(3);
            Roll(3);
            RollGutter(times: 2);
            Roll(3);
            Roll(3);
            RollGutter(times: 2);
            Roll(3);
            Roll(3);           
            RollGutter(times: 2); //Final Frame

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(30, score);
        }

        [TestMethod]
        public void TestAllStikeFollewedBySpareFrame()
        {
            // Arrange
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5); // Final Frame
            RollStrike();

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(200, score);
        }

        [TestMethod]
        public void TestAllStikeFollewedByStanderd()
        {
            // Arrange
            RollStrike();
            Roll(2, times: 2);
            RollStrike();
            Roll(2, times: 2);
            RollStrike();
            Roll(2, times: 2);
            RollStrike();
            Roll(2, times: 2);
            RollStrike();
            Roll(2, times: 2); // Final Frame

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(90, score);
        }

        [TestMethod]
        public void TestAllSpareFollewedByStrikeFrame()
        {
            // Arrange
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike();
            RollSpare(5);
            RollStrike(); // Final Frame
            RollSpare(5);

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(200, score);
        }

        [TestMethod]
        public void TestAllSpareFollewedByStanderdFrame()
        {
            // Arrange
            RollSpare(5);
            Roll(2, times: 2);
            RollSpare(5);
            Roll(2, times: 2);
            RollSpare(5);
            Roll(2, times: 2);
            RollSpare(5);
            Roll(2, times: 2);
            RollStrike();
            Roll(2, times: 2); // Final Frame

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(82, score);
        }

        [TestMethod]
        public void TestScoreShouldBeOneEightSeven()
        {
            // Arrange
            RollStrike();
            RollSpare(9);
            RollSpare(5);
            Roll(7);
            Roll(2);
            RollStrike(times:3);
            Roll(9);
            RollGutter();
            RollSpare(8);            
            RollSpare(9); //Final frame started
            RollStrike();

            // Act
            var score = _game.GetScore();

            // Assert
            Assert.AreEqual(187, score);
        }

        private void Roll(int pins, int times = 1)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(pins);
        }
        private void RollSpare(int role1, int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(role1);
                _game.Roll(10 - role1);
            }
        }
        private void RollStrike(int times = 1)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(10);
        }
        private void RollGutter(int times = 1)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(0);
        }
    }
}

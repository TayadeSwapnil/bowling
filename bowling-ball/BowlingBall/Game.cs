using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private readonly Frame[] frames;
        private const int MAXFRAMES = 10;
        private int frameTracker;
        Frame currentFrame;

        public Game()
        {
            frames = new Frame[MAXFRAMES];
            currentFrame = new StanderdFrame();
        }

        public void Roll(int pins)
        {
            currentFrame = currentFrame.Roll(pins);

            if (currentFrame.IsCompleted)
                currentFrame = MoveToNextFrame();
        }

        private Frame MoveToNextFrame()
        {
            frames[frameTracker] = currentFrame;
            frameTracker++;

            if (frameTracker == MAXFRAMES - 1)
                return new FinalFrame();
            else
                return new StanderdFrame();
        }

        public int GetScore()
        {
            var score = 0;

            for (var i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];

                score += frame.GetScore();

                // Add bonus for strike and spare frame
                if (frame is StrikeFrame)
                {
                    var (role1, role2) = GetNextTwoBallsRolled(i + 1);
                    score += role1 + role2;
                }
                else if (frame is SpareFrame)
                {
                    var role1 = GetNextBallRolled(i + 1);
                    score += role1;
                }
            }

            return score;
        }

        private int GetNextBallRolled(int nextFrameIndex)
        {
            var nextFrame = frames[nextFrameIndex];
            return nextFrame.Role1.Value;
        }

        private (int, int) GetNextTwoBallsRolled(int nextFrameIndex)
        {
            var nextFrame = frames[nextFrameIndex];

            if (nextFrame is StrikeFrame)
            {
                var nextToNextFrame = frames[nextFrameIndex + 1];
                return (nextFrame.Role1.Value, nextToNextFrame.Role1.Value);
            }
            else
            {
                return (nextFrame.Role1.Value, nextFrame.Role2.Value);
            }
        }
    }

}


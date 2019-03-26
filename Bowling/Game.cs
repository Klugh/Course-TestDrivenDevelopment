using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        private int _score = 0;
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int score()
        {
            int firstInFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(firstInFrame))
                {
                    _score += 10 + nextTwoBallsForStrike(firstInFrame);
                    firstInFrame++;
                }
                else
                if (isSpare(firstInFrame))
                {
                    _score += 10 + nextBallForSpare(firstInFrame);
                    firstInFrame += 2;
                }
                else
                {
                    _score += twoBallsInFrame(firstInFrame);
                    firstInFrame += 2;
                }
            }
            return _score;
        }

        private int twoBallsInFrame(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1];
        }

        private int nextBallForSpare(int firstInFrame)
        {
            return rolls[firstInFrame + 2];
        }

        private int nextTwoBallsForStrike(int firstInFrame)
        {
            return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
        }

        private bool isStrike(int firstInFrame)
        {
            return rolls[firstInFrame] == 10;
        }

        private bool isSpare(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
        }
    }
}
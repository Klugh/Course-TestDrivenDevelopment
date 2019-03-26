using System;
using Xunit;

namespace Bowling.Unit.Tests
{
    public class TDDbyExample
    {
        private Game g;

        public TDDbyExample()
        {
            g = new Game();
        }

        private void rollMany(int n, int Pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.roll(Pins);
            }
        }

        private void rollSpare()
        {
            g.roll(5);
            g.roll(5);
        }

        private void rollStrike()
        {
            g.roll(10);
        }

        [Fact]
        public void RollingGutterGame_ShouldReturnScoreOfZero()
        {
            rollMany(20, 0);
            Assert.Equal(0, g.score());
        }

        [Fact]
        public void RollingAllOnes_ShouldReturnScoreOfTwenty()
        {
            rollMany(20, 1);
            Assert.Equal(20, g.score());
        }

        [Fact]
        public void RollingOneSpareFollowedBy3AndTheRestGutterBalls_ShouldReturnScoreOfSixteen()
        {
            rollSpare();
            g.roll(3);
            rollMany(17, 0);
            Assert.Equal(16, g.score());
        }

        [Fact]
        public void RollingOneStrikeFollowedBy3And4AndTheRestGutterBalls_ShouldReturnScoreOfTwentyFour()
        {
            rollStrike();
            g.roll(3);
            g.roll(4);
            rollMany(16, 0);
            Assert.Equal(24, g.score());
        }

        [Fact]
        public void RollingPerfectGame_ShouldReturnScoreOfThreeHundred()
        {
            rollMany(12, 10);
            Assert.Equal(300, g.score());
        }
    }
}

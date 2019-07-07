using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game _game; 
        public GameFixture()
        {
            _game = new Game();
        }

        [Fact]
        public void DummyTest()
        {
            // This is a dummy test that will always pass.
        }

        [Fact]
        public void AllZerosTest()
        {
            RollNTImes(0, 20);
            int score = _game.GetScore();

            Assert.Equal(0, score);
        }

        [Fact]
        public void AllOnesTest()
        {
            RollNTImes(1, 20);
            int score = _game.GetScore();

            Assert.Equal(20, score);
        }

        [Fact]
        public void OneSpareTest()
        {
            _game.Roll(4);
            _game.Roll(6);
            _game.Roll(4);
            RollNTImes(0, 17);

            Assert.Equal(18, _game.GetScore());
        }

        [Fact]
        public void OneStrikeTest()
        {
            _game.Roll(10);
            _game.Roll(5);
            _game.Roll(4);
            RollNTImes(0, 16);

            Assert.Equal(28, _game.GetScore());
        }

        [Fact]
        public void AllStrikeTest()
        {
            RollNTImes(10, 12);

            Assert.Equal(300, _game.GetScore());
        }

        private void RollNTImes(int pins, int times)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(pins);
        }
    }
}
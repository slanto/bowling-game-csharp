using System;
using System.Reflection;
using System.Resources;
using FluentAssertions;
using Xunit;

namespace BowlingGame.Test
{
    public class GameTest
    {
        [Fact]
        public void GivenZeroKnockedDownPins_WhenScoreIsCalled_ThenZeroIsReturned()
        {
            var game = new Game();

            RollMany(game, 20, 0);
                      
            game.Score().Should().Be(0, "global score for all frames without knocked down pins is 0");
        }
        
        [Fact]
        public void GivenOneKnockedDownPinInEachTry_WhenScoreIsCalled_ThenTwentyIsReturned()
        {
            var game = new Game();

            RollMany(game, 20, 1);

            game.Score().Should().Be(20, "global score for all tries with one knocked down pins is 20");
        }

        [Fact]
        public void GivenOneSpare_WhenScoreIsCalled_ThenSixteenIsReturned()
        {
            var game = new Game();

            RollSpare(game);
            game.Roll(3);
            RollMany(game, 17, 0);
            
            game.Score().Should().Be(16, "global score for one spare is 16");
        }

        private static void RollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }

        private static void RollMany(Game game, int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
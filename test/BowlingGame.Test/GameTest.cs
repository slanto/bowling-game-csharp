using System;
using System.Reflection;
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
        public void GivenOneKnockedDownPinInTry_WhenScoreIsCalled_ThenTwentyIsReturned()
        {
            var game = new Game();

            RollMany(game, 20, 1);

            game.Score().Should().Be(20, "global score for all tries with one knocked down pins is 20");
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
using System;

namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;
        
        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var roll = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }                
            }

            return score;
        }

        private int SumOfBallsInFrame(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return _rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return _rolls[roll + 1] + _rolls[roll + 2];
        }
        
        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }
    }
}
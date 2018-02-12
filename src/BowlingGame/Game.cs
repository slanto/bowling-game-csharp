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
                if (IsSpare(roll))
                {
                    score += 10 + _rolls[roll + 2];
                }
                else
                {
                    score += _rolls[roll] + _rolls[roll + 1];
                }
                
                roll += 2;
            }

            return score;
        }

        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }
    }
}
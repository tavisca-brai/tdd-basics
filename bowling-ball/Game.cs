using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int index = 0;
            for(int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(index))
                {
                    score += 10 + StrikeBonus(index);
                    index++;
                }else if (IsSpare(index))
                {
                    score += 10 + SpareBonus(index);
                    index += 2;
                }
                else
                {
                    score += SumOfRolls(index);
                    index += 2;
                }

                
            }

            return score;
        }

        private bool IsSpare(int index)
        {
            if (rolls[index] + rolls[index + 1] == 10)
                return true;
            else
                return false;
        }
        private int SpareBonus(int index)
        {
            return rolls[index + 2];
        }
        private bool IsStrike(int index)
        {
            if (rolls[index] == 10)
                return true;
            else
                return false;
        }
        private int StrikeBonus(int index)
        {
            return rolls[index + 1] + rolls[index + 2];
        }
        private int SumOfRolls(int index)
        {
            return rolls[index] + rolls[index + 1];
        }
    }
}
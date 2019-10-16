using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        static bool notAWinner;
        readonly Random Rand;

        public GameRunner(Random random)
        {
            Rand = random;
        }

        public static void Main(String[] args)
        {
            var runner = new GameRunner(new Random());
            runner.DoMain(args);
        }

        public void DoMain(String[] args)
        {
            Game aGame = new Game();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do
            {
                aGame.Roll(Rand.Next(5) + 1);

                if (Rand.Next(9) == 7)
                {
                    notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }

}


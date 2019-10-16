using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinner;
        private readonly Random Rand;

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

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            do
            {
                aGame.roll(Rand.Next(5) + 1);

                if (Rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }

}


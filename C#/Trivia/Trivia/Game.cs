using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    public class Game
    {
        List<string> players = new List<string>();

        int[] places = new int[6];
        int[] purses = new int[6];

        bool[] inPenaltyBox = new bool[6];

        int currentPlayer;
        bool isGettingOutOfPenaltyBox;

        Questions _questions = new Questions();

        public void Add(string playerName)
        {
            players.Add(playerName);
            places[HowManyPlayers()] = 0;
            purses[HowManyPlayers()] = 0;
            inPenaltyBox[HowManyPlayers()] = false;
            Console.WriteLine($"{playerName} was added");
            Console.WriteLine("They are player number " + HowManyPlayers());
        }

        int HowManyPlayers() => players.Count;

        public void Roll(int roll)
        {
            Console.WriteLine($"{players[currentPlayer]} is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine($"{players[currentPlayer]} is getting out of the penalty box");
                    places[currentPlayer] = places[currentPlayer] + roll;
                    if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                    Console.WriteLine(players[currentPlayer]
                            + "'s new location is "
                            + places[currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    _questions.AskQuestion(CurrentCategory());
                }
                else
                {
                    Console.WriteLine($"{players[currentPlayer]} is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                places[currentPlayer] = places[currentPlayer] + roll;
                if (places[currentPlayer] > 11) places[currentPlayer] = places[currentPlayer] - 12;

                Console.WriteLine($"{players[currentPlayer]}'s new location is {places[currentPlayer]}");
                Console.WriteLine("The category is " + CurrentCategory());
                _questions.AskQuestion(CurrentCategory());
            }
        }

        string CurrentCategory()
        {
            var place = places[currentPlayer] %4;

            if (place == 0) return "Pop";
            if (place == 1) return "Science";
            if (place == 2) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;

            if (inPenaltyBox[currentPlayer])
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    purses[currentPlayer]++;
                    Console.WriteLine($"{players[currentPlayer]} now has {purses[currentPlayer]} Gold Coins.");

                    winner = DidPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
                }

                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            purses[currentPlayer]++;
            Console.WriteLine($"{players[currentPlayer]} now has {purses[currentPlayer]} Gold Coins.");

            winner = DidPlayerWin();
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }

        bool DidPlayerWin()
        {
            return purses[currentPlayer] != 6;
        }
    }

}

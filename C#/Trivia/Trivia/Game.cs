using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    public class Game
    {
        List<string> players = new List<string>();

        int[] _places = new int[6];
        int[] _purses = new int[6];

        bool[] _inPenaltyBox = new bool[6];

        int _currentPlayer;
        bool _isGettingOutOfPenaltyBox;

        Questions _questions = new Questions();

        public void Add(string playerName)
        {
            players.Add(playerName);
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;
            Console.WriteLine($"{playerName} was added");
            Console.WriteLine($"They are player number {HowManyPlayers()}");
        }

        int HowManyPlayers() => players.Count;

        public void Roll(int roll)
        {
            Console.WriteLine($"{players[_currentPlayer]} is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine($"{players[_currentPlayer]} is getting out of the penalty box");
                    _places[_currentPlayer] = _places[_currentPlayer] + roll;
                    if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                    Console.WriteLine(players[_currentPlayer]
                            + "'s new location is "
                            + _places[_currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    _questions.AskQuestion(CurrentCategory());
                }
                else
                {
                    Console.WriteLine($"{players[_currentPlayer]} is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                _places[_currentPlayer] = _places[_currentPlayer] + roll;
                if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                Console.WriteLine($"{players[_currentPlayer]}'s new location is {_places[_currentPlayer]}");
                Console.WriteLine("The category is " + CurrentCategory());
                _questions.AskQuestion(CurrentCategory());
            }
        }

        string CurrentCategory()
        {
            var place = _places[_currentPlayer] %4;

            if (place == 0) return "Pop";
            if (place == 1) return "Science";
            if (place == 2) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;

            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _purses[_currentPlayer]++;
                    Console.WriteLine($"{players[_currentPlayer]} now has {_purses[_currentPlayer]} Gold Coins.");

                    winner = DidPlayerWin();
                    _currentPlayer++;
                    if (_currentPlayer == players.Count) _currentPlayer = 0;

                    return winner;
                }

                _currentPlayer++;
                if (_currentPlayer == players.Count) _currentPlayer = 0;
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _purses[_currentPlayer]++;
            Console.WriteLine($"{players[_currentPlayer]} now has {_purses[_currentPlayer]} Gold Coins.");

            winner = DidPlayerWin();
            _currentPlayer++;
            if (_currentPlayer == players.Count) _currentPlayer = 0;

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == players.Count) _currentPlayer = 0;
            return true;
        }

        bool DidPlayerWin()
        {
            return _purses[_currentPlayer] != 6;
        }
    }

}

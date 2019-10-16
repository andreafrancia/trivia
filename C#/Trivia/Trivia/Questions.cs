using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    public class Questions
    {
        Dictionary<string, LinkedList<string>> _questions;

        public Questions()
        {
            _questions = new Dictionary<string, LinkedList<string>>();
            _questions.Add("Pop", new LinkedList<string>());
            _questions.Add("Science", new LinkedList<string>());
            _questions.Add("Sports", new LinkedList<string>());
            _questions.Add("Rock", new LinkedList<string>());

            for (var i = 0; i < 50; i++)
            {
                _questions["Pop"].AddLast(CreateQuestion(i, "Pop"));
                _questions["Science"].AddLast(CreateQuestion(i, "Science"));
                _questions["Sports"].AddLast(CreateQuestion(i, "Sports"));
                _questions["Rock"].AddLast(CreateQuestion(i, "Rock"));
            }
        }

        string CreateQuestion(int index, string theme)
        {
            return theme + " Question " + index;
        }

        public void AskQuestion(string currentCategory)
        {
            Console.WriteLine(_questions[currentCategory].First());
            _questions[currentCategory].RemoveFirst();
        }
    }
}
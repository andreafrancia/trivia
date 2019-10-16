using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyTrivia
{
    public class Questions
    {

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        public Questions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(CreateQuestion(i, "Sports"));
                rockQuestions.AddLast(CreateQuestion(i, "Rock"));
            }
        }


        string CreateQuestion(int index, string theme)
        {
            return theme + " Question " + index;
        }

        public void AskQuestion(string currentCategory)
        {
            if (currentCategory == "Pop")
            {
                AskQuestionAndRemove(popQuestions);
            }
            if (currentCategory == "Science")
            {
                AskQuestionAndRemove(scienceQuestions);
            }
            if (currentCategory == "Sports")
            {
                AskQuestionAndRemove(sportsQuestions);
            }
            if (currentCategory == "Rock")
            {
                AskQuestionAndRemove(rockQuestions);
            }
        }

        void AskQuestionAndRemove(LinkedList<string> questionsList)
        {
            Console.WriteLine(questionsList.First());
            questionsList.RemoveFirst();
        }
    }
}
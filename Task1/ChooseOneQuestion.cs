using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class ChooseOneQuestion : Question,ICloneable,IComparable
    {
        public ChooseOneQuestion(int id, string body, int marks,AnswerList correctAnswer, AnswerList choices) : base(id, body, marks, QuestionType.ChooseOne, correctAnswer, choices)
        {
        }

        public object Clone()
        {
            return new ChooseOneQuestion(Id, Body, Marks, CorrectAnswer,Choices);
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj.GetType() != typeof(Point)) return 1;
            ChooseOneQuestion chooseOneQuestion = (ChooseOneQuestion)obj;
            return Body.CompareTo(chooseOneQuestion.Body);
        }
        public override string ToString(int Qnum)
        {
            List<string> ChoicesStr = new List<string>();
            for (int i = 0; i < Choices.Count; i++)
            {
                ChoicesStr.Add($"  {i + 1}. {Choices[i]}");
            }

            return $"Question {Qnum}: {Body} [{Marks} Points] [Choose One Answer]\n" +
                   string.Join("\n", ChoicesStr);
        }
    }
}

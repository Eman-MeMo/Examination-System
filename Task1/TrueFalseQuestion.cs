using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class TrueFalseQuestion : Question,ICloneable,IComparable
    {
        public TrueFalseQuestion(int id, string body, int marks, AnswerList correctAnswer) : base(id, body, marks, QuestionType.TrueFalse, correctAnswer, null)
        {
            Choices = new AnswerList(){
                new Answer("True"),
                new Answer("False")
            };
        }

        public object Clone()
        {
            return new TrueFalseQuestion(Id,Body,Marks,CorrectAnswer);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj.GetType() != typeof(Point)) return 1;
            TrueFalseQuestion trueFalseQuestion = (TrueFalseQuestion)obj;
            return Body.CompareTo(trueFalseQuestion.Body);
        }

        public override string ToString(int Qnum)
        {
            List<string> ChoicesStr = new List<string>();
            for (int i = 0; i < Choices.Count; i++)
            {
                ChoicesStr.Add($"  {i + 1}. {Choices[i]}");//1. Test
            }

            return $"Question{Qnum}: {Body}   [{Marks} Points] [True/False]\n" +
                   string.Join("\n", ChoicesStr);
        }
    }
}

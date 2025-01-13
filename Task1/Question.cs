using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal abstract class Question
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public QuestionType Header { get; set; }
        public AnswerList CorrectAnswer { get; set; }
        public AnswerList Choices { get; set; }
        protected Question(int id,string body,int marks,QuestionType header,AnswerList CorAnswer,AnswerList answers)
        {
            Id = id;
            Body = body;
            Marks = marks;
            Header = header;
            Choices = answers;
            CorrectAnswer = CorAnswer;
        }
        public abstract string ToString(int Qnum);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class FinalExam : Exam,IExam<Question, AnswerList>
    {
        public int TotalMarks { get; set; }
        public int PassMarks { get; set; }
        public int StudentMarks { get; set; }
        public bool Passed { get; set; }
        public FinalExam(int id, string name, int numQuestions, Subject sub, TimeSpan duration) : base(id, name, numQuestions, sub,duration)
        {

        }
        public FinalExam(int id, string name, int numQuestions, Subject sub, TimeSpan duration, ExamMode _mode) : base(id, name, numQuestions, sub,duration, _mode)
        {

        }
        public override void Evaluate() 
        {  
            foreach (var item in StudentAnwers)
            {
                if (item.Key.CorrectAnswer.Equals(item.Value))
                {
                    StudentMarks += item.Key.Marks;
                }
                TotalMarks += item.Key.Marks;
            }
            Passed=StudentMarks>=TotalMarks/2;
            
        }
        public override void ShowResult()
        {
            Console.WriteLine();
            Console.WriteLine("=============================== Result ===============================");
            if (Passed)
                Console.WriteLine("Congratulations! You passed this exam!");
            else
                Console.WriteLine("Unfortunately, you failed this exam.");
            Console.WriteLine($"Final exam score: {StudentMarks}");
            Console.WriteLine($"Total Marks = {TotalMarks}");
        }
    }
}

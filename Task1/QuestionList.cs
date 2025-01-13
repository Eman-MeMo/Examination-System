using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    internal class QuestionList : List<Question>
    {
        public string FilePath { get; set; }
        public void Add(Question q)
        {
            base.Add(q);
            if (FilePath == null)
            {
                Console.WriteLine("File Path is Empty!");
            }
            try
            {
                using (TextWriter writer = new StreamWriter(FilePath, append: true))
                {
                    string correctAnswers = "";
                    foreach (var correct in q.CorrectAnswer)
                    {
                        correctAnswers += correct.Body + ", ";
                    }
                    correctAnswers = correctAnswers.TrimEnd(',', ' ');
                    writer.WriteLine($"{q.ToString(q.Id)}\nCorrect Answer: {correctAnswers}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during adding question to Exam File: {ex.Message}");
            }
        }
    }
}

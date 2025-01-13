using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class PracticeExam : Exam,IExam<Question,AnswerList>
    {
        List<string> SummaryOutput {  get; set; }
        public PracticeExam(int id, string name, int numQuestions, Subject sub, TimeSpan duration) : base(id, name, numQuestions, sub, duration)
        {
            
        }
        public PracticeExam(int id, string name, int numQuestions, Subject sub, TimeSpan duration, ExamMode _mode) : base(id, name, numQuestions, sub,duration, _mode)
        {

        }

        public override void Evaluate()
        {
            SummaryOutput = new List<string>();
            int counter = 1;
            foreach (var item in StudentAnwers)
            {
                
                if (item.Key.CorrectAnswer.Count > 1) //ChooseAllQuestion
                {
                    
                    bool isCorrect = true;
                    if (item.Key.CorrectAnswer.Count != item.Value.Count)
                    {
                        isCorrect = false;
                    }
                    else
                    {
                        int i = 0;
                        foreach (var element in item.Key.CorrectAnswer)
                        {
                            if (item.Value[i].Body != element.Body)
                                 isCorrect = false;
                            i++;
                        }
                    }
                    string correctAnswers = "";
                    foreach (var correct in item.Key.CorrectAnswer)
                    {
                        correctAnswers += correct.Body + ", ";
                    }
                    correctAnswers = correctAnswers.TrimEnd(',', ' ');
                    if (isCorrect)
                    {
                        SummaryOutput.Add($"Question {counter}: Correct! The correct answers are: {correctAnswers}.");
                    }
                    else
                    {
                        SummaryOutput.Add($"Question {counter}: Not Correct! The correct answers are: {correctAnswers}");
                    }
                }
                else 
                {
                    var correctAnswerBody = item.Key.CorrectAnswer[0].Body;
                    if (correctAnswerBody.Equals(item.Value[0].Body))
                    {
                        SummaryOutput.Add($"Question {counter}: Correct! The correct answer is {correctAnswerBody}.");
                    }
                    else
                    {
                        SummaryOutput.Add($"Question {counter}: Not Correct! The correct answer is {correctAnswerBody}");
                    }
                }
                counter++;
            }
        }
        public override void ShowResult()
        {
            Console.WriteLine();
            Console.WriteLine("=============================== Model Answer ===============================");
            foreach (var res in SummaryOutput)
            {
                Console.WriteLine(res);
            }
        }
    }

}

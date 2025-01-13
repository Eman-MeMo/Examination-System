using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    internal abstract class Exam:IExam<Question,AnswerList>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Number_Of_Questions { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<Question, AnswerList> StudentAnwers { get; set; }
        public Subject subject { get; set; }
        public ExamMode Status { get; set; }
        public Exam(int id, string name, int numQuestions, Subject sub,TimeSpan duration) :this(id,name,numQuestions,sub,duration,ExamMode.Queued)
        {

        }
        public Exam(int id, string name, int numQuestions,Subject sub,TimeSpan duration,ExamMode _mode)
        {
            Id = id;
            Name = name;
            Number_Of_Questions = numQuestions;
            subject = sub;
            Duration = duration;
            Status = _mode;
            StudentAnwers = new Dictionary<Question, AnswerList>();
            Questions = new QuestionList();
            Questions.FilePath=$"{name} Questions.txt";
            if (!Questions.FilePath.EndsWith(".txt"))
            {
                Questions.FilePath += ".txt";
            }
        }
        public void AddQuestion(Question q)
        {
            if (Questions.Count < Number_Of_Questions)
                Questions.Add(q);
            else
                Console.WriteLine("Number of Questions at this Exam is exceeded!");
        }
        public void StoreAnswers(Question q, AnswerList ans)
        {
             StudentAnwers.Add(q, ans);
        }
        public void RetrieveQuestions() 
        {
            string filePath = $"{Name} Questions.txt";
            List<Question> questions = new List<Question>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    string body = string.Empty;
                    int marks = 0;
                    AnswerList choices = null;
                    AnswerList correctAnswer = null;
                    QuestionType type = QuestionType.TrueFalse;

                    while ((line = reader.ReadLine()) != null)//Question1: C# supports multiple inheritance through classes.   [2 Points] [True/False]
                    {
                        body = string.Empty;
                        correctAnswer = new AnswerList();
                        choices = new AnswerList();
                        if (line.StartsWith("Question"))
                        {
                            var questionParts = line.Split(':');
                            string questionIdPart = questionParts[0].Trim();//Question1
                            body = questionParts[1].Trim();//C# supports multiple inheritance through classes.   [2 Points] [True/False]
                            int questionId = 0;

                            var questionIdMatch = Regex.Match(questionIdPart, @"\d+");//1
                            if (questionIdMatch.Success)
                            {
                                questionId = int.Parse(questionIdMatch.Value);
                            }

                            int pointsIndex = body.IndexOf("[");
                            if (pointsIndex != -1)
                            {
                                string pointsPart = body.Substring(pointsIndex).Trim('[', ']'); //2 Points
                                if (pointsPart.Contains("Points"))
                                {
                                    var marksParts = pointsPart.Split(' ');//2
                                    if (marksParts.Length > 0 && int.TryParse(marksParts[0], out marks))
                                    {
                                        body = body.Substring(0, pointsIndex).Trim(); //C# supports multiple inheritance through classes.
                                    }
                                }
                            }
                            if (line.Contains("[True/False]"))
                            {
                                type = QuestionType.TrueFalse;
                                line.Substring(0, line.IndexOf("[True/False]")).Trim();
                            }
                            else if (line.Contains("[Choose One Answer]"))
                            {
                                type = QuestionType.ChooseOne;
                                line.Substring(0, line.IndexOf("[Choose One Answer]")).Trim();
                            }
                            else if (line.Contains("[Choose Multiple Answers]"))
                            {
                                type = QuestionType.ChooseAll;
                                line.Substring(0, line.IndexOf("[Choose Multiple Answers]")).Trim();
                            }

                            while ((line = reader.ReadLine()) != null && !line.StartsWith("Correct Answer:"))
                            {
                                if (line.Contains("."))
                                {
                                    string choiceText = line.Substring(line.IndexOf(". ") + 1).Trim(); // 1. Answer
                                    choices.Add(new Answer(choiceText));
                                }
                            }
                            if (line.StartsWith("Correct Answer:"))//Correct Answer: int, float
                            {
                                string correctAnswerText = line.Split(':')[1].Trim();//int, float
                                if (correctAnswerText.Contains(","))
                                {
                                    string[] correctAnswers = correctAnswerText.Split(','); //["int","float"]
                                    foreach (string answer in correctAnswers)
                                    {
                                        correctAnswer.Add(new Answer(answer.Trim()));
                                    }
                                }
                                else//False
                                {
                                    correctAnswer.Add(new Answer(correctAnswerText.Trim()));
                                }
                            }
                            if (type == QuestionType.TrueFalse)
                            {
                                questions.Add(new TrueFalseQuestion(questionId, body, marks, correctAnswer));
                            }
                            else if (type == QuestionType.ChooseOne)
                            {
                                questions.Add(new ChooseOneQuestion(questionId, body, marks, correctAnswer, choices));
                            }
                            else if (type == QuestionType.ChooseAll)
                            {
                                questions.Add(new ChooseAllQuestion(questionId, body, marks, correctAnswer, choices));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the files: {ex.Message}");
            }
            Questions.AddRange(questions);
        }
        public void ShowExam()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Starting Exam: {Name} - Duration: {FormatDuration(Duration)} - Question Number: {Number_Of_Questions}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.Add(Duration);

            int counter = 1;
            foreach (Question q in Questions)
            {
                if (DateTime.Now >= endTime)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Time is up! Exam has ended.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                Console.WriteLine(q.ToString(counter));
                do
                {
                    try
                    {
                        if (q is ChooseAllQuestion)
                        {
                            Console.Write("\nEnter answer numbers separated by commas, like 1,2,3: ");
                            string[] ans = Console.ReadLine().Split(",");
                            AnswerList answers = new AnswerList();

                            foreach (string s in ans)
                            {
                                answers.Add(q.Choices[(int.Parse(s)) - 1]);
                            }
                            StoreAnswers(q, answers);
                            break;
                        }
                        else
                        {
                            Console.Write($"\nEnter Answer Number: ");
                            int ans = int.Parse(Console.ReadLine());
                            StoreAnswers(q, new AnswerList() { q.Choices[ans - 1] });
                            break;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Format, Please Enter Integer Values");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid Inputs");
                    }
                } while (true);

                counter++;
            }
            Evaluate();
            ShowResult();
            Status = ExamMode.Finished;
        }

        public abstract void Evaluate();
        public abstract void ShowResult();
        private string FormatDuration(TimeSpan duration)
        {
            if (duration.TotalHours >= 1)
            {
                int hours = (int)duration.TotalHours;
                int minutes = duration.Minutes;
                return $"{hours} hour{(hours > 1 ? "s" : "")} {minutes} minute{(minutes != 1 ? "s" : "")}";
            }
            else
            {
                return $"{duration.Minutes} minute{(duration.Minutes != 1 ? "s" : "")}";
            }
        }
    }
}

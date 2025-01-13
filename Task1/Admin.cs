using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Admin:User
    {
        public Admin(int id, string name, string email, string pass, string phoneNum, string address): base(id, name, email, pass, phoneNum, address) { }
        public void ManageExams()
        {
            List<Subject> subjects = CommunityData.GetSubjects();
            List< Exam > exams = CommunityData.GetExams();

            bool continueManaging = true;
            do
            {
                Console.WriteLine("\nAvailable Subjects:");
                for (int i = 0; i < subjects.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {subjects[i].Name}");
                }

                Console.Write("Choose a subject (enter number): ");
                if (int.TryParse(Console.ReadLine(), out int subjectChoice) && subjectChoice > 0 && subjectChoice <= subjects.Count)
                {
                    Subject selectedSubject = subjects[subjectChoice - 1];

                    Console.WriteLine("\nExam Types:");
                    Console.WriteLine("1. Final Exam");
                    Console.WriteLine("2. Practical Exam");

                    Console.Write("Choose an exam type (enter number): ");
                    if (int.TryParse(Console.ReadLine(), out int examType) && (examType == 1 || examType == 2))
                    {
                        Exam chosenExam = examType == 1 ? exams.Find(e => e is FinalExam && e.subject==selectedSubject) : exams.Find(e => e is PracticeExam && e.subject == selectedSubject);

                        if (chosenExam != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine();
                            Console.WriteLine("Notifications:");
                            Console.WriteLine("--------------");
                            selectedSubject.StartExam(chosenExam);
                            Console.WriteLine();
                            Console.ForegroundColor= ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("No exam of the chosen type available.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid exam type choice.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid subject choice.");
                }

                Console.Write("Do you want to assign another exam? (yes/no): ");
                string choice = Console.ReadLine()?.Trim().ToLower();
                continueManaging = choice == "yes";

            } while (continueManaging);

            Console.WriteLine("Exam management completed.");
        }
    }
}

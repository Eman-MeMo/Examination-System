using System.Diagnostics.CodeAnalysis;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome To our Examination System!");
            Console.WriteLine("----------------------------------");
            bool continueProgram = true;

            do
            {
                Console.WriteLine("\nWelcome! Are you an:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Student");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (enter number): ");
                string userType = Console.ReadLine();

                if (userType == "1")
                {
                    Admin admin = null;
                    try
                    {
                        do
                        {
                            Console.Write("Enter Your Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter Your Password: ");
                            string pass = Console.ReadLine();
                            admin = (Admin)User.Login(email, pass, "Admin");

                            if (admin != null) break;
                        } while (true);

                        Console.WriteLine($"\nWelcome {admin.Name}!");
                        admin.ManageExams();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (userType == "2")
                {
                    Student student = null;
                    try
                    {
                        do
                        {
                            Console.Write("Enter Your Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter Your Password: ");
                            string pass = Console.ReadLine();
                            student = (Student)User.Login(email, pass, "Student");

                            if (student != null) break;
                        } while (true);

                        Console.WriteLine($"\nWelcome {student.Name}!");

                        try
                        {
                            Console.WriteLine("Choose Exam Type:");
                            Console.WriteLine("1. Final Exam");
                            Console.WriteLine("2. Practice Exam");
                            Console.Write("Enter Your Choice: ");
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    CommunityData.Display_Available_Exams("Final Exam", student);
                                    break;
                                case 2:
                                    CommunityData.Display_Available_Exams("Practice Exam", student);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid Format, Please Enter Integer Values.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Inputs.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (userType == "3")
                {
                    Console.WriteLine();
                    Console.WriteLine("Exiting program. Goodbye!");
                    continueProgram = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (continueProgram);
        }
    }
}

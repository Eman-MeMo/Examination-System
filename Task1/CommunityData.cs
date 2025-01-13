using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task1
{
    internal static class CommunityData
    {
        private static List<Question> Questions { get; set; }
        private static List<Student> Students { get; set; }
        private static List<Subject> Subjects { get; set; }
        private static List<Exam> Exams { get; set; }

        private static List<Admin> Admins { get; set; }

        static CommunityData() {

            Subjects = new List<Subject>
            {
                new Subject(1, "C# Programming"),
                new Subject(2, "Object-Oriented Programming (OOP)"),
                new Subject(3, "SQL Basics"),
            };

            #region Questions
            //Questions = new List<Question>()
            //{
            //        //Questions at C#
            //        new TrueFalseQuestion(1, "C# supports multiple inheritance through classes.", 2,new AnswerList () { new Answer("False") }),
            //        new TrueFalseQuestion(2, "The 'int' type in C# can hold floating-point values.", 2,new AnswerList () { new Answer("False") }),
            //        new TrueFalseQuestion(3, "In C#, the 'static' keyword can be used to define class-level members.", 2,new AnswerList () { new Answer("True") }),

            //        new ChooseOneQuestion(1, "What keyword is used to declare a constant in C#?", 2,
            //            new AnswerList(){new Answer("const") },
            //            new AnswerList(){ new Answer("const"), new Answer("static"), new Answer("readonly"), new Answer("var") }),

            //        new ChooseOneQuestion(2, "Which of the following is the correct syntax for a method in C#?", 2,
            //            new AnswerList () { new Answer("public void MethodName()") },
            //            new AnswerList(){ new Answer("public void MethodName()"), new Answer("public MethodName() void"), new Answer("MethodName() public void"), new Answer("void MethodName public()") }),


            //        new ChooseOneQuestion(2, "Which of the following is the default value of a boolean variable in C#?", 2,
            //            new AnswerList () { new Answer("false") },
            //            new AnswerList(){  new Answer("true") ,new Answer("false"), new Answer("null"), new Answer("0") }),

            //        new ChooseOneQuestion(3, "Which of the following types is a reference type in C#?", 2,
            //            new AnswerList () { new Answer("string") },
            //            new AnswerList(){  new Answer("int"), new Answer("float"), new Answer("string"), new Answer("char") }),

            //        new ChooseAllQuestion(1, "Which of the following are value types in C#?", 3,
            //            new AnswerList () { new Answer("int"),new Answer("double") },
            //            new AnswerList(){  new Answer("string"), new Answer("int"), new Answer("object"),new Answer("double"), }),

            //        new ChooseAllQuestion(2, "Which of the following are valid C# access modifiers?", 3,
            //            new AnswerList () { new Answer("public"), new Answer("private"), new Answer("protected") },
            //            new AnswerList(){ new Answer("public"), new Answer("private"), new Answer("protected"), new Answer("default") }),

            //        new ChooseAllQuestion(3, "Which of the following are correct data types in C#?", 3,
            //            new AnswerList () { new Answer("decimal"), new Answer("int"), new Answer("string") },
            //            new AnswerList(){  new Answer("decimal"), new Answer("int"), new Answer("string"), new Answer("list") }),

            //        new ChooseAllQuestion(4, "Which of the following are keywords in C#?", 3,
            //            new AnswerList () { new Answer("final"), new Answer("const"), new Answer("virtual") ,new Answer("static") },
            //            new AnswerList(){  new Answer("final"), new Answer("const"), new Answer("virtual") ,new Answer("static")}),

            //        new ChooseAllQuestion(5, "Which of the following are valid loops in C#?", 3,
            //            new AnswerList () { new Answer("foreach"), new Answer("while"), new Answer("for") },
            //            new AnswerList() { new Answer("foreach"), new Answer("while"), new Answer("for"), new Answer("repeat") }),

            //        // Questions at C# OOP 
            //        new TrueFalseQuestion(4, "In C#, a class can implement multiple interfaces.", 4, new AnswerList () { new Answer("True") }),
            //        new TrueFalseQuestion(5, "C# supports both method overloading and method overriding.", 4, new AnswerList () { new Answer("True") }),
            //        new TrueFalseQuestion(6, "In C#, the 'abstract' keyword is used to create classes that cannot be instantiated.", 4, new AnswerList () { new Answer("True") }),

            //        new ChooseOneQuestion(5, "Which keyword is used to declare an abstract class in C#?", 3,
            //            new AnswerList () { new Answer("abstract") },
            //            new AnswerList() {  new Answer("interface"), new Answer("virtual"), new Answer("abstract"), new Answer("static") }),

            //        new ChooseOneQuestion(6, "Which of the following is used to implement Encapsulation in C#?", 3,
            //            new AnswerList () { new Answer("Setter,Getter") },
            //            new AnswerList() {  new Answer("method overloading"), new Answer("method overriding"), new Answer("Setter,Getter"), new Answer("inheritance") }),

            //        new ChooseOneQuestion(7, "Which of the following is the base class for all classes in C#?", 3,
            //            new AnswerList () { new Answer("System.Object") },
            //            new AnswerList() {  new Answer("Console"), new Answer("BaseClass"), new Answer("Class"),new Answer("System.Object") }),

            //        new ChooseAllQuestion(4, "Which of the following can be inherited in C#?", 3,
            //            new AnswerList () { new Answer("class"),new Answer("interface") },
            //            new AnswerList(){ new Answer("class"), new Answer("enum"), new Answer("struct"), new Answer("interface") }),

            //        new ChooseAllQuestion(6, "Which of the following are NOT features of Object-Oriented Programming?", 4,
            //            new AnswerList () { new Answer("Assembly") },
            //            new AnswerList() {  new Answer("Inheritance"), new Answer("Polymorphism"), new Answer("Encapsulation"), new Answer("Assembly") }),

            //        new ChooseAllQuestion(7, "Which of the following are valid access modifiers in C#?", 4,
            //            new AnswerList () { new Answer("public"), new Answer("internal"),new Answer("private"), },
            //            new AnswerList() {  new Answer("public"), new Answer("internal"), new Answer("default"),new Answer("private"), }),

            //        new ChooseAllQuestion(8, "Which of the following can be used to achieve polymorphism in C#?", 4,
            //            new AnswerList () { new Answer("method overriding"), new Answer("method overloading"), },
            //            new AnswerList() { new Answer("method overriding"), new Answer("method overloading"), new Answer("inheritance"), new Answer("abstraction") }),

            //        new ChooseAllQuestion(9, "Which of the following are abstract in C#?", 4,
            //            new AnswerList () { new Answer("abstract class"), new Answer("interface") },
            //            new AnswerList() { new Answer("abstract class"), new Answer("interface"), new Answer("enum"), new Answer("struct") }),

            //        // Questions at SQL
            //        new TrueFalseQuestion(7, "In SQL, the 'INNER JOIN' keyword returns records that have matching values in both tables.", 3, new AnswerList () { new Answer("True") }),
            //        new TrueFalseQuestion(8, "A 'LEFT JOIN' returns all records from the right table and matching records from the left table.", 3, new AnswerList () { new Answer("False") }),
            //        new TrueFalseQuestion(9, "SQL allows the use of the 'GROUP BY' clause to group rows that have the same values.", 3, new AnswerList () { new Answer("True") }),

            //        new ChooseOneQuestion(8, "Which SQL clause is used to filter records?", 3,
            //            new AnswerList () { new Answer("WHERE") },
            //            new AnswerList(){ new Answer("WHERE"), new Answer("ORDER BY"), new Answer("GROUP BY"), new Answer("HAVING") }),

            //        new ChooseOneQuestion(9, "Which SQL join returns only records that exist in both tables?", 3,
            //            new AnswerList () { new Answer("INNER JOIN") },
            //            new AnswerList(){  new Answer("LEFT JOIN"), new Answer("RIGHT JOIN"), new Answer("INNER JOIN"), new Answer("FULL JOIN") }),

            //        new ChooseOneQuestion(10, "Which SQL clause is used to group rows that have the same values?", 3,
            //            new AnswerList () { new Answer("GROUP BY") },
            //            new AnswerList(){  new Answer("ORDER BY"), new Answer("GROUP BY"), new Answer("HAVING"), new Answer("WHERE") }),

            //        new ChooseOneQuestion(11, "Which SQL command is used to delete a record from a table?", 3,
            //            new AnswerList () { new Answer("DELETE") },
            //            new AnswerList(){  new Answer("REMOVE"), new Answer("DROP"), new Answer("TRUNCATE"),new Answer("DELETE"), }),

            //        new ChooseOneQuestion(12, "Which SQL statement is used to retrieve data from a table?", 3,
            //            new AnswerList () { new Answer("SELECT") },
            //            new AnswerList(){  new Answer("GET"), new Answer("FETCH"), new Answer("RETRIEVE"),new Answer("SELECT"), }),

            //        new ChooseAllQuestion(10, "Which of the following are valid SQL commands?", 3,
            //            new AnswerList () { new Answer("INSERT"), new Answer("SELECT"), new Answer("UPDATE"), new Answer("MERGE") },
            //            new AnswerList() {  new Answer("INSERT"), new Answer("SELECT"), new Answer("UPDATE"), new Answer("MERGE") }),

            //        new ChooseAllQuestion(11, "Which of the following are SQL JOIN types?", 3,
            //            new AnswerList () { new Answer("INNER JOIN"), new Answer("LEFT JOIN"), new Answer("RIGHT JOIN"), new Answer("OUTER JOIN") },
            //            new AnswerList() { new Answer("INNER JOIN"), new Answer("LEFT JOIN"), new Answer("RIGHT JOIN"), new Answer("OUTER JOIN") }),

            //        new ChooseAllQuestion(12, "Which of the following SQL clauses are used for grouping data?", 3,
            //            new AnswerList () { new Answer("GROUP BY"),new Answer("HAVING") },
            //            new AnswerList() { new Answer("GROUP BY"), new Answer("ORDER BY"), new Answer("HAVING"), new Answer("WHERE") })
            //};
            #endregion

            Admins = new List<Admin>
            {
                new Admin(1,"eman","eman@gmail.com","159","123456789121","Cairo"),
            };
            
            Students = new List<Student>
            {
                new Student(1, "Ahmed Ali", "ahmed.ali@example.com","1234", "123-456-7890", "Street 123, Al-Nakheel"),
                new Student(2, "Fatima Al-Zahra", "fatima.alzahra@example.com","5678", "123-555-7890", "Street 456, Al-Zeitoun"),
                new Student(3, "Ali Mohamed", "ali.mohamed@example.com", "9101","123-666-7890", "Street 789, Al-Tamar"),
                new Student(4, "Sara Youssef", "sara.youssef@example.com","1213", "123-777-7890", "Street 123, Al-Burtuqal"),
                new Student(5, "Mahmoud Abdallah", "mahmoud.abdallah@example.com","1415", "123-888-7890", "Street 456, Al-Zohour"),
                new Student(6, "Dina Mostafa", "dina.mostafa@example.com","1617", "123-999-7890", "Street 789, Al-Sarou"),
                new Student(7, "Iman Ahmed", "iman.ahmed@example.com", "1819","123-000-7890", "Street 123, Al-Arz")
            };

            Exams = new List<Exam>()
            {
                new FinalExam(1, "Final Exam - C# Basics", 12, Subjects[0], TimeSpan.FromMinutes(30)),
                new PracticeExam(2, "Practice Exam - C# Basics", 12, Subjects[0], TimeSpan.FromMinutes(20)),

                new FinalExam(3, "Final Exam - Advanced C# OOP", 11, Subjects[1], TimeSpan.FromMinutes(40)),
                new PracticeExam(4, "Practice Exam - Advanced C# OOP", 11, Subjects[1], TimeSpan.FromMinutes(25)),

                new FinalExam(5, "Final Exam - SQL Server Basics", 11, Subjects[2], TimeSpan.FromMinutes(35)),
                new PracticeExam(6, "Practice Exam - SQL Server Basics", 11, Subjects[2], TimeSpan.FromMinutes(1))

            };

            //Register Student ot Subject
            #region
            Students[0].AddSubject(Subjects[0]);
            Students[0].AddSubject(Subjects[1]);

            Students[1].AddSubject(Subjects[2]);
            Students[1].AddSubject(Subjects[0]);

            Students[2].AddSubject(Subjects[1]);
            Students[2].AddSubject(Subjects[0]);

            Students[3].AddSubject(Subjects[1]);
            Students[3].AddSubject(Subjects[2]);

            Students[4].AddSubject(Subjects[2]);
            Students[4].AddSubject(Subjects[1]);

            Students[5].AddSubject(Subjects[0]);
            Students[5].AddSubject(Subjects[2]);

            Students[6].AddSubject(Subjects[0]);
            Students[6].AddSubject(Subjects[1]);
            Students[6].AddSubject(Subjects[2]);
            #endregion

            //Get Questions of Exams
            Exams[0].RetrieveQuestions();
            Exams[1].RetrieveQuestions();
            Exams[2].RetrieveQuestions();
            Exams[3].RetrieveQuestions();
            Exams[4].RetrieveQuestions();
            Exams[5].RetrieveQuestions();
            #region Get Questions of Exams
            //Exams[0].AddQuestion(Questions[0]);
            //Exams[0].AddQuestion(Questions[1]);
            //Exams[0].AddQuestion(Questions[2]);
            //Exams[0].AddQuestion(Questions[3]);
            //Exams[0].AddQuestion(Questions[4]);
            //Exams[0].AddQuestion(Questions[5]);
            //Exams[0].AddQuestion(Questions[6]);
            //Exams[0].AddQuestion(Questions[7]);
            //Exams[0].AddQuestion(Questions[8]);
            //Exams[0].AddQuestion(Questions[9]);
            //Exams[0].AddQuestion(Questions[10]);
            //Exams[0].AddQuestion(Questions[11]);

            //Exams[1].AddQuestion(Questions[0]);
            //Exams[1].AddQuestion(Questions[1]);
            //Exams[1].AddQuestion(Questions[2]);
            //Exams[1].AddQuestion(Questions[3]);
            //Exams[1].AddQuestion(Questions[4]);
            //Exams[1].AddQuestion(Questions[5]);
            //Exams[1].AddQuestion(Questions[6]);
            //Exams[1].AddQuestion(Questions[7]);
            //Exams[1].AddQuestion(Questions[8]);
            //Exams[1].AddQuestion(Questions[9]);
            //Exams[1].AddQuestion(Questions[10]);
            //Exams[1].AddQuestion(Questions[11]);


            //Exams[2].AddQuestion(Questions[12]);
            //Exams[2].AddQuestion(Questions[13]);
            //Exams[2].AddQuestion(Questions[14]);
            //Exams[2].AddQuestion(Questions[15]);
            //Exams[2].AddQuestion(Questions[16]);
            //Exams[2].AddQuestion(Questions[17]);
            //Exams[2].AddQuestion(Questions[18]);
            //Exams[2].AddQuestion(Questions[19]);
            //Exams[2].AddQuestion(Questions[20]);
            //Exams[2].AddQuestion(Questions[21]);
            //Exams[2].AddQuestion(Questions[22]);

            //Exams[3].AddQuestion(Questions[12]);
            //Exams[3].AddQuestion(Questions[13]);
            //Exams[3].AddQuestion(Questions[14]);
            //Exams[3].AddQuestion(Questions[15]);
            //Exams[3].AddQuestion(Questions[16]);
            //Exams[3].AddQuestion(Questions[17]);
            //Exams[3].AddQuestion(Questions[18]);
            //Exams[3].AddQuestion(Questions[19]);
            //Exams[3].AddQuestion(Questions[20]);
            //Exams[3].AddQuestion(Questions[21]);
            //Exams[3].AddQuestion(Questions[22]);

            //Exams[4].AddQuestion(Questions[23]);
            //Exams[4].AddQuestion(Questions[24]);
            //Exams[4].AddQuestion(Questions[25]);
            //Exams[4].AddQuestion(Questions[26]);
            //Exams[4].AddQuestion(Questions[27]);
            //Exams[4].AddQuestion(Questions[28]);
            //Exams[4].AddQuestion(Questions[30]);
            //Exams[4].AddQuestion(Questions[31]);

            //Exams[5].AddQuestion(Questions[23]);
            //Exams[5].AddQuestion(Questions[24]);
            //Exams[5].AddQuestion(Questions[25]);
            //Exams[5].AddQuestion(Questions[26]);
            //Exams[5].AddQuestion(Questions[27]);
            //Exams[5].AddQuestion(Questions[28]);
            //Exams[5].AddQuestion(Questions[30]);
            //Exams[5].AddQuestion(Questions[31]);
            #endregion
        }
        public static List<Admin> GetAdmins()
        {
            return Admins;
        }
        public static List<Student> GetStudents()
        {
            return Students;
        }
        public static List<Subject> GetSubjects()
        {
            return Subjects;
        }
        public static List<Question> GetQuestions()
        {
            return Questions;
        }
        public static List<Exam> GetExams()
        {
            return Exams;
        }
        public static List<Exam> GetExamsByType(string examType,Student s)
        {
            List <Exam> exms = new List <Exam>();
            if (examType == "Final Exam")
            {
                foreach (var ex in Exams)
                    if (ex is FinalExam && ex.Status==ExamMode.Starting && s.Subjects.Contains(ex.subject))
                        exms.Add(ex);
            }else if (examType == "Practice Exam")
            {
                foreach (var ex in Exams)
                    if (ex is PracticeExam && ex.Status == ExamMode.Starting && s.Subjects.Contains(ex.subject))
                        exms.Add(ex);
            }
            return exms;
        }
        public static void Display_Available_Exams(string examType,Student s)
        {
            Console.WriteLine($"\nAvailable {examType}s:");
            var exams = GetExamsByType(examType,s);

            if (exams.Count > 0)
            {
                for (int i = 0; i < exams.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {exams[i].Name} ({exams[i].subject.Name})");
                }
                do
                {
                    try
                    {
                        Console.Write("\nEnter the number of the exam you want to take: ");
                        int examChoice;
                        if (int.TryParse(Console.ReadLine(), out examChoice) && examChoice > 0 && examChoice <= exams.Count)
                        {
                            exams[examChoice - 1].ShowExam(); 
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Format, Please Enter Integer Values");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid Inputs");
                    }

                } while (true);
            }
            else
            {
                Console.WriteLine($"No {examType}s are available at the moment.");
            }
        }
    }
}

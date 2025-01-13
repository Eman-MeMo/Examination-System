using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Student:User
    {
        
        public List<Subject> Subjects { get; set; }
        public Student(int id, string name, string email,string pass, string phoneNum, string address):base(id,name,email,pass,phoneNum,address)
        { 
            Subjects = new List<Subject>();
        }
        public Student(int id,string name,string email,string pass,string phoneNum,string address, List<Subject> subjects): base(id, name, email, pass, phoneNum, address)
        {
            
            Subjects = subjects;
        }
        
        public void AddSubject(Subject s) //Registeration
        {
            Subjects.Add(s);
            s.NotifyStudents += Exam_Status_Notify;
        }
        public void RemoveSubject(Subject s)
        {
            Subjects.Remove(s);
            s.NotifyStudents -= Exam_Status_Notify;
        }
        private void Exam_Status_Notify(object? sender, EventArgs e)
        {
            ExamEventArgs examEventArgs = e as ExamEventArgs;
            if (examEventArgs == null) return;
            Exam exam = examEventArgs.Exam;
            foreach (var sub in Subjects)
            {
                if (sub.Id == exam.subject.Id)
                {
                    Console.WriteLine($"Student {Name} have Notification that Exam \"{exam.Name}\" of {exam.subject.Name} is {exam.Status}");
                }
            }  
        }
        
    }
}

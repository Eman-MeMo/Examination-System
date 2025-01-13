using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EventHandler NotifyStudents { get; set; }
        public Subject(int id,string name) {

            Id = id;
            Name = name;
        }
        public void StartExam(Exam ex)
        {
            ex.Status = ExamMode.Starting;
            ex.subject = this;
            NotifyStudents?.Invoke(this, new ExamEventArgs(ex));
        }

    }
}

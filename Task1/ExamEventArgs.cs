using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class ExamEventArgs : EventArgs
    {
        public Exam Exam { get; set; }

        public ExamEventArgs(Exam exam)
        {
            Exam = exam;
        }
    }
}

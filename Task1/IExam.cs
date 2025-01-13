using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IExam<T1, T2>
    {
        void StoreAnswers(T1 input, T2 input2);
        void ShowExam();
        void Evaluate();
        void ShowResult();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class AnswerList:List<Answer>
    {
        public override bool Equals(object? obj)
        {
            AnswerList other = obj as AnswerList;
            if (other == null) return false;
            if(other.GetType() != typeof(AnswerList)) return false;
            if (Count != other.Count) return false;
            for(int i = 0; i < Count; i++) 
            {
                if (this[i].Body != other[i].Body)
                   return false;
            }
            return true;
        }
    }
}

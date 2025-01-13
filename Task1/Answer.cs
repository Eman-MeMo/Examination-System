using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Answer
    {
        public string Body { get; set; }
        public Answer(string body) {

            Body = body;
        }
        public override string ToString()
        {
            return $"{Body}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Test
    {
        public int Length { get; }
        public string name;
        public bool b;

        public Test()
        {
            Length = 0;
            name = "";
            b = false;
        }

        void Print(string msg)
        {
            if (msg == "" || msg ==null)
            {
                return;
            }
            Console.WriteLine(msg);
        }

        public string GetReverseName()
        {
            var charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}

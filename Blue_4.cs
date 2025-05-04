using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            int temp = 0;
            
            foreach (char c in Input)
            {
                if (char.IsDigit(c)) temp = temp  * 10 + (c - '0');
                else
                {
                    _output += temp;
                    temp = 0;
                }
            }
            _output += temp;

        }
        public override string ToString()
        {
            return $"{_output}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output
        {
            get
            {
                if (_output == null) return null;
                string[] copy = new string[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }

        public Blue_1(string input)  : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] text = new string[0];
            _output = Input.Split(' ');

            for (int i = 0; i < _output.Length;)
            {
                string temp = "";
                int cnt = _output[i].Length; 

                while (cnt <= 50)
                {
                    temp += _output[i++] + " ";
                    //если есть след слово то прибавляем
                    if (i != _output.Length) cnt += _output[i].Length + 1;
                    else break;
                }
                int n = text.Length;
                Array.Resize(ref text, n + 1);
                text[n] = text[n] = temp.TrimEnd(); // + элемент в конец
            }
            _output = text;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            return string.Join(Environment.NewLine, _output);  //Соединяем строки через перенос 

        }
    }
}

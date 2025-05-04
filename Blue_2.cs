using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _remove;
        private string _output;

        public string Output => _output;

        public Blue_2(string input, string remove) : base(input)
        {
            _remove = remove;
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_remove))
            {
                _output = null;
                return;
            }
            string[] fragments = Input.Split(' ');
            string text = "";
            _output = Input;
            foreach (string f in fragments)
            {
                if (f.Contains(_remove))
                {
                    if (f.Contains("\"") && !f.Contains('.') && !f.Contains(','))
                    {
                        text = _output.Replace(f + " ", "\"\""+ " ");
                    }
                    else if (f.Contains("\"") && f.Contains('.'))
                    {
                        text = _output.Replace(f + " ", "\"\"" + "." + " ");
                    }
                    else if (f.Contains("\"") && f.Contains(','))
                    {
                        text = _output.Replace(f + " ", "\"\"" + "," + " ");
                    }

                    else if (f.Contains('.'))
                    {
                        text = _output.Replace(" " + f, ".");
                    }

                    else if (f.Contains(","))
                    {
                        text = _output.Replace(" " + f, ",");
                    }
                    else if (!f.Contains("\"") && !f.Contains('.') && !f.Contains(','))
                    {
                        text = _output.Replace(f + " ", "");
                    }
                    _output = text;
                }

            }
            //_output = _output.Replace("  ","");
            _output = _output.Trim();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output)) return string.Empty;
            return _output;
        }
    }
}

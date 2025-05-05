using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output => _output;

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            int cntletters = 0;
            string letters = "";
            char[] split = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(split, StringSplitOptions.RemoveEmptyEntries);
            foreach (string w in words)
            {
                if (w.Length > 0 && char.IsLetter(w[0])) letters += char.ToLower(w[0]);
            }

            (char, double)[] uletters = new (char, double)[letters.Length];

            for (int i = 0; i < uletters.Length; i++) uletters[i] = ('\0', 0);
            foreach (char l in letters)
            {
                bool uniq = false;
                for (int i = 0; i < uletters.Length; i++)
                {
                    if (uletters[i].Item1 == l)
                    {
                        uletters[i] = (l, uletters[i].Item2 + 1);
                        uniq = true;
                        break;
                    }
                }

                if (!uniq)
                {
                    for (int j = 0; j < uletters.Length; j++)
                    {
                        if (uletters[j].Item1 == '\0')
                        {
                            uletters[j] = (l, 1);
                            cntletters++;
                            break;
                        }
                    }
                }
            }
            // подсчет частоты в процентах
            int cnt = 0;
            (char, double)[] res = new (char, double)[cntletters];
            foreach (var u in uletters)
            {
                if ((u.Item1 != '\0'))
                {
                    double percent = u.Item2 / letters.Length * 100;
                    res[cnt++] = (u.Item1, percent);
                }
            }
            // сортировка
            for (int i = 0; i < res.Length - 1; i++)
            {
                for (int j = 0; j < res.Length - i - 1; j++)
                {
                    if (res[j].Item2 < res[j + 1].Item2 || (res[j].Item2 == res[j + 1].Item2 && res[j].Item1 > res[j + 1].Item1)) (res[j], res[j + 1]) = (res[j + 1], res[j]);
                }
            }
            _output = res;
        }
        public override string ToString()
        {
            if (_output == null) return null;
            var sb = new StringBuilder();
            foreach (var item in _output)
            {
                sb.AppendLine($"{item.Item1} - {item.Item2:F4}");
            }
            return sb.ToString().Trim();
        }
    }
}

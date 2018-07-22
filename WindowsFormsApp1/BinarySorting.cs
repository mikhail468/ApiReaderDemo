using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class BinarySorting
    {
        private void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(9);
            list.Add(4);
            list.Add(15);
            list.Add(5);
            list.Add(7);
            list.Add(2);
            string s = "";
            foreach (int x in list)
            {
                s = s + x + "\n";
            }
            Console.WriteLine(s);

        }

        public List<int> Sorting(List<int> elements)
        {
            string aI;
            string aJ;

            for (int i = 0; i < elements.Count; i++)
            {
                aI = Convert.ToString(elements[i], 2);
                for (int j = i + 1; j < elements.Count; j++)
                {
                    aJ = Convert.ToString(elements[j], 2);
                    if (aJ.Length - aJ.Replace("1", "").Length > aI.Length - aI.Replace("1", "").Length)
                    {
                        int s = elements[i];
                        elements[i] = elements[j];
                        elements[j] = s;
                        aI = Convert.ToString(elements[i], 2);
                        continue;
                    }
                    if (aJ.Length - aJ.Replace("1", "").Length == aI.Length - aI.Replace("1", "").Length)
                    {
                        if (elements[j] < elements[i])
                        {
                            int d = elements[i];
                            elements[i] = elements[j];
                            elements[j] = d;
                            aI = Convert.ToString(elements[i], 2);
                            continue;
                        }
                    }
                }
            }

            return elements;
        }
    }
}

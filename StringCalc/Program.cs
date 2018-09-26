using System;
using System.Linq;

namespace StringCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            string addStr = "22+1+5-6";
            //TO DO: daca ii schimb ordinea operatiilor matematice de ex: 22-5+6 nu mai merge si aici ar trebui sa aplic chain of responsability... cred
            //adica cand se schimba symbolul initial sa schimb si eu operatiunea
            int x = Add(RemoveSpace(addStr));
            Console.WriteLine(x);
            Console.ReadKey();
        }

        static int Add(string calculation)
        {
            char symbol = '+';
            int index = calculation.IndexOf(symbol);
            int a = 0;
            int b = 0;
            int result = 0;

            if (index >= 0)
            {
                string strA = calculation.Substring(0, index);
                string strB = calculation.Substring(index + 1);
                if (!int.TryParse(strB, out b))
                {
                    if (strB.Contains('+'))
                    {
                        b = Add(strB);
                    }
                    else if (strB.Contains('-'))
                    {
                        b = Subtract(strB);
                    }
                }
                a = int.Parse(strA);
            }
            result = a + b;
            return result;
        }
        static string RemoveSpace(string initial)
        {
            return initial.Replace(" ", string.Empty);
        }
        static int Subtract(string calculation)
        {
            char symbol = '-';
            int index = calculation.IndexOf(symbol);
            int a = 0;
            int b = 0;
            int result = 0;
            if (index >= 0)
            {
                string strA = calculation.Substring(0, index);
                string strB = calculation.Substring(index + 1);
                if (!int.TryParse(strB, out b))
                {
                    b = Subtract(strB);
                }
                a = int.Parse(strA);
            }
            result = a - b;
            return result;
        }
    }
}

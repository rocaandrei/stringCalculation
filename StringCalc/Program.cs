using System;
using System.Linq;

namespace StringCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            IChainOperation chain1Add = new Add();
            IChainOperation chain2Subtract = new Subtract();
            IChainOperation chain3Unknow = new Unknow();

            chain1Add.SetNextChain(chain2Subtract);
            chain2Subtract.SetNextChain(chain3Unknow);

            string test = "1-2-3";
            int result = chain1Add.Calculate(test);
            Console.WriteLine(result);
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

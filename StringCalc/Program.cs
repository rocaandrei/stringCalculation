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
            chain2Subtract.SetNextChain(chain1Add);

            string test = "1-2-3"; //aici rezultatul este 2 si ar trebui sa fie 0
            int result = chain1Add.Calculate(test);
            Console.WriteLine(result);
            string test1 = "1+2+3";//asta functioneaza
            int result1 = chain1Add.Calculate(test1);
            Console.WriteLine(result1);
            string test2 = "15+20-10+2";//functioneaza si asta 
            int result2 = chain1Add.Calculate(test2);
            Console.WriteLine(result2);
            string test3 = "14-10+3-1";
            int result3 = chain1Add.Calculate(test3);
            Console.WriteLine(result3);
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

using System;
using System.Linq;

namespace StringCalc
{
    public class Program
    {
        static void Main(string[] args)
        {
            AbstractChainOperation chain1Add = new Add();
            AbstractChainOperation chain2Subtract = new Subtract();
            AbstractChainOperation chain3Unknow = new Unknow();

            chain1Add.SetNextChain(chain2Subtract);
            chain2Subtract.SetNextChain(chain3Unknow);

            string test = "1-2-3"; //aici rezultatul este 2 si ar trebui sa fie 0
            int result = chain2Subtract.Calculate(test);
            ShowCalculation(test, result);
            string test0 = "1-2+3+5+5";//functioneaza
            int result0 = chain1Add.Calculate(test0);
            ShowCalculation(test0, result0);
            string test1 = "1+2+3";//asta functioneaza
            int result1 = chain1Add.Calculate(test1);
            ShowCalculation(test1, result1);
            string test2 = "15+20-10+2";//functioneaza si asta 
            int result2 = chain1Add.Calculate(test2);
            ShowCalculation(test2, result2);
            string test3 = "14-10+3-1";//functioneaza
            int result3 = chain1Add.Calculate(test3);
            ShowCalculation(test3, result3);
            string test4 = "1  + 2  + 3  + 100";
            int result4 = chain1Add.Calculate(RemoveSpace( test4));
            ShowCalculation(RemoveSpace(test4), result4);

            Console.ReadKey();

        }
        static void ShowCalculation(string input, int result)
        {
            Console.WriteLine(input + "= " + result);
        }
      
        static string RemoveSpace(string initial)
        {
            return initial.Replace(" ", string.Empty);
        }
       
    }
}

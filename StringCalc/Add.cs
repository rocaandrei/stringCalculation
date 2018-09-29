using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Add : IChainOperation
    {
        private IChainOperation _nextChain;
        public int Calculate(string request)
        {
            if (request.Contains("+"))//nu est bun if-ul cu contains in cazul 1-2+3, ca poate as inceapa stringu-ul cu - si int.Parese de A sa nu mearga 
            {
                int index = request.IndexOf('+');
                int a = 0;
                int b = 0;
                int result = 0;
                if(index >= 0)
                {
                    string strA = request.Substring(0, index);
                    string strB = request.Substring(index + 1);
                    if (!int.TryParse(strB,out b))
                    {
                        if (strB.Contains("+"))
                        {
                            b = Calculate(strB);
                        }
                        else
                        {
                            b = _nextChain.Calculate(strB);
                        }
                    }
                    a = int.Parse(strA);
                }
                result = a + b;
                return result;
            }
            else
            {
                return _nextChain.Calculate(request);
            }
        }

        public void SetNextChain(IChainOperation nextChain)
        {
            _nextChain = nextChain;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Add : AbstractChainOperation
    {
        private AbstractChainOperation _nextChain;
        public override int Calculate(string request)
        {
            if (request.Contains("+"))
            {
                int index = request.IndexOf('+');
                int a = 0;
                int b = 0;
                int result = 0;
                if (index >= 0)
                {
                    string strA = request.Substring(0, index);
                    a = IsNumber(strA);
                    string strB = request.Substring(index + 1);
                    b = IsNumber(strB);
                }
                result = a + b;
                return result;
            }
            else
            {
                return _nextChain.Calculate(request);
            }
        }

        public override void SetNextChain(AbstractChainOperation nextChain)
        {
            _nextChain = nextChain;
        }
    }
}

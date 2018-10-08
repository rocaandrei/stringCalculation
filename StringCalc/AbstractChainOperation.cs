using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public abstract class AbstractChainOperation
    {
        public abstract void SetNextChain(AbstractChainOperation nextChain);
        public abstract int Calculate(string request);

        public virtual int IsNumber(string input)
        {
            int number = 0;
            if (!int.TryParse(input, out number))
            {
                number = Calculate(input);
            }
            else
            {
                number = int.Parse(input);
            }

            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Unknow : AbstractChainOperation
    {
        private AbstractChainOperation _nextChain;
        public override int Calculate(string request)
        {
            Console.WriteLine("Unknow operation for: " + request);
            return 0;
        }

        public override void SetNextChain(AbstractChainOperation nextChain)
        {
            _nextChain = nextChain;
        }
    }
}

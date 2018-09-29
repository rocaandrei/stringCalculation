using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class Unknow : IChainOperation
    {
        private IChainOperation _nextChain;
        public int Calculate(string request)
        {
            Console.WriteLine("Unknow operation for: " + request);
            return 0;
        }

        public void SetNextChain(IChainOperation nextChain)
        {
            _nextChain = nextChain;
        }
    }
}

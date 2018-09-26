using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class CalculationNumbers//in test inca...
    {
        int _number1;
        int _number2;
        List<char> _operationSymbol;
        string[] digits;

        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public char OperationSymbol { get; set; }

        public CalculationNumbers( string calculationWanted)
        {
            _operationSymbol = new List<char>();
            if (calculationWanted.Contains("+"))
            {
                digits = calculationWanted.Split('+');
                _operationSymbol.Add('+');
            }
            if (calculationWanted.Contains("-"))
            {
                digits = calculationWanted.Split('-');
                _operationSymbol.Add('-');
               
            }
        }

    }
}

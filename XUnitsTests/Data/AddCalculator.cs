using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitsTests.Data
{
    internal class AddCalculator: ICalculator
    {

        public int Calc(int x, int y)
        {
            return x + y;
        }
        
    } 
}

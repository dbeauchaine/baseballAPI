using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.Helpers
{
    public class SafeDivide
    {
        public static double divideDouble(double numerator, double denominator)
        {
            return denominator != 0 ? numerator / denominator : 0;
        }
    }
}

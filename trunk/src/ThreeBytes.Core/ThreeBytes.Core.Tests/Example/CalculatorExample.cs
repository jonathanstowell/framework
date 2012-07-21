using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeBytes.Core.Tests.Example
{
    public class CalculatorExample
    {
        public int Add(params int[] args)
        {
            int result = 0;

            foreach (var a in args)
            {
                result += a;
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public class Circle : ICalculate
    {
        private int _number;
        public int Number{get{return _number;} set{_number=value;}}
        public int Calculate()
        {
            _number=(int)(Math.PI*Math.Pow(_number,2));
            return _number;
        }
    }
}
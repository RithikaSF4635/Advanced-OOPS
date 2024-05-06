using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class Syncfusion : Employee
    {
        //Abstract property definition
        public override string Name{get{return _name;} set{_name=value;}}
        public override double Salary(int dates)
        {
            Amount=(double)dates*500;
            return Amount;
        }
    }
}
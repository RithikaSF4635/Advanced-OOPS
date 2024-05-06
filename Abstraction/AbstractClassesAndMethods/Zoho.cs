using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class Zoho : Employee
    {
        
        public override string Name{get {return _name;} set{_name=value;}}

        public override double Salary(int dates)
        {
            Amount=(double)dates*1000;
            return Amount;
        }
    }
}
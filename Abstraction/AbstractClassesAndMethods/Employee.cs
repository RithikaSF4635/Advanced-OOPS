using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public abstract class Employee //abstract class
    {
        //Abstract class - partial abstraction.
        //It has fields,property,method,constructor,destructor,indexers,events.
        //can have both abstract declaration and normal definition
        //can only used with an inherited class
        //Not support multiple inheritance
        //it can't be static class
        
        protected string _name; //normal fields
        public abstract string Name { get; set; }  //abstract property
        public double Amount{ get; set; } //normal property
        
        public string Display() //normal method
        {
            return _name;
        }
        
        public abstract double Salary(int dates); //Abstract Method - Only Declaration
        
    }
}
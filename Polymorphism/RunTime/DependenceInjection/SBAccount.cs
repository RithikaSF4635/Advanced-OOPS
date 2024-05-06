using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependenceInjection
{
    public class SBAccount : IAccounts
    {
        public int AccountNumber {get;set;}
        public string Name {get; set;}
        public double Balance{get; set;}
    }
}
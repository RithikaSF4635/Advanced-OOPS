using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class Second : First
    {
        public int ProtectedNumberOut {get{return ProtectedNumber;}}
        internal protected int InternalProtected1=40;
    }
}
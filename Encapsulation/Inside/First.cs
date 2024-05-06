using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Outside;
namespace Inside
{
    public class First : Third
    {
        
        private int _privateNumber=10;
        public int PrivateOut { get{return _privateNumber;} }
        
        public int PublicNumber=20;
        protected int ProtectedNumber=30;
        
        public int InternalProtectedOut { get{return InternalProtected;} }
        
        
        
        
    }
}
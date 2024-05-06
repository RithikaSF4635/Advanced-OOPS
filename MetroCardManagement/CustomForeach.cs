using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public partial class CustomList<Type> : IEnumerable,IEnumerator
    {
        int position;
        public IEnumerator GetEnumerator()
        {
            position=-1;
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            if (position<=_count-1)
            {
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position=-1;
        }

        public object Current{get{return _array[position];}}
    }
}
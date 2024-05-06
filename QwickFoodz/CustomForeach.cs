using System;
using System.Collections;
using System.Collections.Generic;


namespace QwickFoodz
{
    public partial class CustomList<Type> : IEnumerator,IEnumerable
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
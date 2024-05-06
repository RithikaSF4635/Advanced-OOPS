using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OperatorOverLoading
{
    public class Box
    {
        private double _length;
        private double _breadth;
        private double _heigth;

        public Box(double length,double breadth,double heigth)
        {
            _length=length;
            _breadth=breadth;
            _heigth=heigth;
        }

        public double CalculateVolume()
        {
            return _length*_breadth*_heigth;
        }
        public  static Box Add(Box box1,Box box2)
        {
            Box box=new Box(0,0,0);
            box._length=box1._length+box2._length;
            box._breadth=box1._breadth+box2._breadth;
            box._heigth=box1._heigth+box2._heigth;
            return box;
        }

        public static Box operator+(Box box1,Box box2)
        {
            Box box=new Box(0,0,0);
            box._length=box1._length+box2._length;
            box._breadth=box1._breadth+box2._breadth;
            box._heigth=box1._heigth+box2._heigth;
            return box;
        }
    }
}
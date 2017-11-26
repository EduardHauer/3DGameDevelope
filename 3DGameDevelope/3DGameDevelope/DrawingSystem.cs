using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingSystem
{
    public class Point2D
    {
        public int x;
        public int y;

        public Point2D(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
    public class Point3D : Point2D
    {
        public int z;

        public Point3D(int _x, int _y, int _z) : base(_x, _y)
        {
            z = _z;
        }
    }
}

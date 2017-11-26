using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingSystem
{
    interface IDraw{
        void Draw(ConsoleColor color);
    }

    public class Point2D : IDraw
    {
        public bool fullPixel = false;

        public int x;
        public int y;

        public Point2D(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public Point2D(Point2D p)
        {
            x = p.x;
            y = p.y;
        }

        public void Draw(ConsoleColor color)
        {
            Console.SetCursorPosition(fullPixel ? x * 2 : x, y);
            Console.BackgroundColor = color;
            Console.Write(" ");
            Console.SetCursorPosition(fullPixel ? x * 2 + 1 : x, y);
            Console.Write(" ");
            Console.ResetColor();
        }

        public bool IsFullPixeled()
        {
            return fullPixel;
        }

        #region operators
        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.x + b.x, a.y + b.y);
        }
        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.x - b.x, a.y - b.y);
        }
        public static Point2D operator *(Point2D a, Point2D b)
        {
            return new Point2D(a.x * b.x, a.y * b.y);
        }
        public static Point2D operator /(Point2D a, Point2D b)
        {
            return new Point2D(a.x / b.x, a.y / b.y);
        }

        public static bool operator !=(Point2D a, Point2D b)
        {
            return a.x != b.x && a.y != b.y;
        }
        public static bool operator ==(Point2D a, Point2D b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator >(Point2D a, Point2D b)
        {
            return a.x > b.x && a.y > b.y;
        }
        public static bool operator <(Point2D a, Point2D b)
        {
            return a.x < b.x && a.y < b.y;
        }
        public static bool operator >=(Point2D a, Point2D b)
        {
            return a.x >= b.x && a.y >= b.y;
        }
        public static bool operator <=(Point2D a, Point2D b)
        {
            return a.x <= b.x && a.y <= b.y;
        }
        #endregion

    }
    public class Point3D : Point2D
    {
        public int z;

        public Point3D(int _x, int _y, int _z) : base(_x, _y)
        {
            z = _z;
        }

        public Point3D(Point3D p) : base(p.x, p.y)
        {
            z = p.z;
        }
    }

    public class Line2D : IDraw
    {
        public bool fullPixel = false;

        public Point2D p1;
        public Point2D p2;

        public List<Point2D> pList = new List<Point2D>();

        public Line2D(Point2D _p1, Point2D _p2)
        {
            p1 = _p1;
            p2 = _p2;
        }
        public Line2D(Point2D _p1, Point2D _p2, List<Point2D> _pList)
        {
            p1 = _p1;
            p2 = _p2;
            pList = _pList;
        }
        public Line2D(Line2D l)
        {
            p1 = l.p1;
            p2 = l.p2;
            pList = l.pList;
        }
        public Line2D(int x1, int y1, int x2, int y2)
        {
            p1 = new Point2D(x1, y1);
            p2 = new Point2D(x2, y2);
        }
        public Line2D(int x1, int y1, int x2, int y2, List<Point2D> _pList)
        {
            p1 = new Point2D(x1, y1);
            p2 = new Point2D(x2, y2);
            pList = _pList;
        }

        public void GetLine()
        {
            Point2D p3 = p2 - p1;
            if (p3.x > p3.y)
            {
                double j = (double)p3.y / p3.x;
                for (double i = 0, l = 0; i < p3.y; i += j, l += 1)
                {
                    pList.Add(new Point2D((int)l + p1.x, (int)i + p1.y));
                }
            }
            else if (p3.x < p3.y)
            {
                double j = (double)p3.x / p3.y;
                for (double i = 0, l = 0; i < p3.x; i += j, l += 1)
                {
                    pList.Add(new Point2D((int)i + p1.x, (int)l + p1.y));
                }
            }
            else if (p3.x == p3.y)
            {
                for (int i = 0; i < p3.x; i++)
                {
                    pList.Add(new Point2D(i + p1.x, i + p1.y));
                }
            }
        }

        public void Draw(ConsoleColor color)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                pList[i].fullPixel = fullPixel;
                pList[i].Draw(color);
            }
        }
    }
}

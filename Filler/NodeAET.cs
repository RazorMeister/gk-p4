using System;
using System.Drawing;

namespace gk_p4.Filler
{
    public class NodeAET
    {
        public Point A { get; private set; }
        public Point B { get; private set; }
        public int YMax { get; private set; }
        public double X { get; private set; }
        public double D { get; private set; }

    public NodeAET(Point a, Point b, int yScanLine)
        {
            this.A = a;
            this.B = b;

            this.SetX(yScanLine);
        }

        public void SetX(int yScanLine)
        {
            var equation = new LineEquation(this.A, this.B);
            this.X = equation.VerticalLine ? equation.A : ((double)yScanLine - equation.B) / equation.A;
        }
	}
}

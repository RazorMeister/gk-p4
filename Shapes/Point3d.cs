using System.Drawing;

namespace gk_p4.Shapes
{
    class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point ToPoint()
        {
            return new Point((int)this.X, (int)this.Y);
        }
    }
}

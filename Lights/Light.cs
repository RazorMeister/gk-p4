using System.Drawing;
using gk_p4.Shapes;

namespace gk_p4.Lights
{
    internal class Light : ILight
    {
        public Point3d Position { get; protected set; }
        public double[] Color { get; }

        public Light(Point3d position, Color color)
        {
            this.Position = position;
            this.Color = new double[] { color.R / 255.0, color.G / 255.0, color.B / 255.0 };
        }

        public void SetPosition(Point3d position)
        {
            this.Position = position;
        }
    }

}

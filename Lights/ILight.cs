using gk_p4.Shapes;

namespace gk_p4.Lights
{
    internal interface ILight
    {
        public Point3d Position { get; }
        public double[] Color { get; }
    }
}

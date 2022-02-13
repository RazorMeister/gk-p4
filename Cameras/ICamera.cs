using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Cameras
{
    internal interface ICamera
    {
        public Matrix<double> Matrix { get; }
        public Point3d Position { get; }
        public Point3d Target { get; }

        public void SetPosition(Point3d position);

        public void SetTarget(Point3d target);
    }
}

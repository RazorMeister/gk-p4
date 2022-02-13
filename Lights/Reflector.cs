using System.Drawing;
using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Lights
{
    internal class Reflector : Light
    {
        public Point3d Target { get; protected set; }
        public Vector<double> D { get; protected set; }

        public Reflector(Point3d position, Color color, Point3d target) : base(position, color)
        {
            this.Target = target;
            this.CalculateD();
        }

        public void SetPositionAndTarget(Point3d position, Point3d target)
        {
            this.SetPosition(position);
            this.Target = target;
            this.CalculateD();
        }

        private void CalculateD()
        {
            this.D = Vector<double>.Build.DenseOfArray(new[]
            {
                this.Target.X - this.Position.X,
                this.Target.Y - this.Position.Y,
                this.Target.Z - this.Position.Z
            }).Normalize(2);
        }
    }
}

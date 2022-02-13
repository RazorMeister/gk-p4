using gk_p4.Helpers;
using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Cameras
{
    internal abstract class BaseCamera : ICamera
    {
        public Matrix<double> Matrix { get; protected set; }
        public Point3d Position { get; protected set; }
        public Point3d Target { get; protected set; }
        public double R { get; protected set; }
        public readonly double BaseR;

        protected BaseCamera(Point3d position, Point3d? target = null)
        {
            this.Position = position;
            this.Target = target ?? new Point3d(0.0, 0.0, 0.0);
            this.CalculateR();
            this.BaseR = this.R;

            this.Matrix = this.CreateLookAt();
        }

        protected Matrix<double> GetDefaultMatrix()
        {
            return this.CreateLookAt();
        }

        protected void CalculateR()
        {
            this.R = this.Position.GetDistance(this.Target);
        }

        public void SetPosition(Point3d position)
        {
            this.Position = position;
            this.Matrix = this.CreateLookAt();
            this.CalculateR();
        }

        public void SetTarget(Point3d target)
        {
            this.Target = target;
            this.Matrix = this.CreateLookAt();
            this.CalculateR();
        }

        protected Matrix<double> CreateLookAt()
        {
            Vector<double> position = this.Position.ToVector();
            Vector<double> target = this.Target.ToVector();
            Vector<double> upVec = Vector<double>.Build.DenseOfArray(new[] { 0.0, 0.0, 1.0 });

            Vector<double> Zvec = (target - position).Normalize(2);
            Vector<double> Xvec = MathNetHelper.Cross(Zvec, upVec).Normalize(2);
            Vector<double> Yvec = MathNetHelper.Cross(Xvec, Zvec).Normalize(2);
            Zvec = -Zvec;

            return Matrix<double>.Build.DenseOfArray(new[,] 
            { 
                { Xvec[0], Xvec[1], Xvec[2], -Xvec.DotProduct(position) },
                { Yvec[0], Yvec[1], Yvec[2], -Yvec.DotProduct(position) },
                { Zvec[0], Zvec[1], Zvec[2], -Zvec.DotProduct(position) },
                { 0.0, 0.0, 0.0, 1.0 }
            });
        }
    }
}

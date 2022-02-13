using System;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Shapes
{
    abstract class Shape3D
    {
        public Matrix<double> Matrix { get; set; }
        public Shape3D? ParentShape { get; protected set; } = null;

        public abstract void Draw(
            PaintEventArgs e, 
            FastBitmap bm, 
            Func<Point3d, Point3d> func, 
            Func<Point3d, Point3d> funcNormal, 
            double[,] zBuffer,
            Scene.Scene scene
        );

        public void CalculateMatrix()
        {
            this.Matrix = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { 1.0, 0.0, 0.0, 0.0 },
                { 0.0, 1.0, 0.0, 0.0 },
                { 0.0, 0.0, 1.0, 0.0 },
                { 0.0, 0.0, 0.0, 1.0 },
            });
        }

        public void SetParentShape(Shape3D parentShape)
        {
            this.ParentShape = parentShape;
        }

        public Shape3D GetParentShape()
        {
            return this.ParentShape ?? this;
        }

        public Point3d TransformByMatrix(Point3d p)
        {
            Vector<double> vec = Vector<double>.Build.DenseOfArray(new[] { p.X, p.Y, p.Z, 1.0 });
            vec = this.Matrix * vec;
            return new Point3d(vec[0], vec[1], vec[2]);
        }
    }
}

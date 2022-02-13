using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using gk_p4.Shading;

namespace gk_p4.Shapes
{
    internal class Triangle
    {
        public Point3d A { get; private set; }
        public Point3d B { get; private set; }
        public Point3d C { get; private set; }
        public Point3d MiddlePoint { get; private set; }

        public Color Color { get; private set; }

        public Point3d[] transformedPoints { get; protected set; }

        public Ball? ParentBall { get; set; } = null;
        public Shape3D ParentShape { get; set; }

        public Triangle(Point3d a, Point3d b, Point3d c, Color color, Shape3D parentShape)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.Color = color;
            this.ParentShape = parentShape;

            this.MiddlePoint = new Point3d(
                (this.A.X + this.B.X + this.C.X) / 3.0,
                (this.A.Y + this.B.Y + this.C.Y) / 3.0,
                (this.A.Z + this.B.Z + this.C.Z) / 3.0
            );
        }

        private double GetTriangleField(Point3d p1, Point3d p2, Point3d p3 )
        {
            // 1/2 * Determinant(x1 - x2, y1 - y2 | x1 - x3, y1 - y3)

            double firstX = p1.X - p2.X;
            double firstY = p1.Y - p2.Y;

            double secondX = p1.X - p3.X;
            double secondY = p1.Y - p3.Y;

            return Math.Abs((firstX * secondY - firstY * secondX) / 2.0);
        }

        public (double p1, double p2, double p3) GetBarycentricCoeffs(Point3d current, Point3d[] points, double? field = null)
        {
            field ??= this.GetTriangleField(points[0], points[1], points[2]);

            double p1 = this.GetTriangleField(current, points[1], points[2]) / (double)field;
            double p2 = this.GetTriangleField(current, points[0], points[2]) / (double)field;
            double p3 = this.GetTriangleField(current, points[0], points[1]) / (double)field;

            if (double.IsNaN(p1) && double.IsNaN(p2) && double.IsNaN(p3))
            {
                p1 = 1.0;
                p2 = 0.0;
                p3 = 0.0;
            }

            if (double.IsNaN(p1)) p1 = 0.0;
            if (double.IsNaN(p2)) p2 = 0.0;
            if (double.IsNaN(p3)) p3 = 0.0;


            // Case when it is sth like 0, ∞, ∞
            if (double.IsInfinity(p1)) p1 = 0.5;
            if (double.IsInfinity(p2)) p2 = 0.5;
            if (double.IsInfinity(p3)) p3 = 0.5;

            // Case when p1 is very big number 
            double sum = p1 + p2 + p3;

            if (sum > 1.0)
            {
                p1 /= sum;
                p2 /= sum;
                p3 /= sum;
            }

            return (p1, p2, p3);
        }

        public Vector<double> GetNormalVector(double x, double y, double z, Func<Point3d, Point3d> funcNormal)
        {
            Point3d current = new Point3d(x, y, z);
            (double p1, double p2, double p3) = this.GetBarycentricCoeffs(current, new[] { this.A, this.B, this.C });

            Vector<double> AN = funcNormal(this.A).ToVector();
            Vector<double> BN = funcNormal(this.B).ToVector();
            Vector<double> CN = funcNormal(this.C).ToVector();

            return (AN.Normalize(2).Multiply(p1) + BN.Normalize(2).Multiply(p2) + CN.Normalize(2).Multiply(p3)).Normalize(2);
        }

        // https://www.khronos.org/opengl/wiki/Calculating_a_Surface_Normal
        public Vector<double> GetNormalSurfaceVector(double x, double y, double z, Func<Point3d, Point3d> funcNormal)
        {
            Point3d AN = funcNormal(this.A);
            Point3d BN = funcNormal(this.B);
            Point3d CN = funcNormal(this.C);

            Vector<double> U = AN.ToVector() - BN.ToVector();
            Vector<double> V = AN.ToVector() - CN.ToVector();

            return Vector<Double>.Build.DenseOfArray(new[]
            {
                U[1] * V[2] - U[2] * V[1],
                U[2] * V[0] - U[0] * V[2],
                U[0] * V[1] - U[1] * V[0]
            }).Normalize(2);
        }

        public double GetZ(double x, double y, Point3d[] points)
        {
            Point3d current = new Point3d(x, y, 0.0);
            (double p1, double p2, double p3) = this.GetBarycentricCoeffs(current, points);
            return p1 * points[0].Z + p2 * points[1].Z + p3 * points[2].Z;
        }

        public Point3d GetOriginLocation(double x, double y, Point3d[] points, bool print = false)
        {
            Point3d current = new Point3d(x, y, 0.0);
            (double p1, double p2, double p3) = this.GetBarycentricCoeffs(current, points);

            return new Point3d(
                p1 * this.A.X + p2 * this.B.X + p3 * this.C.X,
                p1 * this.A.Y + p2 * this.B.Y + p3 * this.C.Y,
                p1 * this.A.Z + p2 * this.B.Z + p3 * this.C.Z
            );
        }

        public bool ShouldDraw(Scene.Scene scene, Func<Point3d, Point3d> funcNormal)
        {
            Point3d p = this.ParentShape.TransformByMatrix(this.A);

            Vector<double> cameraObjectVector = Vector<Double>.Build.DenseOfArray(new[]
            {
                p.X - scene.Camera.Position.X,
                p.Y - scene.Camera.Position.Y,
                p.Z - scene.Camera.Position.Z
            }).Normalize(2);

            Vector<double> objectVector = this.GetNormalSurfaceVector(p.X, p.Y, p.Z, funcNormal);

            return cameraObjectVector.DotProduct(objectVector) <= 0;
        }

        public void Draw(PaintEventArgs e, FastBitmap bm, Func<Point3d, Point3d> func, Func<Point3d, Point3d> funcNormal, double[,] zBuffer, Scene.Scene scene)
        {
            // Back-face sculling
            if (!this.ShouldDraw(scene, funcNormal)) return;

            List<Point3d> points3d = new List<Point3d> { func(this.A), func(this.B), func(this.C) };
            this.transformedPoints = points3d.ToArray();

            List<Point> points = new List<Point>();

            points3d.ForEach(p => points.Add(p.ToPoint()));

            IShading shading = scene.CreateShading(this, funcNormal);

            Filler.Filler.FillPolygon(points, (x, y) => {
                double z = this.GetZ(x, y, this.transformedPoints);

                if (x >= zBuffer.GetLength(0) || y >= zBuffer.GetLength(1) || x < 0 || y < 0) return;

                if (z < zBuffer[x, y])
                {
                    Point3d origin = this.GetOriginLocation(x, y, this.transformedPoints);
                    Color newColor = shading.GetColor(origin.X, origin.Y, origin.Z);

                    bm.SetPixel(x, y, newColor);
                    zBuffer[x, y] = z;
                }
            });
        }
    }
}

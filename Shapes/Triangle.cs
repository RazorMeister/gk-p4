using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace gk_p4.Shapes
{
    internal class Triangle
    {
        public Vector<double> A { get; set; }
        public Vector<double> B { get; set; }
        public Vector<double> C { get; set; }

        public Color Color { get; set; }

        private double GetTriangleField(Point p1, Point p2, Point p3)
        {
            // 1/2 * Determinant(x1 - x2, y1 - y2 | x1 - x3, y1 - y3)

            double firstX = p1.X - p2.X;
            double firstY = p1.Y - p2.Y;

            double secondX = p1.X - p3.X;
            double secondY = p1.Y - p3.Y;

            return Math.Abs((firstX * secondY - firstY * secondX) / 2.0);
        }

        public (double, Vector3d) GetZN(int x, int y, double field, List<Point3d> points, List<Vector3d> normalVectors)
        {
            Point currPoint = new Point(x, y);

            double p1Alfa = this.GetTriangleField(currPoint, points[1].ToPoint(), points[2].ToPoint()) / field;
            double p2Alfa = this.GetTriangleField(currPoint, points[0].ToPoint(), points[2].ToPoint()) / field;
            double p3Alfa = this.GetTriangleField(currPoint, points[0].ToPoint(), points[1].ToPoint()) / field;

            return (
                p1Alfa * points[0].Z + p2Alfa * points[1].Z + p3Alfa * points[2].Z,
                p1Alfa * normalVectors[0] + p2Alfa * normalVectors[1] + p3Alfa * normalVectors[2]
            );
        }

        public void Draw(PaintEventArgs e, FastBitmap bm, Func<Vector<double>, Point3d> func, Func<Vector<double>, Point3d> funcNormal, double[,] zBuffer)
        {
            List<Point3d> points3d = new List<Point3d> { func(this.A), func(this.B), func(this.C) };
            List<Point> points = new List<Point>();
            List<Point3d> normalVectorsPoints = new List<Point3d> { funcNormal(this.A), funcNormal(this.B), funcNormal(this.C) };

            List<Vector3d> normalVectors = new List<Vector3d>
            {
                new Vector3d(normalVectorsPoints[0]),
                new Vector3d(normalVectorsPoints[1]),
                new Vector3d(normalVectorsPoints[2])
            };

            points3d.ForEach(p => points.Add(p.ToPoint()));

            double field = this.GetTriangleField(points[0], points[1], points[2]);


            Filler.Filler.FillPolygon(points, (x, y) => {
                (double z, Vector3d n) = this.GetZN(x, y, field, points3d, normalVectors);

                if (x >= zBuffer.GetLength(0) || y >= zBuffer.GetLength(1) || x < 0 || y < 0) return;

                if (z < zBuffer[x, y])
                {
                    double scalar = n.ToVersor().ScalarProduct(new Vector3d() { X = 0, Y = 0, Z = 1 });
                    Color newColor = Color.FromArgb(
                        255, 
                        Math.Min(255, Math.Max(0, (int)(Color.R * scalar))),
                        Math.Min(255, Math.Max(0, (int)(Color.G * scalar))),
                        Math.Min(255, Math.Max(0, (int)(Color.B * scalar)))
                    );

                    bm.SetPixel(x, y, newColor);
                    zBuffer[x, y] = z;
                }
            });
        }
    }
}

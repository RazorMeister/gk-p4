using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gk_p4.Shapes
{
    class Pyramid : Shape3D
    {
        public Point3d Vertex { get; private set; }
        public List<Point3d> BasePoints { get; private set; } = new List<Point3d>();
        public Point3d BaseCenter { get; private set; }
        public List<Triangle> Triangles { get; private set; }

        public Pyramid(Point3d vertex, Point3d baseCenter, int edgesCount, double r)
        {
            this.Matrix = Matrix<double>.Build.Dense(4, 4);
            this.CalculateMatrix();

            this.Vertex = vertex;
            this.BaseCenter = baseCenter;
            this.CalculareBasePoints(edgesCount, r);

            this.MakeTriangles();
        }

        private void CalculareBasePoints(int edgesCount, double r)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                this.BasePoints.Add(
                    new Point3d(
                        x: this.BaseCenter.X + r * Math.Cos(2 * Math.PI * i / edgesCount),
                        y: this.BaseCenter.Y + r * Math.Sin(2 * Math.PI * i / edgesCount),
                        z: this.BaseCenter.Z
                    )
                );
            }
        }

        public void MakeTriangles(Color[] triangleColors = null)
        {
            this.Triangles = new List<Triangle>();

            // Boki
            for (int i = 0; i < this.BasePoints.Count; i++)
            {
                // Protection for good triangle vertexes order
                if (this.Vertex.Z < this.BaseCenter.Z)
                {
                    this.Triangles.Add(
                        new Triangle(
                            b: this.BasePoints[i],
                            a: this.BasePoints[(i + 1) % this.BasePoints.Count],
                            c: this.Vertex,
                            color: Color.Red,
                            parentShape: this.GetParentShape()
                        )
                    );
                }
                else
                {
                    this.Triangles.Add(
                        new Triangle(
                            a: this.BasePoints[i],
                            b: this.BasePoints[(i + 1) % this.BasePoints.Count],
                            c: this.Vertex,
                            color: Color.Red,
                            parentShape: this.GetParentShape()
                        )
                    );
                }
            }

            // Podstawa
            for (int i = 0; i < this.BasePoints.Count; i++)
            {
                this.Triangles.Add(
                    new Triangle(
                        c: this.BasePoints[i],
                        b: this.BasePoints[(i + 1) % this.BasePoints.Count],
                        a: this.BaseCenter,
                        color: Color.Blue,
                        parentShape: this.GetParentShape()
                    )
                );
            }
        }

        public override void Draw(PaintEventArgs e, FastBitmap bm, Func<Point3d, Point3d> func, Func<Point3d, Point3d> funcNormal, double[,] zBuffer, Scene.Scene scene)
        {
            this.Triangles.ForEach(triangle => triangle.Draw(e, bm, func, funcNormal, zBuffer, scene));
        }
    }
}

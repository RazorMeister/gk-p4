using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace gk_p4.Shapes
{
    class Pyramid : Shape3D
    {
        public Matrix<double> Matrix { get; private set; }
        public Vector<double> Vertex { get; set; }
        public Vector<double> A { get; set; }
        public Vector<double> B { get; set; }
        public Vector<double> C { get; set; }
        public Vector<double> D { get; set; }
        public List<Triangle> Triangles { get; private set; }

        public int Type { get; set; }

        public double Alfa { get; private set; } = 0;

        public Pyramid(int type = 0)
        {
            this.Type = type;
            this.Matrix = Matrix<double>.Build.Dense(4, 4);
            this.CalculateMatrix();
        }

        public void CalculateMatrix()
        {
            if (this.Type == 0)
            {
                this.Matrix[0, 0] = Math.Cos(this.Alfa);
                this.Matrix[0, 1] = -Math.Sin(this.Alfa);
                this.Matrix[0, 3] = 0.1;

                this.Matrix[1, 0] = Math.Sin(this.Alfa);
                this.Matrix[1, 1] = Math.Cos(this.Alfa);
                this.Matrix[1, 3] = 0.2;

                this.Matrix[2, 2] = 1;
                this.Matrix[2, 3] = 0.3;

                this.Matrix[3, 3] = 1;
            } 
            else
            {
                this.Matrix[0, 0] = Math.Cos(2 * this.Alfa);
                this.Matrix[0, 2] = -Math.Sin(2 * this.Alfa);
                this.Matrix[0, 3] = -0.1;

                this.Matrix[1, 1] = 1;
                this.Matrix[1, 3] = -0.2;

                this.Matrix[2, 0] = Math.Sin(2 * this.Alfa);
                this.Matrix[2, 2] = Math.Cos(2 * this.Alfa);
                this.Matrix[2, 3] = -0.3;

                this.Matrix[3, 3] = 1;
            }
        }

        public void MakeTriangles(Color[] triangleColors)
        {
            this.Triangles = new List<Triangle>();

            // Boki
            this.Triangles.Add(new Triangle() { A = this.A, B = this.B, C = this.Vertex, Color = triangleColors[0] });
            this.Triangles.Add(new Triangle() { A = this.B, B = this.C, C = this.Vertex, Color = triangleColors[1] });
            this.Triangles.Add(new Triangle() { A = this.C, B = this.D, C = this.Vertex, Color = triangleColors[2] });
            this.Triangles.Add(new Triangle() { A = this.D, B = this.A, C = this.Vertex, Color = triangleColors[3] });

            // Podstawa
            this.Triangles.Add(new Triangle() { A = this.A, B = this.B, C = this.C, Color = triangleColors[4] });
            this.Triangles.Add(new Triangle() { A = this.A, B = this.C, C = this.D, Color = triangleColors[4] });
        }

        public void IncrementAlfa()
        {
            this.Alfa += 0.1;
            this.CalculateMatrix();
        }

        public void Draw(PaintEventArgs e, FastBitmap bm, Func<Vector<double>, Point3d> func, Func<Vector<double>, Point3d> funcNormal, double[,] zBuffer)
        {
            var vertex = func(this.Vertex);
            var a = func(this.A);
            var b = func(this.B);
            var c = func(this.C);
            var d = func(this.D);

            Pen black = new Pen(Brushes.Black);

            /*e.Graphics.DrawLine(black, vertex.ToPoint(), a.ToPoint());
            e.Graphics.DrawLine(black, vertex.ToPoint(), b.ToPoint());
            e.Graphics.DrawLine(black, vertex.ToPoint(), c.ToPoint());
            e.Graphics.DrawLine(black, vertex.ToPoint(), d.ToPoint());
            e.Graphics.DrawLine(black, a.ToPoint(), b.ToPoint());
            e.Graphics.DrawLine(black, b.ToPoint(), c.ToPoint());
            e.Graphics.DrawLine(black, c.ToPoint(), d.ToPoint());
            e.Graphics.DrawLine(black, d.ToPoint(), a.ToPoint());*/

            this.Triangles.ForEach(triangle => triangle.Draw(e, bm, func, funcNormal, zBuffer));
        }
    }
}

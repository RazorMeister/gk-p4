using MathNet.Numerics.LinearAlgebra;
using System;
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
                this.Matrix[1, 1] = -Math.Cos(this.Alfa);
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
                this.Matrix[2, 2] = -Math.Cos(2 * this.Alfa);
                this.Matrix[2, 3] = -0.3;

                this.Matrix[3, 3] = 1;
            }
        }

        public void IncrementAlfa()
        {
            this.Alfa += 0.2;
            this.CalculateMatrix();
        }

        public void Draw(PaintEventArgs e, Func<Vector<double>, Point> func)
        {
            var vertex = func(this.Vertex);
            var a = func(this.A);
            var b = func(this.B);
            var c = func(this.C);
            var d = func(this.D);

            Pen black = new Pen(Brushes.Black);

            e.Graphics.DrawLine(black, (Point)vertex, (Point)a);
            e.Graphics.DrawLine(black, (Point)vertex, (Point)b);
            e.Graphics.DrawLine(black, (Point)vertex, (Point)c);
            e.Graphics.DrawLine(black, (Point)vertex, (Point)d);
            e.Graphics.DrawLine(black, (Point)a, (Point)b);
            e.Graphics.DrawLine(black, (Point)b, (Point)c);
            e.Graphics.DrawLine(black, (Point)c, (Point)d);
            e.Graphics.DrawLine(black, (Point)d, (Point)a);
        }
    }
}

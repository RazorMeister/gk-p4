using gk_p3;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk_p4
{
    class Pyramid
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

        public void Draw(PaintEventArgs e, Func<Vector<double>, Point?> func)
        {
            var vertex = func(this.Vertex);
            var a = func(this.A);
            var b = func(this.B);
            var c = func(this.C);
            var d = func(this.D);

            Pen black = new Pen(Brushes.Black);

            //Debug.WriteLine(vertex);
            //Debug.WriteLine(a);
            //Debug.WriteLine(b);

            if (vertex != null && a != null)
                e.Graphics.DrawLine(black, (Point)vertex, (Point)a);

            if (vertex != null && b != null)
                e.Graphics.DrawLine(black, (Point)vertex, (Point)b);

            if (vertex != null && c != null)
                e.Graphics.DrawLine(black, (Point)vertex, (Point)c);

            if (vertex != null && d != null)
                e.Graphics.DrawLine(black, (Point)vertex, (Point)d);

            if (a != null && b != null)
                e.Graphics.DrawLine(black, (Point)a, (Point)b);

            if (b != null && c != null)
                e.Graphics.DrawLine(black, (Point)b, (Point)c);

            if (c != null && d != null)
                e.Graphics.DrawLine(black, (Point)c, (Point)d);

            if (d != null && a != null)
                e.Graphics.DrawLine(black, (Point)d, (Point)a);
        }
    }
}

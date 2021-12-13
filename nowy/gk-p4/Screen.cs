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
    class Screen
    {
        public Matrix<double> Matrix { get; private set; }
        public double N { get; private set; } = 1.0;
        public double F { get; private set; } = 100.0;
        public double FOV { get; private set; }
        public double A { get; private set; }

        public Screen()
        {
            this.Matrix = Matrix<double>.Build.Dense(4, 4);
            this.SetFOV(100);
        }
        
        public void SetA(double width, double height)
        {
            this.A = height / width;
            this.CalculateMatrix();
        }

        public void SetFOV(double fov)
        { 
            this.FOV = (fov * Math.PI) / 180;
            this.CalculateMatrix();
        }

        public void CalculateMatrix()
        {
            double e = 1.0 / Math.Tan((double)this.FOV / 2);

            this.Matrix[0, 0] = e;
            this.Matrix[1, 1] = e / this.A;
            this.Matrix[2, 2] = -(this.F + this.N) / (this.F - this.N);
            this.Matrix[2, 3] = -(2.0 * this.F * this.N) / (this.F - this.N);
            this.Matrix[3, 2] = -1;
        }

        public Point? ToPoint(int width, int height, Matrix<double> modelMatrix, Matrix<double> viewMatrix, Matrix<double> projMatrix, Vector<double> point)
        {
            Matrix<double> pointVector = Matrix<double>.Build.Dense(4, 1);
            pointVector[0, 0] = point[0];
            pointVector[1, 0] = -point[1];
            pointVector[2, 0] = point[2];
            pointVector[3, 0] = 1;

            var pPrim = projMatrix * viewMatrix * modelMatrix * pointVector;

            double x = pPrim[0, 0] / pPrim[3, 0];
            double y = pPrim[1, 0] / pPrim[3, 0];

            return new Point((int)((x + 1.0) * ((double)width / 2.0)), height - (int)((y + 1.0) * ((double)height / 2.0)));

        }

        public FastBitmap ToBitmap(int width, int height, Camera camera, Pyramid pyramid, PaintEventArgs e)
        {
            var bm = new FastBitmap(width, height);

            pyramid.Draw(e, (Vector<double> p) => this.ToPoint(width, height, pyramid.Matrix, camera.Matrix, this.Matrix, p));

            return bm;
        }
    }
}

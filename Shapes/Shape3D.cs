using System;
using System.Drawing;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Shapes
{
    internal interface Shape3D
    {
        public Matrix<double> Matrix { get; }
        public void Draw(PaintEventArgs e, FastBitmap bm, Func<Vector<double>, Point3d> func, Func<Vector<double>, Point3d> funcNormal, double[,] zBuffer);
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Shapes
{
    internal interface Shape3D
    {
        public Matrix<double> Matrix { get; }
        public void Draw(PaintEventArgs e, Func<Vector<double>, Point> func);
    }
}

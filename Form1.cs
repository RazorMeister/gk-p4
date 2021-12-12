using System.Diagnostics;
using System.Drawing.Drawing2D;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            var m = Matrix<double>.Build.Dense(4, 4);

            m[0, 0] = 1;
            m[1, 3] = 1;
            m[1, 1] = 1;
            m[2, 2] = 1;
            m[3, 3] = 1;
            m[3, 0] = 1;

            var m1 = Matrix<double>.Build.Dense(4, 4);

            m1[0, 0] = 1;
            m1[0, 3] = 1;
            m1[1, 2] = 1;
            m1[2, 1] = 1;
            m1[3, 0] = 1;
            m1[3, 3] = 1;

            Debug.WriteLine(m * m1);
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
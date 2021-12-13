using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk_p4
{
    public partial class Form1 : Form
    {
        private Camera camera;
        private Screen screen;
        private Pyramid pyramid;
        private Pyramid pyramidSecond;

        public Form1()
        {
            InitializeComponent();

            this.camera = new Camera();

            this.screen = new Screen();
            this.screen.SetA(this.wrapper.Width, this.wrapper.Height);

            this.pyramid = new Pyramid(1);
            this.pyramid.Vertex = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 2 });
            this.pyramid.A = Vector<double>.Build.DenseOfArray(new double[] { -1, -1, 0 });
            this.pyramid.B = Vector<double>.Build.DenseOfArray(new double[] { 1, -1, 0 });
            this.pyramid.C = Vector<double>.Build.DenseOfArray(new double[] { 1, 1, 0 });
            this.pyramid.D = Vector<double>.Build.DenseOfArray(new double[] { -1, 1, 0 });
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            this.screen.ToBitmap(this.wrapper.Width, this.wrapper.Height, this.camera, this.pyramid, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.screen.SetA(this.wrapper.Width, this.wrapper.Height);
            this.wrapper.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.screen.SetFOV(this.trackBar1.Value);
            this.wrapper.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pyramid.IncrementAlfa();
            this.wrapper.Invalidate();
        }
    }
}

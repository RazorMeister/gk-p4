﻿using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using System.Windows.Forms;
using gk_p4.Shapes;

namespace gk_p4
{
    public partial class Form1 : Form
    {
        private Camera camera;
        private Screen screen;
        private List<Shape3D> shapes = new List<Shape3D>();

        public Form1()
        {
            InitializeComponent();

            this.camera = new Camera();

            this.screen = new Screen();
            this.screen.SetA(this.wrapper.Width, this.wrapper.Height);

            Pyramid pyramid = new Pyramid();
            pyramid.Vertex = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 2 });
            pyramid.A = Vector<double>.Build.DenseOfArray(new double[] { -1, -1, 0 });
            pyramid.B = Vector<double>.Build.DenseOfArray(new double[] { 1, -1, 0 });
            pyramid.C = Vector<double>.Build.DenseOfArray(new double[] { 1, 1, 0 });
            pyramid.D = Vector<double>.Build.DenseOfArray(new double[] { -1, 1, 0 });

            Pyramid pyramid2 = new Pyramid(1);
            pyramid2.Vertex = Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 2 });
            pyramid2.A = Vector<double>.Build.DenseOfArray(new double[] { -1, -1, 0 });
            pyramid2.B = Vector<double>.Build.DenseOfArray(new double[] { 1, -1, 0 });
            pyramid2.C = Vector<double>.Build.DenseOfArray(new double[] { 1, 1, 0 });
            pyramid2.D = Vector<double>.Build.DenseOfArray(new double[] { -1, 1, 0 });

            this.shapes.Add(pyramid);
            this.shapes.Add(pyramid2);
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            this.shapes.ForEach(shape => this.screen.ToBitmap(this.wrapper.Width, this.wrapper.Height, this.camera, shape, e));
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.wrapper != null && this.screen != null)
            {
                this.screen.SetA(this.wrapper.Width, this.wrapper.Height);
                this.wrapper.Invalidate();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.screen.SetFOV(this.trackBar1.Value);
            this.wrapper.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Pyramid)this.shapes[0]).IncrementAlfa();
            ((Pyramid)this.shapes[1]).IncrementAlfa();
            this.wrapper.Invalidate();
        }
    }
}

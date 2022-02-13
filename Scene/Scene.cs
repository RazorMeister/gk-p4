using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using gk_p4.Animations;
using gk_p4.Cameras;
using gk_p4.Lights;
using gk_p4.Shading;

namespace gk_p4.Scene
{
    class Scene
    {
        private Dictionary<string, Shape3D> shapes = new Dictionary<string, Shape3D>();
        private Dictionary<string, IAnimation> animations = new Dictionary<string, IAnimation>();

        public Dictionary<string, ILight> Lights { get; private set; } = new Dictionary<string, ILight>();
        public ShadingTypeEnum ShadingType { get; private set; }
        public ICamera Camera { get; private set; }
        public double[,] ZBuffer { get; private set; }
        public Matrix<double> Matrix { get; private set; }
        public double N { get; private set; } = 1.0;
        public double F { get; private set; } = 100.0;
        public double FOV { get; private set; }
        public double A { get; private set; }
        public double Kd { get; private set; } = 0.5;
        public double Ks { get; private set; } = 0.5;
        public int M { get; private set; } = 50;

        private Timer timer;

        private int wrapperWidth;
        private int wrapperHeight;

        public Scene()
        {
            this.Matrix = Matrix<double>.Build.Dense(4, 4);
            this.SetFOV(50);

            this.timer = new Timer();
            timer.Interval = 30;
            timer.Tick += this.OnTick;
            timer.Start();
        }

        public Scene AddShape(string id, Shape3D shape)
        {
            this.shapes.Add(id, shape);
            return this;
        }

        public Shape3D GetShape(string id)
        {
            return this.shapes[id];
        }

        public Scene AddLight(string id, ILight light)
        {
            this.Lights.Add(id, light);
            return this;
        }

        public ILight GetLight(string id)
        {
            return this.Lights[id];
        }

        public Scene AddAnimation(string id, IAnimation animation)
        {
            this.animations.Add(id, animation);
            return this;
        }

        public IAnimation GetAnimation(string id)
        {
            return this.animations[id];
        }

        public Scene SetCamera(ICamera camera)
        {
            if (this.Camera is ITickCamera) ((ITickCamera)this.Camera).StopTick();
            this.Camera = camera;
            if (this.Camera is ITickCamera) ((ITickCamera)this.Camera).StartTick();
            return this;
        }

        public Scene SetKd(double kd)
        {
            this.Kd = kd;
            return this;
        }

        public Scene SetKs(double ks)
        {
            this.Ks = ks;
            return this;
        }

        public Scene SetM(int m)
        {
            this.M = m;
            return this;
        }

        public Scene SetShadingType(ShadingTypeEnum shadingType)
        {
            this.ShadingType = shadingType;
            return this;
        }

        public Scene SetA()
        {
            this.A = (double)this.wrapperHeight / (double)this.wrapperWidth;
            this.CalculateMatrix();
            return this;
        }

        public void StartAnimations()
        {
            this.timer.Start();
        }

        public void StopAnimations()
        {
            this.timer.Stop();
        }

        public Scene SetFOV(double fov)
        {
            this.FOV = (fov * Math.PI) / 180;
            this.CalculateMatrix();
            return this;
        }

        public void CalculateMatrix()
        {
            double e = 1.0 / Math.Tan((double)this.FOV / 2);

            this.Matrix[0, 0] = e;
            this.Matrix[1, 1] = e / this.A;
            this.Matrix[2, 2] = -(this.F + this.N) / (this.F - this.N);
            this.Matrix[2, 3] = -(2.0 * this.F * this.N) / (this.F - this.N);
            this.Matrix[3, 2] = -1.0;
        }

        public Scene UpdateWidthAndHeight(int wrapperWidth, int wrapperHeight)
        {
            this.wrapperWidth = wrapperWidth;
            this.wrapperHeight = wrapperHeight;

            this.SetA();
            this.CreateNewZBuffer();
            return this;
        }

        public void ToBitmap(FastBitmap bm, PaintEventArgs e)
        {
            Parallel.ForEach(this.shapes.Values, shape => shape.Draw(
                 e,
                 bm,
                 p => this.ToPoint(shape.Matrix, Camera.Matrix, this.Matrix, p),
                 p => this.ToNormalVector(shape.Matrix, Camera.Matrix, p),
                 this.ZBuffer,
                 this
             ));
        }

        public void CreateNewZBuffer()
        {
            this.ZBuffer = new double[this.wrapperWidth, this.wrapperHeight];
            this.ResetZBuffer();
        }

        public void ResetZBuffer()
        {
            for (int i = 0; i < this.ZBuffer.GetLength(0); i++)
                for (int j = 0; j < this.ZBuffer.GetLength(1); j++)
                    this.ZBuffer[i, j] = Double.MaxValue;
        }

        public void OnTick(object sender, EventArgs e)
        {
            foreach (IAnimation animation in this.animations.Values)
                if (animation.IsOn)
                    animation.Tick(this);
        }

        public IShading CreateShading(Triangle triangle, Func<Point3d, Point3d> funcNormal)
        {
            return ShadingFactory.CreateShading(this.ShadingType, triangle, this, funcNormal);
        }

        public Point3d ToPoint(Matrix<double> modelMatrix, Matrix<double> viewMatrix, Matrix<double> projMatrix, Point3d point)
        {
            Matrix<double> pointVector = Matrix<double>.Build.Dense(4, 1);
            pointVector[0, 0] = point.X;
            pointVector[1, 0] = point.Y;
            pointVector[2, 0] = point.Z;
            pointVector[3, 0] = 1;

            var pPrim = projMatrix * viewMatrix * modelMatrix * pointVector;

            double x = pPrim[0, 0] / pPrim[3, 0];
            double y = pPrim[1, 0] / pPrim[3, 0];
            double z = pPrim[2, 0] / pPrim[3, 0];

            return new Point3d(
                ((x + 1.0) * ((double)this.wrapperWidth / 2.0)),
                this.wrapperHeight - ((y + 1.0) * ((double)this.wrapperHeight / 2.0)),
                z
            );
        }

        public Point3d ToNormalVector(Matrix<double> modelMatrix, Matrix<double> viewMatrix, Point3d point)
        {
            Matrix<double> pointVector = Matrix<double>.Build.Dense(4, 1);
            pointVector[0, 0] = point.X;
            pointVector[1, 0] = point.Y;
            pointVector[2, 0] = point.Z;
            pointVector[3, 0] = 0;

            var pPrim = modelMatrix * pointVector;

            return new Point3d(
                pPrim[0, 0],
                pPrim[1, 0],
                pPrim[2, 0]
            );
        }
    }
}

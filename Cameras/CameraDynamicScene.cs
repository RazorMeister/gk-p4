using System;
using System.Windows.Forms;
using gk_p4.Shapes;

namespace gk_p4.Cameras
{
    class CameraDynamicScene : BaseCamera, ITickCamera
    {
        public int Angle { get; private set; } = 0;

        private Timer timer;

        public CameraDynamicScene(Point3d position, Point3d? target = null) : base(position, target)
        {
            this.SetMatrix();

            this.timer = new Timer();
            this.timer.Interval = 20;
            this.timer.Tick += this.OnTick;
        }

        public void StartTick()
        {
            this.timer.Start();
        }

        public void StopTick()
        {
            this.timer.Stop();
        }

        public void OnTick(object sender, EventArgs e)
        {
            this.Angle += 2;
            this.SetMatrix();
        }
        
        private void SetMatrix()
        {
            double correctionAngle = (double)this.Angle * (Math.PI / 180.0);

            this.SetPosition(new Point3d(
                this.BaseR * Math.Cos(2 * Math.PI - correctionAngle),
                this.BaseR * Math.Sin(2 * Math.PI - correctionAngle),
                this.Position.Z
            ));

        }
    }
}

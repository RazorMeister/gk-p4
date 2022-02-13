using System;
using System.Windows.Forms;
using gk_p4.Shapes;
using gk_p4.Scene;
using gk_p4.Cameras;
using gk_p4.Shading;

namespace gk_p4
{
    public partial class Form1 : Form
    {
        private readonly Scene.Scene scene;

        private readonly ICamera staticObjectCamera;
        private readonly ICamera staticSceneCamera;
        private readonly ICamera dynamicObjectCamera;
        private readonly ICamera dynamicSceneCamera;

        public Form1()
        {
            InitializeComponent();

            this.staticObjectCamera = new CameraStatic(new Point3d(5.0, 0.0, 0.5));
            this.staticSceneCamera = new CameraStatic(new Point3d(0.0, -6.0, 2.0));

            this.dynamicObjectCamera = new CameraDynamicObject(new Point3d(7.0, 0.0, 1.0));
            this.dynamicSceneCamera = new CameraDynamicScene(new Point3d(5.0, 0.0, 1.0));

            this.scene = SceneFactory.CreateScene(this.wrapper.Width, this.wrapper.Height).SetCamera(staticObjectCamera);
        }

        private void wrapper_Paint(object sender, PaintEventArgs e)
        {
            this.scene.ResetZBuffer();

            using (FastBitmap bm = new FastBitmap(this.wrapper.Width, this.wrapper.Height))
            {
                this.scene.ToBitmap(bm, e);
                e.Graphics.DrawImage(bm.Bitmap, 0, 0);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.wrapper != null && this.scene != null)
            {
                this.scene.UpdateWidthAndHeight(this.wrapper.Width, this.wrapper.Height);
                this.wrapper.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.wrapper.Invalidate();
        }

        #region Shading events
        private void shadingContantRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetShadingType(ShadingTypeEnum.Const);
        }

        private void shadingPhongRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetShadingType(ShadingTypeEnum.Phong);
        }

        private void shadingGouraudRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetShadingType(ShadingTypeEnum.Gouraud);
        }
        #endregion


        #region Light setting events
        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            double kdValue = this.kdTrackBar.Value / 10.0;
            this.scene.SetKd(kdValue);
            kdLabel.Text = $"Kd: {kdValue}";
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            double ksValue = this.ksTrackBar.Value / 10.0;
            this.scene.SetKs(ksValue);
            ksLabel.Text = $"Ks: {ksValue}";
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            int mValue = this.mTrackBar.Value;
            this.scene.SetM(mValue);
            mLabel.Text = $"M: {mValue}";
        }
        #endregion


        #region Camera events
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.scene.SetFOV(this.trackBar1.Value);
            this.fovLabel.Text = $"FOV: {this.trackBar1.Value}";
            this.wrapper.Invalidate();
        }

        private void cameraStaticForObject_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetCamera(this.staticObjectCamera);
        }

        private void cameraStaticForScene_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetCamera(this.staticSceneCamera);
        }

        private void cameraDynamicForObject_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetCamera(this.dynamicObjectCamera);
        }

        private void cameraDynamicForScene_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.SetCamera(this.dynamicSceneCamera);
        }
        #endregion

        private void animationOnCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.animationOnCheckbox.Checked) this.scene.StartAnimations();
            else this.scene.StopAnimations();
        }
    }
}

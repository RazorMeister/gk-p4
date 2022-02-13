using System;
using System.Windows.Forms;

namespace gk_p4.Shapes
{
    class Bowl : Shape3D
    {
        private readonly Pyramid pyramidUp;
        private readonly Ball upBall;
        private readonly Pyramid pyramidDown;

        public Bowl(Pyramid up, Pyramid down, Ball upBall)
        {
            up.SetParentShape(this);
            down.SetParentShape(this);
            upBall.SetParentShape(this);

            this.pyramidUp = up;
            this.pyramidDown = down;
            this.upBall = upBall;

            this.CalculateMatrix();
        }

        public override void Draw(PaintEventArgs e, FastBitmap bm, Func<Point3d, Point3d> func, Func<Point3d, Point3d> funcNormal, double[,] zBuffer, Scene.Scene scene)
        {
            this.pyramidUp.Draw(e, bm, func, funcNormal, zBuffer, scene);
            this.pyramidDown.Draw(e, bm, func, funcNormal, zBuffer, scene);
            this.upBall.Draw(e, bm, func, funcNormal, zBuffer, scene);
        }
    }
}

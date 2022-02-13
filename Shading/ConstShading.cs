using System;
using System.Drawing;
using gk_p4.Scene;
using gk_p4.Shapes;

namespace gk_p4.Shading
{
    internal class ConstShading : BaseShading
    {
        private readonly Color color;

        public ConstShading(Triangle triangle, Scene.Scene scene, Func<Point3d, Point3d> funcNormal) : base(triangle, scene, funcNormal)
        {
            this.color = SceneLightGenerator.GetColor(
                triangle.A.X, triangle.A.Y, triangle.A.Z, 
                this.Triangle, this.Scene, this.FuncNormal
            );
        }

        public override Color GetColor(double x, double y, double z)
        {
            return this.color;
        }
    }
}

using System;
using System.Drawing;
using gk_p4.Scene;
using gk_p4.Shapes;

namespace gk_p4.Shading
{
    internal class PhongShading : BaseShading
    {
        public PhongShading(Triangle triangle, Scene.Scene scene, Func<Point3d, Point3d> funcNormal) : base(triangle, scene, funcNormal) { }

        public override Color GetColor(double x, double y, double z)
        {
            return SceneLightGenerator.GetColor(x, y, z, this.Triangle, this.Scene, this.FuncNormal);
        }
    }
}

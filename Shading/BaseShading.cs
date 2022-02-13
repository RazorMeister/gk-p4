using System;
using System.Drawing;
using gk_p4.Shapes;

namespace gk_p4.Shading
{
    internal abstract class BaseShading : IShading
    {
        public Triangle Triangle { get; protected set; }
        public Scene.Scene Scene { get; protected set; }
        public Func<Point3d, Point3d> FuncNormal { get; protected set; }

        public BaseShading(Triangle triangle, Scene.Scene scene, Func<Point3d, Point3d> funcNormal)
        {
            this.Triangle = triangle;
            this.Scene = scene;
            this.FuncNormal = funcNormal;
        }

        public abstract Color GetColor(double x, double y, double z);
    }
}

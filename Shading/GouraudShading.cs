using System;
using System.Collections.Generic;
using System.Drawing;
using gk_p4.Scene;
using gk_p4.Shapes;

namespace gk_p4.Shading
{
    internal class GouraudShading : BaseShading
    {
        private readonly List<Color> colors = new List<Color>();

        public GouraudShading(Triangle triangle, Scene.Scene scene, Func<Point3d, Point3d> funcNormal) : base(triangle, scene, funcNormal)
        {
            Point3d[] points = new[] {triangle.A, triangle.B, triangle.C};

            foreach (Point3d point in points)
                this.colors.Add(SceneLightGenerator.GetColor(point.X, point.Y, point.Z, this.Triangle, this.Scene, this.FuncNormal));
        }

        public override Color GetColor(double x, double y, double z)
        {
            Point3d current = new Point3d(x, y, z);
            (double p1, double p2, double p3) = this.Triangle.GetBarycentricCoeffs(current,
                new[] {this.Triangle.A, this.Triangle.B, this.Triangle.C});

            double r = p1 * (double) this.colors[0].R + p2 * (double) this.colors[1].R + p3 * (double) this.colors[2].R;
            double g = p1 * (double) this.colors[0].G + p2 * (double) this.colors[1].G + p3 * (double) this.colors[2].G;
            double b = p1 * (double) this.colors[0].B + p2 * (double) this.colors[1].B + p3 * (double) this.colors[2].B;

            return Color.FromArgb(
                Math.Max(0, Math.Min(255, (int)r)),
                Math.Max(0, Math.Min(255, (int)g)),
                Math.Max(0, Math.Min(255, (int)b))
            );
        }
    }
}

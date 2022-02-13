using System;
using System.Drawing;
using gk_p4.Lights;
using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Scene
{
    internal class SceneLightGenerator
    {
        private const int AMBIENT_KA = 5;

        public static Color GetColor(double x, double y, double z, Triangle triangle, Scene scene, Func<Point3d, Point3d> funcNormal)
        {
            double[] resultColor = new[] { 0.0, 0.0, 0.0 };
            double[] objectColor = new[] { (double)triangle.Color.R / 255.0, (double)triangle.Color.G / 255.0, (double)triangle.Color.B / 255.0 };

            Point3d current = new Point3d(x, y, z);
            Point3d currentTransformed = triangle.ParentShape.TransformByMatrix(current);

            Vector<double> N = triangle.GetNormalVector(x, y, z, funcNormal).Normalize(2);
            Vector<double> V = Vector<double>.Build.DenseOfArray(new[] { scene.Camera.Position.X - currentTransformed.X, scene.Camera.Position.Y - currentTransformed.Y, scene.Camera.Position.Z - currentTransformed.Z }).Normalize(2);

            foreach (ILight light in scene.Lights.Values)
            {
                Vector<double> L = Vector<double>.Build.DenseOfArray(new[] { light.Position.X - currentTransformed.X, light.Position.Y - currentTransformed.Y, light.Position.Z - currentTransformed.Z }).Normalize(2);
                double nCosL = N.DotProduct(L);

                double D = scene.Kd * Math.Max(0.0, nCosL);

                Vector<double> R = (2.0 * nCosL * N - L).Normalize(2);
                double cosVR = Math.Max(0.0, V.DotProduct(R));

                double S = scene.Ks * Math.Max(0, Math.Pow(cosVR, scene.M));

                for (int i = 0; i < 3; i++)
                {
                    double IlIo = light.Color[i] * objectColor[i];

                    if (light is Reflector)
                    {
                        Vector<double> reflectorD = -((Reflector) light).D;
                        double dCosL = Math.Max(0.0, reflectorD.DotProduct(L));
                        IlIo *= Math.Max(0, Math.Pow(dCosL, scene.M));
                    }

                    resultColor[i] += (D * IlIo + S * IlIo);
                }
            }

            // Result color with ambient
            for (int i = 0; i < 3; i++)
                resultColor[i] = Math.Max(0, Math.Min(255, (int)(AMBIENT_KA + resultColor[i] * 255.0)));

            return Color.FromArgb(255, (int)resultColor[0], (int)resultColor[1], (int)resultColor[2]);
        }
    }
}

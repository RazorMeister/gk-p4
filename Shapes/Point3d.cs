using System;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Shapes
{
    class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double GetDistance(Point3d otherP)
        {
            double dx = this.X - otherP.X;
            double dy = this.Y - otherP.Y;
            double dz = this.Z - otherP.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public Point ToPoint()
        {
            return new Point((int)this.X, (int)this.Y);
        }

        public string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }

        public Vector<double> ToVector()
        {
            return Vector<double>.Build.DenseOfArray(new[] { this.X, this.Y, this.Z });
        }

        public static Point3d FromVector(Vector<double> v)
        {
            return new Point3d(v[0], v[1], v[2]);
        }
    }
}

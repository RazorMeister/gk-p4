using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk_p4.Shapes
{
    class Ball : Shape3D
    {
        private const int BALL_DENSITY = 40;

        private List<Triangle> triangles = new List<Triangle>();

        public Point3d Center { get; private set; }
        public double Radius { get; private set; }
        public Color Color { get; private set; }

        public Ball(Point3d center, double radius, Color color)
        {
            this.Center = center;
            this.Radius = radius;
            this.Color = color;

            this.CalculateMatrix();
            this.Triangulate();
        }

        public override void Draw(PaintEventArgs e, FastBitmap bm, Func<Point3d, Point3d> func, Func<Point3d, Point3d> funcNormal, double[,] zBuffer, Scene.Scene scene)
        {
            Parallel.ForEach(this.triangles, triangle => triangle.Draw(e, bm, func, funcNormal, zBuffer, scene));
        }

        public void Triangulate()
        {
            this.triangles = new List<Triangle>();
            var trlist = this.CreateTriangles(BALL_DENSITY);

            for (int i = 0; i < trlist.Count; i++)
            {
                Point3d p1 = new Point3d(
                    trlist[i].A.X * this.Radius + this.Center.X,
                    trlist[i].A.Y * this.Radius + this.Center.Y,
                    trlist[i].A.Z * this.Radius + this.Center.Z
                );

                Point3d p2 = new Point3d(
                    trlist[i].B.X * this.Radius + this.Center.X,
                    trlist[i].B.Y * this.Radius + this.Center.Y,
                    trlist[i].B.Z * this.Radius + this.Center.Z
                );

                Point3d p3 = new Point3d(
                    trlist[i].C.X * this.Radius + this.Center.X,
                    trlist[i].C.Y * this.Radius + this.Center.Y,
                    trlist[i].C.Z * this.Radius + this.Center.Z
                );


                Triangle tr = new Triangle(p1, p2, p3, this.Color, this.GetParentShape());
                tr.ParentBall = this;

                this.triangles.Add(tr);
            }
        }

        private List<Triangle> CreateTriangles(int density)
        {
            int count = density * 2;
            double steps = Math.PI / density;

            Point3d[,] pointList = new Point3d[density + 1, count + 1];

            for (int tita = 0; tita <= density; tita++)
            {
                double vtita = tita * steps;

                for (int nphi = -density; nphi <= density; nphi++)
                {
                    double vphi = nphi * steps;
                    pointList[tita, nphi + density] = new Point3d(
                        Math.Sin(vtita) * Math.Cos(vphi),
                        Math.Sin(vtita) * Math.Sin(vphi),
                        Math.Cos(vtita)
                    );
                }
            }

            List<Triangle> toReturn = new List<Triangle>();

            for (int n_tita = 1; n_tita <= pointList.GetLength(0) - 1; n_tita++)
            {
                for (int n_phi = 0; n_phi <= pointList.GetLength(1) - 1; n_phi++)
                {
                    Triangle t1 = new Triangle(
                        pointList[n_tita, n_phi],
                        pointList[n_tita, (n_phi + 1) % pointList.GetLength(1)],
                        pointList[n_tita - 1, n_phi],
                        this.Color,
                        this.GetParentShape()
                    );

                    Triangle t2 = new Triangle(
                        pointList[n_tita, (n_phi + 1) % pointList.GetLength(1)],
                        pointList[n_tita - 1, (n_phi + 1) % pointList.GetLength(1)],
                        pointList[n_tita - 1, n_phi],
                        this.Color,
                        this.GetParentShape()
                    );

                    toReturn.Add(t1);
                    toReturn.Add(t2);
                }
            }

            return toReturn;
        }
    }
}

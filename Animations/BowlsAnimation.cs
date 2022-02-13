using System;
using System.Collections.Generic;
using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Animations
{
    internal class BowlsAnimation : IAnimation
    {
        public bool IsOn { get; set; } = false;

        private double bowlsRotation = 0.0;

        public void Tick(Scene.Scene scene)
        {
            this.bowlsRotation += 0.2;

            List<Shape3D> bowls = new List<Shape3D>
                {scene.GetShape("bowl-left"), scene.GetShape("bowl-center"), scene.GetShape("bowl-right")};

            Matrix<double> newMatrix = Matrix<double>.Build.DenseOfArray(new[,]
            {
                { Math.Cos(this.bowlsRotation), 0.0, -Math.Sin(this.bowlsRotation), -0.1 },
                { 0.0, 1.0, 0.0, -0.2 },
                { Math.Sin(this.bowlsRotation), 0, Math.Cos(this.bowlsRotation), -0.3 },
                { 0.0, 0.0, 0.0, 1.0 }
            });

            bowls.ForEach(bowl => bowl.Matrix = newMatrix);

            if (this.bowlsRotation >= Math.PI / 2.0)
            {
                scene.GetAnimation("ball-animation").Reset(scene);
                this.Reset(scene);

                bowls.ForEach(bowl => bowl.CalculateMatrix());
            }
        }

        public void Reset(Scene.Scene scene)
        {
            this.bowlsRotation = 0.0;
            this.IsOn = false;
        }
    }
}

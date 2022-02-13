using System;
using gk_p4.Cameras;
using gk_p4.Lights;
using gk_p4.Shapes;
using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Animations
{
    internal class BallAnimation : IAnimation
    {
        public bool IsOn { get; set; } = true;

        private double ballMoveOffset = 0.0;
        private double ballRotation = 0.0;

        public void Tick(Scene.Scene scene)
        {
            this.ballMoveOffset += 0.1;
            this.ballRotation += 0.1;

            Matrix<double> ballModel = Matrix<double>.Build.DenseOfArray(new[,]
            {
                { 1.0, 0.0, 0.0, -this.ballMoveOffset },
                { 0.0, 1.0, 0.0, 0.0 },
                { 0.0, 0.0, 1.0, 0.0 },
                { 0.0, 0.0, 0.0, 1.0 }

            });

            Matrix<double> ballRotationModel = Matrix<double>.Build.DenseOfArray(new[,]
            {
                { 1.0, 0.0, 0.0, 0.0 },
                { 0.0, Math.Cos(this.ballRotation), -Math.Sin(this.ballRotation), 0.0 },
                { 0.0, Math.Sin(this.ballRotation), Math.Cos(this.ballRotation), 0.0 },
                { 0.0, 0.0, 0.0, 1.0 }
            });

            Ball ball = (Ball) scene.GetShape("ball");
            ball.Matrix = ballModel * ballRotationModel;

            var transformedBallCenter = ball.TransformByMatrix(ball.Center);

            // Update dynamic camera if present
            if (scene.Camera is CameraDynamicObject)
                scene.Camera.SetPosition(new Point3d(transformedBallCenter.X + 1.5, transformedBallCenter.Y, transformedBallCenter.Z + 1.5));

            // Update reflector position
            Reflector reflector = (Reflector) scene.GetLight("ball-reflector");
            reflector.SetPositionAndTarget(
                new Point3d(transformedBallCenter.X, transformedBallCenter.Y, transformedBallCenter.Z + 0.5),    
                new Point3d(0.0, 0.0, -0.5 + this.ballMoveOffset / 2.0)   
            );

            if (this.ballMoveOffset >= 1.5)
            {
                this.IsOn = false;
                scene.GetAnimation("bowls-animation").IsOn = true;
            }
        }

        public void Reset(Scene.Scene scene)
        {
            this.ballMoveOffset = 0.0;
            this.ballRotation = 0.0;
            this.IsOn = true;
        }
    }
}

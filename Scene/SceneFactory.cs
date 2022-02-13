using gk_p4.Shapes;
using System.Drawing;
using gk_p4.Animations;
using gk_p4.Lights;
using gk_p4.Shading;

namespace gk_p4.Scene
{
    class SceneFactory
    {
        const int PYRAMID_DENSITY = 10;

        static public Scene CreateScene(int width, int height)
        {
            Pyramid pyramidCenterDown = new Pyramid(
                new Point3d(0, 0, 0.8),
                new Point3d(0, 0, -0.5),
                PYRAMID_DENSITY,
                0.5
            );
            Pyramid pyramidCenterUp = new Pyramid(
                new Point3d(0, 0, 0.5),
                new Point3d(0, 0, 1.3),
                PYRAMID_DENSITY,
                0.3
            );
            Ball upBallCenter = new Ball(new Point3d(0, 0, 1.3), 0.3, Color.Red);
            Bowl bowlCenter = new Bowl(pyramidCenterUp, pyramidCenterDown, upBallCenter);

            Pyramid pyramidRightDown = new Pyramid(
                new Point3d(0, 1, 0.8),
                new Point3d(0, 1, -0.5),
                PYRAMID_DENSITY,
                0.5
            );
            Pyramid pyramidRightUp = new Pyramid(
                new Point3d(0, 1, 0.5),
                new Point3d(0, 1, 1.3),
                PYRAMID_DENSITY,
                0.3
            );
            Ball upBallRight = new Ball(new Point3d(0, 1, 1.3), 0.3, Color.Red);
            Bowl bowlRight = new Bowl(pyramidRightUp, pyramidRightDown, upBallRight);

            Pyramid pyramidLeftDown = new Pyramid(
                new Point3d(0, -1, 0.8),
                new Point3d(0, -1, -0.5),
                PYRAMID_DENSITY,
                0.5
            );
            Pyramid pyramidLeftUp = new Pyramid(
                new Point3d(0, -1, 0.5),
                new Point3d(0, -1, 1.3),
                PYRAMID_DENSITY,
                0.3
            );
            Ball upBallLeft = new Ball(new Point3d(0, -1, 1.3), 0.3, Color.Red);
            Bowl bowlLeft = new Bowl(pyramidLeftUp, pyramidLeftDown, upBallLeft);

            Ball ball = new Ball(new Point3d(2, 0, 0.0), 0.3, Color.Green);

            Light backLight = new Light(new Point3d(-3.0, 0.0, 0.0), Color.White);
            Light frontLightLeft = new Light(new Point3d(3.0, -3.0, 0.0), Color.White);
            Light frontLightRight = new Light(new Point3d(3.0, 3.0, 0.0), Color.White);
            Light topLight = new Light(new Point3d(1.0, 0.0, 3.0), Color.White);

            Reflector reflector = new Reflector(new Point3d(2.0, 0.0, 0.5), Color.Pink, new Point3d(0.0, 0.0, -0.5));

            return
                new Scene()
                    .UpdateWidthAndHeight(width, height)

                    .SetShadingType(ShadingTypeEnum.Const)

                    .AddShape("bowl-right", bowlRight)
                    .AddShape("bowl-center", bowlCenter)
                    .AddShape("bowl-left", bowlLeft)
                    .AddShape("ball", ball)

                    .AddLight("back-light", backLight)
                    .AddLight("front-left-light", frontLightLeft)
                    .AddLight("front-right-left", frontLightRight)
                    .AddLight("top-light", topLight)
                    .AddLight("ball-reflector", reflector)

                    .AddAnimation("ball-animation", new BallAnimation())
                    .AddAnimation("bowls-animation", new BowlsAnimation())
            ;
        }
    }
}

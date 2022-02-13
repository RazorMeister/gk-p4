using System;
using gk_p4.Shapes;

namespace gk_p4.Shading
{
    internal class ShadingFactory
    {
        public static IShading CreateShading(ShadingTypeEnum type, Triangle triangle, Scene.Scene scene, Func<Point3d, Point3d> funcNormal)
        {
            switch (type)
            {
                case ShadingTypeEnum.Phong:
                    return new PhongShading(triangle, scene, funcNormal);
                case ShadingTypeEnum.Gouraud:
                    return new GouraudShading(triangle, scene, funcNormal);
                default:
                    return new ConstShading(triangle, scene, funcNormal);
            }
        }
    }
}

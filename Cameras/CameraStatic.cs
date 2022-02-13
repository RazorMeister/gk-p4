using gk_p4.Shapes;

namespace gk_p4.Cameras
{
    class CameraStatic : BaseCamera
    {
        public CameraStatic(Point3d position, Point3d? target = null) : base(position, target) { }
    }
}

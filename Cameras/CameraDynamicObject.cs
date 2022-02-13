using gk_p4.Shapes;

namespace gk_p4.Cameras
{
    class CameraDynamicObject : BaseCamera
    {
        public CameraDynamicObject(Point3d position, Point3d? target = null) : base(position, target) { }
    }
}

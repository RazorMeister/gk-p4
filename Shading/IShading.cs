using System.Drawing;

namespace gk_p4.Shading
{
    internal interface IShading
    {
        public Color GetColor(double x, double y, double z);
    }
}

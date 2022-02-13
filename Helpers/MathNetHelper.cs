using MathNet.Numerics.LinearAlgebra;

namespace gk_p4.Helpers
{
    internal class MathNetHelper
    {
        public static Vector<double> Cross(Vector<double> left, Vector<double> right)
        {
            return Vector<double>.Build.DenseOfArray(new[]
            {
                left[1] * right[2] - left[2] * right[1],
                -left[0] * right[2] + left[2] * right[0],
                left[0] * right[1] - left[1] * right[0]
            });
        }
    }
}

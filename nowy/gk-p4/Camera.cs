using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gk_p4
{
    class Camera
    {
        public Matrix<double> Matrix { get; private set; }

        public Camera()
        {
            this.Matrix = Matrix<double>.Build.Dense(4, 4);

            this.Matrix[0, 1] = 1;
            this.Matrix[0, 3] = -0.5;
            this.Matrix[1, 2] = 1;
            this.Matrix[1, 3] = -0.5;
            this.Matrix[2, 0] = 1;
            this.Matrix[2, 3] = -3;
            this.Matrix[3, 3] = 1;
        }
    }
}

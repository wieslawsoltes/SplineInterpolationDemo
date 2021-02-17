// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/CubicSpline.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/IInterpolation.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/SplineBoundaryCondition.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Sorting.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.Equality.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.cs
using System;
using System.Linq;
using MathNet.Numerics.Interpolation;

namespace SplineInterpolationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[]
            {
                2,
                6,
                18,
                36,
                72,
                144,
                432,
                1008
            };

            double[] y = new double[]
            {
                123,
                117,
                107,
                92,
                33,
                32,
                8,
                7
            };

            Console.WriteLine($"X Y");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine($"{x[i]} {y[i]}");
            }

            var spline = CubicSpline.InterpolateNaturalSorted(x, y);

            Console.WriteLine($"Interpolated:");
            var min = x.Min();
            var max = x.Max();
            for (double t = min; t <= max; t += 1)
            {
                double interpolated = spline.Interpolate(t);
                Console.WriteLine($"{t} {interpolated}");
            }
        }
    }
}
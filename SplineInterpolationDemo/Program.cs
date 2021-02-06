// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/CubicSpline.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/IInterpolation.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/SplineBoundaryCondition.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Sorting.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.Equality.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.cs
using System;
using MathNet.Numerics.Interpolation;

namespace SplineInterpolationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[13];
            double[] y = new double[13];
            Console.WriteLine($"X Y");
            for (int i = 0; i <= 12; i++)
            {
                x[i] = i * Math.PI / 12;
                y[i] = Math.Sin(x[i]);
                Console.WriteLine($"{x[i]} {y[i]}");
            }
            var spline = CubicSpline.InterpolateNatural(x, y);
            double testX = 1.5 * Math.PI / 12;
            double testY = spline.Interpolate(testX);
            Console.WriteLine($"Interpolated:");
            Console.WriteLine($"{testX} {testY}");
        }
    }
}
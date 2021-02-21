// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/CubicSpline.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/IInterpolation.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Interpolation/SplineBoundaryCondition.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Sorting.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.Equality.cs
// https://github.com/mathnet/mathnet-numerics/blob/master/src/Numerics/Precision.cs
using System;
using System.Linq;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.LinearRegression;

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

            Console.WriteLine($"Interpolated:");

            //var spline = CubicSpline.InterpolateNaturalSorted(x, y);
            //var spline = CubicSpline.InterpolateAkimaSorted(x, y);
            var spline = CubicSpline.InterpolatePchipSorted(x, y);
            //var spline = LinearSpline.InterpolateSorted(x, y);
            //var spline = NevillePolynomialInterpolation.InterpolateSorted(x, y);
            //var spline = Barycentric.InterpolateRationalFloaterHormannSorted(x, y);
            //var spline = BulirschStoerRationalInterpolation.InterpolateSorted(x, y);
            //var spline = LogLinear.InterpolateSorted(x, y);
            //var spline = StepInterpolation.InterpolateSorted(x, y);

            var min = x.Min();
            var max = x.Max();
            for (double t = min; t <= max; t += 1)
            {
                double interpolated = spline.Interpolate(t);
                //Console.WriteLine($"{t} {interpolated}");
            }

           
            // var (a, b) = SimpleRegression.Fit(x, y);
            // for (double t = min; t <= max; t += 1)
            // {
            //     double interpolated = a + b * t;
            //     Console.WriteLine($"{t} {interpolated}");
            // }

            Test2();
        }

        static void Test2()
        {
            float[] x = new float[]
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

            float[] y = new float[]
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

            
            var min = x.Min();
            var max = x.Max();
            var xs = new float[(int)(max - min) + 1];
            int j = 0;
            for (float t = min; t <= max; t += 1)
            {
                xs[j] = t;
                j++;
            }

            var spline = new TestMySpline.CubicSpline();
            float[] ys = spline.FitAndEval(x, y, xs);
            
            //TestMySpline.CubicSpline.FitParametric(x, y, 1000, out var xs, out var ys);

            for (int i = 0; i < xs.Length; i++)
            {
                Console.WriteLine($"{xs[i]} {ys[i]}");
            }
        }
    }
}
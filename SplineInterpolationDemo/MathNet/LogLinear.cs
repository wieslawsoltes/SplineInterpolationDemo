// <copyright file="LogLinear.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
//
// Copyright (c) 2009-2014 Math.NET
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
    /// <summary>
    /// Piece-wise Log-Linear Interpolation
    /// </summary>
    /// <remarks>This algorithm supports differentiation, not integration.</remarks>
    public class LogLinear
    {
        /// <summary>
        /// Internal Spline Interpolation
        /// </summary>
        readonly LinearSpline _spline;

        /// <param name="x">Sample points (N), sorted ascending</param>
        /// <param name="logy">Natural logarithm of the sample values (N) at the corresponding points</param>
        public LogLinear(double[] x, double[] logy)
        {
            _spline = LinearSpline.InterpolateSorted(x, logy);
        }

        /// <summary>
        /// Create a piecewise log-linear interpolation from a set of (x,y) value pairs, sorted ascendingly by x.
        /// </summary>
        public static LogLinear InterpolateSorted(double[] x, double[] y)
        {
            if (x.Length != y.Length)
            {
                throw new ArgumentException("All vectors must have the same dimensionality.");
            }

            var logy = new double[y.Length];

            for (int i = 0; i < y.Length; i++)
            {
                logy[i] = Math.Log(y[i]);
            }

            return new LogLinear(x, logy);
        }

        /// <summary>
        /// Interpolate at point t.
        /// </summary>
        /// <param name="t">Point t to interpolate at.</param>
        /// <returns>Interpolated value x(t).</returns>
        public double Interpolate(double t)
        {
            return Math.Exp(_spline.Interpolate(t));
        }
    }
}

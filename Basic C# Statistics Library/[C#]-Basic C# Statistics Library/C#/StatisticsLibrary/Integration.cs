using System;
using System.Collections.Generic;

namespace StatisticsLibrary
{
    class Integration
    {
        public double TrapezoidalRule(int n, double a, double b, Func<double, double> f)
        {
            double h = (b - a) / n;
            double s = 0.5 * (f(a) + f(b));
            double x = a + h;

            for (int i = 1; i < n; i++)
            {
                s += f(x);
                x += h;
            }

            return h * s;
        }

        public double SimpsonsRule(int n, double a, double b, Func<double, double> f)
        {
            double h = (b - a) / n;
            double h2 = 2.0 * h;
            double s = 0.0;
            double t = 0.0;
            double x = a + h;

            for (int i = 1; i < n; i += 2)
            {
                s += f(x);
                x += h2;
            }

            x = a + h2;

            for (int i = 2; i < n; i += 2)
            {
                t += f(x);
                x += h2;
            }

            return h * (f(a) + 4 * s + 2 * t + f(b)) / 3.0;
        }

        public void GenerateGaussianLegendreAbscissasAndWeights(int n, double[] x, double[] w)
        {
            OrthogonalPolynomials op = new OrthogonalPolynomials();
            List<double> roots = new List<double>();
            Zeros zeros = new Zeros("Legendre", 0.0, 0.0, n, ref roots);

            for (int i = 0; i < n; i++)
            {
                double xi = roots[i];
                double fd = op.g("Legendre", xi, n);
                double x2 = 1.0 - xi * xi;

                x[i] = xi;
                w[i] = 2.0 / (x2 * fd * fd);
            }
        }

        public double GLIntegrate11(int n, double[] x, double[] w, Func<double, double> f)
        {
            double sum = 0.0;

            for (int i = 0; i < n; i++)
                sum += w[i] * f(x[i]);

            return sum;
        }

        public double GLIntegrateAB(int n, double a, double b,
            double[] x, double[] w, Func<double, double> f)
        {
            double c = (b - a) / 2.0;
            double d = (b + a) / 2.0;
            double sum = 0.0;

            for (int i = 0; i < n; i++)
                sum += w[i] * f(c * x[i] + d);

            return c * sum;
        }
    }
}
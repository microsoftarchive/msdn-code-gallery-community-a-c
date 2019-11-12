using System;

namespace StatisticsLibrary
{
    class OrthogonalPolynomials
    {
        public double f(
            string name,
            double alpha,
            double beta,
            double x,
            int n)
        {
            double a1n = 1, a2n = 1, a3n = 1, a4n = 1;
            double f0 = 1, f1 = x, f2 = 1;

            if (name.CompareTo("Laguerre") == 0)
                f1 = -x + 1;

            else if (name.CompareTo("Gegenbauer") == 0)
            {
                if (alpha != 0)
                    f1 = 2 * alpha * x;
            }

            else if (name.CompareTo("Generalized Laguerre") == 0)
                f1 = alpha + 1 - x;

            else if (name.CompareTo("Jacobi") == 0)
                f1 = 0.5 * (alpha - beta + (alpha + beta + 2) * x);

            for (int k = 2; k <= n; k++)
            {
                if (name.CompareTo("Chebyshev") == 0)
                {
                    a1n = 1.0;
                    a2n = 0.0;
                    a3n = 2.0;
                    a4n = 1.0;
                }

                else if (name.CompareTo("Laguerre") == 0)
                {
                    a1n = k - 1 + 1;
                    a2n = 2 * (k - 1) + 1;
                    a3n = -1.0;
                    a4n = k - 1;
                }

                else if (name.CompareTo("Legendre") == 0)
                {
                    a1n = k + 1 - 1;
                    a2n = 0.0;
                    a3n = 2.0 * (k - 1) + 1;
                    a4n = k - 1;
                }

                else if (name.CompareTo("Gegenbauer") == 0)
                {
                    if (alpha != 0)
                    {
                        a1n = k - 1 + 2;
                        a2n = 0;
                        a3n = 2 * (k - 1 + alpha);
                        a4n = k - 1 + 2 * alpha - 1;
                    }

                    else
                    {
                        a1n = 1.0;
                        a2n = 0.0;
                        a3n = 2.0;
                        a4n = 1.0;
                    }
                }

                else if (name.CompareTo("Generalized Laguerre") == 0)
                {
                    a1n = k - 1 + 1;
                    a2n = 2 * (k - 1) + alpha + 1;
                    a3n = -1;
                    a4n = k - 1 + alpha;
                }

                else if (name.CompareTo("Jacobi") == 0)
                {
                    double t = 2 * (k - 1) + alpha + beta;

                    a1n = 2 * k * (k + alpha + beta) * t;
                    a2n = alpha * alpha - beta * beta;
                    a3n = (t + 1) * t * (t + 2);
                    a4n = 2 * (k - 1 + alpha) * (k - 1 + beta) * (t + 2);
                }

                f2 = ((a2n + a3n * x) * f1 - a4n * f0) / a1n;
                f0 = f1;
                f1 = f2;
            }

            if (alpha == 0 && name.CompareTo("Gegenbauer") == 0)
                f2 = 2 * f2 / n;

            return f2;
        }

        public double g(String name, double x, int n)
        {
            double f0 = 1, f1 = x, f2 = 1;

            if (name.CompareTo("Laguerre") != 0)
            {
                if (x == 1.0)
                    x -= 0.0000001;

                else if (x == -1.0)
                    x += 0.0000001;
            }

            double g0x = 1.0, g1x = 1.0, g2x = 1.0;

            if (name.CompareTo("Chebyshev") == 0)
            {
                g0x = n;
                g1x = -n * x;
                g2x = 1.0 - x * x;
            }

            else if (name.CompareTo("Laguerre") == 0)
            {
                g0x = -n;
                g1x = n;
                g2x = x;
            }

            else if (name.CompareTo("Legendre") == 0)
            {
                g0x = n;
                g1x = -n * x;
                g2x = 1.0 - x * x;
            }

            f0 = f(name, 0.0, 0.0, x, n - 1);
            f1 = f(name, 0.0, 0.0, x, n);
            f2 = (g1x * f1 + g0x * f0) / g2x;

            return f2;
        }

        public double wf(
           string name,
           double alpha,
           double beta,
           double x,
           int n)
        {
            double wx = 0.0;

            if (name.CompareTo("Gegenbauer") == 0)
                wx = Math.Pow(1 - x * x, alpha - 0.5);

            else if (name.CompareTo("Generalized Laguerre") == 0)
                wx = Math.Exp(-x) * Math.Pow(x, alpha);

            else if (name.CompareTo("Jacobi") == 0)
                wx = Math.Pow(1 - x, alpha) * Math.Pow(1 + x, beta);

            return wx * f(name, alpha, beta, x, n);
        }
    }
}
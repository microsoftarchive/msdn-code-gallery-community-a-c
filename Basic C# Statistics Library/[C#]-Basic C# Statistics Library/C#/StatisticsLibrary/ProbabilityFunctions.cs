using System;

namespace StatisticsLibrary
{
    public class ProbabilityFunctions
    {
        private Functions f = new Functions(128);

        public double ChiSquare(double chi2, int nu, double epsilon)
        {
            int minus = 1, n = 0;
            double nu2 = nu / 2.0, sum = 0, term = 0;
            double x = Math.Pow(chi2 / 2.0, nu2);
            double y = chi2 / 2.0, xn = 1;

            while (true)
            {
                term = minus * xn / (f.Factorial(n) * (nu2 + n));

                if (Math.Abs(term) < epsilon)
                    break;

                sum += term;
                minus = -minus;
                xn *= y;
                n++;
            }

            return x * sum / f.Gamma(nu2);
        }

        public double Normal(double x, double epsilon)
        {
            double sum = 0.0, term = 0, twon = 1.0, x2 = x * x;
            int n = 0, minus = 1;

            while (true)
            {
                term = minus * x / (f.Factorial(n) * twon * (2 * n + 1));

                if (Math.Abs(term) < epsilon)
                    break;

                sum += term;
                minus = -minus;
                twon *= 2;
                x *= x2;
                n++;
            }

            return sum / Math.Sqrt(2.0 * Math.PI) + 0.5;
        }
    }
}
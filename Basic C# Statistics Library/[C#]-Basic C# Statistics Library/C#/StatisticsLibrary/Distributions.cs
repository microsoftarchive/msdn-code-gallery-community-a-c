using System;

namespace StatisticsLibrary
{
    public class Distributions
    {
        private Functions f = new Functions(128);
        private ProbabilityFunctions pf = new ProbabilityFunctions();

        public double Binomial(double p, int a, int n)
        {
            double p1 = 1.0 - p, sum = 0;

            for (int s = a; s <= n; s++)
                sum += f.BinomialCoefficient(n, s) * Math.Pow(p, s) * Math.Pow(p1, n - s);

            return sum;
        }

        public double ChiSquare(double chi2, int nu, double epsilon)
        {
            return 1.0 - pf.ChiSquare(chi2, nu, epsilon);
        }

        public double Hypergeometric(double x, int nu1, int nu2)
        {
            return 0.0;
        }

        public double InversetDistribution(double A0, int nu)
        {
            double t = 0.0001, term = 0;

            while (true)
            {
                double ft = A0 - f.A(t, nu);
                double dt = -f.DADt(t, nu);

                if (Math.Abs(ft) < 1.0e-10)
                    return t;

                term = ft / dt;

                if (Math.Abs(term) < 1.0e-10)
                    return t;

                t -= term;
            }
        }

        public double NegativeBinomial(double p, double q, int a, int n)
        {
            double pn = Math.Pow(p, n), sum = 0;

            for (int s = a; s <= n; s++)
                sum += f.BinomialCoefficient(n + s - 1, s) * Math.Pow(q, s);

            return pn * sum;
        }
        
        public double Normal(double x, double epsilon)
        {
            return 1.0 - pf.Normal(x, epsilon);
        }

        public double Poisson(double m, double nu)
        {
            double exp = Math.Exp(-m), mj = 1, sum = 0;
            int fnu = (int)Math.Floor(nu);

            for (int j = 0; j <= fnu; j++)
            {
                sum += mj / f.Factorial(j);
                mj *= m;
            }

            return exp * sum;
        }

        public double Studentst(double t, int nu)
        {
            return 1.0 - f.A(t, nu);
        }
    }
}
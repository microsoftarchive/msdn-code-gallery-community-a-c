using System;

namespace BlackScholesEquation
{
    class EuropeanCall
    {
        private double N, sigma2;
        private double d1, d2, deltaT, sd;
        private double phi1, phi2, phi3, phi4;
        private double p1, p2;

        // Translated from Pascal code found in Wikipedia article
        // https://en.wikipedia.org/wiki/Normal_distribution#Cumulative_distribution_function

        private double CDF(double x)
        {
            double sum = x, val = x;

            for (int i = 1; i <= 100; i++)
            {
                val *= x * x / (2.0 * i + 1.0);
                sum += val;
            }

            return 0.5 + (sum / Math.Sqrt(2.0 * Math.PI)) * Math.Exp(-(x * x) / 2.0);
        }

        public EuropeanCall(double S, double X, double r,
            double sigma, double t, double T, out double c, out double p)
        {
            // S = underlying asset price (stock price)
            // X = exercise price
            // r = risk free interst rate
            // sigma = standard deviation of underlying asset (stock)
            // t = current date
            // T = maturity date

            sigma2 = sigma * sigma;
            deltaT = T - t;
            N = 1.0 / Math.Sqrt(2.0 * Math.PI * sigma2);
            sd = Math.Sqrt(deltaT);
            d1 = (Math.Log(S / X) + (r + 0.5 * sigma2) * deltaT) / (sigma * sd);
            d2 = d1 - sigma * sd;
            phi1 = CDF(d1);
            phi2 = CDF(d2);
            phi3 = CDF(-d2);
            phi4 = CDF(-d1);
            c = S * phi1 - X * Math.Exp(-r * deltaT) * phi2;
            p = X * Math.Exp(-r * deltaT) * phi3 - S * phi4;
        }
    }
}
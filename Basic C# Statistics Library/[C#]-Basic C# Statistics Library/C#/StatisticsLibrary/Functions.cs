using System;

namespace StatisticsLibrary
{
    public class Functions
    {
        private double icbA, icbB, icgA;
        private double[] xi, wi;
        private int ni;
        private Integration integ;

        public Functions(int ni)
        {
            this.ni = ni;
            xi = new double[ni];
            wi = new double[ni];
            integ = new Integration();
            integ.GenerateGaussianLegendreAbscissasAndWeights(ni, xi, wi);
        }

        public double A(double t, int nu)
        {
            // Equations 26.7.3 and 26.7.4 page 948
            // Handbook of Mathematical Functions
            // Edited by Milton Abramowitz and Irene A. Stegun

            double sum = 0, theta = Math.Atan(t / Math.Sqrt(nu));
            double cos = Math.Cos(theta), sin = Math.Sin(theta);
            double cos2 = cos * cos;

            if (nu == 1)
                return 2.0 * theta / Math.PI;

            if (nu % 2 == 1)
            {
                double pcos = cos;

                for (int i = 1; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        numer *= 2 * j;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        denom *= 2 * j + 1;

                    sum += numer * pcos / denom;
                    pcos *= cos2;
                }

                sum = 2.0 * (theta + sin * sum) / Math.PI;
            }

            else
            {
                double pcos = cos2;

                for (int i = 2; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= i / 2; j++)
                        denom *= 2 * j;

                    for (int j = 1; j <= i / 2; j++)
                        numer *= 2 * j - 1;

                    sum += numer * pcos / denom;
                    pcos *= cos2;
                }

                sum = sin * (1.0 + sum);
            }

            return sum;
        }

        public double DADt(double t, int nu)
        {
            // Found by differentiation of
            // Equations 26.7.3 and 26.7.4 page 948
            // Handbook of Mathematical Functions
            // Edited by Milton Abramowitz and Irene A. Stegun

            double sum1 = 0, sum2 = 0, theta = Math.Atan(t / Math.Sqrt(nu));
            double cos = Math.Cos(theta), sin = Math.Sin(theta);
            double cos2 = cos * cos;
            double thetap = 1.0 / ((1.0 + t * t / nu) * Math.Sqrt(nu));

            if (nu == 1)
                return 2.0 * thetap / Math.PI;

            if (nu % 2 == 1)
            {
                double pcos = cos;

                for (int i = 1; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        numer *= 2 * j;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        denom *= 2 * j + 1;

                    sum1 += numer * pcos / denom;
                    pcos *= cos2;
                }

                sum1 = 2.0 * thetap * (1.0 + cos * sum1) / Math.PI;

                pcos = 1.0;

                for (int i = 1; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        numer *= 2 * j;

                    for (int j = 1; j <= (i - 1) / 2; j++)
                        denom *= 2 * j + 1;

                    sum2 += i * numer * pcos / denom;
                    pcos *= cos2;
                }

                sum1 += -2.0 * thetap * sin * sin * sum2 / Math.PI;
            }

            else
            {
                double pcos = cos2;

                for (int i = 2; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= i / 2; j++)
                        denom *= 2 * j;

                    for (int j = 1; j <= i / 2; j++)
                        numer *= 2 * j - 1;

                    sum1 += numer * pcos / denom;
                    pcos *= cos2;
                }

                sum1 = thetap * cos * (1.0 + sum1);

                pcos = cos;

                for (int i = 2; i <= nu - 2; i += 2)
                {
                    double denom = 1, numer = 1;

                    for (int j = 1; j <= i / 2; j++)
                        denom *= 2 * j;

                    for (int j = 1; j <= i / 2; j++)
                        numer *= 2 * j - 1;

                    sum2 += i * numer * pcos / denom;
                    pcos *= cos2;
                }

                sum1 += -thetap * sin * sin * sum2;
            }

            return sum1;
        }
        
        public double Beta(double p, double q)
        {
            return Gamma(p) * Gamma(q) / Gamma(p + q);
        }

        public double BinomialCoefficient(int m, int n)
        {
            return Factorial(m) / (Factorial(m - n) * Factorial(n));
        }

        public double Factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        public double DIncompleteBetaDx(double x, double a, double b)
        {
            double f = Math.Pow(x, a - 1) * Math.Pow(1 - x, b - 1);

            return f / Beta(a, b);
        }

        // the three methods below are translated from the C functions
        // found in a "Numerical Library in C for Scientists and Engineers"
        // Chapter 6 Special Functions by H.T. Lau, PhD
        
        public double Gamma(double x)
        {
            int inv;
            double y, s, f = 0, g, odd = 0, even = 0;

            if (x < 0.5)
            {
                y = x - Math.Floor(x / 2.0) * 2;
                s = Math.PI;
                if (y >= 1.0)
                {
                    s = -s;
                    y = 2.0 - y;
                }
                if (y >= 0.5) y = 1.0 - y;
                inv = 1;
                x = 1.0 - x;
                f = s / Math.Sin(Math.PI * y);
            }
            else
                inv = 0;
            if (x > 22.0)
                g = Math.Exp(LogGamma(x));
            else
            {
                s = 1.0;
                while (x > 1.5)
                {
                    x = x - 1.0;
                    s *= x;
                }
                g = s / ReciprocalGamma(1.0 - x, ref odd, ref even);
            }
            return (inv == 1 ? f / g : g);
        }

        public double LogGamma(double x)
        {
            int i;
            double r, x2, y, f, u0, u1, u, z;
            double[] b = new double[19];

            if (x > 13.0)
            {
                r = 1.0;
                while (x <= 22.0)
                {
                    r /= x;
                    x += 1.0;
                }
                x2 = -1.0 / (x * x);
                r = Math.Log(r);
                return Math.Log(x) * (x - 0.5) - x + r + 0.918938533204672 +
                        (((0.595238095238095e-3 * x2 + 0.793650793650794e-3) * x2 +
                        0.277777777777778e-2) * x2 + 0.833333333333333e-1) / x;
            }
            else
            {
                f = 1.0;
                u0 = u1 = 0.0;
                b[1] = -0.0761141616704358; b[2] = 0.0084323249659328;
                b[3] = -0.0010794937263286; b[4] = 0.0001490074800369;
                b[5] = -0.0000215123998886; b[6] = 0.0000031979329861;
                b[7] = -0.0000004851693012; b[8] = 0.0000000747148782;
                b[9] = -0.0000000116382967; b[10] = 0.0000000018294004;
                b[11] = -0.0000000002896918; b[12] = 0.0000000000461570;
                b[13] = -0.0000000000073928; b[14] = 0.0000000000011894;
                b[15] = -0.0000000000001921; b[16] = 0.0000000000000311;
                b[17] = -0.0000000000000051; b[18] = 0.0000000000000008;
                if (x < 1.0)
                {
                    f = 1.0 / x;
                    x += 1.0;
                }
                else
                    while (x > 2.0)
                    {
                        x -= 1.0;
                        f *= x;
                    }
                f = Math.Log(f);
                y = x + x - 3.0;
                z = y + y;
                for (i = 18; i >= 1; i--)
                {
                    u = u0;
                    u0 = z * u0 + b[i] - u1;
                    u1 = u;
                }
                return (u0 * y + 0.491415393029387 - u1) * (x - 1.0) * (x - 2.0) + f;
            }
        }

        public double ReciprocalGamma(double x, ref double odd, ref double even)
        {
            int i;
            double alfa, beta, x2;
            double[] b = new double[13];

            b[1] = -0.283876542276024; b[2] = -0.076852840844786;
            b[3] = 0.001706305071096; b[4] = 0.001271927136655;
            b[5] = 0.000076309597586; b[6] = -0.000004971736704;
            b[7] = -0.000000865920800; b[8] = -0.000000033126120;
            b[9] = 0.000000001745136; b[10] = 0.000000000242310;
            b[11] = 0.000000000009161; b[12] = -0.000000000000170;
            x2 = x * x * 8.0;
            alfa = -0.000000000000001;
            beta = 0.0;
            for (i = 12; i >= 2; i -= 2)
            {
                beta = -(alfa * 2.0 + beta);
                alfa = -beta * x2 - alfa + b[i];
            }
            even = (beta / 2.0 + alfa) * x2 - alfa + 0.921870293650453;
            alfa = -0.000000000000034;
            beta = 0.0;
            for (i = 11; i >= 1; i -= 2)
            {
                beta = -(alfa * 2.0 + beta);
                alfa = -beta * x2 - alfa + b[i];
            }
            odd = (alfa + beta) * 2.0;
            return (odd) * x + (even);
        }

        // Gauss series

        public double HypergeometricSeries(
            double b, double a, double c, double x, double epsilon)
        {
            if (c - a - b <= 0)
                return 0;

            double sum = 0, term = 0, z = 1;
            int n = 0;

            while (true)
            {
                term = Gamma(a + n) * Gamma(b + n) * z / Gamma(c + n) / Factorial(n);

                if (Math.Abs(term) < epsilon)
                    break;

                sum += term;
                z *= x;
                n++;

                if (n == 75)
                    return 0;
            }

            return Gamma(c) * sum / Gamma(a) / Gamma(b);
        }

        public double HyperIncompleteBeta(double x, double a, double b, double epsilon)
        {
            return Math.Pow(x, a) * HypergeometricSeries(a, 1 - b, a + 1, x, epsilon) / (a * Beta(a, b));
        }

        // the method below are translated from the C functions
        // found in a "Numerical Library in C for Scientists and Engineers"
        // Chapter 6 Special Functions by H.T. Lau, PhD

        public double IncompleteBeta(double x, double p, double q, double eps)
        {
            int m, n, neven = 0, recur = 0;
            double g, f, fn, fn1, fn2, gn, gn1, gn2, dn, pq;

            if (x == 0.0 || x == 1.0)
                return x;
            else
            {
                if (x > 0.5)
                {
                    f = p;
                    p = q;
                    q = f;
                    x = 1.0 - x;
                    recur = 1;
                }
                else
                    recur = 0;
                g = fn2 = 0.0;
                m = 0;
                pq = p + q;
                f = fn1 = gn1 = gn2 = 1.0;
                neven = 0;
                n = 1;
                do
                {
                    if (neven == 1)
                    {
                        m++;
                        dn = m * x * (q - m) / (p + n - 1.0) / (p + n);
                    }
                    else
                        dn = -x * (p + m) * (pq + m) / (p + n - 1.0) / (p + n);
                    g = f;
                    fn = fn1 + dn * fn2;
                    gn = gn1 + dn * gn2;
                    f = fn / gn;
                    fn2 = fn1;
                    fn1 = fn;
                    gn2 = gn1;
                    gn1 = gn;
                    n++;
                    neven = n % 2 == 0 ? 1 : 0;
                } while (Math.Abs((f - g) / f) > eps);
                f = f * Math.Pow(x, p) * Math.Pow(1.0 - x, q) * Gamma(p + q) / Gamma(p + 1.0) / Gamma(q);
                if (recur == 1) f = 1.0 - f;
                return f;
            }
        }

        private double d2m1(double x, double a, double b, int m)
        {
            return -(a + m) * (a + b + m) * x / ((a + 2 * m) * (a + 2 * m + 1));
        }

        private double d2m(double x, double a, double b, int m)
        {
            return m * (b - m) * x / ((a + 2 * m - 1) * (a + 2 * m));
        }

        public double IncompleteBetaFunctionCF1(double x, double a, double b, double epsilon)
        {
            // p. 944 "Handbook of Mathematical Functions"
            // Edited by Milton Abrmowitz and Irene A. Stegun
            // Also see p. 19

            if (x == 0 || x == 1)
                return x;

            if (Math.Abs(x) > 1)
                return 0;

            bool recur;

            if (x > 0.5)
            {
                double t = a;

                a = b;
                b = t;
                x = 1 - x;
                recur = true;
            }

            else
                recur = false;

            double A0 = 0, B0 = 1;
            double A1 = 1, B1 = 1, A2 = 0, B2 = 0;
            double A3 = 0, B3 = 0, A4 = 0, B4 = 0;
            double d1 = 0, d2 = 0, d3 = 0;
            double f3 = 0, f4 = 0;
            int m = 0;

            d1 = d2m1(x, a, b, m);
            A2 = A1 + d1 * A0;
            B2 = B1 + d1 * B0;
            m++;

            while (true)
            {
                d2 = d2m(x, a, b, m);
                A3 = A2 + d2 * A1;
                B3 = B2 + d2 * B1;
                f3 = A3 / B3;
                d3 = d2m1(x, a, b, m);
                A4 = A3 + d3 * A2;
                B4 = B3 + d3 * B2;
                f4 = A4 / B4;

                if (Math.Abs((f4 - f3) / f4) < epsilon)
                    break;

                A1 = A3;
                B1 = B3;
                A2 = A4;
                B2 = B4;
                m++;

                if (m == 100)
                    return double.NaN;
            }

            f4 *= Math.Pow(x, a) * Math.Pow(1 - x, b) / a / Beta(a, b);

            if (recur)
                f4 = 1 - f4;

            return f4;
        }

        private double e2m(double x2, double a, double b, int m)
        {
            return -(a + m + 1) * (b - m) * x2 / ((a + 2 * m - 2) * (a + 2 * m - 1));
        }

        private double e2m1(double x2, double a, double b, int m)
        {
            return m * (a + b - 1 + m) * x2 / ((a + 2 * m - 1) * (a + 2 * m));
        }

        public double IncompleteBetaFunctionCF2(double x, double a, double b, double epsilon)
        {
            // p. 944 "Handbook of Mathematical Functions"
            // Edited by Milton Abrmowitz and Irene A. Stegun
            // Also see p. 19

            if (x == 0 || x == 1)
                return x;

            if (Math.Abs(x) > 1)
                return 0;

            bool recur;

            if (x > 0.5)
            {
                double t = a;

                a = b;
                b = t;
                x = 1 - x;
                recur = true;
            }

            else
                recur = false;

            if (x >= (a - 1) / (a + b - 2))
                return double.NaN;

            double x1 = 1 - x;
            double x2 = x / x1;
            double Am = 1, Bm = 0, A0 = 0, B0 = 1;
            double A1 = 0, B1 = 0, A2 = 0, B2 = 0;
            double A3 = 0, B3 = 0;
            double e1 = 1, e2 = 0, e3 = 0;
            double f2 = 0, f3 = 0;
            int m = 1;

            A1 = A0 + e1 * Am;
            B1 = B0 + e1 * Bm;

            while (true)
            {
                e2 = e2m(x2, a, b, m);
                A2 = A1 + e2 * A0;
                B2 = B1 + e2 * B0;
                f2 = A2 / B2;
                e3 = e2m1(x2, a, b, m);
                A3 = A2 + e3 * A1;
                B3 = B2 + e3 * B1;
                f3 = A3 / B3;
                m++;

                if (Math.Abs((f3 - f2) / f3) < epsilon)
                    break;

                A0 = A2;
                B0 = B2;
                A1 = A3;
                B1 = B3;

                if (m >= 100)
                    return double.NaN;
            }

            f3 *= Math.Pow(x, a) * Math.Pow(x1, b - 1) / a / Beta(a, b);

            if (recur)
                f3 = 1 - f3;

            return f3;
        }

        private double icbft(double t)
        {
            return Math.Pow(t, icbA - 1) * Math.Pow(1 - t, icbB - 1);
        }

        public double IncompleteBetaFunctionIntegration(
            double x, double a, double b, double epsilon)
        {
            if (x == 0 || x == 1)
                return x;

            bool recur;

            if (x > 0.5)
            {
                double t = a;

                a = b;
                b = t;
                x = 1 - x;
                recur = true;
            }

            else
                recur = false;

            icbA = a;
            icbB = b;

            double ibf = integ.GLIntegrateAB(ni, 0, x, xi, wi, icbft) / Beta(icbA, icbB);

            if (double.IsInfinity(ibf))
                ibf = 0;

            if (recur)
                ibf = 1 - ibf;

            return ibf;
        }

        private double icgft(double t)
        {
            return Math.Exp(-t) * Math.Pow(t, icgA - 1);
        }

        public double IncompleteGammaIntegration(double a, double x, double infinity)
        {
            icgA = a;
            return integ.GLIntegrateAB(ni, x, infinity, xi, wi, icgft);
        }

        public double IncompleteGammaCF(double a, double x, double epsilon)
        {
            // p. 263 "Handbook of Mathematical Functions"
            // Edited by Milton Abrmowitz and Irene A. Stegun
            // Also see p. 19

            double A0 = 0, B0 = 1;
            double A1 = 1, B1 = x, A2 = 0, B2 = 0;
            double A3 = 0, B3 = 0, fk2 = 0, fk3 = 0;
            int k = 1;

            while (true)
            {
                A2 = A1 + (k - a) * A0;
                B2 = B1 + (k - a) * B0;
                fk2 = A2 / B2;
                A3 = x * A2 + k * A1;
                B3 = x * B2 + k * B1;
                fk3 = A3 / B3;

                if (Math.Abs((fk2 - fk3) / fk2) < epsilon)
                    break;

                A0 = A2;
                B0 = B2;
                A1 = A3;
                B1 = B3;
                k++;

                if (k == 100)
                    return double.NaN;
            }

            return Math.Exp(-x) * Math.Pow(x, a) * fk2;
        }

        // the two methods below are translated from the C functions
        // found in a "Numerical Library in C for Scientists and Engineers"
        // Chapter 6 Special Functions by H.T. Lau, PhD

        public void ErrorFunction(double x, out double erf, out double erfc)
        {
            if (x > 26.0)
            {
                erf = 1.0;
                erfc = 0.0;
                return;
            }
            else if (x < -5.5)
            {
                erf = -1.0;
                erfc = 2.0;
                return;
            }
            else
            {
                double absx, c, p, q;
                absx = Math.Abs(x);
                if (absx <= 0.5)
                {
                    c = x * x;
                    p = ((-0.356098437018154e-1 * c + 0.699638348861914e1) * c +
                            0.219792616182942e2) * c + 0.242667955230532e3;
                    q = ((c + 0.150827976304078e2) * c + 0.911649054045149e2) * c +
                            0.215058875869861e3;
                    erf = x * p / q;
                    erfc = 1.0 - (erf);
                }
                else
                {
                    erfc = Math.Exp(-x * x) * NonExperFc(absx);
                    erf = 1.0 - (erfc);
                    if (x < 0.0)
                    {
                        erf = -(erf);
                        erfc = 2.0 - (erfc);
                    }
                }
            }
        }

        private double NonExperFc(double x)
        { 
            double absx, erf, erfc, c, p, q;

            absx = Math.Abs(x);
            if (absx <= 0.5)
            {
                ErrorFunction(x,  out erf, out erfc);
                return Math.Exp(x * x) * erfc;
            }
            else if (absx < 4.0)
            {
                c = absx;
                p = ((((((-0.136864857382717e-6 * c + 0.564195517478974e0) * c +
                        0.721175825088309e1) * c + 0.431622272220567e2) * c +
                        0.152989285046940e3) * c + 0.339320816734344e3) * c +
                        0.451918953711873e3) * c + 0.300459261020162e3;
                q = ((((((c + 0.127827273196294e2) * c + 0.770001529352295e2) * c +
                        0.277585444743988e3) * c + 0.638980264465631e3) * c +
                        0.931354094850610e3) * c + 0.790950925327898e3) * c +
                        0.300459260956983e3;
                return ((x > 0.0) ? p / q : Math.Exp(x * x) * 2.0 - p / q);
            }
            else
            {
                c = 1.0 / x / x;
                p = (((0.223192459734185e-1 * c + 0.278661308609648e0) * c +
                        0.226956593539687e0) * c + 0.494730910623251e-1) * c +
                        0.299610707703542e-2;
                q = (((c + 0.198733201817135e1) * c + 0.105167510706793e1) * c +
                        0.191308926107830e0) * c + 0.106209230528468e-1;
                c = (c * (-p) / q + 0.564189583547756) / absx;
                return ((x > 0.0) ? c : Math.Exp(x * x) * 2.0 - c);
            }
        }
    }
}
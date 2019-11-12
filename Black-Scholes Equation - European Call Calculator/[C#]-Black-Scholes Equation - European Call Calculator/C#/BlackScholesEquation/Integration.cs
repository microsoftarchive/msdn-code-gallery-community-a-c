using System;

namespace BlackScholesEquation
{
    class Integration
    {
        public double integral(double a, double b, Func<double, double> fx,
            double[] e, bool ua, bool ub)
        {
            double x0, x1=0, x2, f0, f1=0, f2, re, ae, b1=0, x;

            re = e[1];
            if (ub)
                ae = e[2] * 180.0 / Math.Abs(b - a);
            else
                ae = e[2] * 90.0 / Math.Abs(b - a);
            if (ua)
            {
                e[3] = e[4] = 0.0;
                x = x0 = a;
                f0 = fx(x);
            }
            else {
                x = x0 = a = e[5];
                f0 = e[6];
            }
            e[5] = x = x2 = b;
            e[6] = f2 = fx(x);
            e[4] += integralqad(false, fx, e, ref x0, ref x1, ref x2, ref f0, ref f1, ref f2, re, ae, b1);
            if (!ub)
            {
                if (a < b)
                {
                    b1 = b - 1.0;
                    x0 = 1.0;
                }
                else {
                    b1 = b + 1.0;
                    x0 = -1.0;
                }
                f0 = e[6];
                e[5] = x2 = 0.0;
                e[6] = f2 = 0.0;
                ae = e[2] * 90.0;
                e[4] -= integralqad(true, fx, e, ref x0, ref x1, ref x2, ref f0, ref f1, ref f2, re, ae, b1);
            }
            return e[4];
        }

        private double integralqad(bool transf, Func<double, double> fx, double[] e,
            ref double x0, ref double x1, ref double x2, ref double f0, ref double f1,
            ref double f2, double re, double ae, double b1)
        {
            /* this function is internally used by INTEGRAL */

            double sum, hmin, x, z;

            hmin = Math.Abs((x0) - (x2)) * re;
            x = (x1) = ((x0) + (x2)) * 0.5;
            if (transf)
            {
                z = 1.0 / x;
                x = z + b1;
                f1 = fx(x) * z * z;
            }
            else
                f1 = fx(x);
            sum = 0.0;

            integralint(transf, fx, e, ref x0, ref x1, ref x2, ref f0, ref f1, ref f2, ref sum, re, ae, b1, hmin);
            return sum / 180.0;
        }

        private void integralint(bool transf, Func<double, double> fx, double[] e,
            ref double x0, ref double x1, ref double x2, ref double f0, ref double f1,
            ref double f2, ref double sum, double re, double ae, double b1, double hmin)
        {
            /* this function is internally used by INTEGRALQAD of INTEGRAL */

            bool anew;
            double x3, x4, f3, f4, h, x, z, v, t;

            x4 = x2;
            x2 = x1;
            f4 = f2;
            f2 = f1;
            anew = true;
            while (anew)
            {
                anew = false;
                x = x1 = (x0 + x2) * 0.5;
                if (transf)
                {
                    z = 1.0 / x;
                    x = z + b1;
                    f1 = fx(x) * z * z;
                }
                else
                    f1 = fx(x);
                x = x3 = (x2 + x4) * 0.5;
                if (transf)
                {
                    z = 1.0 / x;
                    x = z + b1;
                    f3 = fx(x) * z * z;
                }
                else
                    f3 = fx(x);
                h = x4 - x0;
                v = (4.0 * (f1 + f3) + 2.0 * f2 + f0 + f4) * 15.0;
                t = 6.0 * (f2 - 4.0 * (f1 + f3) + f0 + f4);
                if (Math.Abs(t) < Math.Abs(v) * re + ae)
                    sum += (v - t) * h;
                else if (Math.Abs(h) < hmin)
                    e[3] += 1.0;
                else {
                    integralint(transf, fx, e, ref x0, ref x1, ref x2,
                        ref f0, ref f1, ref f2, ref sum, re, ae, b1, hmin);
                    x2 = x3;
                    f2 = f3;
                    anew = true;
                }
                if (!anew)
                { 
                    x0 = x4;
                    f0 = f4;
                }
            }
        }
    }
}
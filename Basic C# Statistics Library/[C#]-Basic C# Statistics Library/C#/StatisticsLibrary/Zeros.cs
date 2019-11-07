using System;
using System.Collections.Generic;

// the methods below are translated from the C functions
// found in a "Numerical Library in C for Scientists and Engineers"
// by H.T. Lau, PhD

namespace StatisticsLibrary
{
    class Zeros
    {
        private void dupvec(int l, int u, int shift, double[] a, double[] b)
        {
            for (; l <= u; l++) a[l] = b[l + shift];
        }

        private void rotcol(int l, int u, int i, int j, double[,] a, double c, double s)
        {
            double x, y;

            for (; l <= u; l++)
            {
                x = a[l, i];
                y = a[l, j];
                a[l, i] = x * c + y * s;
                a[l, j] = y * c - x * s;
            }
        }

        private int qrivalsymtri(double[] d, double[] bb, int n, double[] em)
        {
            int i, i1, low, oldlow, n1, count, max;
            double bbtol, bbmax, bbi, bbn1, machtol, dn, delta, f, num, shift, g, h,
                    t, p, r, s, c, oldg;

            t = em[2] * em[1];
            bbtol = t * t;
            machtol = em[0] * em[1];
            max = (int)em[4];
            bbmax = 0.0;
            count = 0;
            oldlow = n;
            n1 = n - 1;
            while (n > 0)
            {
                i = n;
                do
                {
                    low = i;
                    i--;
                } while ((i >= 1) ? (bb[i] > bbtol ? true : false) : false);
                if (low > 1)
                    if (bb[low - 1] > bbmax) bbmax = bb[low - 1];
                if (low == n)
                    n = n1;
                else
                {
                    dn = d[n];
                    delta = d[n1] - dn;
                    bbn1 = bb[n1];
                    if (Math.Abs(delta) < machtol)
                        r = Math.Sqrt(bbn1);
                    else
                    {
                        f = 2.0 / delta;
                        num = bbn1 * f;
                        r = -num / (Math.Sqrt(num * f + 1.0) + 1.0);
                    }
                    if (low == n1)
                    {
                        d[n] = dn + r;
                        d[n1] -= r;
                        n -= 2;
                    }
                    else
                    {
                        count++;
                        if (count > max) break;
                        if (low < oldlow)
                        {
                            shift = 0.0;
                            oldlow = low;
                        }
                        else
                            shift = dn + r;
                        h = d[low] - shift;
                        if (Math.Abs(h) < machtol)
                            h = (h <= 0.0) ? -machtol : machtol;
                        g = h;
                        t = g * h;
                        bbi = bb[low];
                        p = t + bbi;
                        i1 = low;
                        for (i = low + 1; i <= n; i++)
                        {
                            s = bbi / p;
                            c = t / p;
                            h = d[i] - shift - bbi / h;
                            if (Math.Abs(h) < machtol)
                                h = (h <= 0.0) ? -machtol : machtol;
                            oldg = g;
                            g = h * c;
                            t = g * h;
                            d[i1] = oldg - g + d[i];
                            bbi = (i == n) ? 0.0 : bb[i];
                            p = t + bbi;
                            bb[i1] = s * p;
                            i1 = i;
                        }
                        d[n] = g + shift;
                    }
                }
                n1 = n - 1;
            }
            em[3] = Math.Sqrt(bbmax);
            em[5] = count;
            return n;
        }

        private void allzerortpol(int n, double[] b, double[] c, double[] zer,
                        double[] em)
        {
            int i;
            double nrm;
            double[] bb = new double[n + 1];
            nrm = Math.Abs(b[0]);
            for (i = 1; i <= n - 2; i++)
                if (c[i] + Math.Abs(b[i]) > nrm) nrm = c[i] + Math.Abs(b[i]);
            if (n > 1)
                nrm = (nrm + 1 >= c[n - 1] + Math.Abs(b[n - 1])) ? nrm + 1.0 :
                            (c[n - 1] + Math.Abs(b[n - 1]));
            em[1] = nrm;
            for (i = n; i >= 1; i--) zer[i] = b[i - 1];
            dupvec(1, n - 1, 0, bb, c);
            qrivalsymtri(zer, bb, n, em);
        }

        private void alljaczer(int n, double alfa, double beta, double[] zer)
        {
            double sum, min, gamma, zeri;
            double[] a = null, b = null;
            double[] em = new double[6];
            int i, m;

            if (alfa == beta)
            {
                a = new double[n / 2 + 1];
                b = new double[n / 2 + 1];
                m = n / 2;
                if (n != 2 * m)
                {
                    gamma = 0.5;
                    zer[m + 1] = 0.0;
                }
                else
                    gamma = -0.5;
                min = 0.25 - alfa * alfa;
                sum = alfa + gamma + 2.0;
                a[0] = (gamma - alfa) / sum;
                a[1] = min / sum / (sum + 2.0);
                b[1] = 4.0 * (1.0 + alfa) * (1.0 + gamma) / sum / sum / (sum + 1.0);
                for (i = 2; i <= m - 1; i++)
                {
                    sum = i + i + alfa + gamma;
                    a[i] = min / sum / (sum + 2.0);
                    sum *= sum;
                    b[i] = 4.0 * i * (i + alfa + gamma) * (i + alfa) * (i + gamma) / sum / (sum - 1.0);
                }
                em[0] = double.MinValue;
                em[2] = double.Epsilon;
                em[4] = 6 * m;
                allzerortpol(m, a, b, zer, em);
                for (i = 1; i <= m; i++)
                {
                    zer[i] = zeri = -Math.Sqrt((1.0 + zer[i]) / 2.0);
                    zer[n + 1 - i] = -zeri;
                }
            }
            else
            {
                a = new double[n + 1];
                b = new double[n + 1];
                min = (beta - alfa) * (beta + alfa);
                sum = alfa + beta + 2.0;
                b[0] = 0.0;
                a[0] = (beta - alfa) / sum;
                a[1] = min / sum / (sum + 2.0);
                b[1] = 4.0 * (1.0 + alfa) * (1.0 + beta) / sum / sum / (sum + 1.0);
                for (i = 2; i <= n - 1; i++)
                {
                    sum = i + i + alfa + beta;
                    a[i] = min / sum / (sum + 2.0);
                    sum *= sum;
                    b[i] = 4.0 * i * (i + alfa + beta) * (i + alfa) * (i + beta) / (sum - 1.0) / sum;
                }
                em[0] = double.MinValue;
                em[2] = double.Epsilon;
                em[4] = 6 * n;
                allzerortpol(n, a, b, zer, em);
            }
        }

        private void alllagzer(int n, double alfa, double[] zer)
        {
            double[] a = null, b = null, em = new double[6];
            int i;

            a = new double[n + 1];
            b = new double[n + 1];
            b[0] = 0.0;
            a[n - 1] = n + n + alfa - 1.0;
            for (i = 1; i <= n - 1; i++)
            {
                a[i - 1] = i + i + alfa - 1.0;
                b[i] = i * (i + alfa);
            }
            em[0] = double.MinValue;
            em[2] = double.Epsilon;
            em[4] = 6 * n;
            allzerortpol(n, a, b, zer, em);
        }

        public Zeros(
            string name,
            double alpha,
            double beta,
            int n,
            ref List<double> roots)
        {
            double[] zer = new double[n + 1];

            if (name.CompareTo("Legendre") == 0)
            {
                double[] b = new double[n];
                double[] c = new double[n];
                double[] em = new double[6];

                for (int i = 0; i < n; i++)
                {
                    b[i] = 0.0;
                    c[i] = i * i / (4.0 * i * i - 1.0);
                }

                em[0] = em[2] = 1.0E-10;
                em[4] = 5.0 * n;

                allzerortpol(n, b, c, zer, em);
            }

            else if (name.CompareTo("Gegenbauer") == 0)
            {
                if (alpha > 0)
                    alljaczer(n, alpha - 0.5, alpha - 0.5, zer);

                else if (alpha == 0)
                {
                    double[] b = new double[n];
                    double[] c = new double[n];
                    double[] em = new double[6];

                    c[1] = 0.5;

                    for (int k = 2; k < n; k++)
                        c[k] = 0.25;

                    em[0] = em[2] = 1.0E-10;
                    em[4] = 5.0 * n;

                    allzerortpol(n, b, c, zer, em);
                }
            }

            else if (name.CompareTo("Generalized Laguerre") == 0)
                alllagzer(n, alpha, zer);

            else if (name.CompareTo("Jacobi") == 0)
                alljaczer(n, alpha, beta, zer);

            roots = new List<double>();

            for (int i = 1; i <= n; i++)
                roots.Add(zer[i]);
        }
    }
}
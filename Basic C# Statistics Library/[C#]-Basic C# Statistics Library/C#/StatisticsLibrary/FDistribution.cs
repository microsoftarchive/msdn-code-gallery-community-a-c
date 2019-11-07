using System;
using System.Collections.Generic;

namespace StatisticsLibrary
{
    public class IxPoint
    {
        private double ix, x;
        private int nu1, nu2;

        public double Ix
        {
            get
            {
                return ix;
            }
        }

        public double X
        {
            get
            {
                return x;
            }
        }

        public int Nu1
        {
            get
            {
                return nu1;
            }
        }

        public int Nu2
        {
            get
            {
                return nu2;
            }
        }

        public IxPoint(double ix, double x, int nu1, int nu2)
        {
            this.ix = ix;
            this.x = x;
            this.nu1 = nu1;
            this.nu2 = nu2;
        }

    }

    public class IXPointComparerIx : IComparer<IxPoint>
    {
        public int Compare(IxPoint i1, IxPoint i2)
        {
            if (i1.Ix < i2.Ix)
                return -1;

            else if (i1.Ix > i2.Ix)
                return +1;

            return 0;
        }
    }

    class IXPointComparerNu1Nu2 : IComparer<IxPoint>
    {
        public int Compare(IxPoint i1, IxPoint i2)
        {
            if (i1.Nu1 < i2.Nu1)
                return -1;

            else if (i1.Nu1 > i2.Nu1)
                return +1;

            if (i1.Nu2 < i2.Nu2)
                return -1;

            else if (i1.Nu2 > i2.Nu2)
                return +1;

            return 0;
        }
    }

    public class FDistribution
    {
        Distributions dis = new Distributions();
        Functions f = new Functions(256);

        private double Convertx(double x, int nu1, int nu2)
        {
            double F = (nu2 / x - nu2) / nu1;

            return F;
        }

        private void Search(
            double I0, int nu1Max, int nu2Max, int iPoints,
            ref double[,] table, ref int valuesFound,
            Func<double, double, double, double, double> incompleteBeta)
        {
            double x;
            double Ix = 0, Ix0 = 0, Ix1 = 0, y = 0, x0 = 0, x1 = 0;
            double slope = 0, inter = 0;
            IxPoint ixp;
            IXPointComparerIx compareIx = new IXPointComparerIx();

            for (int nu1 = 1; nu1 <= nu1Max; nu1++)
            {
                double b = 0.5 * nu1;

                for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                {
                    if (double.IsNaN(table[nu1, nu2]))
                    {
                        bool found = false;
                        double a = 0.5 * nu2, m = 1.0 / iPoints;
                        List<IxPoint> list = new List<IxPoint>();

                        for (int k = 0; k < iPoints; k++)
                        {
                            x = m * k;

                            Ix = incompleteBeta(x, a, b, 1.0e-5);

                            ixp = new IxPoint(Ix, x, nu1, nu2);
                            list.Add(ixp);
                        }

                        list.Sort(compareIx);

                        for (int i = 0; !found && i < list.Count - 1; i++)
                        {
                            ixp = list[i];
                            Ix0 = ixp.Ix;
                            x0 = ixp.X;
                            ixp = list[i + 1];
                            Ix1 = ixp.Ix;
                            x1 = ixp.X;

                            found =
                                (Ix0 != double.NaN && Ix1 != double.NaN) &&
                                (I0 >= Ix0 && I0 <= Ix1);
                        }

                        if (found)
                        {
                            // linear interpolation

                            slope = (Ix1 - Ix0) / (x1 - x0);
                            inter = Ix0 - slope * x0;
                            y = (I0 - inter) / slope;
                            y = Convertx(y, nu1, nu2);

                            if (y < 0)
                                y = double.NaN;

                            else
                                valuesFound++;
                        }

                        else
                            y = double.NaN;

                        table[nu1, nu2] = y;
                    }
                }
            }
        }

        public double[,] BuildInverseFDistributionTable(
            double I0, int nu1Max, int nu2Max, int iPoints,
            out int valuesRequested, out int valuesFound)
        {
            double[,] table = new double[nu1Max + 1, nu2Max + 1];
            IxPoint ixp;
            IXPointComparerIx compareIx = new IXPointComparerIx();

            valuesRequested = nu1Max * nu2Max;
            valuesFound = 0;

            for (int nu1 = 1; nu1 <= nu1Max; nu1++)
                for (int nu2 = 1; nu2 <= nu2Max; nu2++)
                    table[nu1, nu2] = double.NaN;

            for (int nu2 = 1; nu2 <= nu2Max; nu2++)
            {
                double t = dis.InversetDistribution(1 - I0, nu2);

                table[1, nu2] = t * t;
                valuesFound++;
            }

            Search(I0, nu1Max, nu2Max, iPoints, ref table, ref valuesFound,
                f.IncompleteBetaFunctionCF1);

            if (valuesFound == valuesRequested)
                return table;

            Search(I0, nu1Max, nu2Max, iPoints, ref table, ref valuesFound,
                f.IncompleteBetaFunctionIntegration);

            return table;
        }
    }
}
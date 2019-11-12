using System.Collections.Generic;

namespace StatisticsLibrary
{
    public class Analysis
    {
        private Functions f = new Functions(128);
        private Distributions dis = new Distributions();
        private SampleStatistics ss = new SampleStatistics();

        private string SingleDataAnalysis(double[] x)
        {
            string r = string.Empty, s = "\r\n";

            r += "Count       : " + x.Length + s;
            r += "Mean        : " + ss.Mean(x) + s;
            r += "Median      : " + ss.Median(x) + s;
            r += "Max         : " + ss.Max(x) + s;
            r += "Min         : " + ss.Min(x) + s;
            r += "Kurtosis    : " + ss.Kurtosis(x) + s;
            r += "Kurtosos Pop: " + ss.KurtosisPop(x) + s;
            r += "Skweness    : " + ss.Skewness(x) + s;
            r += "Std Dev     : " + ss.StandardDeviation(x) + s;
            r += "Variance    : " + ss.Variance(x) + s;
            return r;
        }

        public string DataAnalysis(double[] x)
        {
            return SingleDataAnalysis(x);
        }

        public string DataAnalysis(List<double> xl)
        {
            return SingleDataAnalysis(xl.ToArray());
        }

        public string DataAnalysis(double[] x, double[] y)
        {
            double df, F = ss.FStatistic(x, y);
            double t = ss.StudenttStatisticIndependent(x, y);
            double wt = ss.WelchtStatistic(x, y, out df), z;
            int nu = x.Length + y.Length - 2;
            int nu1 = x.Length - 1, nu2 = nu1;
            string r = string.Empty;
                
            r += SingleDataAnalysis(x);
            r += "\r\n";
            r += SingleDataAnalysis(y);
            r += "\r\n";
            r += "Covariance  : " + ss.Covariance(x, y) + "\r\n";
            r += "Correlation : " + ss.Correlation(x, y) + "\r\n";
            r += "t-Statistic : " + t + "\r\n";
            r += "Degrees     : " + nu.ToString() + "\r\n";
            r += "t-Test      : " + (1.0 - f.A(t, nu)) + "\r\n";
            r += "Welch's t-st: " + wt + "\r\n";
            r += "Degrees     : " + ((int)df) + "\r\n";
            r += "Welch's Test: " + (1.0 - f.A(wt, (int)df)) + "\r\n";
            r += "F-Statistic : " + F + "\r\n";
            z = nu2 / (nu2 + nu1 * F);
            r += "F-Test      : " +
                (2.0 * (1 - f.IncompleteBetaFunctionIntegration(z, 0.5 * nu2, 0.5 * nu1, 1.0e-10))) + "\r\n";
            return r;
        }

        public string DataAnalysis(List<double> xl, List<double> yl)
        {
            return DataAnalysis(xl.ToArray(), yl.ToArray());
        }
    }
}
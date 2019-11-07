namespace BlackScholesEquation
{
    class CNMethod
    {
        // solve the partial differential equation U_t = a * U_xx
        // U(0, t) = U(1, t) = 0

        public double[] CrankNicolson(double a, double deltaT, double deltaX, double[] D)
        {
            double r = a * deltaT / (2.0 * deltaX * deltaX);
            int N = (int)(1.0 / deltaX);
            double[] A = new double[N], B = new double[N], C = new double[N], U = new double[N];

            B[0] = B[N - 1] = 1.0 + 2.0 * r;

            for (int i = 1; i < N - 1; i++)
            {
                A[i] = -r;
                B[i] = 1.0 + 2.0 * r;
                C[i] = -r;
            }

            for (int k = 1; k < N; k++)
            {
                if (B[k - 1] == 0)
                    return null;

                double m = A[k] / B[k - 1];

                B[k] -= m * C[k - 1];
                D[k] -= m * D[k - 1];
            }

            if (B[N - 1] == 0)
                return null;

            U[N - 1] = D[N - 1] / B[N - 1];

            for (int k = N - 2; k >= 0; k--)
                U[k] = (D[k] - C[k] * U[k + 1]) / B[k];

            return U;
        }
    }
}
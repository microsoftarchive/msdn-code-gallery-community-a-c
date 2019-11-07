
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraMatrices
{
    class Matrix
    {
        decimal[,] matriz;

        public Matrix(decimal[,] m)
        {
            matriz = m;
        }

        public decimal[,] Suma(decimal[,] m)
        {
            decimal[,] Sumada = new decimal[m.GetLength(0), m.GetLength(1)];

            if (matriz.GetLength(0) != m.GetLength(0) || matriz.GetLength(1) != m.GetLength(1))
                throw new Exception("Las matrices son impoisibles de sumar");

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Sumada[i, j] = m[i, j] + matriz[i, j];
                }
            }

            return Sumada;
        }

        public decimal[,] EscalarMult(decimal escalar)
        {
            decimal[,] multiplicada = new decimal[matriz.GetLength(0), matriz.GetLength(1)];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    multiplicada[i, j] = escalar * matriz[i, j];
                }
            }

            return multiplicada;
        }

        public decimal[,] Resta(decimal[,] m)
        {
            if (matriz.GetLength(0) != m.GetLength(0) || matriz.GetLength(1) != m.GetLength(1))
                throw new Exception("Las matrices son impoisibles de restar");

            Matrix matriz1 = new Matrix(m);

            return Suma(matriz1.EscalarMult(-1));
        }

        private decimal[,] ElimFilCol(decimal[,] a, int fila, int column)
        {
            decimal[,] result = new decimal[a.GetLength(0) - 1, a.GetLength(1) - 1];
            bool fil = false;
            bool col = false;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                col = false;
                if (i == fila) { fil = true; }
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (j == column) { col = true; }
                    if (!fil && !col) { result[i, j] = a[i, j]; }
                    if (!fil && col) { result[i, j] = a[i, j + 1]; }
                    if (fil && !col) { result[i, j] = a[i + 1, j]; }
                    if (fil && col) { result[i, j] = a[i + 1, j + 1]; }

                }
            }
            return result;
        }

        public decimal Determinante()
        {
            if (matriz.GetLength(0) != matriz.GetLength(1))
                throw new Exception("Matriz no cuadrada");
            return Determinante(this.matriz);
        }
        private decimal Determinante(decimal[,] m)
        {
            decimal determinante = 0;


            if (m.Length == 1)
                return m[0, 0];

            else
            {
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    determinante += (decimal)Math.Pow(-1, i) * m[i, 0] * Determinante(ElimFilCol(m, i, 0));
                }
            }

            return determinante;
        }

        private decimal[,] SustCol(decimal[,] m, decimal[] soluciones, int col)
        {
            decimal[,] sustituida = new decimal[m.GetLength(0), m.GetLength(1)];

            for (int i = 0; i < sustituida.GetLength(0); i++)
            {
                for (int j = 0; j < sustituida.GetLength(1); j++)
                {
                    if (j == col)
                        sustituida[i, j] = soluciones[i];

                    else
                        sustituida[i, j] = m[i, j];
                }
            }
            return sustituida;
        }

        public decimal[] Cramer(decimal[] terminos)
        {
            decimal[] soluciones = new decimal[terminos.Length];

            decimal determinante = Determinante(matriz);

            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                soluciones[j] = Determinante(SustCol(matriz, terminos, j)) / determinante;
            }
            return soluciones;
        }
        public decimal[,] Inversa()
        {
            decimal determinante = Determinante();
            decimal[,] result = new decimal[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = (decimal)Math.Pow(-1, i + j) * Determinante(ElimFilCol(matriz, i, j));
                }
            }
            result = EscalarMult(Transpuesta(result), 1 / determinante);
            return result;
        }
        decimal[,] Transpuesta(decimal[,] m)
        {
            decimal[,] result = new decimal[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = m[j, i];
                }
            }
            return result;
        }
        public decimal[,] Transpuesta()
        {
            decimal[,] result = new decimal[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matriz[j, i];
                }
            }
            return result;

        }
        decimal[,] EscalarMult(decimal[,] matriz, decimal escalar)
        {
            decimal[,] multiplicada = new decimal[matriz.GetLength(0), matriz.GetLength(1)];

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    multiplicada[i, j] = escalar * matriz[i, j];
                }
            }

            return multiplicada;
        }
        public decimal[,] ProductoMatrices(decimal[,] b)
        {
            if (matriz.GetLength(1) != b.GetLength(0))
                throw new Exception("No se puede multiplicar");
            decimal[,] result = new decimal[matriz.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    for (int k = 0; k < matriz.GetLength(1); k++)
                    {
                        result[i, j] += matriz[i, k] * b[k, j];
                    }
            return result;
        }
        public decimal[,] Gauss()
        {
            bool sePuedeContinuar = true;
            decimal[,] result = new decimal[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matriz[i, j];
                }

            }
            for (int i = 0; i < Math.Min(result.GetLength(0), result.GetLength(1)); i++)
            {
                if (result[i, i] == 0)
                {
                    for (int j = i + 1; j < result.GetLength(0); j++)
                    {
                        if (result[j, i] != 0)
                        {
                            IntercambiarFilas(result, i, j);
                            sePuedeContinuar = true;
                            break;
                        }
                        else
                        {
                            sePuedeContinuar = false;
                        }
                    }
                }
                if (sePuedeContinuar)
                {
                    AnulaColumna(result, i);
                }

            }
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = Math.Round(result[i, j], 2);
                }
            }
            return result;
        }

        private void AnulaColumna(decimal[,] matriz, int i)
        {
            decimal terminoAnulante = 0;
            for (int j = i + 1; j < matriz.GetLength(0); j++)
            {
                terminoAnulante = -1 * matriz[j, i] / matriz[i, i];
                for (int k = i; k < matriz.GetLength(1); k++)
                {
                    matriz[j, k] = matriz[i, k] * terminoAnulante + matriz[j, k];
                }
            }
        }

        private void IntercambiarFilas(decimal[,] result, int i, int j)
        {
            decimal[] fila1 = new decimal[result.GetLength(1)];
            for (int k = 0; k < result.GetLength(1); k++)
            {
                fila1[k] = result[i, k];
            }
            for (int k = 0; k < result.GetLength(1); k++)
            {
                result[i, k] = result[j, k];
                result[j, k] = fila1[k];

            }
        }
    }
}

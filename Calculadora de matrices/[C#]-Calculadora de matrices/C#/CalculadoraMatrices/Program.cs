using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CalculadoraMatrices
{
    class Program
    {
        static decimal[,] operando1;
        static decimal[,] operando2;
        static string operador;
        static decimal escalar;
        static string[] vectorInc;
        static decimal[] vectorTer;

        static void Main(string[] args)
        {
            Leer();
            Matrix matris = new Matrix(operando1);

            switch (operador)
            {
                case "+":
                    ImprimirMatriz(matris.Suma(operando2));
                    break;
                case "-":
                    ImprimirMatriz(matris.Resta(operando2));
                    break;
                case ".":
                    ImprimirMatriz(matris.EscalarMult(escalar));
                    break;
                case "det":
                    Console.WriteLine(matris.Determinante());
                    break;
                case "cramer":
                    ImprimeCramer(vectorInc, matris.Cramer(vectorTer));
                    break;
                case "inv":
                    ImprimirMatriz(matris.Inversa());
                    break;
                case "t":
                    ImprimirMatriz(matris.Transpuesta());
                    break;
                case "*":
                    ImprimirMatriz(matris.ProductoMatrices(operando2));
                    break;
                case "gauss":
                    ImprimirMatriz(matris.Gauss());
                    break;
            }
            Console.ReadLine();
        }
        private static void Leer()
        {
            StreamReader reader = new StreamReader("Intput.txt");

            operador = reader.ReadLine();
            if (operador == ".")
                escalar = decimal.Parse(reader.ReadLine());
            string[] orden = reader.ReadLine().Split('x');
            string[] aux = new string[0];
            int m = int.Parse(orden[0]);
            int n = int.Parse(orden[1]);
            operando1 = new decimal[m, n];
            for (int i = 0; i < m; i++)
            {
                aux = reader.ReadLine().Split(',');

                for (int j = 0; j < n; j++)
                {
                    operando1[i, j] = decimal.Parse(aux[j]);
                }
            }
            if (operador == "cramer")
            {
                orden = reader.ReadLine().Split('x');
                m = int.Parse(orden[0]);
                vectorInc = new string[m];
                for (int i = 0; i < m; i++)
                    vectorInc[i] = reader.ReadLine();
                orden = reader.ReadLine().Split('x');
                m = int.Parse(orden[0]);
                vectorTer = new decimal[m];
                for (int i = 0; i < m; i++)
                    vectorTer[i] = decimal.Parse(reader.ReadLine());

            }
            if (!reader.EndOfStream)
            {
                orden = reader.ReadLine().Split('x');
                m = int.Parse(orden[0]);
                n = int.Parse(orden[1]);
                operando2 = new decimal[m, n];
                for (int i = 0; i < m; i++)
                {
                    aux = reader.ReadLine().Split(',');

                    for (int j = 0; j < n; j++)
                    {
                        operando2[i, j] = decimal.Parse(aux[j]);
                    }
                }
            }
        }
        public static void ImprimirMatriz(decimal[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }
        public static void ImprimeCramer(string[] s, decimal[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine(s[i] + " = " + Convert.ToString(v[i]));
            }
        }
    }
}

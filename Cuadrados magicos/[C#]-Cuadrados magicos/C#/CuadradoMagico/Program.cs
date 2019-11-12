using System;
using System.Collections.Generic;
using System.Text;

namespace CuadradoMagico
{
    class Program
    {
        public static bool EsCuadradoPerfecto(int[,] matriz)
        {
            if (matriz.GetLength(0) != matriz.GetLength(1))
                return false;
            else
            {
                int suma1 = 0, suma2 = 0, suma3 = 0, suma4 = 0;
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        suma1 += matriz[i, j];
                        suma2 += matriz[j, i];
                        if (i == 0)
                        {
                            suma3 += matriz[j, j];
                            suma4 += matriz[j, matriz.GetLength(1) - 1 - j];
                        }
                    }
                    if (suma1 != suma2 || suma1 != suma3 || suma1 != suma4)
                        return false;
                    suma1 = 0;
                    suma2 = 0;
                }
                return true;
            }
        }


        static void Main(string[] args)
        {
            int[,] cuadrado ={ { 1, 8, 10, 15 }, { 12, 13, 3, 6 }, { 7, 2, 16, 9 }, { 14, 11, 5, 4 } };
            Console.WriteLine("La matriz cuadrada: ");
            for (int i = 0; i < cuadrado.GetLength(0); i++)
            {
                for (int j = 0; j < cuadrado.GetLength(1); j++)
                    Console.Write(cuadrado[i, j].ToString() + '\t');
                Console.WriteLine();
            }
            if (EsCuadradoPerfecto(cuadrado))
                Console.WriteLine("Es un cuadrado magico.");
            else
                Console.WriteLine("No es un cuadrado magico.");
            Console.ReadLine();
        }
    }
}

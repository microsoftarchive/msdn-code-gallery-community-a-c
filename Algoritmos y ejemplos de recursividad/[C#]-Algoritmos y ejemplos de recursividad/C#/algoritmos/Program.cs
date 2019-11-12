using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algoritmos
{
    class Program
    {

        static long Factorial(long n)
        {
            if (n < 0) throw new Exception("El parámetro debe ser positivo");
            else if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }

        static long FactorialIterativo(long n)
        {
            if (n < 0) throw new Exception("El parámetro debe ser positivo");
            long result = 1;
            for (long k = 1; k <= n; k++) result *= k;
            return result;
        }

        static int Mcd(int a, int b)
        {
            if (a < 0 || b < 0) throw new Exception("Los parámetros deben ser positivos");
            else if (b > a) return Mcd(b, a);
            else if (b == 0) return a;
            else return Mcd(a - b, b);
        }

        static int Pos(int[] a, int x)
        {
            return Pos(a, x, 0, a.Length - 1);
        }

        static int Pos(int[] a, int x, int inf, int sup)
        {
            if (inf > sup) return -1;
            int medio = inf + (sup - inf) / 2;
            if (x > a[medio]) return Pos(a, x, medio + 1, sup);
            else if (x < a[medio]) return Pos(a, x, inf, medio - 1);
            else return medio;
        }

        static long Fibonnaci(int n)
        {
            if (n == 0 || n == 1) return 1;
            else return Fibonnaci(n - 1) + Fibonnaci(n - 2);
        }

        static long FibonnaciIterativo(int n)
        {
            if (n < 0) throw new Exception("El parámetro debe ser positivo");
            long ultimo = 1, penultimo = 1;
            for (int k = 2; k <= n; k++)
            {
                long temp = penultimo; penultimo = ultimo; ultimo = ultimo + temp;
            }
            return ultimo;
        }

        

        static void Main(string[] args)
        {

            //Prueba de factorial
            do
            {
                Console.WriteLine("\nEntre un numero para hallar el factorial (Pecione Enter para pasar al siguiente proceso)");
                string s = Console.ReadLine();
                if (s.Length == 0) break;
                int k = Int32.Parse(s);
                Console.WriteLine("\nFactorial recursivo de {0} es {1}", k, Factorial(k));
                Console.WriteLine("\nFactorial iterativo de {0} es {1}", k, FactorialIterativo(k));
            } while (true);

            //Prueba de MCD
            do
            {
                Console.WriteLine("\nEntre dos numeros para hallar el MCD (Pecione Enter para pasar al siguiente proceso)");
                string s1 = Console.ReadLine();
                if (s1.Length == 0) break;
                string s2 = Console.ReadLine();
                int a = Int32.Parse(s1);
                int b = Int32.Parse(s2);
                Console.WriteLine("\nMCD de {0} y {1} es {2}", a, b, Mcd(a, b));
            } while (true);

            //Prueba de búsqueda binaria
            int[] valores = new int[20];
            Random generador = new Random();
            for (int k = 0; k < valores.Length; k++)
                valores[k] = generador.Next(40);
            Array.Sort(valores);
            Console.WriteLine("\nValores del array ordenado");
            for (int k = 0; k < valores.Length; k++)
                Console.Write("{0}  ", valores[k]);
            Console.WriteLine();
            do
            {
                Console.WriteLine("\nEntre el número a buscar (Pecione Enter para pasar al siguiente proceso)");
                string s3 = Console.ReadLine();
                if (s3.Length == 0) break;
                int k = Int32.Parse(s3);
                Console.WriteLine("El número {0} está en la posición {1}", k, Pos(valores, k));
            } while (true);

            //Prueba de Fibonnaci
            //Probar con valores hasta que se note la diferencia de tiempo entre la solución recursiva y la iterativa
            do
            {
                Console.WriteLine("\nEntre el número a buscar de Fibonnaci (Pecione Enter para salir)");
                string s4 = Console.ReadLine();
                if (s4.Length == 0) break;
                int k = Int32.Parse(s4);
                Console.WriteLine("El número {0} de la sucesión de Fibonnaci (via iterativa) es {1}", k, FibonnaciIterativo(k));
                Console.WriteLine("El número {0} de la sucesión de Fibonnaci (via recursiva) es {1}", k, Fibonnaci(k));
            } while (true);
        }
    }
}

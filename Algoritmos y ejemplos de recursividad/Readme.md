# Algoritmos y ejemplos de recursividad
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Console
## Topics
- Algorithm
- recurrence
## Updated
- 04/22/2012
## Description

<h1>Introduccion</h1>
<p><em>Grupo de metodos en c# para ilustrar el uso de la recursividad en este lenguage.</em></p>
<h1></h1>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Metodos para hallar el factorial de forma recurciva e iterativa, Hallar el MCD, hacer busquedas binarias,&nbsp;Prueba de Fibonnaci. Mediante una aplicacion de consola escrita en C# se pretende ilustrar el uso de la recursividad</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algoritmos
{
    class Program
    {

        static long Factorial(long n)
        {
            if (n &lt; 0) throw new Exception(&quot;El par&aacute;metro debe ser positivo&quot;);
            else if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }

        static long FactorialIterativo(long n)
        {
            if (n &lt; 0) throw new Exception(&quot;El par&aacute;metro debe ser positivo&quot;);
            long result = 1;
            for (long k = 1; k &lt;= n; k&#43;&#43;) result *= k;
            return result;
        }

        static int Mcd(int a, int b)
        {
            if (a &lt; 0 || b &lt; 0) throw new Exception(&quot;Los par&aacute;metros deben ser positivos&quot;);
            else if (b &gt; a) return Mcd(b, a);
            else if (b == 0) return a;
            else return Mcd(a - b, b);
        }

        static int Pos(int[] a, int x)
        {
            return Pos(a, x, 0, a.Length - 1);
        }

        static int Pos(int[] a, int x, int inf, int sup)
        {
            if (inf &gt; sup) return -1;
            int medio = inf &#43; (sup - inf) / 2;
            if (x &gt; a[medio]) return Pos(a, x, medio &#43; 1, sup);
            else if (x &lt; a[medio]) return Pos(a, x, inf, medio - 1);
            else return medio;
        }

        static long Fibonnaci(int n)
        {
            if (n == 0 || n == 1) return 1;
            else return Fibonnaci(n - 1) &#43; Fibonnaci(n - 2);
        }

        static long FibonnaciIterativo(int n)
        {
            if (n &lt; 0) throw new Exception(&quot;El par&aacute;metro debe ser positivo&quot;);
            long ultimo = 1, penultimo = 1;
            for (int k = 2; k &lt;= n; k&#43;&#43;)
            {
                long temp = penultimo; penultimo = ultimo; ultimo = ultimo &#43; temp;
            }
            return ultimo;
        }

        

        static void Main(string[] args)
        {

            //Prueba de factorial
            do
            {
                Console.WriteLine(&quot;\nEntre un numero para hallar el factorial (Pecione Enter para pasar al siguiente proceso)&quot;);
                string s = Console.ReadLine();
                if (s.Length == 0) break;
                int k = Int32.Parse(s);
                Console.WriteLine(&quot;\nFactorial recursivo de {0} es {1}&quot;, k, Factorial(k));
                Console.WriteLine(&quot;\nFactorial iterativo de {0} es {1}&quot;, k, FactorialIterativo(k));
            } while (true);

            //Prueba de MCD
            do
            {
                Console.WriteLine(&quot;\nEntre dos numeros para hallar el MCD (Pecione Enter para pasar al siguiente proceso)&quot;);
                string s1 = Console.ReadLine();
                if (s1.Length == 0) break;
                string s2 = Console.ReadLine();
                int a = Int32.Parse(s1);
                int b = Int32.Parse(s2);
                Console.WriteLine(&quot;\nMCD de {0} y {1} es {2}&quot;, a, b, Mcd(a, b));
            } while (true);

            //Prueba de b&uacute;squeda binaria
            int[] valores = new int[20];
            Random generador = new Random();
            for (int k = 0; k &lt; valores.Length; k&#43;&#43;)
                valores[k] = generador.Next(40);
            Array.Sort(valores);
            Console.WriteLine(&quot;\nValores del array ordenado&quot;);
            for (int k = 0; k &lt; valores.Length; k&#43;&#43;)
                Console.Write(&quot;{0}  &quot;, valores[k]);
            Console.WriteLine();
            do
            {
                Console.WriteLine(&quot;\nEntre el n&uacute;mero a buscar (Pecione Enter para pasar al siguiente proceso)&quot;);
                string s3 = Console.ReadLine();
                if (s3.Length == 0) break;
                int k = Int32.Parse(s3);
                Console.WriteLine(&quot;El n&uacute;mero {0} est&aacute; en la posici&oacute;n {1}&quot;, k, Pos(valores, k));
            } while (true);

            //Prueba de Fibonnaci
            //Probar con valores hasta que se note la diferencia de tiempo entre la soluci&oacute;n recursiva y la iterativa
            do
            {
                Console.WriteLine(&quot;\nEntre el n&uacute;mero a buscar de Fibonnaci (Pecione Enter para salir)&quot;);
                string s4 = Console.ReadLine();
                if (s4.Length == 0) break;
                int k = Int32.Parse(s4);
                Console.WriteLine(&quot;El n&uacute;mero {0} de la sucesi&oacute;n de Fibonnaci (via iterativa) es {1}&quot;, k, FibonnaciIterativo(k));
                Console.WriteLine(&quot;El n&uacute;mero {0} de la sucesi&oacute;n de Fibonnaci (via recursiva) es {1}&quot;, k, Fibonnaci(k));
            } while (true);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;algoritmos&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;Factorial(<span class="cs__keyword">long</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(n&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;El&nbsp;par&aacute;metro&nbsp;debe&nbsp;ser&nbsp;positivo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(n&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>&nbsp;n&nbsp;*&nbsp;Factorial(n&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;FactorialIterativo(<span class="cs__keyword">long</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(n&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;El&nbsp;par&aacute;metro&nbsp;debe&nbsp;ser&nbsp;positivo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;result&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">long</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;k&nbsp;&lt;=&nbsp;n;&nbsp;k&#43;&#43;)&nbsp;result&nbsp;*=&nbsp;k;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Mcd(<span class="cs__keyword">int</span>&nbsp;a,&nbsp;<span class="cs__keyword">int</span>&nbsp;b)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(a&nbsp;&lt;&nbsp;<span class="cs__number">0</span>&nbsp;||&nbsp;b&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;Los&nbsp;par&aacute;metros&nbsp;deben&nbsp;ser&nbsp;positivos&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(b&nbsp;&gt;&nbsp;a)&nbsp;<span class="cs__keyword">return</span>&nbsp;Mcd(b,&nbsp;a);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(b&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;a;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>&nbsp;Mcd(a&nbsp;-&nbsp;b,&nbsp;b);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Pos(<span class="cs__keyword">int</span>[]&nbsp;a,&nbsp;<span class="cs__keyword">int</span>&nbsp;x)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Pos(a,&nbsp;x,&nbsp;<span class="cs__number">0</span>,&nbsp;a.Length&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Pos(<span class="cs__keyword">int</span>[]&nbsp;a,&nbsp;<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;inf,&nbsp;<span class="cs__keyword">int</span>&nbsp;sup)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(inf&nbsp;&gt;&nbsp;sup)&nbsp;<span class="cs__keyword">return</span>&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;medio&nbsp;=&nbsp;inf&nbsp;&#43;&nbsp;(sup&nbsp;-&nbsp;inf)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(x&nbsp;&gt;&nbsp;a[medio])&nbsp;<span class="cs__keyword">return</span>&nbsp;Pos(a,&nbsp;x,&nbsp;medio&nbsp;&#43;&nbsp;<span class="cs__number">1</span>,&nbsp;sup);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(x&nbsp;&lt;&nbsp;a[medio])&nbsp;<span class="cs__keyword">return</span>&nbsp;Pos(a,&nbsp;x,&nbsp;inf,&nbsp;medio&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>&nbsp;medio;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;Fibonnaci(<span class="cs__keyword">int</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(n&nbsp;==&nbsp;<span class="cs__number">0</span>&nbsp;||&nbsp;n&nbsp;==&nbsp;<span class="cs__number">1</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">return</span>&nbsp;Fibonnaci(n&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;&#43;&nbsp;Fibonnaci(n&nbsp;-&nbsp;<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;FibonnaciIterativo(<span class="cs__keyword">int</span>&nbsp;n)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(n&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(<span class="cs__string">&quot;El&nbsp;par&aacute;metro&nbsp;debe&nbsp;ser&nbsp;positivo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;ultimo&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;penultimo&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;k&nbsp;&lt;=&nbsp;n;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">long</span>&nbsp;temp&nbsp;=&nbsp;penultimo;&nbsp;penultimo&nbsp;=&nbsp;ultimo;&nbsp;ultimo&nbsp;=&nbsp;ultimo&nbsp;&#43;&nbsp;temp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ultimo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prueba&nbsp;de&nbsp;factorial</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nEntre&nbsp;un&nbsp;numero&nbsp;para&nbsp;hallar&nbsp;el&nbsp;factorial&nbsp;(Pecione&nbsp;Enter&nbsp;para&nbsp;pasar&nbsp;al&nbsp;siguiente&nbsp;proceso)&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(s.Length&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;Int32.Parse(s);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nFactorial&nbsp;recursivo&nbsp;de&nbsp;{0}&nbsp;es&nbsp;{1}&quot;</span>,&nbsp;k,&nbsp;Factorial(k));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nFactorial&nbsp;iterativo&nbsp;de&nbsp;{0}&nbsp;es&nbsp;{1}&quot;</span>,&nbsp;k,&nbsp;FactorialIterativo(k));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prueba&nbsp;de&nbsp;MCD</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nEntre&nbsp;dos&nbsp;numeros&nbsp;para&nbsp;hallar&nbsp;el&nbsp;MCD&nbsp;(Pecione&nbsp;Enter&nbsp;para&nbsp;pasar&nbsp;al&nbsp;siguiente&nbsp;proceso)&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s1&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(s1.Length&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s2&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;a&nbsp;=&nbsp;Int32.Parse(s1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;b&nbsp;=&nbsp;Int32.Parse(s2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nMCD&nbsp;de&nbsp;{0}&nbsp;y&nbsp;{1}&nbsp;es&nbsp;{2}&quot;</span>,&nbsp;a,&nbsp;b,&nbsp;Mcd(a,&nbsp;b));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prueba&nbsp;de&nbsp;b&uacute;squeda&nbsp;binaria</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;valores&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[<span class="cs__number">20</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;generador&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;valores.Length;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;valores[k]&nbsp;=&nbsp;generador.Next(<span class="cs__number">40</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Array.Sort(valores);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nValores&nbsp;del&nbsp;array&nbsp;ordenado&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;valores.Length;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(<span class="cs__string">&quot;{0}&nbsp;&nbsp;&quot;</span>,&nbsp;valores[k]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nEntre&nbsp;el&nbsp;n&uacute;mero&nbsp;a&nbsp;buscar&nbsp;(Pecione&nbsp;Enter&nbsp;para&nbsp;pasar&nbsp;al&nbsp;siguiente&nbsp;proceso)&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s3&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(s3.Length&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;Int32.Parse(s3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;El&nbsp;n&uacute;mero&nbsp;{0}&nbsp;est&aacute;&nbsp;en&nbsp;la&nbsp;posici&oacute;n&nbsp;{1}&quot;</span>,&nbsp;k,&nbsp;Pos(valores,&nbsp;k));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Prueba&nbsp;de&nbsp;Fibonnaci</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Probar&nbsp;con&nbsp;valores&nbsp;hasta&nbsp;que&nbsp;se&nbsp;note&nbsp;la&nbsp;diferencia&nbsp;de&nbsp;tiempo&nbsp;entre&nbsp;la&nbsp;soluci&oacute;n&nbsp;recursiva&nbsp;y&nbsp;la&nbsp;iterativa</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;\nEntre&nbsp;el&nbsp;n&uacute;mero&nbsp;a&nbsp;buscar&nbsp;de&nbsp;Fibonnaci&nbsp;(Pecione&nbsp;Enter&nbsp;para&nbsp;salir)&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;s4&nbsp;=&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(s4.Length&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;Int32.Parse(s4);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;El&nbsp;n&uacute;mero&nbsp;{0}&nbsp;de&nbsp;la&nbsp;sucesi&oacute;n&nbsp;de&nbsp;Fibonnaci&nbsp;(via&nbsp;iterativa)&nbsp;es&nbsp;{1}&quot;</span>,&nbsp;k,&nbsp;FibonnaciIterativo(k));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;El&nbsp;n&uacute;mero&nbsp;{0}&nbsp;de&nbsp;la&nbsp;sucesi&oacute;n&nbsp;de&nbsp;Fibonnaci&nbsp;(via&nbsp;recursiva)&nbsp;es&nbsp;{1}&quot;</span>,&nbsp;k,&nbsp;Fibonnaci(k));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1></h1>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p><em>****************************************************************************************************</em></p>
<p>&nbsp;</p>

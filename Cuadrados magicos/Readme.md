# Cuadrados magicos
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Console
## Topics
- Algorithm
## Updated
- 04/15/2012
## Description

<h1>Introduccion</h1>
<p><em>Resolucion de cuadrados magicos</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>De La wikipedia :<a href="http://es.wikipedia.org/wiki/Cuadrado_m%C3%A1gico">http://es.wikipedia.org/wiki/Cuadrado_m%C3%A1gico</a></em></p>
<p>Un&nbsp;<strong>cuadrado m&aacute;gico</strong>&nbsp;es una&nbsp;<a class="new" title="Tabla (matemáticas) (aún no redactado)" href="http://es.wikipedia.org/w/index.php?title=Tabla_(matem%C3%A1ticas)&action=edit&redlink=1">tabla</a>&nbsp;donde se dispone
 de una serie de&nbsp;<a title="Número entero" href="http://es.wikipedia.org/wiki/N%C3%BAmero_entero">n&uacute;meros enteros</a>&nbsp;en un cuadrado o&nbsp;<a class="mw-redirect" title="Matriz (matemática)" href="http://es.wikipedia.org/wiki/Matriz_(matem%C3%A1tica)">matriz</a>&nbsp;de
 forma tal que la suma de los n&uacute;meros por columnas, filas y diagonales principales sea la misma, la&nbsp;<strong>constante m&aacute;gica</strong>. Usualmente los n&uacute;meros empleados para rellenar las casillas son consecutivos, de 1 a&nbsp;<em>n</em>&sup2;,
 siendo&nbsp;<em>n</em>&nbsp;el n&uacute;mero de columnas y filas del cuadrado m&aacute;gico.</p>
<p>Los cuadrados m&aacute;gicos actualmente no tienen ninguna aplicaci&oacute;n t&eacute;cnica conocida que se beneficien de estas caracter&iacute;sticas, por lo que sigue recluido al divertimento, curiosidad y al pensamiento matem&aacute;tico. Aparte de esto,
 en las llamadas ciencias ocultas y m&aacute;s concretamente en la&nbsp;<a title="Magia" href="http://es.wikipedia.org/wiki/Magia">magia</a>&nbsp;tienen un lugar destacado.</p>
<p><em><br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
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
                for (int i = 0; i &lt; matriz.GetLength(0); i&#43;&#43;)
                {
                    for (int j = 0; j &lt; matriz.GetLength(1); j&#43;&#43;)
                    {
                        suma1 &#43;= matriz[i, j];
                        suma2 &#43;= matriz[j, i];
                        if (i == 0)
                        {
                            suma3 &#43;= matriz[j, j];
                            suma4 &#43;= matriz[j, matriz.GetLength(1) - 1 - j];
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
            Console.WriteLine(&quot;La matriz cuadrada: &quot;);
            for (int i = 0; i &lt; cuadrado.GetLength(0); i&#43;&#43;)
            {
                for (int j = 0; j &lt; cuadrado.GetLength(1); j&#43;&#43;)
                    Console.Write(cuadrado[i, j].ToString() &#43; '\t');
                Console.WriteLine();
            }
            if (EsCuadradoPerfecto(cuadrado))
                Console.WriteLine(&quot;Es un cuadrado magico.&quot;);
            else
                Console.WriteLine(&quot;No es un cuadrado magico.&quot;);
            Console.ReadLine();
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;CuadradoMagico&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;EsCuadradoPerfecto(<span class="cs__keyword">int</span>[,]&nbsp;matriz)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(matriz.GetLength(<span class="cs__number">0</span>)&nbsp;!=&nbsp;matriz.GetLength(<span class="cs__number">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;suma1&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;suma2&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;suma3&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;suma4&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;matriz.GetLength(<span class="cs__number">0</span>);&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;matriz.GetLength(<span class="cs__number">1</span>);&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma1&nbsp;&#43;=&nbsp;matriz[i,&nbsp;j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma2&nbsp;&#43;=&nbsp;matriz[j,&nbsp;i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(i&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma3&nbsp;&#43;=&nbsp;matriz[j,&nbsp;j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma4&nbsp;&#43;=&nbsp;matriz[j,&nbsp;matriz.GetLength(<span class="cs__number">1</span>)&nbsp;-&nbsp;<span class="cs__number">1</span>&nbsp;-&nbsp;j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(suma1&nbsp;!=&nbsp;suma2&nbsp;||&nbsp;suma1&nbsp;!=&nbsp;suma3&nbsp;||&nbsp;suma1&nbsp;!=&nbsp;suma4)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma1&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;suma2&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[,]&nbsp;cuadrado&nbsp;={&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">8</span>,&nbsp;<span class="cs__number">10</span>,&nbsp;<span class="cs__number">15</span>&nbsp;},&nbsp;{&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">13</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">6</span>&nbsp;},&nbsp;{&nbsp;<span class="cs__number">7</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;<span class="cs__number">9</span>&nbsp;},&nbsp;{&nbsp;<span class="cs__number">14</span>,&nbsp;<span class="cs__number">11</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">4</span>&nbsp;}&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;La&nbsp;matriz&nbsp;cuadrada:&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;cuadrado.GetLength(<span class="cs__number">0</span>);&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;cuadrado.GetLength(<span class="cs__number">1</span>);&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.Write(cuadrado[i,&nbsp;j].ToString()&nbsp;&#43;&nbsp;<span class="cs__string">'\t'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(EsCuadradoPerfecto(cuadrado))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Es&nbsp;un&nbsp;cuadrado&nbsp;magico.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;No&nbsp;es&nbsp;un&nbsp;cuadrado&nbsp;magico.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1></h1>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************<br>
*************************************************************************************</p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p>&nbsp;</p>

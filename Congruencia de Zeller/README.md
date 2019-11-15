# Congruencia de Zeller
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- Windows Forms
## Topics
- C#
- Numerical Computing
## Updated
- 05/18/2017
## Description

<h1>Introduction</h1>
<p><span>La congruencia de Zeller es un algoritmo ideado por Julius Christian Johannes Zeller&nbsp;</span><span>un sacerdote protestante alem&aacute;n que vivi&oacute; en el siglo XIX. Zeller observ&oacute; que exist&iacute;a una dependencia entre las fechas
 del calendario gregoriano y el d&iacute;a de la semana que les correspond&iacute;a. A ra&iacute;z de esa observaci&oacute;n, obtuvo (se dice que por tanteo), esta f&oacute;rmula, en apariencia m&aacute;gica, que lleva su nombre,&nbsp;</span><span>para calcular
 el d&iacute;a de la semana de cualquier fecha del calendario.</span></p>
<div></div>
<div><span>Para el calendario gregoriano la congruencia de Zeller es:</span></div>
<p>&nbsp;</p>
<p><img id="173569" src="173569-captura_1.png" alt="" width="320" height="39"></p>
<p><span>para el calendario juliano es:</span></p>
<p><img id="173570" src="173570-captura_2.png" alt="" width="320" height="44"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div><span>donde<br>
h es el d&iacute;a de la semana (0 = s&aacute;bado, 1 = domingo, 2 = lunes,...),<br>
q es el d&iacute;a del mes,<br>
m es el mes,<br>
J es la centuria (es realidad &lfloor;a&ntilde;o / 100&rfloor;) y<br>
K el a&ntilde;o de la centuria (a&ntilde;o mod 100).<br>
Enero y febrero se cuentan como meses 13 y 14 del a&ntilde;o anterior. Observe, que el 2 de enero de 2013, es m=13; a&ntilde;o=2012<br>
Es oportuno recordar que la funci&oacute;n mod es el residuo que queda de la divisi&oacute;n de dos n&uacute;meros.<br>
En las implementaciones inform&aacute;ticas en las que el m&oacute;dulo de un n&uacute;mero negativo es negativo, la manera m&aacute;s sencilla de obtener un resultado entre 0 y 6 es reemplazar - 2 J por &#43; 5 J y - J por &#43; 6 J.<br>
<br>
Algoritmo Z(y, m, d)</span></div>
<div><span>Entrada: El a&ntilde;o y, mes m (1 &le; m &le; 12) y d&iacute;a d (1 &le; d &le; 31).</span></div>
<div><span>Salida: El d&iacute;a de la semana.</span></div>
<div><span>t &larr; (0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4)&nbsp;</span></div>
<div><span>n &larr; (domingo, lunes, martes, mi&eacute;rcoles, jueves, viernes, s&aacute;bado)</span></div>
<div><span>if m &lt; 3&nbsp;</span></div>
<div><span>y &larr; y - 1&nbsp;</span></div>
<div><span>w &larr; (y &#43; &lfloor;y/4&rfloor; - &lfloor;y/100&rfloor; &#43; &lfloor;y/400&rfloor; &#43; tm-1 &#43; d) mod 7&nbsp;</span></div>
<div><span>devolver nw</span></div>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>&nbsp;</p>
<div>
<div><span>Una forma m&aacute;s f&aacute;cil de ver el mismo desarrollo es la siguiente</span></div>
</div>
<p><span></p>
<div>
<div></div>
</div>
<div>
<div>a = (14 - Mes) / 12</div>
</div>
<div>
<div>y = A&ntilde;o - a</div>
</div>
<div>
<div>m = Mes &#43; 12 * a - 2</div>
</div>
<div>
<div></div>
</div>
<div>
<div>Para el calendario Juliano:</div>
</div>
<div>
<div>d = (5 &#43; dia &#43; y &#43; y/4 &#43; (31*m)/12) mod 7</div>
</div>
<div>
<div></div>
</div>
<div>
<div>Para el calendario Gregoriano:</div>
</div>
<div>
<div>&nbsp;d = (d&iacute;a &#43; y &#43; y/4 - y/100 &#43; y/400 &#43; (31*m)/12) mod 7</div>
</div>
<div>
<div>El resultado es un cero (0) para el domingo, 1 para el lunes&hellip; 6 para el s&aacute;bado</div>
</div>
<div>
<div></div>
</div>
<div>
<div>Ejemplo, &iquest;En qu&eacute; d&iacute;a de la semana cae el 2 de agosto de 1953??</div>
</div>
<div>
<div>' a = (14 - 8) / 12 = 0</div>
</div>
<div>
<div>' y = 1953 - 0 = 1953</div>
</div>
<div>
<div>' m = 8 &#43; 12 * 0 - 2 = 6</div>
</div>
<div>
<div>' d = (2 &#43; 1953 &#43; 1953 / 4 - 1953 / 100 &#43; 1953 / 400 &#43; (31 * 6) / 12) Mod 7</div>
</div>
<div>
<div>' &nbsp; = (2 &#43; 1953 &#43; &nbsp;488 &nbsp; - &nbsp; &nbsp;19 &nbsp; &#43; &nbsp; &nbsp; 4 &nbsp; &nbsp;&#43; &nbsp; &nbsp;15 &nbsp; &nbsp;) mod 7</div>
</div>
<div>
<div>' &nbsp; = 2443 mod 7</div>
</div>
<div>
<div>' &nbsp; = 0</div>
</div>
<div>
<div>' &nbsp;El valor cero(0) corresponde al domingo.</div>
<div></div>
<div></div>
<div>La norma ISO 8601:2004, en su apartado 3.2.2 define el c&oacute;digo de los d&iacute;as de la semana as&iacute; como los nombres de los d&iacute;as de la semana (evidentemente est&aacute;n en ingl&eacute;s) pero lo que interesa resaltar es que la numeraci&oacute;n
 que propone el est&aacute;ndar no coincide con la numeraci&oacute;n que proporciona el algoritmo de Zeller (y por tanto, la funci&oacute;n [DayOfWeek]) la diferencia est&aacute; en la forma de contar, el algoritmo de Zeller proporciona valores del 0 (domingo)
 1 lunes&hellip; hasta al 6(s&aacute;bado), mientras que la norma ISO 8601, dice que los valores van desde el 1 lunes al 7 domingo.</div>
</div>
<div></div>
</span>
<p></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><img id="173572" src="https://i1.code.msdn.s-msft.com/congruencia-de-zeller-48268c0a/image/file/173572/1/captura_3.png" alt="" width="357" height="307" style="display:block; margin-left:auto; margin-right:auto"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Zeller_I_Forms&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;dias&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;&nbsp;Domingo&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Lunes&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Martes&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Miercoles&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Jueves&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Viernes&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;&nbsp;Sabado&nbsp;&quot;</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Exit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button2_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;dia,&nbsp;mes,&nbsp;a&ntilde;o;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dia&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBox1.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mes&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBox2.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a&ntilde;o&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBox3.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;((dia&nbsp;&lt;&nbsp;<span class="cs__number">32</span>)&nbsp;&amp;&amp;&nbsp;(mes&nbsp;&lt;&nbsp;<span class="cs__number">13</span>)&nbsp;&amp;&amp;&nbsp;(a&ntilde;o&nbsp;&lt;&nbsp;<span class="cs__number">10000</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;a&nbsp;=&nbsp;(<span class="cs__number">14</span>&nbsp;-&nbsp;mes)&nbsp;/&nbsp;<span class="cs__number">12</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;y&nbsp;=&nbsp;a&ntilde;o&nbsp;-&nbsp;a;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;m&nbsp;=&nbsp;mes&nbsp;&#43;&nbsp;<span class="cs__number">12</span>&nbsp;*&nbsp;a&nbsp;-&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;d&nbsp;=&nbsp;(dia&nbsp;&#43;&nbsp;y&nbsp;&#43;&nbsp;y&nbsp;/&nbsp;<span class="cs__number">4</span>&nbsp;-&nbsp;y&nbsp;/&nbsp;<span class="cs__number">100</span>&nbsp;&#43;&nbsp;y&nbsp;/&nbsp;<span class="cs__number">400</span>&nbsp;&#43;&nbsp;(<span class="cs__number">31</span>&nbsp;*&nbsp;m)&nbsp;/&nbsp;<span class="cs__number">12</span>)&nbsp;%&nbsp;<span class="cs__number">7</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBox4.Text&nbsp;=&nbsp;dias[d];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>

# Bubble Sort C#
## License
- MIT
## Technologies
- C#
- Visual Studio 2013
## Topics
- bubble sort
- Ordering
- Estrutura de Dados
## Updated
- 04/18/2015
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><span style="font-size:small">O&nbsp;<em><strong>bubble sort</strong></em>, ou ordena&ccedil;&atilde;o por flutua&ccedil;&atilde;o (literalmente &quot;por bolha&quot;), &eacute; um&nbsp;<a title="Algoritmo de ordenação" href="http://pt.wikipedia.org/wiki/Algoritmo_de_ordena%C3%A7%C3%A3o">algoritmo
 de ordena&ccedil;&atilde;o</a>&nbsp;dos mais simples. A ideia &eacute; percorrer o&nbsp;<a class="mw-redirect" title="Vector" href="http://pt.wikipedia.org/wiki/Vector">vector</a>&nbsp;diversas vezes, a cada passagem fazendo flutuar para o topo o maior elemento
 da sequ&ecirc;ncia. Essa movimenta&ccedil;&atilde;o lembra a forma como as bolhas em um&nbsp;<a title="Tanque (reservatório)" href="http://pt.wikipedia.org/wiki/Tanque_(reservat%C3%B3rio)">tanque</a>&nbsp;de &aacute;gua procuram seu pr&oacute;prio n&iacute;vel,
 e disso vem o nome do algoritmo.</span></p>
<p><span style="font-size:small">No melhor caso, o algoritmo executa&nbsp;<img class="mwe-math-fallback-image-inline x_tex" src="http://upload.wikimedia.org/math/7/b/8/7b8b965ad4bca0e41ab51de7b31363a1.png" alt="n">&nbsp;opera&ccedil;&otilde;es relevantes,
 onde&nbsp;<em>n</em>&nbsp;representa o n&uacute;mero de elementos do vector. No pior caso, s&atilde;o feitas&nbsp;<img class="mwe-math-fallback-image-inline x_tex" src="http://upload.wikimedia.org/math/b/0/8/b08b1c6ec09f20907eb1d6f1392c01c6.png" alt="n^2">&nbsp;opera&ccedil;&otilde;es.
 A&nbsp;<a title="Complexidade" href="http://pt.wikipedia.org/wiki/Complexidade">complexidade</a>&nbsp;desse&nbsp;<a title="Algoritmo" href="http://pt.wikipedia.org/wiki/Algoritmo">algoritmo</a>&nbsp;&eacute; de&nbsp;<a title="Ordem quadrática" href="http://pt.wikipedia.org/wiki/Ordem_quadr%C3%A1tica">Ordem
 quadr&aacute;tica</a>. Por isso, ele n&atilde;o &eacute; recomendado para programas que precisem de velocidade e operem com quantidade elevada de dados. - Wikip&eacute;dia</span></p>
<p><span style="font-size:small">Esse exemplo mostra uma forma de ser feita utilizando C# ordenando uma cadeia de numeros.</span></p>
<h1>Descri&ccedil;&atilde;o</h1>
<p><span style="font-size:small">Este codigo simples, mostra para que o leitor, como ele pode ser feito na linguagem C#, &nbsp;a fim de ajudar a compreender melhor como pode ser feito nessa linguagem.</span></p>
<p><span style="font-size:small">Os exemplos abaixos mostram perfeitamente como funciona um bubble sort. A partir do in&iacute;cio da cole&ccedil;&atilde;o ele come&ccedil;a a comparar cada par adjacente, trocando a sua posi&ccedil;&atilde;o, caso eles n&atilde;o
 estajam na ordem certa (a &uacute;ltima for menor do que o anterior a ela). Depois de cada itera&ccedil;&atilde;o, um elemento inferior (o &uacute;ltima) &eacute; necess&aacute;rio para ser comparado at&eacute; que n&atilde;o haja mais elementos para a esquerda
 para ser comparadas.</span><em><br>
</em></p>
<p><img id="136602" src="136602-bubble-sort-example-300px.gif" alt="" width="300" height="180">Cr&eacute;dito pela Anima&ccedil;&atilde;o:&quot;Bubble-sort-example-300px&quot; by Swfung8 - Own work. Licensed under CC BY-SA 3.0 via Wikimedia Commons
 - http://commons.wikimedia.org/wiki/File:Bubble-sort-example-300px.gif#/media/File:Bubble-sort-example-300px.gif</p>
<p>&nbsp;</p>
<p><em><br>
</em></p>
<p><img id="136601" src="136601-bubble_sort_animation.gif" alt="" width="280" height="237">Cr&eacute;ditos pela anima&ccedil;&atilde;o:&nbsp;&quot;Bubble sort animation&quot; por Este ficheiro foi inicialmente carregado por Nmnogueira em Wikip&eacute;dia
 em ingl&ecirc;s - Own work by uploader using Matlab. Licenciado sob CC BY-SA 2.5, via Wikimedia Commons - http://commons.wikimedia.org/wiki/File:Bubble_sort_animation.gif#/media/File:Bubble_sort_animation.gif</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;numbers&nbsp;=&nbsp;{&nbsp;<span class="cs__number">45</span>,&nbsp;<span class="cs__number">81</span>,&nbsp;<span class="cs__number">29</span>,&nbsp;<span class="cs__number">66</span>,&nbsp;<span class="cs__number">03</span>,&nbsp;<span class="cs__number">52</span>,&nbsp;<span class="cs__number">51</span>,&nbsp;<span class="cs__number">55</span>,&nbsp;<span class="cs__number">74</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Example&nbsp;Bubble&nbsp;Sort&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bubbleSort(numbers,&nbsp;numbers.Length);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;numbers.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(numbers[i]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;bubbleSort(<span class="cs__keyword">int</span>[]&nbsp;arr,&nbsp;<span class="cs__keyword">int</span>&nbsp;length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;repos&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*Ir&aacute;&nbsp;percorrer&nbsp;o&nbsp;vetor,&nbsp;comparando&nbsp;cada&nbsp;elemento&nbsp;do&nbsp;vetor&nbsp;com&nbsp;o&nbsp;elemento&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;imediatamente&nbsp;seguinte&nbsp;(arr[j]&nbsp;=&nbsp;arr[j&nbsp;&#43;&nbsp;1];)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;O&nbsp;numero&nbsp;maximo&nbsp;de&nbsp;execu&ccedil;&otilde;es&nbsp;do&nbsp;trecho&nbsp;do&nbsp;algoritmo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;p/&nbsp;que&nbsp;o&nbsp;vetor&nbsp;fique&nbsp;ordenado&nbsp;&eacute;&nbsp;de&nbsp;N&nbsp;-&nbsp;1,&nbsp;onde&nbsp;N&nbsp;&eacute;&nbsp;o&nbsp;numero&nbsp;de&nbsp;vezes.*/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;Will&nbsp;go&nbsp;through&nbsp;the&nbsp;vector,&nbsp;comparing&nbsp;each&nbsp;element&nbsp;of&nbsp;the&nbsp;array&nbsp;with&nbsp;the&nbsp;element&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;immediately&nbsp;following&nbsp;(arr[j]&nbsp;=&nbsp;arr[j&nbsp;&#43;&nbsp;1];)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;maximum&nbsp;number&nbsp;of&nbsp;implementation&nbsp;of&nbsp;the&nbsp;algorithm&nbsp;for&nbsp;the&nbsp;vector&nbsp;section&nbsp;be&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;ordained&nbsp;is&nbsp;N&nbsp;-&nbsp;1,&nbsp;where&nbsp;N&nbsp;is&nbsp;the&nbsp;number&nbsp;of&nbsp;times.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;i&nbsp;determina&nbsp;o&nbsp;n&uacute;mero&nbsp;de&nbsp;etapas&nbsp;para&nbsp;a&nbsp;ordena&ccedil;&atilde;o</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;i&nbsp;determines&nbsp;the&nbsp;number&nbsp;of&nbsp;steps&nbsp;for&nbsp;sorting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;length&nbsp;-&nbsp;<span class="cs__number">1</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;j&nbsp;determina&nbsp;o&nbsp;numero&nbsp;de&nbsp;compara&ccedil;&otilde;es&nbsp;em&nbsp;cada&nbsp;etapa&nbsp;e&nbsp;os&nbsp;indices&nbsp;a&nbsp;serem</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//pesquisados&nbsp;para&nbsp;a&nbsp;compara&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;j&nbsp;determines&nbsp;the&nbsp;number&nbsp;of&nbsp;comparisons&nbsp;in&nbsp;each&nbsp;step&nbsp;and&nbsp;the&nbsp;indices&nbsp;to&nbsp;be</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;studied&nbsp;for&nbsp;comparison</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;length&nbsp;-&nbsp;(i&nbsp;&#43;&nbsp;<span class="cs__number">1</span>);&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(arr[j]&nbsp;&gt;&nbsp;arr[j&nbsp;&#43;&nbsp;<span class="cs__number">1</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;repos&nbsp;=&nbsp;arr[j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;arr[j]&nbsp;=&nbsp;arr[j&nbsp;&#43;&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;arr[j&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;repos;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>programa.cs</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on bubble sort, see http://en.wikipedia.org/wiki/Bubble_sort</em></p>
<p><em>Para mais informa&ccedil;&otilde;es sobre bubble sort(Met&oacute;do bolha), veja&nbsp;http://pt.wikipedia.org/wiki/Bubble_sort</em></p>

# BDD com C#, SpecFlow e WaTin
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- C# Language
- Visual Studio 2013
- BDD
- SpecFlow
- WaTin
- Behavior Driven Development
## Topics
- Architecture and Design
- automated tests of Visual Studio extensions
- Design Patterns
- BDD
- Behavior Driven Development
## Updated
- 04/21/2014
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><em>Demonstra&ccedil;&atilde;o simples do uso de BDD com SpecFlow e WaTin para automatiza&ccedil;&atilde;o de interface gr&aacute;fica.&nbsp;</em></p>
<p><em><br>
</em></p>
<h1><span>Ferramentas necess&aacute;rias:</span></h1>
<p><em>SpecFlow para Visual Studio 2012 / 2013&nbsp;</em></p>
<p><em>Nuget&nbsp;</em></p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Descri&ccedil;&atilde;o</span></p>
<p><span>O que &eacute; o BDD? &nbsp;</span></p>
<p><span>B</span>ehavior&nbsp;<span>D</span>riven&nbsp;<span>D</span>evelopment, ou Desenvolvimento Guiado por comportamento, &eacute; uma t&eacute;cnica de desenvolvimento &aacute;gil que visa integrar regras de neg&oacute;cio com linguagem de programa&ccedil;&atilde;o,
 encorajando a colabora&ccedil;&atilde;o entre os desenvolvedores, QA, e pessoas n&atilde;o-t&eacute;cnicas (analistas de neg&oacute;cios, gestores, etc). S&atilde;o focados a linguagem e intera&ccedil;&otilde;es usadas no processo de desenvolvimento de software.
 Para o desenvolvedor que se beneficiar dessa t&eacute;cnica &eacute; poss&iacute;vel escrever os testes em sua l&iacute;ngua nativa em combina&ccedil;&atilde;o com a Ubiquitous Language (Linguagem Onipresente), ditada por quem entende do neg&oacute;cio, para
 que a comunica&ccedil;&atilde;o seja facilmente convergida.</p>
<p>Segue abaixo um trecho retirado do Wikipedia sobre as pr&aacute;ticas do BDD:</p>
<blockquote>
<ol>
<li>Envolver as partes interessadas no processo atrav&eacute;s de Outside-in Development (Desenvolvimento de Fora pra Dentro);
</li><li>Usar exemplos para descrever o comportamento de uma aplica&ccedil;&atilde;o ou unidades de c&oacute;digo;
</li><li>Automatizar os exemplos para prover um feedback r&aacute;pido e testes de regress&atilde;o;
</li><li>Usar &ldquo;deve&rdquo; na hora de descrever o comportamento de software para ajudar esclarecer responsabilidades e permitir que funcionalidades do software sejam questionadas;
</li><li>Usar &ldquo;dubl&ecirc;s&rdquo; de teste (mocks, stubs, fakes, dummies, spies) para auxiliar na colabora&ccedil;&atilde;o entre m&oacute;dulos e c&oacute;digos que ainda n&atilde;o foram escritos;
</li></ol>
</blockquote>
<p>Outside-in Development: &nbsp;Basicamente &eacute; se concentrar em satisfazer a necessidade das partes interessadas em seu software, seu objetivo final &eacute; a produ&ccedil;&atilde;o de um software que &eacute; altamente consum&iacute;vel e atende as
 expectativas dos interessados.</p>
<p>No BDD conseguimos dar vida a documenta&ccedil;&atilde;o, associando os benef&iacute;cios de uma documenta&ccedil;&atilde;o formal, baseada no neg&oacute;cio, com testes de unidade que provam que a documenta&ccedil;&atilde;o de fato &eacute; v&aacute;lida.</p>
<p>Por ser guiado pelo comportamento, &eacute; f&aacute;cil percebemos o benef&iacute;cio desta t&eacute;cnica atrav&eacute;s de uma interface gr&aacute;fica, onde podemos&nbsp;mostrar para as pessoas n&atilde;o t&eacute;cnicas que os requisitos descritos atrav&eacute;s
 dos comportamentos est&atilde;o sendo cumpridos. Estes requisitos podem ser descritos por qualquer pessoa, desde que alinhados com a equipe de neg&oacute;cios.</p>
<p>formal, baseada no neg&oacute;cio, com testes de unidade que provam que a documenta&ccedil;&atilde;o de fato &eacute; v&aacute;lida.</p>
<p>&nbsp;</p>
<p style="text-align:center"><span style="color:#ff0000">Reques&iacute;to de comportamento</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="color:#ff0000">C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__preproc">#language:&nbsp;pt-BR</span>&nbsp;
&nbsp;
&nbsp;Funcionalidade:&nbsp;Visitar&nbsp;a&nbsp;documenta&ccedil;&atilde;o&nbsp;<span class="cs__keyword">do</span>&nbsp;SpecFlow&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Para&nbsp;que&nbsp;facilite&nbsp;a&nbsp;tomada&nbsp;de&nbsp;decis&atilde;o&nbsp;na&nbsp;hora&nbsp;de&nbsp;utilizar&nbsp;o&nbsp;SpecFlow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Eu,&nbsp;como&nbsp;usu&aacute;rio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Desejo&nbsp;conhecer&nbsp;a&nbsp;documenta&ccedil;&atilde;o&nbsp;oficial.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
@mytag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Cen&aacute;rio:&nbsp;Visualizar&nbsp;a&nbsp;configura&ccedil;&atilde;o&nbsp;padr&atilde;o&nbsp;<span class="cs__keyword">do</span>&nbsp;SpecFlow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dado&nbsp;que&nbsp;eu&nbsp;entrei&nbsp;na&nbsp;tela&nbsp;inicial&nbsp;<span class="cs__keyword">do</span>&nbsp;site&nbsp;SpecFlow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E&nbsp;cliquei&nbsp;no&nbsp;item&nbsp;<span class="cs__string">&quot;Documentation&quot;</span>,&nbsp;no&nbsp;menu&nbsp;horizontal&nbsp;<span class="cs__keyword">do</span>&nbsp;topo&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Quando&nbsp;eu&nbsp;clicar&nbsp;em&nbsp;<span class="cs__string">&quot;Configuration&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Ent&atilde;o&nbsp;devo&nbsp;ser&nbsp;levado&nbsp;para&nbsp;a&nbsp;p&aacute;gina&nbsp;&nbsp;de&nbsp;demonstra&ccedil;&atilde;o&nbsp;da&nbsp;configura&ccedil;&atilde;o&nbsp;padr&atilde;o&nbsp;<span class="cs__keyword">do</span>&nbsp;SpecFlow&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;E&nbsp;deve&nbsp;ser&nbsp;exibido&nbsp;um&nbsp;alert&nbsp;dizendo&nbsp;<span class="cs__string">&quot;Ol&aacute;&nbsp;mundo,&nbsp;sou&nbsp;o&nbsp;Watin&quot;</span>.&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p style="text-align:center"><span style="font-size:xx-small; color:#ff0000">Iniciando o IE, atrav&eacute;s do WaTin e abrindo uma p&aacute;gina.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">IE&nbsp;browser&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;IE();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Given(@<span class="js__string">&quot;que&nbsp;eu&nbsp;entrei&nbsp;na&nbsp;tela&nbsp;inicial&nbsp;do&nbsp;site&nbsp;SpecFlow&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;DadoQueEuEntreiNaTelaInicialDoSiteSpecFlow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;browser.GoTo(<span class="js__string">&quot;http://www.specflow.org/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p style="text-align:center"><span style="color:#ff0000">&nbsp;Entrando num item do menu e validando se a URL bate com o requesito</span></p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;[Given(@<span class="js__string">&quot;cliquei&nbsp;no&nbsp;item&nbsp;&quot;</span><span class="js__string">&quot;(.*)&quot;</span><span class="js__string">&quot;,&nbsp;no&nbsp;menu&nbsp;horizontal&nbsp;do&nbsp;topo&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;DadoCliqueiNoItemNoMenuHorizontalDoTopo(string&nbsp;p0)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;menuHorizontal&nbsp;=&nbsp;browser.List(Find.ById(<span class="js__string">&quot;menu-main&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;itemDocumentacao&nbsp;=&nbsp;menuHorizontal.OwnListItem(Find.ById(<span class="js__string">&quot;menu-item-267&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;itemDocumentacao.Links[<span class="js__num">0</span>].Click();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsTrue(browser.Uri.ToString().Equals(<span class="js__string">&quot;http://www.specflow.org/documentation/&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<ul>
</ul>
<h1>Refer&ecirc;ncias:</h1>
<p><a href="http://dannorth.net/introducing-bdd/" target="_blank">Dan North &amp; Associates<br>
</a><a href="http://elemarjr.net/" target="_blank">Elemar Dev<br>
</a><a href="http://msdn.microsoft.com/pt-br/magazine/gg490346.aspx" target="_blank">MSDN<br>
</a><a href="http://en.wikipedia.org/wiki/Domain-driven_design" target="_blank">Wikipedia</a></p>

# Como exibir caixa de mensagem em uma aplicação Windows Forms com C#
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
## Topics
- C#
- Windows Forms
- .Net Programming
## Updated
- 09/20/2013
## Description

<h1>Introdu&ccedil;&atilde;o</h1>
<p><span style="font-size:small"><em><em>Quando voc&ecirc; est&aacute; come&ccedil;ando na &aacute;rea de programa&ccedil;&atilde;o de aplica&ccedil;&otilde;es Windows Forms um dos objetos mais legais e importantes que est&aacute; presente em todas as telas
 &eacute; a classe utilizada para exibir as caixas de mensagem. O nome desta classe em aplica&ccedil;&otilde;es Windows Forms &eacute; MessageBox. Este exemplo demonstra como exibir caixa de mensagem simples, de alerta, de erro e de pergunta em aplica&ccedil;&otilde;es
 Windows Forms utilizando C#.</em></em></span></p>
<h1><span>Tecnologias Utilizadas</span></h1>
<p><span style="font-size:small"><em>- Visual Studio Express 2012 for Windows Desktop</em></span></p>
<p><span style="font-size:small"><em>- Linguagem C#</em></span></p>
<h1>Classe MessageBox</h1>
<p><span style="font-size:small">A tradu&ccedil;&atilde;o da palavra &eacute;:</span></p>
<p><span style="font-size:small">- Message = Mensagem</span></p>
<p><span style="font-size:small">- Box = Caixa</span></p>
<p><span style="font-size:small">Ou seja, a classe representa um objeto de uma caixa de mensagem. Com ela &eacute; poss&iacute;vel exibir uma caixa de mensagem com um t&iacute;tulo, texto, bot&otilde;es e &iacute;cones para instruir o usu&aacute;rio.</span></p>
<p><br>
<span style="font-size:small">Para exibir a caixa de mensagem &eacute; utilizado o m&eacute;todo
<strong>Show( par&acirc;metro(s) )</strong>. A tradu&ccedil;&atilde;o da palavra <strong>
Show </strong>&eacute; <strong>Mostrar</strong>, ou seja, &eacute; um m&eacute;todo utilizado para mostrar a caixa de mensagem.&nbsp;</span></p>
<p><span style="font-size:small">A classe <strong>MessageBox </strong>&eacute; localizada dentro do namespace
<strong>System.Windows.Forms</strong> conforme imagem abaixo (imagem exibida quando passa o mouse sobre a classe MessageBox).</span></p>
<p><img id="96735" src="96735-passarmousesobre.png" alt="" width="812" height="155"></p>
<p><span style="font-size:20px; font-weight:bold">Caixa de Mensagem Simples</span></p>
<p><span style="font-size:small">Para exibir uma caixa de mensagem simples, basta utilizar o m&eacute;todo
<strong>Show </strong>e passar como par&acirc;metro apenas um texto com a mensagem que ser&aacute; exibida na tela. C&oacute;digo a seguir:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MessageBox.Show(&quot;Mensagem Simples&quot;);</pre>
<div class="preview">
<pre class="csharp">MessageBox.Show(<span class="cs__string">&quot;Mensagem&nbsp;Simples&quot;</span>);</pre>
</div>
</div>
</div>
<h1><span>Caixa de Mensagem de Aten&ccedil;&atilde;o, Erro, Informa&ccedil;&atilde;o, Pergunta</span></h1>
<p><span style="font-size:small">A caixa de mensagem possui 21 maneiras de ser constru&iacute;da utilizando o m&eacute;todo Show, ou seja, possui 21 construtores.
</span></p>
<p><span style="font-size:small">Para exibir as caixas de mensagem de aten&ccedil;&atilde;o, erro, informa&ccedil;&atilde;o e perguntas, &eacute; utilizado o construtor n&uacute;mero sete, conforme imagem a seguir.</span></p>
<p><img id="96738" src="96738-construtorsete.png" alt="" width="793" height="106"></p>
<p>Par&acirc;metros:</p>
<p>1) O primeiro par&acirc;metro &eacute; o texto que ser&aacute; exibido na caixa de mensagem.</p>
<p>2) O sergundo par&acirc;metro &eacute; o texto exibido no t&iacute;tulo da janela da caixa de mensagem.</p>
<p>3) O terceiro par&acirc;metro s&atilde;o quais bot&otilde;es ser&atilde;o exibidos na caixa de mensagem.</p>
<p>4) O quarto par&acirc;metro &eacute; o &iacute;cone que ser&aacute; exibido na janela.</p>
<p>&nbsp;</p>
<p>Caixa de mensagem de aten&ccedil;&atilde;o. Exibe apenas o bot&atilde;o OK e o &iacute;cone utilizado &eacute; o
<strong>Warning </strong>( icone amarelo ).</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MessageBox.Show(&quot;Aten&ccedil;&atilde;o, campo X obrigat&oacute;rio&quot;, &quot;Aten&ccedil;&atilde;o&quot;, MessageBoxButtons.OK, MessageBoxIcon.Warning);</pre>
<div class="preview">
<pre class="csharp">MessageBox.Show(<span class="cs__string">&quot;Aten&ccedil;&atilde;o,&nbsp;campo&nbsp;X&nbsp;obrigat&oacute;rio&quot;</span>,&nbsp;<span class="cs__string">&quot;Aten&ccedil;&atilde;o&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Warning);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Caixa de mensagem de erro. Exibe apenas o bot&atilde;o OK e o &iacute;cone utilizado &eacute; o
<strong>Error </strong>que &eacute; um &iacute;cone vermelho.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MessageBox.Show(&quot;Erro ao cadastrar.&quot;, &quot;Erro&quot;, MessageBoxButtons.OK, MessageBoxIcon.Error);</pre>
<div class="preview">
<pre class="csharp">MessageBox.Show(<span class="cs__string">&quot;Erro&nbsp;ao&nbsp;cadastrar.&quot;</span>,&nbsp;<span class="cs__string">&quot;Erro&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Error);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Caixa de mensagem de informa&ccedil;&atilde;o. Exibe apenas o bot&atilde;o OK e o &iacute;cone utilizado &eacute; o
<strong>Information </strong>que &eacute; um &iacute;cone azul.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">MessageBox.Show(&quot;Cadastrado com sucesso&quot;, &quot;Informa&ccedil;&atilde;o&quot;, MessageBoxButtons.OK, MessageBoxIcon.Information);</pre>
<div class="preview">
<pre class="csharp">MessageBox.Show(<span class="cs__string">&quot;Cadastrado&nbsp;com&nbsp;sucesso&quot;</span>,&nbsp;<span class="cs__string">&quot;Informa&ccedil;&atilde;o&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Caixa de mensagem de pergunta. Exibe os bot&otilde;es YesNo (SimN&atilde;o) e o &iacute;cone &eacute; o
<strong>Question </strong>com um ponto de interroga&ccedil;&atilde;o.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">            DialogResult dialogResult = MessageBox.Show(&quot;Tem certeza?&quot;, &quot;Pergunta&quot;, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                //A&ccedil;&atilde;o/c&oacute;digo caso o usu&aacute;rio aperte o bot&atilde;o Yes (se o idioma do computador for em portugu&ecirc;s ser&aacute; SIM )
                MessageBox.Show(&quot;Apertou Sim&quot;);
            }
            else
            {
                //A&ccedil;&atilde;o/c&oacute;digo caso o usu&aacute;rio aperte o bot&atilde;o No (se o idioma do computador for em portugu&ecirc;s ser&aacute; N&Atilde;O )
                MessageBox.Show(&quot;Apertou N&atilde;o&quot;);
            }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogResult&nbsp;dialogResult&nbsp;=&nbsp;MessageBox.Show(<span class="cs__string">&quot;Tem&nbsp;certeza?&quot;</span>,&nbsp;<span class="cs__string">&quot;Pergunta&quot;</span>,&nbsp;MessageBoxButtons.YesNo,&nbsp;MessageBoxIcon.Question);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dialogResult&nbsp;==&nbsp;System.Windows.Forms.DialogResult.Yes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//A&ccedil;&atilde;o/c&oacute;digo&nbsp;caso&nbsp;o&nbsp;usu&aacute;rio&nbsp;aperte&nbsp;o&nbsp;bot&atilde;o&nbsp;Yes&nbsp;(se&nbsp;o&nbsp;idioma&nbsp;do&nbsp;computador&nbsp;for&nbsp;em&nbsp;portugu&ecirc;s&nbsp;ser&aacute;&nbsp;SIM&nbsp;)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Apertou&nbsp;Sim&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//A&ccedil;&atilde;o/c&oacute;digo&nbsp;caso&nbsp;o&nbsp;usu&aacute;rio&nbsp;aperte&nbsp;o&nbsp;bot&atilde;o&nbsp;No&nbsp;(se&nbsp;o&nbsp;idioma&nbsp;do&nbsp;computador&nbsp;for&nbsp;em&nbsp;portugu&ecirc;s&nbsp;ser&aacute;&nbsp;N&Atilde;O&nbsp;)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Apertou&nbsp;N&atilde;o&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
&nbsp;</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&lt;object width=&quot;0&quot; height=&quot;0&quot; data=&quot;data:application/x-silverlight-2,&quot; type=&quot;application/x-silverlight-2&quot;&gt; &lt;param name=&quot;id&quot; value=&quot;4b8bf81a-1baa-93b6-3ad9-2aa048bd85a8&quot; /&gt;<span><a href="http://go.microsoft.com/fwlink/?LinkID=149156" style="text-decoration:none"><img src="-?linkid=108181" alt="Get Microsoft Silverlight" style="border-style:none"></a></span>
 &lt;/object&gt; </p>

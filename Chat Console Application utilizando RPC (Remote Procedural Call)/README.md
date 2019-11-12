# Chat Console Application utilizando RPC (Remote Procedural Call)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- IPC and RPC
- Remote procedure call
## Topics
- threading
- RPC
- Inter-process Communication
- Thread Synchronization
- Threads
- Remote procedure call
## Updated
- 07/11/2013
## Description

<h3><span style="font-size:2em">Introdu&ccedil;&atilde;o</span></h3>
<p>Esta aplica&ccedil;&atilde;o simples &eacute; para exemplificar o uso das t&eacute;cnicas de Remote Procedural Call (RPC) na comunica&ccedil;&atilde;o entre processos com um chat.&nbsp;</p>
<h1><span>Executando o exemplo</span></h1>
<p><span style="color:#ff0000"><strong>Muito Importante:</strong></span> PARA INICIAR A APLICA&Ccedil;&Atilde;O PRIMEIRO DEVE SER INICIADO A APLICA&Ccedil;&Atilde;O MailServer. ELA INICIAR&Aacute; OUTROS 2 PROCESSOS CLIENTE.</p>
<p>Para depugar o cliente deve fechar os processos abertos automaticamente e depois iniciar a aplication MailClient pelo Visual Studio</p>
<p><span style="font-size:20px; font-weight:bold">Descri&ccedil;&atilde;o</span></p>
<p>Essa aplica&ccedil;&atilde;o consiste em tem um processo servidor, onde ele ser&aacute; o dono do objeto. O objeto compartilhado ser&aacute; as mensagens. Essas mensagens s&atilde;o constantemente atualizadas nos outros processos por uma thread.</p>
<p>Ou seja, neste projeto existe:</p>
<ul>
<li>No minimo 3 processos (1 servidor, 2 clientes) </li><li>1 Thread para cada cliente que ir&aacute; atualizar as mensagens que forem chegando.
</li></ul>
<p>&nbsp;</p>
<h1>Arquitetura</h1>
<p>O projeto funciona com 3 aplica&ccedil;&otilde;es essenciais umas pras outras. IMail, MailClient, MailServer.</p>
<h2>IMail</h2>
<p>Esta aplica&ccedil;&atilde;o so tem uma classe dentro dela, que &eacute; a <em>
ISend.cs</em></p>
<p>Esta classe define as funcoes do objeto compartilhado, como a comunica&ccedil;&atilde;o entre processos &eacute; feita pela rede, quando o Objeto &eacute; recebido ele n&atilde;o &eacute; tipado, assim &eacute; preciso realizar um Cast utilizando essa interface
 para que a classe que &nbsp;foi recebida essa informa&ccedil;&atilde;o consiga interpretar aquele objeto e transformalo em um tipo conhecido.</p>
<h2>MailServer</h2>
<p>Mail server &eacute; onde &eacute; feita a abertura da porta para que os clientes possam acessar determinados objetos. Ao fazer isso o objeto &eacute; instanciado e fica disponivel para que os clientes o acessem</p>
<h2>MailClient</h2>
<p>Mail Client &eacute; (ou s&atilde;o) a(s) aplica&ccedil;&otilde;es que fazem o acesso a este objeto compartilhado. Assim, ao enviar uma mensagem o que &eacute; feito &eacute; a atualiza&ccedil;&atilde;o de um objeto da classe
<em>SendMail.cs</em>&nbsp;que est&aacute; dentro da aplica&ccedil;&atilde;o <strong>
MailServer</strong>.</p>
<p>&Eacute; importante ressaltar que nesse ponto &eacute; onde &eacute; apontado aonde est&aacute; rodando o servidor. No nosso caso &eacute; no localhost. Para acessar em outra m&aacute;quina basta trocar este endere&ccedil;o para o endere&ccedil;o IP.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Type&nbsp;requiredType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(ISend);&nbsp;
&nbsp;
&nbsp;remoteObject&nbsp;=&nbsp;(ISend)Activator.GetObject(requiredType,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;tcp://localhost:9998/MailServer&quot;</span>);</pre>
</div>
</div>
</div>
<p>Segue imagem da tela:</p>
<p><img id="92254" src="92254-print1.png" alt="" width="625" height="596"></p>

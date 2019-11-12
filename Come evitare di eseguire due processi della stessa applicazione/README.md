# Come evitare di eseguire due processi della stessa applicazione
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- .NET Framework
- .NET Framework 4.0
## Topics
- Architecture and Design
- threading
## Updated
- 03/18/2012
## Description

<h1>Introduction</h1>
<div><em><span><em>
<p>Questo semplice esempio di codice fa uso della Classe Mutex , la quale esegue una verifica di quanti processi di un applicazione sono eseguiti. Viene fornito un semplice esempio dimostrativo scaricabile dove nel file Program.cs , e inserito il codice per
 evitare che vengano eseguiti due processi della stessa applicazione , quindi compilare il progetto , avviare l'applicazione per due volte dall'eseguibile prodotto dalla compilazione. Nel primo avvio l'applicazione si avvier&agrave; regolarmente , invece tentando
 di avviare un nuovo processo della stessa applicazione si avr&agrave; visualizzato un messaggio che indica che vi l'applicazione e gi&agrave; in esecuzione.</p>
</em></span></em></div>
<h1><span>Building the Sample</span></h1>
<div><em>Questo esempio e stato creato e compilato con VisualStudio 2010 e net Framework 4.0</em></div>
<div><span style="font-size:20px; font-weight:bold">&nbsp;</span></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div>Con questo esempio , verr&agrave; dimostrato cone evitare di eseguire due processi della stessa applicazione.Con vb.net e sufficiente flaggare la check box 'rendi a istanza singola' che trovate nelle propriet&agrave; del progetto alla sezione Applicazione.Questa
 possibilit&agrave; non e disponibile in un applicazione eseguita con C#, ed ecco che ci viene in aiuto la Classe Mutex.Per maggiori informazioni riguardo la classe Mutex vi rimando al seguente
<a href="http://msdn.microsoft.com/en-us/library/system.threading.mutex.aspx">Link.</a>&nbsp;</div>
<div>&nbsp;</div>
<div>
<p>Ma ora vediamo come utilizzarla , in questo esempio viene eseguito nel file Program.cs una verifica mediante la classe Mutex.</p>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/it-IT/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/it-IT/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/it-IT/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/it-IT/library/System.Threading.aspx" target="_blank" title="Auto generated link to System.Threading">System.Threading</a>;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MutexClassExample&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;Mutex&nbsp;m;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Punto&nbsp;di&nbsp;ingresso&nbsp;principale&nbsp;dell'applicazione.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[STAThread]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;first&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Mutex(<span class="cs__keyword">true</span>,&nbsp;Application.ProductName.ToString(),&nbsp;<span class="cs__keyword">out</span>&nbsp;first);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;((first))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.EnableVisualStyles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.SetCompatibleTextRenderingDefault(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run(<span class="cs__keyword">new</span>&nbsp;Form1());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.ReleaseMutex();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Applicazione&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Application.ProductName.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&nbsp;&#43;<span class="cs__string">&quot;gi&agrave;&nbsp;in&nbsp;esecuzione&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;}&nbsp;
&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>Questa riga di codice&nbsp; m = new Mutex(true, Application.ProductName.ToString(), out first); richiede tre parametri.Il primio&nbsp; parametro initiallyOwned di tipo bool ,<span class="hps">vero</span>
<span class="hps">per dare</span> <span class="hps">la propriet&agrave;</span>
<span class="hps">thread chiamante</span> <span class="hps">iniziale del</span>
<span class="hps">mutex</span><span>, altrimenti</span> <span class="hps">false.Il secondo parametro di tipo string a cui dobbiamo assegnare il nome della nostra applicazione , l'ultimo infine sempre di tipo bool che assegna il risultato alla variabile
 first . Quest'ultima determina se l'applicazione e gi&agrave; in esecuzione o meno a seconda dello stato. In questo caso se true avremo il messaggio di applicazione gi&agrave; in esecuzione , se false significa che non vi era ancora un processo della nostra
 applicazione avviato.</span></div>
<div>&nbsp;</div>
<h1>More Information</h1>
<div><em>Per maggiori informazioni potete contattarmi a questo <a href="http://community.visual-basic.it/carmelolamonica/default.aspx">
indirizzo</a> .</em></div>

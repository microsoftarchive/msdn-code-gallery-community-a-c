# Cargar datos de mySQL
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Data Access
## Updated
- 05/28/2011
## Description

<h1>Introducci&oacute;n</h1>
<p><em>En este simple ejemplo voy a cargar en una aplicaci&oacute;n de Windows Forms en un combobox los datos de una base de datos en mySQL.</em></p>
<h1>Requisitos para cargar el ejemplo</h1>
<p><em><span>Si deseamos crear una aplicaci&oacute;n en C# que se conecte a mySQL, es necesario bajarse los conectores de mySQL.</span><br>
<span><br>
</span><br>
<span>Pueden googlear y buscar mySQL C# connector y bajarse los conectores. En mi caso lo baj&eacute; de este link (el sitio web de mySQL tiene un delf&iacute;n rid&iacute;culo con cara del retrasado de Flipper):</span><br>
<span><a href="http://dev.mysql.com/downloads/connector/net/6.2.html">http://dev.mysql.com/downloads/connector/net/6.2.html</a></span><br>
<br>
<span>En mi caso, mi base de datos se llama:</span><br>
<span>DB1, el usuario se llama root y el pwd root.</span><br>
<span><br>
</span><br>
<span>En mi base de datos DB1, tengo una tabla llamada empleados con la columna nombre.</span><br>
<span><br>
</span><br>
<span>Para crear una base de datos llamada DB1 en mysql:</span><br>
<strong><em>Create database db1;&nbsp;</em></strong><br>
<strong><em><br>
</em></strong><br>
<span>Para crear una tabla en mySQL el c&oacute;digo que use fue el siguiente:</span><br>
<span><strong><em>Create table empleados(nombre char(20);</em></strong></span><br>
<span><strong><em><br>
</em></strong></span><br>
<span>Para insertar datos;</span><br>
<span><strong><em>Insert into empleados values(&quot;Juan&quot;);</em></strong></span><br>
<span><strong><em>Insert into empleados values(&quot;Jose&quot;);</em></strong></span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span>Los valores Juan y Jose ser&aacute;n cargados y mi formulario de C#.</span><br>
<span>Estoy usando un archivo de Configuraci&oacute;n AppConfig con los siguientes datos de conexi&oacute;n a mySQL:</span><br>
<br>
<br>
&quot;SERVER=localhost ;DATABASE=db1;UID=root; PASSWORD=root&quot;;<br>
<br>
<br>
<span>El resto es agregar la referencia mySQL a mi aplicaci&oacute;n y agregar luego el uso de MySQL:</span><br>
<span><br>
</span><br>
</p>
<div class="separator"><a href="http://2.bp.blogspot.com/_F7cZ5fhxFC8/TTsEgHJYyRI/AAAAAAAAAo8/0k6KmWhzQn4/s1600/Agregar&#43;referencia&#43;mysql.JPG"><img src="-agregar&#43;referencia&#43;mysql.jpg" border="0" alt="" width="258" height="320"></a></div>
<br>
</em>
<p></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Windows.Forms.aspx" target="_blank" title="Auto generated link to System.Windows.Forms">System.Windows.Forms</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MySql.Data.MySqlClient;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/System.Configuration.aspx" target="_blank" title="Auto generated link to System.Configuration">System.Configuration</a>;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WindowsFormsApplication2&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;MyConString&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;connectionStringName&quot;</span>].ToString();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MySqlConnection&nbsp;connection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MySqlConnection(MyConString);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MySqlCommand&nbsp;command&nbsp;=&nbsp;connection.CreateCommand();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MySqlDataReader&nbsp;Reader;&nbsp;command.CommandText&nbsp;=&nbsp;<span class="cs__string">&quot;select&nbsp;nombre&nbsp;from&nbsp;empleados&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Reader&nbsp;=&nbsp;command.ExecuteReader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(Reader.Read())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;comboBox1.Items.Add(Reader[<span class="cs__string">&quot;nombre&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>El archivo adjundo</em> </li></ul>
<h1>More Information</h1>
<p><em>Para m&aacute;s informaci&oacute;n ver mi blog:</em></p>
<p><em><a href="http://elpaladintecnologico.blogspot.com/2011/01/c-y-la-base-de-datos-mysql.html">http://elpaladintecnologico.blogspot.com/2011/01/c-y-la-base-de-datos-mysql.html</a><br>
</em></p>

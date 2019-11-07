# C# y procedimientos almacenados de SQL Server
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
## Topics
- Data Access
## Updated
- 06/02/2011
## Description

<h1>Introducci&oacute;n</h1>
<p>En este ejemplo, voy a trabajar con Windows Forms y con Procedimientos almacenados de SQL Server. El trabajo fue realizado por uno de mis alumnos (Miguel Caviedes) y funciona en SQL Server 2005 y 2008 (deber&iacute;a funcionar en 2000 o superior).</p>
<p><em><br>
</em></p>
<h1><span>Requerimientos</span></h1>
<p><em></p>
<div>En este ejemplo, voy a trabajar con Windows Forms y con Procedimientos almacenados de SQL Server. El trabajo fue realizado por uno de mis alumnos (Miguel Caviedes) y funciona en SQL Server 2005 y 2008 (deber&iacute;a funcionar en 2000 o superior).</div>
<div>Este ejemplo puede ser usado tambi&eacute;n con WPF.</div>
<br>
</em>
<p></p>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p><em></p>
<div>En este ejemplo, voy a trabajar con Windows Forms y con Procedimientos almacenados de SQL Server. El trabajo fue realizado por uno de mis alumnos (Miguel Caviedes) y funciona en SQL Server 2005 y 2008 (deber&iacute;a funcionar en 2000 o superior).</div>
<div>Este ejemplo puede ser usado tambi&eacute;n con WPF.</div>
<div>Lo que hace este ejemplo es insertar nombres, apellidos, emails y direcciones al presionar el bot&oacute;n&nbsp;<strong>Nuevo Registro.</strong></div>
<div><strong><br>
</strong></div>
<div class="separator"><a href="http://1.bp.blogspot.com/-wzoyScrX8lg/TVsG0Es-P7I/AAAAAAAAApU/9eT0h34e2b0/s1600/insertardatos&#43;procedimientos&#43;almacenados.jpg"></a></div>
<div><strong><br>
</strong></div>
<div><strong><br>
</strong></div>
<div><strong>Figura 1. Formulario</strong></div>
<div>Primeramente, voy a crearme una tabla de SQL Server de clientes:</div>
<div>SET&nbsp;ANSI_NULLS&nbsp;ON</div>
<div>GO</div>
<div>SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON</div>
<div>GO</div>
<div>CREATE&nbsp;TABLE&nbsp;[dbo].[cliente](</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[idCliente] [bigint]&nbsp;IDENTITY(1,1)&nbsp;NOT&nbsp;NULL,</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[nombres] [nchar](50)&nbsp;COLLATEModern_Spanish_CI_AS&nbsp;NULL,</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[apellidos] [nchar](50)&nbsp;COLLATEModern_Spanish_CI_AS&nbsp;NULL,</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[direccion] [nchar](50)&nbsp;COLLATEModern_Spanish_CI_AS&nbsp;NULL,</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[email] [nchar](100)&nbsp;COLLATEModern_Spanish_CI_AS&nbsp;NULL,</div>
<div>&nbsp;CONSTRAINT&nbsp;[PK_cliente]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED</div>
<div>(</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[idCliente]&nbsp;ASC</div>
<div>)WITH&nbsp;(PAD_INDEX&nbsp;&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF)&nbsp;ON[PRIMARY]</div>
<div>)&nbsp;ON&nbsp;[PRIMARY]</div>
<div></div>
<div>Luego, creamos algunos datos en la tabla (ese trabajito les dejo como tarea).</div>
<div>Ahora, voy a crear un procedimiento almacenado que inserta datos en mi tabla de clientes:</div>
<div></div>
<div>set&nbsp;ANSI_NULLS&nbsp;ON</div>
<div>set&nbsp;QUOTED_IDENTIFIER&nbsp;ON</div>
<div>GO</div>
<div>CREATE&nbsp;PROCEDURE&nbsp;[dbo].[InsertarCliente]</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@nombres&nbsp;nchar(50),</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@apellidos&nbsp;nchar(50),</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@direccion&nbsp;nchar(50),</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@email&nbsp;nchar(100)</div>
<div>AS</div>
<div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Insert&nbsp;into&nbsp;cliente&nbsp;values</div>
<div>(@nombres,</div>
<div>@apellidos,</div>
<div>@direccion,</div>
<div>@email)</div>
&nbsp;&nbsp;</em>
<p></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public partial class WFClientes : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public WFClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    this.textBox1.Text = &quot;&quot;;
                    this.textBox2.Text = &quot;&quot;;
                    this.textBox3.Text = &quot;&quot;;
                    this.textBox4.Text = &quot;&quot;;
                    this.textBox5.Text = &quot;&quot;;
                    this.button4.Visible = true;
                    this.button1.Visible = false;
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(&quot;Please open a new connection&quot; &#43; &quot;\n&quot;
                            &#43; &quot;TargetSite: &quot; &#43; ex.TargetSite &#43; &quot;\n&quot; &#43;
                            &quot;Source: &quot; &#43; ex.Source &#43; &quot;\n&quot;

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show(&quot;Please open a new connection&quot; &#43; &quot;\n&quot;
                            &#43; &quot;TargetSite: &quot; &#43; ex.TargetSite &#43; &quot;\n&quot; &#43;
                            &quot;Source: &quot; &#43; ex.Source &#43; &quot;\n&quot; &#43;
                            &quot;ErrorCode: &quot; &#43; ex.ErrorCode &#43; &quot;\n&quot; &#43;
                            &quot;Server: &quot; &#43; ex.Server &#43; &quot;\n&quot; &#43;
                            &quot;State: &quot; &#43; ex.State &#43; &quot;\n&quot; &#43;
                            &quot;Number: &quot; &#43; ex.Number &#43; &quot;\n&quot; &#43;
                            &quot;Message: &quot; &#43; ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;WFClientes&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;BindingSource&nbsp;bindingSource1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;SqlDataAdapter&nbsp;dataAdapter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlDataAdapter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;WFClientes()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox2.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox3.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox4.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox5.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button4.Visible&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Visible&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(System.InvalidOperationException&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;open&nbsp;a&nbsp;new&nbsp;connection&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;TargetSite:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.TargetSite&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Source:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Source&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CargarLog(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//error&nbsp;de&nbsp;sentencia&nbsp;sql&nbsp;que&nbsp;no&nbsp;sea&nbsp;la&nbsp;correta</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(SqlException&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;open&nbsp;a&nbsp;new&nbsp;connection&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;TargetSite:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.TargetSite&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Source:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Source&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;ErrorCode:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.ErrorCode&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Server:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Server&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;State:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.State&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Number:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Number&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Message:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CargarLog(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CargarLog(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<h1>Mayor informaci&oacute;n</h1>
<p><a href="http://elpaladintecnologico.blogspot.com/2011/02/c-y-procedimientos-almacenados-de-sql.html">http://elpaladintecnologico.blogspot.com/2011/02/c-y-procedimientos-almacenados-de-sql.html</a></p>
<p><em>For more information on X, see ...?</em></p>

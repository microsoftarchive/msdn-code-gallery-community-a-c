# Crear un backup de base de datos SQL Server desde c#
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
<p><em>En esta ocasi&oacute;n les explicare como realizar el un backup de una base de datos SQL Server usando Visual Studio.<br>
Voy a utilizar c# para mi cometido, pero se puede utilizar tambi&eacute;n Visual Basic. Es muy parecido.<br>
<br>
Primeramente voy a crear en el SQL Server Management Studio un procedimiento almacenado que realiza un backup de mi base de datos.</em></p>
<p>El ejemplo a descargarse contiene el proyecto en visual studio, el script para crear el procedimiento almacenado y un backup de la base de datos.</p>
<h1>Requisitos</h1>
<p><em>Para este ejemplo se utiliz&oacute; SQL Server Express Edition, pero funciona con cualquier edici&oacute;n. Tambi&eacute;n se utiliz&oacute; Visual Studio 2008, por lo cual funcionar&aacute; con esa versi&oacute;n o Superior. Si su visual Studio es inferior,
 puede copiar el c&oacute;digo que funcionar&aacute; en versiones anteriores m&aacute;s no as&iacute; el proyecto al bajarse.</em></p>
<p><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></p>
<p><em>&nbsp;</em></p>
<p>Primeramente voy a crear en el SQL Server Management Studio un procedimiento almacenado que realiza un backup de mi base de datos:<br>
<br>
<br>
<br>
</p>
<div>create&nbsp;procedure&nbsp;[dbo].[backupdb]</div>
<div>as</div>
<div>BACKUP&nbsp;DATABASE&nbsp;[test]&nbsp;TO&nbsp;&nbsp;DISK&nbsp;=N'C:\copia\test.bak'</div>
<div>WITH&nbsp;NOFORMAT,&nbsp;NOINIT,&nbsp;&nbsp;NAME&nbsp;=&nbsp;N'test-Completa Base de datos Copia de seguridad',&nbsp;SKIP,NOREWIND,&nbsp;NOUNLOAD,&nbsp;&nbsp;STATS&nbsp;=&nbsp;10</div>
<p><br>
<br>
<strong><em><br>
</em></strong><br>
<br>
Este c&oacute;digo obtiene una copia de respaldo&nbsp;<strong>carpeta &quot;copia&quot; en el drive c</strong>&nbsp;de mi base de datos test en un archivo llamado&nbsp;<strong>test.bak</strong><br>
<strong><br>
</strong><br>
Luego, desde c# llamamos al procedimiento almacenado asi:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace InsertarDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
         {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings[&quot;connectionStringName&quot;].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);


                SqlCommand cmd = new SqlCommand(&quot;backupdb&quot;, cnn);
                cmd.CommandType = CommandType.StoredProcedure;




                cnn.Open();


                cmd.ExecuteNonQuery();


                MessageBox.Show(&quot;El backup fue realizado exitosamente&quot;);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Drawing;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Windows.Forms;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.SqlClient;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Configuration;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;InsertarDatos&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;ConnectionString&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;connectionStringName&quot;</span>].ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;cnn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(ConnectionString);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;backupdb&quot;</span>,&nbsp;cnn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cnn.Open();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.ExecuteNonQuery();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;El&nbsp;backup&nbsp;fue&nbsp;realizado&nbsp;exitosamente&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<h1>Mayor informaci&oacute;n</h1>
<p><em><a href="http://elpaladintecnologico.blogspot.com/2011/02/como-crear-un-backup-de-una-base-de.html">http://elpaladintecnologico.blogspot.com/2011/02/como-crear-un-backup-de-una-base-de.html</a></em></p>

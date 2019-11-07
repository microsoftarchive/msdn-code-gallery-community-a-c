# ComboBox con imágenes
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Windows Forms
## Topics
- Controls
- Windows Forms
- ComboBox
## Updated
- 06/24/2015
## Description

<p>En este ejemplo muestro c&oacute;mo crear un ComboBox en el que los items est&aacute;n compuestos por una imagen adem&aacute;s del texto a mostrar.</p>
<p><img id="139282" src="139282-03-resultado-final.png" alt="" width="461" height="326"></p>
<p>Para poder personalizar el dibujado de los items debemos establecer la propiedad
<em>DrawMode</em> del ComboBox al valor <em>DrawMode.OwnerDrawFixed</em>.</p>
<p>Tambi&eacute;n establezco la propiedad <em>DropDownStyle</em> al valor <em>ComboBoxStyle.DropDownList</em>. Si selecciona cualquiera de los otros valores en los que la parte de texto resulta editable no se puede personalizar el dibujado de &eacute;ste elemento
 por lo que &uacute;nicamente se mostrar&aacute; el texto del item seleccionado. Si el estilo del ComboBox es
<em>ComboBoxStyle.DropDownList</em> la parte de texto del control no es editable y se dibuja igual que los items de la lista, por lo que resulta personalizable como &eacute;stos.</p>
<p>&nbsp;</p>
<p>De esta forma podemos controlar el dibujado de cada item desde el evento <em>DrawItem</em>.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">        private void cmbImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index &gt;= 0)
            {
                if (e.Index &lt; listImages.Images.Count)
                {
                    Image img = new Bitmap(listImages.Images[e.Index], new Size(32, 32));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(string.Format(&quot;Minion {0}&quot;, e.Index &#43; 1)
                    , e.Font, new SolidBrush(e.ForeColor)
                    , e.Bounds.Left &#43; 32, e.Bounds.Top);
            }
        }</pre>
<pre class="hidden">    Private Sub cmbImages_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbImages.DrawItem
        e.DrawBackground()
        e.DrawFocusRectangle()
        If e.Index &gt;= 0 Then
            If e.Index &lt; listImages.Images.Count Then
                Dim img As Image = New Bitmap(listImages.Images(e.Index), New Size(32, 32))
                e.Graphics.DrawImage(img, New PointF(e.Bounds.Left, e.Bounds.Top))
            End If
            e.Graphics.DrawString(String.Format(&quot;Minion {0}&quot;, e.Index &#43; 1) _
                                      , e.Font, New SolidBrush(e.ForeColor) _
                                      , e.Bounds.Left &#43; 32, e.Bounds.Top)
        End If
    End Sub</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;cmbImages_DrawItem(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;DrawItemEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.DrawBackground();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.DrawFocusRectangle();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Index&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Index&nbsp;&lt;&nbsp;listImages.Images.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;img&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(listImages.Images[e.Index],&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__number">32</span>,&nbsp;<span class="cs__number">32</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawImage(img,&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(e.Bounds.Left,&nbsp;e.Bounds.Top));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Graphics.DrawString(<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;Minion&nbsp;{0}&quot;</span>,&nbsp;e.Index&nbsp;&#43;&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;e.Font,&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidBrush(e.ForeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;e.Bounds.Left&nbsp;&#43;&nbsp;<span class="cs__number">32</span>,&nbsp;e.Bounds.Top);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Antes de dibujar la imagen modifico el tama&ntilde;o para ajustarlo al tama&ntilde;o del item del combobox.&nbsp;</div>
<div class="endscriptcode">Los m&eacute;todos <em>DrawBackground</em> y <em>DrawFocusRectange</em> se encargan de dibujar el fondo y un rect&aacute;ngulo para resaltar el elemento activo de la lista, mientras que
<em>DrawImage</em> y <em>DrawString</em> se encargan de dibujar la imagen y el texto del elemento respectivamente.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Se puede encontrar una descripci&oacute;n m&aacute;s detallada del ejemplo en el siguiente art&iacute;culo:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><a href="http://pildorasdotnet.blogspot.com/2015/06/combobox-con-imagenes.html">ComboBox con im&aacute;genes</a></div>
<p></p>

# Criando gráficos com o ASP.Net 4.0 Chart Controls
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- ASP.NET
- Charts
## Topics
- Charts
## Updated
- 10/16/2012
## Description

<p>Ol&aacute;,</p>
<p>Como bom admirador de dados (t&eacute;cnicas e formatos de persist&ecirc;ncia em sua maioria) tamb&eacute;m gosto da parte de visualiza&ccedil;&atilde;o de dados. E quando pensamento em &ldquo;visualiza&ccedil;&atilde;o de dados&rdquo;, logo surge em nossa
 mente in&uacute;meros tipos de gr&aacute;ficos. Diante disso, gostaria de neste post demonstrar como podemos criar dois tipos de gr&aacute;ficos muito comuns: pizza e colunas. Para tanto utilizaremos o ASP.Net 4.0 Chart Controls, este n&atilde;o &eacute; um
 recurso novo, na verdade seu lan&ccedil;amento veio junto com o ASP.Net 4.0, em 2010.</p>
<p><a href="http://ferhenriquef.files.wordpress.com/2012/10/chart.jpg"><img title="chart" src="http://ferhenriquef.files.wordpress.com/2012/10/chart_thumb.jpg?w=268&h=207" border="0" alt="chart" width="268" height="207" style="padding-left:0px; padding-right:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-top:0px"></a></p>
<p><span id="more-1012">&nbsp;</span></p>
<p>Os dois s&atilde;o muitos simples de serem constru&iacute;dos, mas possuem algoritmos diferentes para sua implementa&ccedil;&atilde;o.</p>
<p><strong>1 &ndash; Construindo o HTML</strong></p>
<p>O HTML abaixo ser&aacute; utilizando para constru&ccedil;&atilde;o do gr&aacute;fico de colunas:</p>
<pre class="code"><span style="color:blue">&lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Chart </span><span style="color:red">ID</span><span style="color:blue">=&quot;ColumnChart&quot; </span><span style="color:red">runat</span><span style="color:blue">=&quot;server&quot; </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;WhiteSmoke&quot; </span><span style="color:red">BackGradientStyle</span><span style="color:blue">=&quot;TopBottom&quot;
    </span><span style="color:red">BackSecondaryColor</span><span style="color:blue">=&quot;White&quot; </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;26, 59, 105&quot; </span><span style="color:red">BorderlineDashStyle</span><span style="color:blue">=&quot;Solid&quot;
    </span><span style="color:red">BorderWidth</span><span style="color:blue">=&quot;2&quot; </span><span style="color:red">Height</span><span style="color:blue">=&quot;350px&quot; </span><span style="color:red">ImageLocation</span><span style="color:blue">=&quot;~/TempImages/ChartPic_#SEQ(300,3)&quot;
    </span><span style="color:red">Palette</span><span style="color:blue">=&quot;BrightPastel&quot; </span><span style="color:red">Width</span><span style="color:blue">=&quot;900px&quot;&gt;
    &lt;</span><span style="color:maroon">Legends</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Legend </span><span style="color:red">LegendStyle</span><span style="color:blue">=&quot;Row&quot; </span><span style="color:red">IsTextAutoFit</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">DockedToChartArea</span><span style="color:blue">=&quot;ChartArea1&quot;
            </span><span style="color:red">Docking</span><span style="color:blue">=&quot;Bottom&quot; </span><span style="color:red">IsDockedInsideChartArea</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Default&quot; </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;Transparent&quot;
            </span><span style="color:red">Alignment</span><span style="color:blue">=&quot;Center&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Legend</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">Legends</span><span style="color:blue">&gt;
    &lt;</span><span style="color:maroon">BorderSkin </span><span style="color:red">SkinStyle</span><span style="color:blue">=&quot;Emboss&quot; /&gt;
    &lt;</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series1&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series2&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series3&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series4&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series5&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series6&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series7&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series8&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
    &lt;</span><span style="color:maroon">ChartAreas</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">ChartArea </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;Gainsboro&quot; </span><span style="color:red">BackGradientStyle</span><span style="color:blue">=&quot;TopBottom&quot; </span><span style="color:red">BackSecondaryColor</span><span style="color:blue">=&quot;White&quot;
            </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;ChartArea1&quot; </span><span style="color:red">ShadowColor</span><span style="color:blue">=&quot;Transparent&quot;&gt;
            &lt;</span><span style="color:maroon">AxisY2 </span><span style="color:red">Interval</span><span style="color:blue">=&quot;25&quot; </span><span style="color:red">IsLabelAutoFit</span><span style="color:blue">=&quot;False&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">Enabled</span><span style="color:blue">=&quot;False&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisY2</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">AxisX2 </span><span style="color:red">Interval</span><span style="color:blue">=&quot;25&quot; </span><span style="color:red">IsLabelAutoFit</span><span style="color:blue">=&quot;False&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">Enabled</span><span style="color:blue">=&quot;False&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisX2</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">Area3DStyle </span><span style="color:red">Inclination</span><span style="color:blue">=&quot;15&quot; </span><span style="color:red">IsClustered</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">IsRightAngleAxes</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">LightStyle</span><span style="color:blue">=&quot;Realistic&quot;
                </span><span style="color:red">Rotation</span><span style="color:blue">=&quot;10&quot; </span><span style="color:red">WallWidth</span><span style="color:blue">=&quot;0&quot; /&gt;
            &lt;</span><span style="color:maroon">AxisY </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisY</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">AxisX </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisX</span><span style="color:blue">&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">ChartArea</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">ChartAreas</span><span style="color:blue">&gt;
&lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Chart</span><span style="color:blue">&gt;  
</span></pre>
<p>O HTML abaixo ser&aacute; utilizando para constru&ccedil;&atilde;o do gr&aacute;fico de pizza:</p>
<pre class="code"><span style="color:blue">&lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Chart </span><span style="color:red">ID</span><span style="color:blue">=&quot;PieChart&quot; </span><span style="color:red">runat</span><span style="color:blue">=&quot;server&quot; </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;WhiteSmoke&quot; </span><span style="color:red">BackGradientStyle</span><span style="color:blue">=&quot;TopBottom&quot;
    </span><span style="color:red">BackSecondaryColor</span><span style="color:blue">=&quot;White&quot; </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;26, 59, 105&quot; </span><span style="color:red">BorderlineDashStyle</span><span style="color:blue">=&quot;Solid&quot;
    </span><span style="color:red">BorderWidth</span><span style="color:blue">=&quot;2&quot; </span><span style="color:red">Height</span><span style="color:blue">=&quot;350px&quot; </span><span style="color:red">ImageLocation</span><span style="color:blue">=&quot;~/TempImages/ChartPic_#SEQ(300,3)&quot;
    </span><span style="color:red">Palette</span><span style="color:blue">=&quot;BrightPastel&quot; </span><span style="color:red">Width</span><span style="color:blue">=&quot;900px&quot;&gt;
    &lt;</span><span style="color:maroon">Legends</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Legend </span><span style="color:red">LegendStyle</span><span style="color:blue">=&quot;Row&quot; </span><span style="color:red">IsTextAutoFit</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">DockedToChartArea</span><span style="color:blue">=&quot;ChartArea1&quot;
            </span><span style="color:red">Docking</span><span style="color:blue">=&quot;Bottom&quot; </span><span style="color:red">IsDockedInsideChartArea</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Default&quot; </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;Transparent&quot;
            </span><span style="color:red">Alignment</span><span style="color:blue">=&quot;Center&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Legend</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">Legends</span><span style="color:blue">&gt;
    &lt;</span><span style="color:maroon">BorderSkin </span><span style="color:red">SkinStyle</span><span style="color:blue">=&quot;Emboss&quot; /&gt;
    &lt;</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;180, 26, 59, 105&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;Series1&quot;&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">Series</span><span style="color:blue">&gt;
    &lt;</span><span style="color:maroon">ChartAreas</span><span style="color:blue">&gt;
        &lt;</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">ChartArea </span><span style="color:red">BackColor</span><span style="color:blue">=&quot;Gainsboro&quot; </span><span style="color:red">BackGradientStyle</span><span style="color:blue">=&quot;TopBottom&quot; </span><span style="color:red">BackSecondaryColor</span><span style="color:blue">=&quot;White&quot;
            </span><span style="color:red">BorderColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; </span><span style="color:red">Name</span><span style="color:blue">=&quot;ChartArea1&quot; </span><span style="color:red">ShadowColor</span><span style="color:blue">=&quot;Transparent&quot;&gt;
            &lt;</span><span style="color:maroon">AxisY2 </span><span style="color:red">Interval</span><span style="color:blue">=&quot;25&quot; </span><span style="color:red">IsLabelAutoFit</span><span style="color:blue">=&quot;False&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">Enabled</span><span style="color:blue">=&quot;False&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisY2</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">AxisX2 </span><span style="color:red">Interval</span><span style="color:blue">=&quot;25&quot; </span><span style="color:red">IsLabelAutoFit</span><span style="color:blue">=&quot;False&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">Enabled</span><span style="color:blue">=&quot;False&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisX2</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">Area3DStyle </span><span style="color:red">Inclination</span><span style="color:blue">=&quot;15&quot; </span><span style="color:red">IsClustered</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">IsRightAngleAxes</span><span style="color:blue">=&quot;False&quot; </span><span style="color:red">LightStyle</span><span style="color:blue">=&quot;Realistic&quot;
                </span><span style="color:red">Rotation</span><span style="color:blue">=&quot;10&quot; </span><span style="color:red">WallWidth</span><span style="color:blue">=&quot;0&quot; /&gt;
            &lt;</span><span style="color:maroon">AxisY </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisY</span><span style="color:blue">&gt;
            &lt;</span><span style="color:maroon">AxisX </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot;&gt;
                &lt;</span><span style="color:maroon">LabelStyle </span><span style="color:red">Font</span><span style="color:blue">=&quot;Trebuchet MS, 8.25pt, style=Bold&quot; /&gt;
                &lt;</span><span style="color:maroon">MajorGrid </span><span style="color:red">LineColor</span><span style="color:blue">=&quot;64, 64, 64, 64&quot; /&gt;
            &lt;/</span><span style="color:maroon">AxisX</span><span style="color:blue">&gt;
        &lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">ChartArea</span><span style="color:blue">&gt;
    &lt;/</span><span style="color:maroon">ChartAreas</span><span style="color:blue">&gt;
&lt;/</span><span style="color:maroon">asp</span><span style="color:blue">:</span><span style="color:maroon">Chart</span><span style="color:blue">&gt;       
</span></pre>
<p>&Eacute; importante lembra de fazer o registro do assembly System.Web.DataVisualization na p&aacute;gina, para que os controles de gr&aacute;ficos sejam corretamente identificados e renderizados.</p>
<pre class="code"><span style="background:yellow">&lt;%</span><span style="color:blue">@ </span><span style="color:maroon">Register </span><span style="color:red">assembly</span><span style="color:blue">=&quot;System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35&quot; 
    </span><span style="color:red">namespace</span><span style="color:blue">=&quot;System.Web.UI.DataVisualization.Charting&quot; </span><span style="color:red">tagprefix</span><span style="color:blue">=&quot;asp&quot; </span><span style="background:yellow">%&gt;


</span></pre>
<p><strong>2 &ndash; Gerando dados</strong></p>
<p>O c&oacute;digo abaixo ir&aacute; criar dados aleat&oacute;rios, estes dados s&atilde;o apenas dados de teste criados para este exemplo. Quando for necess&aacute;rio implementar uma aplica&ccedil;&atilde;o real basta substituir o meio de popular os dados
 desta entidade ChartData com dados vindos do Entity Framework, DataTable, arquivos XML, ou qualquer outra fonte de dados.</p>
<pre class="code"><span style="color:blue">private static </span>ChartData[] CreateSampleData()
{
    ChartData[] data = <span style="color:blue">new </span>ChartData[8];

    <span style="color:#2b91af">Random </span>rnd = <span style="color:blue">new </span><span style="color:#2b91af">Random</span>(<span style="color:#2b91af">DateTime</span>.Now.Millisecond);

    <span style="color:blue">for </span>(<span style="color:blue">int </span>i = 0; i &lt; data.Length; i&#43;&#43;)
    {
        <span style="color:blue">int </span>index = i &#43; 1;

        ChartData currentChartData = data[i] = <span style="color:blue">new </span>ChartData();
        currentChartData.X = index;
        currentChartData.Y = rnd.Next(25) &#43; rnd.NextDouble();
        currentChartData.Legend = <span style="color:blue">string</span>.Format(<span style="color:#a31515">&quot;Legend {0}&quot;</span>, index);
    }

    <span style="color:blue">return </span>data;
}</pre>
<p>A estrutura que utilizo para representar os dados dos gr&aacute;ficos &eacute; a estrutura abaixo:</p>
<pre class="code"><span style="color:blue">public class </span><span style="color:#2b91af">ChartData
</span>{
    <span style="color:blue">public double </span>X { <span style="color:blue">get</span>; <span style="color:blue">set</span>; }

    <span style="color:blue">public double </span>Y { <span style="color:blue">get</span>; <span style="color:blue">set</span>; }

    <span style="color:blue">public string </span>Legend { <span style="color:blue">get</span>; <span style="color:blue">set</span>; }
}</pre>
<p><strong>3 &ndash; Rotina de limpeza</strong></p>
<p>Para limpar qualquer dado esquecido entre uma renderiza&ccedil;&atilde;o ou outra, criei uma rotina de limpeza dos dados dos gr&aacute;ficos, o c&oacute;digo desta rotina pode ser visto abaixo:</p>
<pre class="code"><span style="color:blue">private static void </span>CleanChart(<span style="color:#2b91af">Chart </span>currentChart)
{
    <span style="color:blue">foreach </span>(<span style="color:blue">var </span>itemSerie <span style="color:blue">in </span>currentChart.Series)
    {
        <span style="color:blue">if </span>(itemSerie.Points != <span style="color:blue">null</span>)
            itemSerie.Points.Clear();
    }
}</pre>
<p><strong>4 &ndash; Construindo os gr&aacute;ficos</strong></p>
<p>Por fim, vamos aos algoritmos necess&aacute;rios para construir os gr&aacute;ficos. O c&oacute;digo abaixo &eacute; o algoritmo necess&aacute;rio para criar o gr&aacute;fico de colunas:</p>
<pre class="code"><span style="color:blue">private static void </span>BindColumnChart(<span style="color:#2b91af">Chart </span>currentChart, <span style="color:#2b91af">SeriesChartType </span>chartType, <span style="color:blue">params </span>ChartData[] data)
{
    <span style="color:blue">for </span>(<span style="color:blue">int </span>i = 0; i &lt; data.Length; i&#43;&#43;)
    {
        <span style="color:blue">if </span>(currentChart.Series.Count &lt;= i)
            <span style="color:blue">break</span>;

        ChartData currentChartData = data[i];

        <span style="color:green">// Largura da barra
        </span>currentChart.Series[i][<span style="color:#a31515">&quot;PointWidth&quot;</span>] = <span style="color:#a31515">&quot;1.5&quot;</span>;

        currentChart.Series[i].XValueType = <span style="color:#2b91af">ChartValueType</span>.Double;
        currentChart.Series[i].YValueType = <span style="color:#2b91af">ChartValueType</span>.Double;

        currentChart.Series[i].Points.AddXY(currentChartData.X, currentChartData.Y);
        currentChart.Series[i].Label = currentChartData.Y.ToString(<span style="color:#a31515">&quot;F&quot;</span>);
        currentChart.Series[i].ChartType = chartType;
        currentChart.Series[i].LegendText = currentChartData.Legend;
    }

    currentChart.DataBind();
}</pre>
<p>E o c&oacute;digo abaixo &eacute; o algoritmo necess&aacute;rio para criar o gr&aacute;fico de pizza:</p>
<pre class="code"><span style="color:blue">private static void </span>BindPieChart(<span style="color:#2b91af">Chart </span>currentChart, <span style="color:#2b91af">SeriesChartType </span>chartType, <span style="color:blue">params </span>ChartData[] data)
{
    <span style="color:blue">int </span>serieIndex = 0;

    <span style="color:blue">var </span>xValues = data.Select(d =&gt; d.Legend).ToList();
    <span style="color:blue">var </span>yValues = data.Select(d =&gt; d.Y).ToList();

    currentChart.Series[serieIndex].Points.DataBindXY(xValues, yValues);

    currentChart.Series[serieIndex].ChartType = chartType;

    currentChart.ChartAreas[0].Area3DStyle.Enable3D = <span style="color:blue">true</span>;

    currentChart.DataBind();
}</pre>
<p><strong>5 &ndash; Integrando tudo</strong></p>
<p>Para renderizar todos os gr&aacute;ficos, com os diferentes blocos de c&oacute;digo que constru&iacute;mos, adicionaremos o seguinte bloco de c&oacute;digo no evento Load de nossa p&aacute;gina:</p>
<pre class="code"><span style="color:blue">protected void </span>Page_Load(<span style="color:blue">object </span>sender, <span style="color:#2b91af">EventArgs </span>e)
{
    CleanChart(<span style="color:blue">this</span>.ColumnChart);
    CleanChart(<span style="color:blue">this</span>.PieChart);

    <span style="color:blue">var </span>data = CreateSampleData();

    BindColumnChart(<span style="color:blue">this</span>.ColumnChart, <span style="color:#2b91af">SeriesChartType</span>.Column, data);
    BindPieChart(<span style="color:blue">this</span>.PieChart, <span style="color:#2b91af">SeriesChartType</span>.Pie, data);
}</pre>
<p><strong>6 &ndash; Resultado final</strong></p>
<p>Por fim, nossos gr&aacute;ficos devem ficar desta forma:</p>
<p><a href="http://ferhenriquef.files.wordpress.com/2012/10/chartsample.png"><img title="chartSample" src="http://ferhenriquef.files.wordpress.com/2012/10/chartsample_thumb.png?w=616&h=480" border="0" alt="chartSample" width="616" height="480" style="padding-left:0px; padding-right:0px; display:block; float:none; margin-left:auto; margin-right:auto; padding-top:0px"></a></p>
<p>&nbsp;</p>
<p>Espero que tenha sido &uacute;til.<br>
<br>
At&eacute; o pr&oacute;ximo!</p>
<p>Por<br>
Fernando Henrique Inoc&ecirc;ncio Borba Ferreira<br>
Microsoft Most Valuable Professional &ndash; Data Platform Development</p>

# Chart in MVC using Chart.js library
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Chart
## Topics
- HTML5 Charts
## Updated
- 03/27/2017
## Description

<h1>Introduction</h1>
<p><em>This Solution is created to help you to build interactive charts using Chart.JS library dyanamically.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Everthing is included in this solution. If you are creating a new project then you need chat.js library . you can download it from nuget or from this &nbsp;link &quot;http://www.chartjs.org/&quot;.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This Project is Created to give a brief description on how to build charts using charts.js library &nbsp;and MVC. I have Create Contoller for each type of Chart and All the Charts are shown on Home Page also. I have create a model for filling data in
 chart and filled model &nbsp;using C#. You can feed data in model from database using same way.</em></p>
<p>&nbsp;</p>
<p><img id="171495" src="171495-line%20chart.png" alt="" width="1343" height="662"></p>
<p><em>Bar Chart - Bar Chart is used two show trending data, Bar chart is plotted either verically or horizentally using bars.</em></p>
<p><em>Two types of bar charts are created first is simple with single bars and secont with multiple bars for comparing two years of data month wise.</em></p>
<p>&nbsp;</p>
<p><em>Line Charts - In&nbsp;<span>line chart &nbsp;data is plotted on &nbsp;points on a line.
<em>&nbsp;line chart is&nbsp;</em>Often used to show trend data, and the comparison of two data sets.</span></em></p>
<p><em>There are two samples of Line Chart is ceated one is silgle line chart and another with Multiple Lines</em></p>
<p><em><br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class BarChartController : Controller
    {
        // GET: BarChart
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult BarChartData()
        {

            Chart _chart = new Chart();
            _chart.labels = new string[] { &quot;January&quot;, &quot;February&quot;, &quot;March&quot;, &quot;April&quot;, &quot;May&quot;, &quot;June&quot;, &quot;July&quot;, &quot;August&quot;, &quot;September&quot;, &quot;October&quot;, &quot;Novemeber&quot;, &quot;December&quot; };
            _chart.datasets = new List&lt;Datasets&gt;();
            List&lt;Datasets&gt; _dataSet = new List&lt;Datasets&gt;();
            _dataSet.Add(new Datasets()
            {
                label = &quot;Current Year&quot;,
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                backgroundColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderWidth = &quot;1&quot;
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MultiBarChartData()
        {

            Chart _chart = new Chart();
            _chart.labels = new string[] { &quot;January&quot;, &quot;February&quot;, &quot;March&quot;, &quot;April&quot;, &quot;May&quot;, &quot;June&quot;, &quot;July&quot;, &quot;August&quot;, &quot;September&quot;, &quot;October&quot;, &quot;Novemeber&quot;, &quot;December&quot; };
            _chart.datasets = new List&lt;Datasets&gt;();
            List&lt;Datasets&gt; _dataSet = new List&lt;Datasets&gt;();
            _dataSet.Add(new Datasets()
            {
                label = &quot;Current Year&quot;,
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                backgroundColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderWidth = &quot;1&quot;
            });
            _dataSet.Add(new Datasets()
            {
                label = &quot;Last Year&quot;,
                data = new int[] { 65, 59, 80, 81, 56, 55, 40, 55, 66, 77, 88, 34 },
                backgroundColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderColor = new string[] { &quot;#FF0000&quot;, &quot;#800000&quot;, &quot;#808000&quot;, &quot;#008080&quot;, &quot;#800080&quot;, &quot;#0000FF&quot;, &quot;#000080&quot;, &quot;#999999&quot;, &quot;#E9967A&quot;, &quot;#CD5C5C&quot;, &quot;#1A5276&quot;, &quot;#27AE60&quot; },
                borderWidth = &quot;1&quot;
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BarChartController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET:&nbsp;BarChart</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult&nbsp;BarChartData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chart&nbsp;_chart&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Chart();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.labels&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;January&quot;</span>,&nbsp;<span class="cs__string">&quot;February&quot;</span>,&nbsp;<span class="cs__string">&quot;March&quot;</span>,&nbsp;<span class="cs__string">&quot;April&quot;</span>,&nbsp;<span class="cs__string">&quot;May&quot;</span>,&nbsp;<span class="cs__string">&quot;June&quot;</span>,&nbsp;<span class="cs__string">&quot;July&quot;</span>,&nbsp;<span class="cs__string">&quot;August&quot;</span>,&nbsp;<span class="cs__string">&quot;September&quot;</span>,&nbsp;<span class="cs__string">&quot;October&quot;</span>,&nbsp;<span class="cs__string">&quot;Novemeber&quot;</span>,&nbsp;<span class="cs__string">&quot;December&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.datasets&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Datasets&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Datasets&gt;&nbsp;_dataSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Datasets&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dataSet.Add(<span class="cs__keyword">new</span>&nbsp;Datasets()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label&nbsp;=&nbsp;<span class="cs__string">&quot;Current&nbsp;Year&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">28</span>,&nbsp;<span class="cs__number">48</span>,&nbsp;<span class="cs__number">40</span>,&nbsp;<span class="cs__number">19</span>,&nbsp;<span class="cs__number">86</span>,&nbsp;<span class="cs__number">27</span>,&nbsp;<span class="cs__number">90</span>,&nbsp;<span class="cs__number">20</span>,&nbsp;<span class="cs__number">45</span>,&nbsp;<span class="cs__number">65</span>,&nbsp;<span class="cs__number">34</span>,&nbsp;<span class="cs__number">22</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backgroundColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderWidth&nbsp;=&nbsp;<span class="cs__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.datasets&nbsp;=&nbsp;_dataSet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(_chart,&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult&nbsp;MultiBarChartData()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chart&nbsp;_chart&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Chart();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.labels&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;January&quot;</span>,&nbsp;<span class="cs__string">&quot;February&quot;</span>,&nbsp;<span class="cs__string">&quot;March&quot;</span>,&nbsp;<span class="cs__string">&quot;April&quot;</span>,&nbsp;<span class="cs__string">&quot;May&quot;</span>,&nbsp;<span class="cs__string">&quot;June&quot;</span>,&nbsp;<span class="cs__string">&quot;July&quot;</span>,&nbsp;<span class="cs__string">&quot;August&quot;</span>,&nbsp;<span class="cs__string">&quot;September&quot;</span>,&nbsp;<span class="cs__string">&quot;October&quot;</span>,&nbsp;<span class="cs__string">&quot;Novemeber&quot;</span>,&nbsp;<span class="cs__string">&quot;December&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.datasets&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Datasets&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Datasets&gt;&nbsp;_dataSet&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Datasets&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dataSet.Add(<span class="cs__keyword">new</span>&nbsp;Datasets()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label&nbsp;=&nbsp;<span class="cs__string">&quot;Current&nbsp;Year&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">28</span>,&nbsp;<span class="cs__number">48</span>,&nbsp;<span class="cs__number">40</span>,&nbsp;<span class="cs__number">19</span>,&nbsp;<span class="cs__number">86</span>,&nbsp;<span class="cs__number">27</span>,&nbsp;<span class="cs__number">90</span>,&nbsp;<span class="cs__number">20</span>,&nbsp;<span class="cs__number">45</span>,&nbsp;<span class="cs__number">65</span>,&nbsp;<span class="cs__number">34</span>,&nbsp;<span class="cs__number">22</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backgroundColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderWidth&nbsp;=&nbsp;<span class="cs__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_dataSet.Add(<span class="cs__keyword">new</span>&nbsp;Datasets()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;label&nbsp;=&nbsp;<span class="cs__string">&quot;Last&nbsp;Year&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;{&nbsp;<span class="cs__number">65</span>,&nbsp;<span class="cs__number">59</span>,&nbsp;<span class="cs__number">80</span>,&nbsp;<span class="cs__number">81</span>,&nbsp;<span class="cs__number">56</span>,&nbsp;<span class="cs__number">55</span>,&nbsp;<span class="cs__number">40</span>,&nbsp;<span class="cs__number">55</span>,&nbsp;<span class="cs__number">66</span>,&nbsp;<span class="cs__number">77</span>,&nbsp;<span class="cs__number">88</span>,&nbsp;<span class="cs__number">34</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backgroundColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderColor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;#FF0000&quot;</span>,&nbsp;<span class="cs__string">&quot;#800000&quot;</span>,&nbsp;<span class="cs__string">&quot;#808000&quot;</span>,&nbsp;<span class="cs__string">&quot;#008080&quot;</span>,&nbsp;<span class="cs__string">&quot;#800080&quot;</span>,&nbsp;<span class="cs__string">&quot;#0000FF&quot;</span>,&nbsp;<span class="cs__string">&quot;#000080&quot;</span>,&nbsp;<span class="cs__string">&quot;#999999&quot;</span>,&nbsp;<span class="cs__string">&quot;#E9967A&quot;</span>,&nbsp;<span class="cs__string">&quot;#CD5C5C&quot;</span>,&nbsp;<span class="cs__string">&quot;#1A5276&quot;</span>,&nbsp;<span class="cs__string">&quot;#27AE60&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;borderWidth&nbsp;=&nbsp;<span class="cs__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_chart.datasets&nbsp;=&nbsp;_dataSet;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(_chart,&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>

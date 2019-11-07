# C# - Convert JSON String to JSON Object from TXT
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- JSON
- WinForms
- Visual C#
- txt
## Topics
- C#
- JSON
- Windows Forms Controls
- Visual C#
## Updated
- 08/20/2017
## Description

<p>JSON data format and language has nothing to do, born out of JavaScript, but many programming languages are supported JSON format data generation and analysis. JSON's official MIME type is application / json, and the extension is .json.</p>
<p>In the development of the game project, sometimes with the program to write from TXT to read some of the format, and then converted into JSON way.</p>
<p>In fact, there are many ways, such as loading CSV, XML, etc., here to teach some of the more simple way to write, you can know how to do such a design.</p>
<p>1. Create the interface will use the object:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//Button
public Button button1 = new Button();

//The label that displays the result
public Label resultLabel =new Label();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//Button</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;Button&nbsp;button1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Button();&nbsp;
&nbsp;
<span class="cs__com">//The&nbsp;label&nbsp;that&nbsp;displays&nbsp;the&nbsp;result</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;Label&nbsp;resultLabel&nbsp;=<span class="cs__keyword">new</span>&nbsp;Label();</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">2. Mainly initialized Function:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainForm()
{
	//
	// The InitializeComponent() call is required for Windows Forms designer support.
	//

	//Initialize the height of the interface, so that it will not be too short, wait for the results to be used.
	this.Height=400;
	
	//Initialize a button
	this.button1.Location = new System.Drawing.Point(82, 20);
	this.button1.Name = &quot;btn&quot;;
	this.button1.Size = new System.Drawing.Size(120, 30);
	this.button1.TabIndex = 1;
	this.button1.Text = &quot;Do CSV To JSON&quot;;
	this.button1.UseVisualStyleBackColor = true;
	this.button1.Click &#43;= new System.EventHandler(this.click);
	
	//Initialize a Label, wait for the results used to show
	this.Controls.Add(this.button1);
	this.resultLabel.Location = new System.Drawing.Point(10, 60);
	this.resultLabel.Name = &quot;label1&quot;;
	this.resultLabel.Text = &quot;&quot;;
	this.resultLabel.AutoSize = true;
	this.Controls.Add(this.resultLabel);
	
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;MainForm()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;The&nbsp;InitializeComponent()&nbsp;call&nbsp;is&nbsp;required&nbsp;for&nbsp;Windows&nbsp;Forms&nbsp;designer&nbsp;support.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;the&nbsp;height&nbsp;of&nbsp;the&nbsp;interface,&nbsp;so&nbsp;that&nbsp;it&nbsp;will&nbsp;not&nbsp;be&nbsp;too&nbsp;short,&nbsp;wait&nbsp;for&nbsp;the&nbsp;results&nbsp;to&nbsp;be&nbsp;used.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Height=<span class="cs__number">400</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;a&nbsp;button</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Drawing.Point(<span class="cs__number">82</span>,&nbsp;<span class="cs__number">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Name&nbsp;=&nbsp;<span class="cs__string">&quot;btn&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Size&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Drawing.Size(<span class="cs__number">120</span>,&nbsp;<span class="cs__number">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.TabIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Text&nbsp;=&nbsp;<span class="cs__string">&quot;Do&nbsp;CSV&nbsp;To&nbsp;JSON&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.UseVisualStyleBackColor&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.button1.Click&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.EventHandler(<span class="cs__keyword">this</span>.click);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Initialize&nbsp;a&nbsp;Label,&nbsp;wait&nbsp;for&nbsp;the&nbsp;results&nbsp;used&nbsp;to&nbsp;show</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Controls.Add(<span class="cs__keyword">this</span>.button1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Drawing.Point(<span class="cs__number">10</span>,&nbsp;<span class="cs__number">60</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Name&nbsp;=&nbsp;<span class="cs__string">&quot;label1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.AutoSize&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Controls.Add(<span class="cs__keyword">this</span>.resultLabel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">3. Design a button to listen to the event program:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void click(object sender, EventArgs e)
{
	//Read the csv file, and then use System.IO.File.ReadAllLines to read the JSON String format for each line
	string[] lines = System.IO.File.ReadAllLines(@&quot;csvfile.csv&quot;);
	
	//Here through the foreach to get each line of JSON
	foreach (string line in lines) 
	{
		Console.WriteLine(&quot;JSON String：{0}&quot;, line);
		this.resultLabel.Text &#43;= line&#43;&quot;\n\n&quot;;
		
		//Convert to JSON Object format
		Player pj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize&lt;Player&gt;(line);
		
		//The value of the Object to take out, in the Label above the results of the arrangement
		this.resultLabel.Text &#43;= &quot;JSON Object Id Value：&quot;&#43;pj.Id.ToString()&#43;&quot;\n\n&quot;;
		this.resultLabel.Text &#43;= &quot;JSON Object HP Value：&quot;&#43;pj.HP.ToString()&#43;&quot;\n\n&quot;;
		this.resultLabel.Text &#43;= &quot;JSON Object MP Value：&quot;&#43;pj.MP.ToString()&#43;&quot;\n\n&quot;;
		this.resultLabel.Text &#43;= &quot;JSON Object Skill Value：&quot;&#43;pj.Skill.ToString()&#43;&quot;\n\n\n&quot;;
		Console.WriteLine(&quot;JSON Object Id Value：{0}&quot;, pj.Id);
		Console.WriteLine(&quot;JSON Object HP Value：{0}&quot;, pj.HP);
		Console.WriteLine(&quot;JSON Object MP Value：{0}&quot;, pj.MP);
		Console.WriteLine(&quot;JSON Object Skill Value：{0}&quot;, pj.Skill);

	}
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Read&nbsp;the&nbsp;csv&nbsp;file,&nbsp;and&nbsp;then&nbsp;use&nbsp;System.IO.File.ReadAllLines&nbsp;to&nbsp;read&nbsp;the&nbsp;JSON&nbsp;String&nbsp;format&nbsp;for&nbsp;each&nbsp;line</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;lines&nbsp;=&nbsp;System.IO.File.ReadAllLines(@<span class="cs__string">&quot;csvfile.csv&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Here&nbsp;through&nbsp;the&nbsp;foreach&nbsp;to&nbsp;get&nbsp;each&nbsp;line&nbsp;of&nbsp;JSON</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;line&nbsp;<span class="cs__keyword">in</span>&nbsp;lines)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JSON&nbsp;String：{0}&quot;</span>,&nbsp;line);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;&#43;=&nbsp;line&#43;<span class="cs__string">&quot;\n\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Convert&nbsp;to&nbsp;JSON&nbsp;Object&nbsp;format</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Player&nbsp;pj&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Web.Script.Serialization.JavaScriptSerializer().Deserialize&lt;Player&gt;(line);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;value&nbsp;of&nbsp;the&nbsp;Object&nbsp;to&nbsp;take&nbsp;out,&nbsp;in&nbsp;the&nbsp;Label&nbsp;above&nbsp;the&nbsp;results&nbsp;of&nbsp;the&nbsp;arrangement</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;Id&nbsp;Value：&quot;</span>&#43;pj.Id.ToString()&#43;<span class="cs__string">&quot;\n\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;HP&nbsp;Value：&quot;</span>&#43;pj.HP.ToString()&#43;<span class="cs__string">&quot;\n\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;MP&nbsp;Value：&quot;</span>&#43;pj.MP.ToString()&#43;<span class="cs__string">&quot;\n\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.resultLabel.Text&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;Skill&nbsp;Value：&quot;</span>&#43;pj.Skill.ToString()&#43;<span class="cs__string">&quot;\n\n\n&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;Id&nbsp;Value：{0}&quot;</span>,&nbsp;pj.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;HP&nbsp;Value：{0}&quot;</span>,&nbsp;pj.HP);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;MP&nbsp;Value：{0}&quot;</span>,&nbsp;pj.MP);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;JSON&nbsp;Object&nbsp;Skill&nbsp;Value：{0}&quot;</span>,&nbsp;pj.Skill);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<p><span style="font-size:10px">There are Id, HP, MP, Skill, and then in the program which we define a name named Player object, which also defines the variable Id, HP, MP, Skill (type can be customized)：</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Player
{
	//The following variable is the corresponding from the csvfile.csv JSON format string, which has Id, HP, MP, Skill.
	//Role Id
	public int Id { get; set; }
	//Role HP
	public int HP { get; set; }
	//Role MP
	public string MP { get; set; }
	//Role MP
	public string Skill { get; set; }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Player&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;following&nbsp;variable&nbsp;is&nbsp;the&nbsp;corresponding&nbsp;from&nbsp;the&nbsp;csvfile.csv&nbsp;JSON&nbsp;format&nbsp;string,&nbsp;which&nbsp;has&nbsp;Id,&nbsp;HP,&nbsp;MP,&nbsp;Skill.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Role&nbsp;Id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Role&nbsp;HP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;HP&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Role&nbsp;MP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MP&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Role&nbsp;MP</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Skill&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:10px">Above csvfile.csv, although I was using csv the file name, but in my example, or use TXT way to design.</span></p>
<p>If the CSV is the real format, in fact, will be slightly different, wording also have to change slightly, but in fact the way will be almost.</p>
<p>In the contents of csvfile.csv inside, will see looks like the following string, and then line by line to line:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">{&quot;Id&quot;:100,&quot;HP&quot;:10,&quot;MP&quot;:14,&quot;Skill&quot;:&quot;attack&quot;}</pre>
<div class="preview">
<pre class="csharp">{<span class="cs__string">&quot;Id&quot;</span>:<span class="cs__number">100</span>,<span class="cs__string">&quot;HP&quot;</span>:<span class="cs__number">10</span>,<span class="cs__string">&quot;MP&quot;</span>:<span class="cs__number">14</span>,<span class="cs__string">&quot;Skill&quot;</span>:<span class="cs__string">&quot;attack&quot;</span>}</pre>
</div>
</div>
</div>
<p>And then use the following code to convert：</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">System.Web.Script.Serialization.JavaScriptSerializer().Deserialize&lt;Player&gt;(line);</pre>
<div class="preview">
<pre class="csharp">System.Web.Script.Serialization.JavaScriptSerializer().Deserialize&lt;Player&gt;(line);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:10px">The results are displayed when the button is pressed, and we can use Id, HP, MP, and Skill from the Player.</span></div>
<div class="endscriptcode"><span style="font-size:10px"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:10px"><img id="178219" src="178219-%e5%a6%82%e4%bd%95%e8%a8%ad%e8%a8%88%e6%88%90json%e7%9a%84%e5%ad%97%e4%b8%b2txt%e6%aa%94%ef%bc%8c%e7%84%b6%e5%be%8c%e9%80%8f%e9%81%8e%e8%ae%80%e5%8f%96%e7%9a%84%e6%96%b9%e5%bc%8f%e8%bd%89%e6%8f%9b%e6%88%90%e7%89%a9%e4%bb%b6%e3%80%82.jpg" alt="" width="286" height="393"><br>
</span></div>
<p>The above example is a very basic concept, it can have a lot of changes in the type.</p>
<p>If you want to use the CSV format, it is necessary to add a string of each JSON comma, and then deal with the string with Split way into String Array, and then into the same Deserialize &lt;Player&gt; (your_string) inside The.</p>

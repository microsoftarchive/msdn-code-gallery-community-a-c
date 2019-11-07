# Basic MVVM Setup
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- WPF
- XAML
- MVVM
- Windows Phone
## Topics
- Data Binding
- ViewModel pattern (MVVM)
- WPF Basics
- WPF Data Binding
## Updated
- 03/20/2015
## Description

<h1>Introduction</h1>
<p><em>Having helped alot of people on the MSDN Forum in the WPF section, I tend to see alot of people who fail to exploit the benefits of DataBinding in WPF, and not enough people are aware of the benefits of the MVVM pattern, which will be the main purpose
 of this lesson. To learn how to setup a basic MVVM pattern for an application.<br>
<br>
<strong>Note: </strong>Rating this sample, or asking questions in the Q&amp;A is appreciated since it will help in adding or editing this sample to a better quality.</em></p>
<p><strong>What is MVVM ?</strong></p>
<p><em>MVVM stands for :</em></p>
<ul>
<li>Model </li><li>View </li><li>ViewModel </li></ul>
<p><strong>Model -&nbsp; </strong>The model is an object model. In this case a class called Employee.</p>
<p><strong>View - </strong>The view is the UI ( User Interface ), which creates a visualization of the objects in the ViewModel, in this case MainWindow.xaml</p>
<p><strong>ViewModel - </strong>The ViewModel will be the layer in this application that handles all the logic and the Employee objects, this is the layer that the View will DataBind to.</p>
<h1><span>Scenario</span></h1>
<p><em>In this scenario we have a little company which just expanded rapidly and whenever a new employee arrives, the secretary is in a confused state of mind. She has absolutely no way of keeping order on all the details on every employee without missing a
 few details, so she asked her boss for a way to keep an overview.</em></p>
<p><em>She tells him &quot;I have an offer for a computer software that will make it into an easy task keep track of the employees&quot;.<br>
And He simply says: - &quot;Make it so, number one!&quot;&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Having recieved the task of creating the beforementioned software by Your boss! You now have to figure out, '<em>How will I setup this application?'.</em> Being faithful to this sample, you decide to use C# and WPF, with a MVVM pattern of programming!</p>
<p>First we need our models, because these will contain the information about all the employees, so we will start there.</p>
<p>Below is the Employee class, containing all the properties that we would want for our employee.</p>
<p><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">    public class Employee
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
    }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Employee&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;MemberID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Department&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Phone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Salary&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;</em></div>
<p>&nbsp;</p>
<p>So now we have our Employee class, but we have no where to use it, so we better find a place to put the employee. Useally some people have a tendency to put their Collections and logic in the codebehind ( In this case that would be MainWindow.xaml.cs ),
 but we are going to use a ViewModel, and then bind from the View to the Data in the ViewModel, which is in fact the collection of Employees!</p>
<p>Below is the first part of the ViewModel</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM()
        {
            Employees = GetEmployeeList();
        }

        ObservableCollection&lt;Employee&gt; GetEmployeeList()
        {
            ObservableCollection&lt;Employee&gt; employees = new ObservableCollection&lt;Employee&gt;();

            employees.Add(new Employee { MemberID = 1, Name = &quot;John Hancock&quot;, Department = &quot;IT&quot;, Phone = &quot;31234743&quot;, Email = @&quot;John.Hancock@Company.com&quot;, Salary = &quot;3450.44&quot; });
            employees.Add(new Employee { MemberID = 2, Name = &quot;Jane Hayes&quot;, Department = &quot;Sales&quot;, Phone = &quot;31234744&quot;, Email = @&quot;Jane.Hayes@Company.com&quot;, Salary = &quot;3700&quot; });
            employees.Add(new Employee { MemberID = 3, Name = &quot;Larry Jones&quot;, Department = &quot;Marketing&quot;, Phone = &quot;31234745&quot;, Email = @&quot;Larry.Jones@Company.com&quot;, Salary = &quot;3000&quot; });
            employees.Add(new Employee { MemberID = 4, Name = &quot;Patricia Palce&quot;, Department = &quot;Secretary&quot;, Phone = &quot;31234746&quot;, Email = @&quot;Patricia.Palce@Company.com&quot;, Salary = &quot;2900&quot; });
            employees.Add(new Employee { MemberID = 5, Name = &quot;Jean L. Trickard&quot;, Department = &quot;Director&quot;, Phone = &quot;31234747&quot;, Email = @&quot;Jean.L.Tricard@Company.com&quot;, Salary = &quot;5400&quot; });

            return employees;
        }

        private ObservableCollection&lt;Employee&gt; _employees;
        public ObservableCollection&lt;Employee&gt; Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaiseChange(&quot;Employees&quot;);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseChange(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindowVM&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainWindowVM()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employees&nbsp;=&nbsp;GetEmployeeList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;GetEmployeeList()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;employees&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Employee&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;MemberID&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;John&nbsp;Hancock&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="cs__string">&quot;IT&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="cs__string">&quot;31234743&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="cs__string">&quot;John.Hancock@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="cs__string">&quot;3450.44&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;MemberID&nbsp;=&nbsp;<span class="cs__number">2</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Jane&nbsp;Hayes&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="cs__string">&quot;Sales&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="cs__string">&quot;31234744&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="cs__string">&quot;Jane.Hayes@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="cs__string">&quot;3700&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;MemberID&nbsp;=&nbsp;<span class="cs__number">3</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Larry&nbsp;Jones&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="cs__string">&quot;Marketing&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="cs__string">&quot;31234745&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="cs__string">&quot;Larry.Jones@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="cs__string">&quot;3000&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;MemberID&nbsp;=&nbsp;<span class="cs__number">4</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Patricia&nbsp;Palce&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="cs__string">&quot;Secretary&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="cs__string">&quot;31234746&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="cs__string">&quot;Patricia.Palce@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="cs__string">&quot;2900&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;MemberID&nbsp;=&nbsp;<span class="cs__number">5</span>,&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Jean&nbsp;L.&nbsp;Trickard&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="cs__string">&quot;Director&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="cs__string">&quot;31234747&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="cs__string">&quot;Jean.L.Tricard@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="cs__string">&quot;5400&quot;</span>&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;employees;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;_employees;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;Employees&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_employees;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_employees&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseChange(<span class="cs__string">&quot;Employees&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RaiseChange(<span class="cs__keyword">string</span>&nbsp;PropertyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(PropertyChanged&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyChanged(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(PropertyName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>So, in the viewmodel, we have a few things added, we might as well try and understand what they do !</p>
<p>First the class name. MainWindowVM : <strong>INotifyPropertyChanged</strong></p>
<p>The thing to notice is the 'INotifyPropertyChanged', what this does is inherit the 'INotifyPropertyChanged' interface to the MainWindowVM class. When inheriting this Interface, we now get access to the use of the 'PropertyChangedEventHandler', which we can
 call at any time we would like to update a public property. This ensures that if the View is binding to that specific public property, it will be updated.</p>
<p>But first we have to make sure we implement that PropertyChanged event! and we do that in the bottom of the class by adding this.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseChange(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;event&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;RaiseChange(string&nbsp;PropertyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(PropertyChanged&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyChanged(<span class="js__operator">this</span>,&nbsp;<span class="js__operator">new</span>&nbsp;PropertyChangedEventArgs(PropertyName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">First, we declare the PropertyChangeEventHandler as 'PropertyChanged', and after that we create method called RaiseChange(), this method takes a string property, this will be the name of the public Property that needs to be updated
 in the UI. Which will be called like shown in the code below.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private ObservableCollection&lt;Employee&gt; _employees;
        public ObservableCollection&lt;Employee&gt; Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaiseChange(&quot;Employees&quot;);
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;_employees;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;Employees&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_employees;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_employees&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseChange(<span class="cs__string">&quot;Employees&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the setter you will notice that the private property _employees, is set to the incoming value ( _employees = value; ). After that, the RaiseChange is called, with the public 'Employees' as a parameter.&nbsp;<br>
And finally&nbsp;the RaiseChange method will use the PropertyChanged event to update all the DataBindings.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">But before we start updating all the DataBindings, we have to put something in the Employees collection first! So&nbsp;that we can infact update it! This is done in the Constructor.</div>
<div class="endscriptcode">In the constructer, the lines 'Employees = GetEmployeeList();' appears. In this sample scenario the GetEmployeeList() method returns a hardcoded list example. But in a real case scenario, this could be a list pulled from a database,
 or a local file.</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">But in the code below, you can see how the collection is created and afterwards returned back to the Employees collection.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainWindowVM()
        {
            Employees = GetEmployeeList();
        }

        ObservableCollection&lt;Employee&gt; GetEmployeeList()
        {
            ObservableCollection&lt;Employee&gt; employees = new ObservableCollection&lt;Employee&gt;();

            employees.Add(new Employee { MemberID = 1, Name = &quot;John Hancock&quot;, Department = &quot;IT&quot;, Phone = &quot;31234743&quot;, Email = @&quot;John.Hancock@Company.com&quot;, Salary = &quot;3450.44&quot; });
            employees.Add(new Employee { MemberID = 2, Name = &quot;Jane Hayes&quot;, Department = &quot;Sales&quot;, Phone = &quot;31234744&quot;, Email = @&quot;Jane.Hayes@Company.com&quot;, Salary = &quot;3700&quot; });
            employees.Add(new Employee { MemberID = 3, Name = &quot;Larry Jones&quot;, Department = &quot;Marketing&quot;, Phone = &quot;31234745&quot;, Email = @&quot;Larry.Jones@Company.com&quot;, Salary = &quot;3000&quot; });
            employees.Add(new Employee { MemberID = 4, Name = &quot;Patricia Palce&quot;, Department = &quot;Secretary&quot;, Phone = &quot;31234746&quot;, Email = @&quot;Patricia.Palce@Company.com&quot;, Salary = &quot;2900&quot; });
            employees.Add(new Employee { MemberID = 5, Name = &quot;Jean L. Trickard&quot;, Department = &quot;Director&quot;, Phone = &quot;31234747&quot;, Email = @&quot;Jean.L.Tricard@Company.com&quot;, Salary = &quot;5400&quot; });

            return employees;
        }</pre>
<div class="preview">
<pre class="js">public&nbsp;MainWindowVM()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employees&nbsp;=&nbsp;GetEmployeeList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;GetEmployeeList()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;employees&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObservableCollection&lt;Employee&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="js__operator">new</span>&nbsp;Employee&nbsp;<span class="js__brace">{</span>&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;John&nbsp;Hancock&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;IT&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234743&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="js__string">&quot;John.Hancock@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;3450.44&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="js__operator">new</span>&nbsp;Employee&nbsp;<span class="js__brace">{</span>&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">2</span>,&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Jane&nbsp;Hayes&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;Sales&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234744&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="js__string">&quot;Jane.Hayes@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;3700&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="js__operator">new</span>&nbsp;Employee&nbsp;<span class="js__brace">{</span>&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">3</span>,&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Larry&nbsp;Jones&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;Marketing&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234745&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="js__string">&quot;Larry.Jones@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;3000&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="js__operator">new</span>&nbsp;Employee&nbsp;<span class="js__brace">{</span>&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">4</span>,&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Patricia&nbsp;Palce&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;Secretary&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234746&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="js__string">&quot;Patricia.Palce@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;2900&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="js__operator">new</span>&nbsp;Employee&nbsp;<span class="js__brace">{</span>&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">5</span>,&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Jean&nbsp;L.&nbsp;Trickard&quot;</span>,&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;Director&quot;</span>,&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234747&quot;</span>,&nbsp;Email&nbsp;=&nbsp;@<span class="js__string">&quot;Jean.L.Tricard@Company.com&quot;</span>,&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;5400&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;employees;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Note:&nbsp;<em>In case you have a class like the Employee, which contains a constructor that does some logic when instantiated, using this approach to add the employees would not be a good idea, instead they should be instantiated
 and then added to the collection, like so.</em></strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Employee employee = new Employee() 
            {
                MemberID = 1,
                Name = &quot;Jane Doe&quot;,
                Department = &quot;Banking&quot;,
                Phone = &quot;31234748&quot;,
                Email = &quot;Jane.Doe@Company.Com&quot;,
                Salary = &quot;3350&quot;
            };
            employees.Add(employee);</pre>
<div class="preview">
<pre class="js">Employee&nbsp;employee&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Employee()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MemberID&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Jane&nbsp;Doe&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Department&nbsp;=&nbsp;<span class="js__string">&quot;Banking&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone&nbsp;=&nbsp;<span class="js__string">&quot;31234748&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="js__string">&quot;Jane.Doe@Company.Com&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Salary&nbsp;=&nbsp;<span class="js__string">&quot;3350&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(employee);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</em></strong></div>
</div>
<div class="endscriptcode">So now we have our Employee model that contains a single employee, and the&nbsp;ViewModel containing all our individual&nbsp;employees.</div>
<div class="endscriptcode">Now we just need the View where we can present all the employees. And despite this might have been easy so far. This really is the easiest part.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">In this case we will use a Datagrid control to present our employees. But in order to make the datagrid see the data, we have to add a reference in our xaml to the Viewmodel we need.</div>
<div class="endscriptcode">We do that by adding this line to the xaml 'xmlns:VM=&quot;clr-namespace:Employee_Overview.ViewModels&quot; ' - Short explanation, this creates a reference to the namespace Employee_Overview.ViewModels (clr-namespace:Employee_Overview.ViewModels),
 which is the namespace of our ViewModels class, and we name the reference 'VM' ( xmlns:VM ).</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">And when we have done that, we can add the ViewModel as the DataContext for the Window, this is done by the lines</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">&lt;Window.DataContext&gt;</div>
<div class="endscriptcode">&nbsp; &nbsp;&lt;VM:MainWindowVM/&gt;</div>
<div class="endscriptcode">&lt;/Window.DataContext&gt;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong>Notice: </strong><em>In the datacontext we wite VM: ( The reference name declared before ) and MainWindowVM ( The class name of our ViewModel in the Employee_Overview.ViewModels namespace ).</em></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">So now the ViewModel has been loaded and set as the DataContext of the window, this allows our DataGrid to use the Employees property as its ItemsSource, so when the ItemsSource is set. The application is ready to build and startup.</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window x:Class=&quot;Employee_Overview.MainWindow&quot;
        xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
        xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        xmlns:VM=&quot;clr-namespace:Employee_Overview.ViewModels&quot;
        Title=&quot;Company Employee List&quot; Height=&quot;250&quot; Width=&quot;625&quot;
        Background=&quot;CornflowerBlue&quot;&gt;
    
    &lt;Window.DataContext&gt;
        &lt;VM:MainWindowVM/&gt;
    &lt;/Window.DataContext&gt;
    
    &lt;Grid Margin=&quot;5&quot;&gt;
        &lt;Grid.RowDefinitions&gt;
            &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
            &lt;RowDefinition/&gt;
        &lt;/Grid.RowDefinitions&gt;
        
        &lt;TextBlock Text=&quot;Employees&quot; FontSize=&quot;22&quot; FontWeight=&quot;Bold&quot; Foreground=&quot;DarkBlue&quot;/&gt;
        &lt;DataGrid ItemsSource=&quot;{Binding Employees}&quot; Grid.Row=&quot;1&quot;/&gt;
    &lt;/Grid&gt;
&lt;/Window&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Window&nbsp;x:Class=<span class="js__string">&quot;Employee_Overview.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:VM=<span class="js__string">&quot;clr-namespace:Employee_Overview.ViewModels&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="js__string">&quot;Company&nbsp;Employee&nbsp;List&quot;</span>&nbsp;Height=<span class="js__string">&quot;250&quot;</span>&nbsp;Width=<span class="js__string">&quot;625&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Background=<span class="js__string">&quot;CornflowerBlue&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;VM:MainWindowVM/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Margin=<span class="js__string">&quot;5&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;Auto&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="js__string">&quot;Employees&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;22&quot;</span>&nbsp;FontWeight=<span class="js__string">&quot;Bold&quot;</span>&nbsp;Foreground=<span class="js__string">&quot;DarkBlue&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGrid&nbsp;ItemsSource=<span class="js__string">&quot;{Binding&nbsp;Employees}&quot;</span>&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1><span>Conclusion</span></h1>
<p><span>So now we have created a simple overview of the employees using MVVM, and all it took was</span></p>
<ul>
<li>An employee model class </li><li>A viewmodel class implementing the INotifyPropertyChanged </li><li>A reference in the View to the ViewModel, so all data can be seen and bound to.
</li></ul>
<p>&nbsp;</p>
<p><span>Attached to this sample is a Compressed solution of the project that has just been explained.</span></p>
<p><span><br>
</span></p>

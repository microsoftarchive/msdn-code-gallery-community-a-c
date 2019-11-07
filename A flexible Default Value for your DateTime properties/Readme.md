# A flexible Default Value for your DateTime properties
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
## Topics
- ASP.NET MVC
## Updated
- 03/17/2016
## Description

<p>When creating an MVC application with Entity Framework, it is possible to set default values for most properties in a model using the DefaultValue attribute. However, no much flexibility is offered for a DateTime property. This article presents a custom
 validation attribute for DateTime types that accepts different formats for defining the default value of the property.</p>
<h1>About Default Values</h1>
<p>Let&rsquo;s start defining the problem that this article wants to address. The context is an ASP.NET MVC application with a model, say a Blog Post (class
<strong>BlogPost</strong>) that has a <strong>PublishOn</strong> property of <strong>
DateTime</strong> type. I want to valorise this property with a predefined value if the user does not enter any value via the user interface. Typically, I would set the default value of a model property as a
<strong>DefaultValue</strong> attribute, as in:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[DefaultValue(DateTime.Now)]
public DateTime PublishOn { get; set; }
</pre>
<div class="preview">
<pre class="csharp">[DefaultValue(DateTime.Now)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>However, this code does not compile because an attribute argument must be a constant expression evaluated at compile time, and
<strong>DateTime.Now</strong> is clearly evaluated at run time instead.</p>
<p><img id="149691" src="149691-2016-03-17%2015_31_50-defaultdatetimevalue%20-%20microsoft%20visual%20studio.png" alt="" width="600" height="75"></p>
<p>In light of this, I need another approach to define constant expressions that can be used for identifying a default value for a date, and still be able to be evaluated at run time. The approach that we are going to take in based on string expressions in
 different formats, to cover multiple options.</p>
<p>&nbsp;</p>
<h1>The DefaultDateTimeValue Attribute</h1>
<p>A new attribute is required. Let&rsquo;s call it <strong>DefaultDateTimeValue</strong> because it will deal with
<strong>DateTime</strong> types only. But I want it to be flexible enough to accept:</p>
<ol>
<li>Evaluation of DateTime.Now or DateTime.Today at <strong>run time</strong>; </li><li>Definition of an <strong>absolute</strong> date, such as 01/03/2016; </li><li>Definition of a <strong>relative</strong> date, such as &ldquo;in 30 days from today&rdquo;;
</li><li>Evaluation of <strong>expressions</strong> like &ldquo;first of year, last of month&rdquo;, etc.
</li></ol>
<p>&nbsp;</p>
<p>To express this in C# code, I would like to be able to declare something like:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Evaluate to the current date at run time
[DefaultDateTimeValue(&quot;Now&quot;)]
public DateTime? PublishOn { get; set; }

// Define an absolute date
[DefaultDateTimeValue(&quot;01/03/2016&quot;)]
public DateTime? PublishOn { get; set; }

// Define a relative date (30 days from now)
[DefaultDateTimeValue(&quot;30.00:00:00&quot;)]
public DateTime? PublishOn { get; set; }

// Define a relative date (1 hour from now)
[DefaultDateTimeValue(&quot;1:00:00&quot;)]
public DateTime? PublishOn { get; set; }

// Evaluate to last date of the month
[DefaultDateTimeValue(&quot;LastOfMonth&quot;)]
public DateTime? PublishOn { get; set; }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Evaluate&nbsp;to&nbsp;the&nbsp;current&nbsp;date&nbsp;at&nbsp;run&nbsp;time</span>&nbsp;
[DefaultDateTimeValue(<span class="cs__string">&quot;Now&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Define&nbsp;an&nbsp;absolute&nbsp;date</span>&nbsp;
[DefaultDateTimeValue(<span class="cs__string">&quot;01/03/2016&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Define&nbsp;a&nbsp;relative&nbsp;date&nbsp;(30&nbsp;days&nbsp;from&nbsp;now)</span>&nbsp;
[DefaultDateTimeValue(<span class="cs__string">&quot;30.00:00:00&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Define&nbsp;a&nbsp;relative&nbsp;date&nbsp;(1&nbsp;hour&nbsp;from&nbsp;now)</span>&nbsp;
[DefaultDateTimeValue(<span class="cs__string">&quot;1:00:00&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Evaluate&nbsp;to&nbsp;last&nbsp;date&nbsp;of&nbsp;the&nbsp;month</span>&nbsp;
[DefaultDateTimeValue(<span class="cs__string">&quot;LastOfMonth&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>Exciting! Let&rsquo;s go in order: first we need our custom attribute, and we make it inheriting from
<strong>ValidationAttribute</strong> in the <strong>System.ComponentModel.DataAnnotations</strong> namespace because we want our MVC application to validate this attribute at run time.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[AttributeUsage(AttributeTargets.Property)]
public sealed class DefaultDateTimeValueAttribute : ValidationAttribute
{
    public string DefaultValue { get; set; }

    public DefaultDateTimeValueAttribute(string defaultValue)
    {
        DefaultValue = defaultValue;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        PropertyInfo property = validationContext.ObjectType.GetProperty(validationContext.MemberName);

        // Set default value only if no value is already specified
        if (value == null)
        {
            DateTime defaultValue = GetDefaultValue();
            property.SetValue(validationContext.ObjectInstance, defaultValue);
        }

        return ValidationResult.Success;
    }
</pre>
<div class="preview">
<pre class="csharp">[AttributeUsage(AttributeTargets.Property)]&nbsp;
<span class="cs__keyword">public</span><span class="cs__keyword">sealed</span><span class="cs__keyword">class</span>&nbsp;DefaultDateTimeValueAttribute&nbsp;:&nbsp;ValidationAttribute&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">string</span>&nbsp;DefaultValue&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DefaultDateTimeValueAttribute(<span class="cs__keyword">string</span>&nbsp;defaultValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DefaultValue&nbsp;=&nbsp;defaultValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span><span class="cs__keyword">override</span>&nbsp;ValidationResult&nbsp;IsValid(<span class="cs__keyword">object</span><span class="cs__keyword">value</span>,&nbsp;ValidationContext&nbsp;validationContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyInfo&nbsp;property&nbsp;=&nbsp;validationContext.ObjectType.GetProperty(validationContext.MemberName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;default&nbsp;value&nbsp;only&nbsp;if&nbsp;no&nbsp;value&nbsp;is&nbsp;already&nbsp;specified</span><span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;defaultValue&nbsp;=&nbsp;GetDefaultValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;property.SetValue(validationContext.ObjectInstance,&nbsp;defaultValue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ValidationResult.Success;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>DefaultDateTimeValueAttribute</strong> exposes a <strong>DefaultValue</strong> property, which is assigned in the constructor, and overrides
<strong>IsValid</strong>. This method is invoked during the model validation for the specific property, passing the entered value and a validation context. From the validation context, we obtain the object type (<strong>ObjectType</strong>) where the property
 is defined, which is our model, and the property name (<strong>MemberName</strong>), in our example that is &ldquo;PublishOn&rdquo;.</p>
<p>If there is no value entered by the user, then evaluate the default value to assign to the property. Validation is always successful because a default value will be assigned in any case.</p>
<p>&nbsp;</p>
<h1>Different Default Date Formats</h1>
<p>Evaluation of the default value to assign to the property is done in the <strong>
GetDefaultValue</strong> method of the custom attribute. This method handles the four different options for DateTime values that is possible to specify.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private DateTime GetDefaultValue()
{
    // Resolve a named property of DateTime, like &quot;Now&quot;
    if (this.IsProperty)
    {
        return GetPropertyValue();
    }

    // Resolve a named extension method of DateTime, like &quot;LastOfMonth&quot;
    if (this.IsExtensionMethod)
    {
        return GetExtensionMethodValue();
    }

    // Parse a relative date
    if (this.IsRelativeValue)
    {
        return GetRelativeValue();
    }

    // Parse an absolute date
    return GetAbsoluteValue();
}

private bool IsProperty
    =&gt; typeof(DateTime).GetProperties()
        .Select(p =&gt; p.Name).Contains(this.DefaultValue);

private bool IsExtensionMethod
    =&gt; typeof(DefaultDateTimeValueAttribute).Assembly
        .GetType(typeof(DateTimeExtensions).FullName)
        .GetMethods()
        .Where(m =&gt; m.IsDefined(typeof(ExtensionAttribute), false))
        .Select(p =&gt; p.Name).Contains(this.DefaultValue);

private bool IsRelativeValue
    =&gt; this.DefaultValue.Contains(&quot;:&quot;);
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;GetDefaultValue()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Resolve&nbsp;a&nbsp;named&nbsp;property&nbsp;of&nbsp;DateTime,&nbsp;like&nbsp;&quot;Now&quot;</span><span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.IsProperty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetPropertyValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Resolve&nbsp;a&nbsp;named&nbsp;extension&nbsp;method&nbsp;of&nbsp;DateTime,&nbsp;like&nbsp;&quot;LastOfMonth&quot;</span><span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.IsExtensionMethod)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetExtensionMethodValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Parse&nbsp;a&nbsp;relative&nbsp;date</span><span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.IsRelativeValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetRelativeValue();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Parse&nbsp;an&nbsp;absolute&nbsp;date</span><span class="cs__keyword">return</span>&nbsp;GetAbsoluteValue();&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span><span class="cs__keyword">bool</span>&nbsp;IsProperty&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">typeof</span>(DateTime).GetProperties()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(p&nbsp;=&gt;&nbsp;p.Name).Contains(<span class="cs__keyword">this</span>.DefaultValue);&nbsp;
&nbsp;
<span class="cs__keyword">private</span><span class="cs__keyword">bool</span>&nbsp;IsExtensionMethod&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">typeof</span>(DefaultDateTimeValueAttribute).Assembly&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetType(<span class="cs__keyword">typeof</span>(DateTimeExtensions).FullName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetMethods()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Where(m&nbsp;=&gt;&nbsp;m.IsDefined(<span class="cs__keyword">typeof</span>(ExtensionAttribute),&nbsp;<span class="cs__keyword">false</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(p&nbsp;=&gt;&nbsp;p.Name).Contains(<span class="cs__keyword">this</span>.DefaultValue);&nbsp;
&nbsp;
<span class="cs__keyword">private</span><span class="cs__keyword">bool</span>&nbsp;IsRelativeValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">this</span>.DefaultValue.Contains(<span class="cs__string">&quot;:&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p>The first requirement for evaluating DateTime.Now at run time is met by the <strong>
GetPropertyValue</strong> method. If the specified default value, which is a string, matches the name of a property of the DateTime object, such as &ldquo;Now&rdquo; or &ldquo;Today&rdquo;, the GetPropertyValue method is called (more about this method later).</p>
<p>If the string expression matches the name of an extension method to the DateTime object, that we have defined separately, then the
<strong>GetExtensionMethodValue</strong> method is invoked (more about extensions soon, be patient&hellip;).</p>
<p>Carrying on with the options, if the string expression contains a colon punctuation mark &ldquo;:&rdquo;, then we are likely in presence of an expression of a relative date, so the
<strong>GetRelativeValue</strong> method is invoked. More about why the colon sign in a moment.</p>
<p>Otherwise, we assume it is an absolute date and the <strong>GetAbsoluteValue</strong> method is finally invoked.</p>
<p>Sounds logic, but let&rsquo;s clarify a few things here.</p>
<p>To determine whether the string expression set as expected default value is a property of the
<strong>DateTime</strong> object is a simple reflection on the DateTime type, getting the name of all properties and checking whether this list contains the expression (&ldquo;Now&rdquo; for example).</p>
<p>For determining whether the expression matches the name of an extension method, instead, we need to go a bit around with our reflection, as extension methods are not defined directly into the object type. So we need to check for existence of the extension
 class in the current assembly, retrieve a list of all methods defined as extensions (they have the
<strong>ExtensionAttribute</strong> silently added by the compiler), and match the name against the default value expression.</p>
<p>About relative dates we have already said that the check is simply for a &ldquo;:&rdquo; sign. This is because, as we will see later, the relative expression uses the
<strong>TimeSpan</strong> format, which is &ldquo;dd.hh:mm:ss&rdquo; for days, hours, minutes and seconds, and &ldquo;hh:mm:ss&rdquo; for hours, minutes and seconds. Yes ok, a regular expression match would be more robust, I know&hellip; I leave it for a future
 refactoring :-)</p>
<p>Now that we know how to differentiate the date formats, let&rsquo;s look at the implementation of the method to evaluate these expressions at run time.</p>
<p>&nbsp;</p>
<h1>Evaluating the Default Value</h1>
<h2>GetPropertyValue</h2>
<p><strong>GetPropertyValue</strong> is the method for evaluating a property of <strong>
DateTime</strong> at run time. After creating an instance of a DateTime object via the
<strong>Activator</strong> object, we simply obtain the value of the property by reflection.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private DateTime GetPropertyValue()
{
    var instance = Activator.CreateInstance&lt;DateTime&gt;();
    var value = (DateTime)instance.GetType()
        .GetProperty(this.DefaultValue)
        .GetValue(instance);

    return value;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;GetPropertyValue()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;instance&nbsp;=&nbsp;Activator.CreateInstance&lt;DateTime&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;(DateTime)instance.GetType()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetProperty(<span class="cs__keyword">this</span>.DefaultValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetValue(instance);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">value</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>GetExtensionMethodValue</h2>
<p><strong>GetExtensionMethodValue</strong> takes a longer route to execute an extension method. This is because extension methods cannot be found directly on the type being reflected, as they are indeed extensions, that is defined inside another object. So,
 the approach is to find the extension object in the current assembly, get the method by name and then invoke it on an instance of
<strong>DateTime</strong> obtained via <strong>Activator</strong>. As we are using the extensions methods to calculate dates relative to the current date, e.g. the first of the year, the last of the month, etc., we pass DateTime.Now as parameter.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private DateTime GetExtensionMethodValue()
{
    var instance = Activator.CreateInstance&lt;DateTime&gt;();
    var value = (DateTime)typeof(DefaultDateTimeValueAttribute).Assembly
        .GetType(typeof(DateTimeExtensions).FullName)
        .GetMethod(this.DefaultValue)
        .Invoke(instance, new object[] { DateTime.Now });

    return value;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;GetExtensionMethodValue()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;instance&nbsp;=&nbsp;Activator.CreateInstance&lt;DateTime&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;(DateTime)<span class="cs__keyword">typeof</span>(DefaultDateTimeValueAttribute).Assembly&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetType(<span class="cs__keyword">typeof</span>(DateTimeExtensions).FullName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetMethod(<span class="cs__keyword">this</span>.DefaultValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Invoke(instance,&nbsp;<span class="cs__keyword">new</span><span class="cs__keyword">object</span>[]&nbsp;{&nbsp;DateTime.Now&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">value</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>GetRelativeValue</h2>
<p><strong>GetRelativeValue</strong> works with time spans. The format of the default value is what can be obtained by converting a
<strong>TimeSpan</strong> object to a string, and what can be recognised by the TimeSpan.TryParse method. The time span is then added to the current date to obtain the default date. Please note that time spans can be also negative, so to express a value like
 &ldquo;30 days ago&rdquo;, we should use the format &ldquo;-30.00:00:00&rdquo;.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private DateTime GetRelativeValue()
{
    TimeSpan timeSpan;
    if (!TimeSpan.TryParse(this.DefaultValue, out timeSpan))
    {
        return default(DateTime);
    }

    return DateTime.Now.Add(timeSpan);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;GetRelativeValue()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TimeSpan&nbsp;timeSpan;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!TimeSpan.TryParse(<span class="cs__keyword">this</span>.DefaultValue,&nbsp;<span class="cs__keyword">out</span>&nbsp;timeSpan))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">default</span>(DateTime);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DateTime.Now.Add(timeSpan);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<h2>GetAbsoluteValue</h2>
<p><strong>GetAbsoluteValue</strong> works with fixed dates, so the format is the typical combination of DD/MM/YYYY, depending on the computer&rsquo;s locale. DateTime.TryParse is used to parse the string expression.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private DateTime GetAbsoluteValue()
{
    DateTime value;
    if (!DateTime.TryParse(this.DefaultValue, out value))
    {
        return default(DateTime);
    }

    return value;
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;GetAbsoluteValue()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!DateTime.TryParse(<span class="cs__keyword">this</span>.DefaultValue,&nbsp;<span class="cs__keyword">out</span><span class="cs__keyword">value</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">default</span>(DateTime);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">value</span>;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>The DateTime Extensions</h1>
<p>I mentioned before to some extensions methods that enable some simple evaluation of dynamic dates at run time, that is dates that depends on the current date. The following methods have been implemented; feel free to add your own as needed:</p>
<ul>
<li><strong>FirstOfYear</strong>: returns the 1<sup>st</sup> of January of the current year;
</li><li><strong>LastOfYear</strong>: returns the 31<sup>st</sup> of December of the current year;
</li><li><strong>FirstOfMonth</strong>: returns the 1<sup>st</sup> day of the current month and year;
</li><li><strong>LastOfMonth</strong>: returns the last day of the current month and year, taking into consideration whether it&rsquo;s a leap year (this is done automatically by the DateTime.DaysInMonth method).
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static class DateTimeExtensions
{
    public static DateTime FirstOfYear(this DateTime dateTime)
        =&gt; new DateTime(dateTime.Year, 1, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

    public static DateTime LastOfYear(this DateTime dateTime)
        =&gt; new DateTime(dateTime.Year, 12, 31, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

    public static DateTime FirstOfMonth(this DateTime dateTime)
        =&gt; new DateTime(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);

    public static DateTime LastOfMonth(this DateTime dateTime)
        =&gt; new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DateTimeExtensions&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DateTime&nbsp;FirstOfYear(<span class="cs__keyword">this</span>&nbsp;DateTime&nbsp;dateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(dateTime.Year,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;dateTime.Hour,&nbsp;dateTime.Minute,&nbsp;dateTime.Second,&nbsp;dateTime.Millisecond);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DateTime&nbsp;LastOfYear(<span class="cs__keyword">this</span>&nbsp;DateTime&nbsp;dateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(dateTime.Year,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">31</span>,&nbsp;dateTime.Hour,&nbsp;dateTime.Minute,&nbsp;dateTime.Second,&nbsp;dateTime.Millisecond);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DateTime&nbsp;FirstOfMonth(<span class="cs__keyword">this</span>&nbsp;DateTime&nbsp;dateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(dateTime.Year,&nbsp;dateTime.Month,&nbsp;<span class="cs__number">1</span>,&nbsp;dateTime.Hour,&nbsp;dateTime.Minute,&nbsp;dateTime.Second,&nbsp;dateTime.Millisecond);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DateTime&nbsp;LastOfMonth(<span class="cs__keyword">this</span>&nbsp;DateTime&nbsp;dateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;DateTime(dateTime.Year,&nbsp;dateTime.Month,&nbsp;DateTime.DaysInMonth(dateTime.Year,&nbsp;dateTime.Month),&nbsp;dateTime.Hour,&nbsp;dateTime.Minute,&nbsp;dateTime.Second,&nbsp;dateTime.Millisecond);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<h1>The MVC Application</h1>
<p>We are now in the position of implementing all this infrastructure code into our MVC application. Sticking to a simple model that contains a DateTime property, we can try different combinations of default values as offered by our custom attribute. I left
 the generation of the Controller and relative Views to Visual Studio. There is nothing to change in the generated code, as all the &ldquo;magic&rdquo; happens in the model by setting the
<strong>DefaultDateTimeValue</strong> attribute for the DateTime property.</p>
<p>&nbsp;</p>
<h2>The Model</h2>
<p>The model is a pseudo blog post with simply a primary key (Id), a unique title and a date when the post is going to be published. Feel free to try different combinations of default values. Also, note that the
<strong>PublishOn</strong> property is a nullable DateTime. This is because the jQuery client-side validation would prevent even submitting the form if no value is entered on the UI. If you are bothered by the nullability of the property, disable client-side
 validation and let the form being submitted. Validation will occur server-side during the model binding, which is when the validation attributes are checked. This included also our custom validation attribute that assigns a default value to the property.</p>
<p><img id="149692" src="149692-2016-03-17%2016_23_39-defaultdatetimevalue%20-%20microsoft%20visual%20studio.png" alt="" width="290" height="293"></p>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class BlogPost
{
    public int Id { get; set; }

    [StringLength(1000), Required, Index(IsUnique = true)]
    public string Title { get; set; }

    [DisplayName(&quot;Publish On&quot;)]
    [DefaultDateTimeValue(&quot;Now&quot;)]
    //[DefaultDateTimeValue(&quot;01/03/2016&quot;)]
    //[DefaultDateTimeValue(&quot;30.00:00:00&quot;)]
    //[DefaultDateTimeValue(&quot;1:00:00&quot;)]
    //[DefaultDateTimeValue(&quot;LastOfMonth&quot;)]
    public DateTime? PublishOn { get; set; }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;BlogPost&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[StringLength(<span class="cs__number">1000</span>),&nbsp;Required,&nbsp;Index(IsUnique&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Title&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DisplayName(<span class="cs__string">&quot;Publish&nbsp;On&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DefaultDateTimeValue(<span class="cs__string">&quot;Now&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//[DefaultDateTimeValue(&quot;01/03/2016&quot;)]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//[DefaultDateTimeValue(&quot;30.00:00:00&quot;)]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//[DefaultDateTimeValue(&quot;1:00:00&quot;)]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//[DefaultDateTimeValue(&quot;LastOfMonth&quot;)]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;PublishOn&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<h2>The View</h2>
<p>All the views are generated by the EF scaffolding capability of Visual Studio, so expect to see the typical Create, Delete, Details, Edit and Index
<strong>Razor</strong> views. No changes are applied to these views, but in some way, we need to inform the Html helper that generates the HTML code in the view, to display the default value. Remember, we have implemented a validation attribute, so the default
 value to assign is evaluated only when validation occurs, which is during the model binding. Still, we want to visualise the default value in the view when a new model is created.</p>
<p>To do so, we simply need to customise the editor template for the <strong>DateTime</strong> type. The good news is that MVC has a very powerful convention-based approach where we can extend the framework by simply adding files in the right position with
 the right name. Editor templates are used when the <strong>@Html.EditorFor</strong> method is used on a model property. Specific templates can be specified to be used instead of the standard rendering, but this would require a change to the view, because the
 name of the template has to be specified as an input parameter. Alternatively, for changing the editor template of all properties in a specific type, a Razor partial view with the name of the type can be specified, and saved in the
<strong>View&gt;Shared&gt;EditorTemplates</strong> folder. In our case, that would be
<strong>DateTime.cshtml</strong>.</p>
<p>&nbsp;</p>
<h2>The DateTime Editor Template</h2>
<p>The DateTime editor template displays the date property as a text box using the
<strong>Html.TextBox</strong> extension. Variation of this can be implemented if you decide to use richer components, like jQuery UI DatePicker. What is important here is how the value is evaluated. Information about the value entered in the model is contained
 in the <strong>TemplateInfo</strong> property of the ViewData, more precisely the
<strong>FormattedModelValue</strong> object. This is a generic object, that contains the value of the model property, if any. If no value has been entered yet, which is the case when a new model is being created, the FormattedModelValue is an empty string.</p>
<p>We need to differentiate between creation and editing of the model, as the same editor template is used in both cases. When editing an existing model, FormattedModelValue is the same type of the underlying property. So we can check whether FormattedModelValue
 is DateTime, and if so, we take the assigned value to pass and display in the text box.</p>
<p>Otherwise, we can assume that there is no value assigned, so we need to resolve the default value to assign. This is done by calling a static method on the
<strong>DefaultDateTimeValue</strong> attribute for evaluating the expression of the default value set on the model property. As we are not in the model binding phase here, we need to inform which is the exact object (the model) and property to evaluate. This
 information is contained in the <strong>ViewData.ModelMetadata.ContainerType</strong> and
<strong>ViewData.ModelMetadata.PropertyName</strong> objects respectively.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">@using DefaultDateTimeValue.Models

@{
    DateTime value = ViewData.TemplateInfo.FormattedModelValue is DateTime ?
        (DateTime)ViewData.TemplateInfo.FormattedModelValue :
        DefaultDateTimeValueAttribute.GetDefaultValue(ViewData.ModelMetadata.ContainerType, ViewData.ModelMetadata.PropertyName);
}

@Html.TextBox(string.Empty, value, htmlAttributes: ViewData[&quot;htmlAttributes&quot;])
</pre>
<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;DefaultDateTimeValue.Models&nbsp;
&nbsp;
@{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DateTime&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;ViewData.TemplateInfo.FormattedModelValue&nbsp;<span class="cs__keyword">is</span>&nbsp;DateTime&nbsp;?&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(DateTime)ViewData.TemplateInfo.FormattedModelValue&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DefaultDateTimeValueAttribute.GetDefaultValue(ViewData.ModelMetadata.ContainerType,&nbsp;ViewData.ModelMetadata.PropertyName);&nbsp;
}&nbsp;
&nbsp;
@Html.TextBox(<span class="cs__keyword">string</span>.Empty,&nbsp;<span class="cs__keyword">value</span>,&nbsp;htmlAttributes:&nbsp;ViewData[<span class="cs__string">&quot;htmlAttributes&quot;</span>])&nbsp;
</pre>
</div>
</div>
</div>
<p>The public <strong>GetDefaultValue</strong> method of the <strong>DefaultDateTimeValueAttribute</strong> class simply resolves the property and attribute info via reflection, and then internally evaluates the default value in the same way as seen before
 during validation, by calling the private GetDefaultValue method.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static DateTime GetDefaultValue(Type objectType, string propertyName)
{
    var property = objectType.GetProperty(propertyName);
    var attribute = property.GetCustomAttributes(typeof(DefaultDateTimeValueAttribute), false)
        ?.Cast&lt;DefaultDateTimeValueAttribute&gt;()
        ?.FirstOrDefault();

    return attribute.GetDefaultValue();
}
</pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;DateTime&nbsp;GetDefaultValue(Type&nbsp;objectType,&nbsp;string&nbsp;propertyName)&nbsp;
<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;property&nbsp;=&nbsp;objectType.GetProperty(propertyName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;attribute&nbsp;=&nbsp;property.GetCustomAttributes(<span class="js__operator">typeof</span>(DefaultDateTimeValueAttribute),&nbsp;false)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;?.Cast&lt;DefaultDateTimeValueAttribute&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;?.FirstOrDefault();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;attribute.GetDefaultValue();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>The entire source code is attached to this article and also on <a href="https://stefanotempesta.codeplex.com/SourceControl/latest#StefanoTempestaNet/DefaultDateTimeValue/" target="_blank">
CodePlex</a>, feel free to download and use/amend it at your wish. If you have any interesting enhancements to bring, please shout, will be glad to hear from you!</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
</div>
</div>

# Build Custom Data Annotation Validation Attributes
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET MVC
## Topics
- Data Validation
## Updated
- 08/10/2013
## Description

<h1>Introduction</h1>
<p><em>This sample shows how to extend <a title="ValidatationAttribute" href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.validationattribute.aspx" target="_blank">
System.ComponentModel.DataAnnotations.ValidationAttribute</a> to build your own validation attributes that might require validation between for example model properties in MVC application. For this .NET has CompareAttribute class, but this sample shows how
 with your own attributes you can build more flexible comparison attributes.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Sample is created with Visual Studio 2012 and it contains a sample MVC web site that uses ASP.NET MVC 4.0.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The sample resolves the comparison problems with several attributes. First one is base class for any property comparison attributes which is PropertyValidationAttribute that inherits ValidationAttribute. This class does not do any validation it is just
 for getting the value of the compared property.</em></p>
<p><em>So the main method in PropertyValidationAttribute is GetValue.<br>
</em></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected object GetValue(ValidationContext validationContext)
{
    Type type = validationContext.ObjectType;
    PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

    if (property == null)
        throw new InvalidOperationException(String.Format(&quot;Type {0} does not contains public instance property {1}.&quot;, type.FullName, PropertyName));

    if (IsIndexerProperty(property))
        throw new NotSupportedException(&quot;Property with indexer parameters is not supported.&quot;);

    value = property.GetValue(validationContext.ObjectInstance);

    return value;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;GetValue(ValidationContext&nbsp;validationContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;type&nbsp;=&nbsp;validationContext.ObjectType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PropertyInfo&nbsp;property&nbsp;=&nbsp;type.GetProperty(PropertyName,&nbsp;BindingFlags.Public&nbsp;|&nbsp;BindingFlags.Instance&nbsp;|&nbsp;BindingFlags.GetProperty);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(property&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(String.Format(<span class="cs__string">&quot;Type&nbsp;{0}&nbsp;does&nbsp;not&nbsp;contains&nbsp;public&nbsp;instance&nbsp;property&nbsp;{1}.&quot;</span>,&nbsp;type.FullName,&nbsp;PropertyName));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(IsIndexerProperty(property))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotSupportedException(<span class="cs__string">&quot;Property&nbsp;with&nbsp;indexer&nbsp;parameters&nbsp;is&nbsp;not&nbsp;supported.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">value</span>&nbsp;=&nbsp;property.GetValue(validationContext.ObjectInstance);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">value</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The first actual class that does validation meets the common requirement of comparing dates. It very usual to have two dates that make a range where begin date must be less than or equal to end date. The DateTimeComparisonAttribute
 class inherits from PropertyValidationAttribute to compare two date properties for validity.</div>
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private ValidationResult IsValid(DateTime value, DateTime otherValue)
{
    switch (comparison)
    {
        case ValueComparison.IsEqual:
            if (value != otherValue)
            {
                return failure;
            }
            break;
        case ValueComparison.IsNotEqual:
            if (value == otherValue)
            {
                return failure;
            }
            break;
        case ValueComparison.IsGreaterThan:
            if (value &lt;= otherValue)
            {
                return failure;
            }
            break;
        case ValueComparison.IsGreaterThanOrEqual:
            if (value &lt; otherValue)
            {
                return failure;
            }
            break;
        case ValueComparison.IsLessThan:
            if (value &gt;= otherValue)
            {
                return failure;
            }
            break;
        case ValueComparison.IsLessThanOrEqual:
            if (value &gt; otherValue)
            {
                return failure;
            }
            break;
    }

    return success;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;ValidationResult&nbsp;IsValid(DateTime&nbsp;<span class="cs__keyword">value</span>,&nbsp;DateTime&nbsp;otherValue)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(comparison)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsEqual:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;!=&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsNotEqual:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;==&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsGreaterThan:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;&lt;=&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsGreaterThanOrEqual:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;&lt;&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsLessThan:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;&gt;=&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ValueComparison.IsLessThanOrEqual:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;&gt;&nbsp;otherValue)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;failure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;success;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
The usage of DateTimeComparisonAttribute is very simple. You give the name of the property to compare to and how values are compared. If type of the property is not DateTime or it is nullable DateTime without value, then it is ignored.
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DateTimeModel
{
    [DateTimeCompare(&quot;EndDate&quot;, ValueComparison.IsLessThan, 
     ErrorMessage = &quot;Start date must be earlier than end date.&quot;)]
    public DateTime? StartDate { get; set; }

    [DateTimeCompare(&quot;StartDate&quot;, ValueComparison.IsGreaterThan, 
     ErrorMessage = &quot;End date must be later than start date.&quot;)]
    public DateTime? EndDate { get; set; }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DateTimeModel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DateTimeCompare(<span class="cs__string">&quot;EndDate&quot;</span>,&nbsp;ValueComparison.IsLessThan,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Start&nbsp;date&nbsp;must&nbsp;be&nbsp;earlier&nbsp;than&nbsp;end&nbsp;date.&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;StartDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[DateTimeCompare(<span class="cs__string">&quot;StartDate&quot;</span>,&nbsp;ValueComparison.IsGreaterThan,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;End&nbsp;date&nbsp;must&nbsp;be&nbsp;later&nbsp;than&nbsp;start&nbsp;date.&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime?&nbsp;EndDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
The second validation class is ValueComparisonAttribute that performs in a similar way as DateTimeComparisonAttribute, but using values of objects that implement IComparable interface. Using this attribute is also similar. You set the name of the property to
 compare to and how to compare. If value is not IComparable then exception is thrown.
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected override ValidationResult IsValid(object value, ValidationContext validationContext)
{
    if (value != null)
    {
        IComparable comparable = value as IComparable;

        if (comparable == null)
            throw new InvalidOperationException(&quot;The comparison value must implement System.IComparable interface.&quot;);

        object otherValue = GetValue(validationContext);

        int result = comparable.CompareTo(otherValue);

        return Compare(result);
    }

    return success;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;ValidationResult&nbsp;IsValid(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;ValidationContext&nbsp;validationContext)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IComparable&nbsp;comparable&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;<span class="cs__keyword">as</span>&nbsp;IComparable;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(comparable&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;The&nbsp;comparison&nbsp;value&nbsp;must&nbsp;implement&nbsp;System.IComparable&nbsp;interface.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;otherValue&nbsp;=&nbsp;GetValue(validationContext);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;result&nbsp;=&nbsp;comparable.CompareTo(otherValue);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Compare(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;success;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The third sample validation attribute I have included is RequiredIfAttribute. This compares the value provided property to given value using specified comparison and if outcome is true, then the validated value is required. Namely
 this is for the cases where if some property value meets condition then other property value is required. In my sample web page this is done by comparing age and if under 18, then guardian name would be required.</div>
<p></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class RequiredIfModel
{
    [Range(0, 120)]
    public int Age { get; set; }

    [RequiredIf(&quot;Age&quot;, 18, ValueComparison.IsLessThan, 
     ErrorMessage = &quot;If age is under 18, the name of the guardian must be set.&quot;)]
    public string GuardianName { get; set; }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RequiredIfModel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Range(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">120</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[RequiredIf(<span class="cs__string">&quot;Age&quot;</span>,&nbsp;<span class="cs__number">18</span>,&nbsp;ValueComparison.IsLessThan,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;If&nbsp;age&nbsp;is&nbsp;under&nbsp;18,&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;guardian&nbsp;must&nbsp;be&nbsp;set.&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GuardianName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>PropertyValidationAttribute.cs - base class for all my validation attribute classes that inherits ValidationAttribute.<br>
</em></li><li><em><em>DateTimeCompareAttribute.cs - validation attribute to compare two dates.</em></em>
</li><li><em>ValueComparisonAttribute.cs - validation attribute to compare object values that implement IComparable.</em>
</li><li><em>RequiredIfAttribute.cs - validation attribute to compare if value is required based on value of other property.</em>
</li></ul>
<h1>More Information</h1>
<p><em>In future I might be creating also the client side validation, but the current sample does not have that.</em></p>

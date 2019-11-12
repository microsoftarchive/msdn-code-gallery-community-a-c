# Composing WPF DataGrid Column Templates for a Better User Experience
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Controls
- Data Binding
- DataGrid control
## Updated
- 05/02/2011
## Description

<p><img src="21438-gg983481.julie_lerman_headshot(en-us%2cmsdn.10).jpg" alt="" width="100" height="150" style="float:left; padding-right:5px; padding-bottom:10px">Recently I&rsquo;ve
 been doing some work in Windows Presentation Foundation (WPF) for a client. Although I&rsquo;m a big believer in using third-party tools, I sometimes avoid them in order to find out what challenges lay in wait for developers who, for one reason or another,
 stick to using only those tools that are part of the Visual Studio installation.</p>
<p>So I crossed my fingers and jumped into the WPF DataGrid. There were some user-experience issues that took me days to solve, even with the aid of Web searches and suggestions in online forums. Breaking my DataGrid columns into pairs of complementary templates
 turned out to play a big role in solving these problems. Because the solutions weren&rsquo;t obvious, I&rsquo;ll share them here.</p>
<p>The focus of this column will be working with the WPF ComboBox and DatePicker controls that are inside a WPF DataGrid.</p>
<h2 style="clear:both">The DatePicker and New DataGrid Rows</h2>
<p>One challenge that caused me frustration was user interaction with the date columns in my DataGrid. I had created a DataGrid by dragging an object Data Source onto the WPF window. The designer&rsquo;s default behavior is to create a DatePicker for each DateTime
 value in the object. For example, here&rsquo;s the column created for a DateScheduled field:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;DataGridTemplateColumn</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;&nbsp;dateScheduledColumn&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;DateScheduled&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;100&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTemplateColumn</span>.CellTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DatePicker</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedDate</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=DateScheduled,&nbsp;Mode=TwoWay,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidatesOnExceptions=true,&nbsp;NotifyOnValidationError=true}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/DataGridTemplateColumn.CellTemplate&gt;&nbsp;
<span class="xaml__tag_end">&lt;/DataGridTemplateColumn&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This default isn&rsquo;t conducive to editing. Existing rows weren&rsquo;t updating when edited. The DatePicker doesn&rsquo;t trigger editing in the DataGrid, which means that the data-binding feature won&rsquo;t push the
 change through to the underlying object. Adding the UpdateSourceTrigger attribute to the Binding element and setting its value to PropertyChanged solved this particular problem:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;DatePicker</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedDate</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=&nbsp;DateScheduled,&nbsp;Mode=TwoWay,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidatesOnExceptions=true,&nbsp;NotifyOnValidationError=true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UpdateSourceTrigger=PropertyChanged}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">However, with new rows, there&rsquo;s a worse implication of the  inability of the DatePicker to trigger the DataGrid edit mode. In a DataGrid, a new row is represented by a NewRowPlaceHolder. When you first edit a cell in a new
 row, the edit mode triggers an insert in the data source (again, not in the database, but in the underlying in-memory source). Because DatePicker isn&rsquo;t triggering edit mode, this doesn&rsquo;t happen.</div>
</div>
<p>&nbsp;</p>
<p>I discovered this problem because, coincidentally, a date column was the first column in my row. I was depending on it to trigger the row&rsquo;s edit mode.</p>
<p><strong>Figure 1</strong>&nbsp;shows a new row where the date in the first editable column has been entered.&nbsp;</p>
<p><img title="Entering a Date Value into a New Row Placeholder" src="-gg983481.lerman_figure1_hires(en-us,msdn.10).jpg" alt="image: Entering a Date Value into a New Row Placeholder"></p>
<p>Figure 1&nbsp;<strong>Entering a Date Value into a New Row Placeholder</strong></p>
<p>But after editing the value in the next column, the previous edit value has been lost, as you can see in<strong>Figure 2</strong>.</p>
<p><img title="Date Value Is Lost After the Value of the Task Column in the New Row Is Modified" src="-gg983481.lerman_figure2_hires(en-us,msdn.10).jpg" alt="image: Date Value Is Lost After the Value of the Task Column in the New Row Is Modified"></p>
<p>Figure 2&nbsp;<strong>Date Value Is Lost After the Value of the Task Column in the New Row Is Modified</strong></p>
<p>The key value in the first column has become 0 and the date that was just entered has changed to 1/1/0001. Editing the Task column finally triggered the DataGrid to add a new entity in the source. The ID value becomes an integer&mdash;default, 0&mdash;and
 the date value becomes the .NET default minimum date, 1/1/0001. If I had a default date specified for this class, the user&rsquo;s entered date would have changed to the class default rather than the .NET default. Notice that the date in the Date Performed
 column didn&rsquo;t change to its default. That&rsquo;s because DatePerformed is a nullable property.</p>
<p>So now the user has to go back and fix the Scheduled Date again? I&rsquo;m sure the user won&rsquo;t be happy with that. I struggled with this problem for a while. I even changed the column to a DataTextBoxColumn instead, but then I had to deal with validation
 issues that the DatePicker had protected me from.</p>
<p>Finally, Varsha Mahadevan on the WPF team set me on the right path.</p>
<p>By leveraging the compositional nature of WPF, you can use two elements for the column. Not only does the DataGridTemplateColumn have a CellTemplate element, but there&rsquo;s a CellEditingTemplate as well. Rather than ask the DatePicker control to trigger
 edit mode, I use the DatePicker only when I&rsquo;m already editing. For displaying the date in the CellTemplate, I switched to a TextBlock. Here&rsquo;s the new XAML for dateScheduledCoumn:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;DataGridTemplateColumn&nbsp;x:Name=<span class="js__string">&quot;dateScheduledColumn&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;Header=<span class="js__string">&quot;Date&nbsp;Scheduled&quot;</span>&nbsp;Width=<span class="js__string">&quot;125&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;DataGridTemplateColumn.CellTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;Path=&nbsp;DateScheduled,&nbsp;StringFormat=\{0:d\}}&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&lt;/DataGridTemplateColumn.CellTemplate&gt;&nbsp;
&nbsp;&nbsp;&lt;DataGridTemplateColumn.CellEditingTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DatePicker&nbsp;SelectedDate=&quot;<span class="js__brace">{</span>Binding&nbsp;Path=DateScheduled,&nbsp;Mode=TwoWay,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidatesOnExceptions=true,&nbsp;NotifyOnValidationError=true<span class="js__brace">}</span>&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;
&nbsp;&nbsp;&lt;/DataGridTemplateColumn.CellEditingTemplate&gt;&nbsp;
&lt;/DataGridTemplateColumn&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Notice that I no longer need to specify UpdateSourceTrigger. I&rsquo;ve made the same changes to the DatePerformed column.</div>
<p>&nbsp;</p>
<p>Now the date columns start out as simple text until you enter the cell and it switches to the DatePicker, as you can see in&nbsp;<strong>Figure 3</strong>.</p>
<p><img title="DateScheduled Column Using Both a TextBlock and a DatePicker" src="-gg983481.lerman_figure3_hires(en-us,msdn.10).jpg" alt="image: DateScheduled Column Using Both a TextBlock and a DatePicker"></p>
<p>Figure 3&nbsp;<strong>DateScheduled Column Using Both a TextBlock and a DatePicker</strong></p>
<p>In the rows above the new row, you don&rsquo;t have the DatePicker calendar icon.</p>
<p>But it&rsquo;s still not quite right. We&rsquo;re still getting the default .NET value as we begin editing the row. Now you can benefit from defining a default in the underlying class. I&rsquo;ve modified the constructor of the ScheduleItem class to initialize
 new objects with today&rsquo;s date. If data is retrieved from the database, it will overwrite that default. In my project, I&rsquo;m using the Enity Framework, therefore my classes are generated automatically. However, the generated classes are partial classes,
 which allow me to add the constructor in an additional partial class:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;ScheduleItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ScheduleItem()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateScheduled&nbsp;=&nbsp;DateTime.Today;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Now when I begin entering data into the new row placeholder by modifying the DateScheduled column, the DataGrid will create a new ScheduleItem for me and the default (today&rsquo;s date) will be displayed in the DatePicker control.
 As the user continues to edit the row, the value entered will remain in place this time.</div>
<p>&nbsp;</p>
<h2>Reducing User Clicks to Allow Editing</h2>
<p>One downside to the two-part template is that you have to click on the cell twice to trigger the DatePicker. This is a frustration to anyone doing data entry, especially if they&rsquo;re used to using the keyboard to enter data without touching the mouse.
 Because the DatePicker is in the editing template, it won&rsquo;t get focus until you&rsquo;ve triggered the edit mode&mdash;by default, that is. The design was geared for TextBoxes and with those it works just right. But it doesn&rsquo;t work as well with
 the DatePicker. You can use a&nbsp; combination of XAML and code to force the DatePicker to be ready for typing as soon as a user tabs into that cell.</p>
<p>First you&rsquo;ll need to add a Grid container into the CellEditingTemplate so that it becomes a container of the DatePicker. Then, using the WPF FocusManager, you can force this Grid to be the focal point of the cell when the user enters the cell. Here&rsquo;s
 the new Grid element surrounding the DatePicker:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Grid&nbsp;FocusManager.FocusedElement=<span class="js__string">&quot;{Binding&nbsp;ElementName=&nbsp;dateScheduledPicker}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&lt;DatePicker&nbsp;x:Name=<span class="js__string">&quot;&nbsp;dateScheduledPicker&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SelectedDate=&quot;<span class="js__brace">{</span>Binding&nbsp;Path=DateScheduled,&nbsp;Mode=TwoWay,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ValidatesOnExceptions=true,&nbsp;NotifyOnValidationError=true<span class="js__brace">}</span>&quot;&nbsp;&nbsp;/&gt;&nbsp;
&lt;/Grid&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Notice I&rsquo;ve provided a name for the DatePicker control and I&rsquo;m pointing to that name using the FocusedElement Binding ElementName.</div>
<p>&nbsp;</p>
<p>Moving your attention to the DataGrid that contains this Date-Picker, notice that I&rsquo;ve added three new properties (RowDetailsVisibilityMode, SelectionMode and SelectionUnit), as well as a new event handler (SelectedCellsChanged):</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;DataGrid&nbsp;AutoGenerateColumns=<span class="js__string">&quot;False&quot;</span>&nbsp;EnableRowVirtualization=<span class="js__string">&quot;True&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="js__string">&quot;{Binding}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;12,12,22,31&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name=<span class="js__string">&quot;scheduleItemsDataGrid&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RowDetailsVisibilityMode=<span class="js__string">&quot;VisibleWhenSelected&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectionMode=<span class="js__string">&quot;Extended&quot;</span>&nbsp;SelectionUnit=<span class="js__string">&quot;Cell&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectedCellsChanged=<span class="js__string">&quot;scheduleItemsDataGrid_SelectedCellsChanged&quot;</span>&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The changes to the DataGrid will enable notification when a user selects a new cell in the DataGrid. Finally, when this happens, you need to ensure that the DataGrid does indeed go into edit mode, which will then provide the user
 with the necessary cursor in the DatePicker. The scheduleItemsDataGrid_SelectedCellsChanged method will provide this last bit of logic:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;scheduleItemsDataGrid_SelectedCellsChanged&nbsp;
&nbsp;&nbsp;(object&nbsp;sender,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;System.Windows.Controls.SelectedCellsChangedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(e.AddedCells.Count&nbsp;==&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;currentCell&nbsp;=&nbsp;e.AddedCells[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;string&nbsp;header&nbsp;=&nbsp;(string)currentCell.Column.Header;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;currentCell&nbsp;=&nbsp;e.AddedCells[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(currentCell.Column&nbsp;==&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;scheduleItemsDataGrid.Columns[DateScheduledColumnIndex])&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;scheduleItemsDataGrid.BeginEdit();&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Note that in the class declarations, I&rsquo;ve defined the constant, DateScheduledColumnIndex as 1, the position of the column in the grid.</div>
</div>
<p>&nbsp;</p>
<p>With all of these changes in place, I now have happy end users. It took a bit of poking around to find the right combination of XAML and code elements to make the DatePicker work nicely inside of a DataGrid, and I hope to have helped you avoid making that
 same effort. The UI now works in a way that feels natural to the user.</p>
<h2>Enabling a Restricted ComboBox to Display Legacy Values</h2>
<p>Having grasped the value of layering the elements inside the DataGridTemplateColumn, I revisited another problem that I&rsquo;d nearly given up on with a DataGrid-ComboBox column.</p>
<p>This particular application was being written to replace a legacy application with legacy data. The legacy application had allowed users to enter data without a lot of control. In the new application, the client requested that some of the data entry be restricted
 through the use of drop-down lists. The contents of the drop-down list were provided easily enough using a collection of strings. The challenge was that the legacy data still needed to be displayed even if it wasn&rsquo;t contained in the new restricted list.</p>
<p>My first attempt was to use the DataGridComboBoxColumn:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;DataGridComboBoxColumn&nbsp;x:Name=<span class="js__string">&quot;frequencyCombo&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;MinWidth=<span class="js__string">&quot;100&quot;</span>&nbsp;Header=<span class="js__string">&quot;Frequency&quot;</span>&nbsp;
&nbsp;ItemsSource=<span class="js__string">&quot;{Binding&nbsp;Source={StaticResource&nbsp;frequencyViewSource}}&quot;</span>&nbsp;
&nbsp;SelectedValueBinding=&nbsp;
&nbsp;<span class="js__string">&quot;{Binding&nbsp;Path=Frequency,&nbsp;UpdateSourceTrigger=PropertyChanged}&quot;</span>&gt;&nbsp;
&lt;/DataGridComboBoxColumn&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;The source items are defined in codebehind:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PopulateTrueFrequencyList()&nbsp;
{&nbsp;
&nbsp;&nbsp;_frequencyList&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;String&gt;{<span class="cs__string">&quot;&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Initial&quot;</span>,<span class="cs__string">&quot;2&nbsp;Weeks&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;1&nbsp;Month&quot;</span>,&nbsp;<span class="cs__string">&quot;2&nbsp;Months&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;3&nbsp;Months&quot;</span>,&nbsp;<span class="cs__string">&quot;4&nbsp;Months&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;5&nbsp;Months&quot;</span>,&nbsp;<span class="cs__string">&quot;6&nbsp;Months&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;7&nbsp;Months&quot;</span>,&nbsp;<span class="cs__string">&quot;8&nbsp;Months&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;9&nbsp;Months&quot;</span>,&nbsp;<span class="cs__string">&quot;10&nbsp;Months&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;11&nbsp;Months&quot;</span>,&nbsp;<span class="cs__string">&quot;12&nbsp;Months&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This _frequencyList is bound to frequencyViewSource.Source in another method.</div>
</div>
<p>&nbsp;</p>
<p>In the myriad possible configurations of the DataGridCombo-BoxColumn, I could find no way to display disparate values that may have already been stored in the Frequency field of the database table. I won&rsquo;t bother listing all of the solutions I attempted,
 including one that involved dynamically adding those extra values to the bottom of the _frequencyList and then removing them as needed. That was a solution I disliked but was afraid that I might have to live with.</p>
<p>I knew that the layered approach of WPF to composing a UI had to provide a mechanism for this, and having solved the Date-Picker problem, I realized I could use a similar approach for the ComboBox. The first part of the trick is to avoid the slick DataGridComboBoxColumn
 and use the more classic approach of embedding a ComboBox inside of a DataGridTemplateColumn. Then, leveraging the compositional nature of WPF, you can use two elements for the column just as with the DateScheduled column. The first is a TextBlock to display
 values and the second is a ComboBox for editing purposes.</p>
<p><strong>Figure 4</strong>&nbsp;shows how I&rsquo;ve used them together.</p>
<p>Figure 4&nbsp;<strong>Combining a TextBlock to Display Values and a ComboBox for Editing</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>XAML</span></strong></div>
<div class="pluginEditHolderLink"><strong>Edit Script</strong></div>
<strong><span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;DataGridTemplateColumn</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;taskColumnFaster&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xaml__attr_name">Header</span>=<span class="xaml__attr_value">&quot;Task&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;100&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTemplateColumn</span>.CellTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Task}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/DataGridTemplateColumn.CellTemplate&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataGridTemplateColumn</span>.CellEditingTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;FocusManager.<span class="xaml__attr_name">FocusedElement</span>=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=&nbsp;taskCombo}&quot;</span>&nbsp;<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ComboBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;taskCombo&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;taskViewSource}}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectedItem</span>&nbsp;=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=Task}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">IsSynchronizedWithCurrentItem</span>=<span class="xaml__attr_value">&quot;False&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&lt;/DataGridTemplateColumn.CellEditingTemplate&gt;&nbsp;
<span class="xaml__tag_end">&lt;/DataGridTemplateColumn&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</strong></div>
</div>
<div class="endscriptcode"><strong>&nbsp;<span style="font-weight:normal">The TextBlock has no dependency on the restricted list, so it&rsquo;s able to display whatever value is stored in the database. However, when it&rsquo;s time to edit, the ComboBox will
 be used and entry is limited to the values in the frequencyViewSource.</span></strong></div>
<p>&nbsp;</p>
<h2>Allowing Users to Edit the ComboBox When the Cell Gets Focused</h2>
<p>Again, because the ComboBox won&rsquo;t be available until the user clicks twice in the cell, notice that I wrapped the ComboBox in a Grid to leverage the FocusManager.</p>
<p>I&rsquo;ve modified the SelectedCellsChanged method in case the user starts his new row data entry by clicking the Task cell, not by moving to the first column. The only change is that the code also checks to see if the current cell is in the Task column:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;scheduleItemsDataGrid_SelectedCellsChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;System.Windows.Controls.SelectedCellsChangedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.AddedCells.Count&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;var&nbsp;currentCell&nbsp;=&nbsp;e.AddedCells[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;header&nbsp;=&nbsp;(<span class="cs__keyword">string</span>)currentCell.Column.Header;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(currentCell.Column&nbsp;==&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;scheduleItemsDataGrid.Columns[DateScheduledColumnIndex]&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;||&nbsp;currentCell.Column&nbsp;==&nbsp;scheduleItemsDataGrid.Columns[TaskColumnIndex])&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;scheduleItemsDataGrid.BeginEdit();&nbsp;
&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:15px; font-weight:bold">Don&rsquo;t Neglect User Experience</span></div>
<p>&nbsp;</p>
<p>While we developers are building solutions, it&rsquo;s common to focus on making sure data is valid, that it&rsquo;s getting where it needs to go and other concerns. We may not even notice that we had to click twice to edit a date. But your users will quickly
 let you know if the application you&rsquo;ve written to help them get their jobs done more effectively is actually holding them back because they have to keep going back and forth from the mouse to the keyboard.</p>
<p>While the WPF data-binding features of Visual Studio 2010 are fantastic development time savers, fine-tuning the user experience for the complex data grid&mdash;especially when combining it with the equally complex DatePicker and ComboBoxes&mdash;will be
 greatly appreciated by your end users. Chances are, they won&rsquo;t even notice the extra thought you put in because it works the way they expect it&mdash;but that&rsquo;s part of the fun of our job.</p>
<hr>
<p><strong>Julie Lerman</strong>&nbsp;<em>is a Microsoft MVP, .NET mentor and consultant who lives in the hills of Vermont. You can find her presenting on data access and other Microsoft .NET topics at user groups and conferences around the world. She blogs
 at thedatafarm.com/blog and is the author of the highly acclaimed book, &ldquo;Programming Entity Framework&rdquo; (O&rsquo;Reilly Media, 2010). Follow her on Twitter at&nbsp;<a id="ctl00_MTContentSelector1_mainContentContainer_ctl14" href="http://twitter.com/julielerman">twitter.com/julielerman</a>.</em></p>
<p><em>Thanks to the following technical expert for reviewing this article:&nbsp;<strong>Varsha Mahadevan</strong></em></p>
<hr>
<p><a href="http://msdn.microsoft.com/en-us/magazine/gg749836.aspx" target="_blank"><img src="21437-gg749836.cover_lrg(en-us%2cmsdn.10).png" alt="" width="178" height="239" style="float:left; padding-right:5px"></a></p>
<p>&nbsp;</p>
<h1>MSDN Magazine : April 2011 Issue</h1>
<h3>Windows Azure</h3>
<p>Learn about Windows Azure Caching Services and Command Query Responsibility Segregation (CQRS).</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<hr style="clear:both">
<p>&nbsp;</p>
<p><img src="21431-smalllogo.png" alt="" width="197" height="84" style="float:right"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><em><strong><br>
</strong></em></p>

# Custom WPF DatePicker control
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- MVVM
## Topics
- MVVM
- WPF Data Binding
- DatePicker
## Updated
- 09/28/2014
## Description

<h1>Introduction</h1>
<p>This project provides an example of a custom DatePicker control that updates the value of a source property that is bound to its SelectedDate property directly when you enter a new date in the DatePickerTextBox.</p>
<p>When you bind the SelectedDate property of a DatePicker control in WPF to a DateTime source property and entering a new date in the TextBox using the keyboard, the source property don't actually get set until the TextBox loses focus. This behaviour happens
 even if you set the UpdateSourceTrigger property of the Binding to PropertyChanged. This custom control extends the built-in DatePicker control to solve this issue.</p>
<h1><span>Building the Sample</span></h1>
<p><em>You should be able to build the sample code in Visual Studio by just open the solution file that is included in the .zip file and compile the project. You don't need to change any settings before you run the application.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The sample code includes a WPF Control Library that contains the CustomDatePicker class and a sample WPF application that uses the custom control.</em></p>
<h1><span>Source Code Files</span></h1>
<p>The solution consists of two projects; a sample WPF application with a single window that contains a CustomDatePicker control and a TextBlock element that displays the current value of the same DateTime source property of a view model that is bound to the
 SelectedDate property of the CustomDatePicker control.</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information and explanations about the solution, see the following TechNet Wiki article:&nbsp;</em><a href="http://blog.magnusmontin.net/2014/09/28/binding-datepicker-wpf/">http://social.technet.microsoft.com/wiki/contents/articles/26908.wpfmvvm-binding-the-datepickertextbox-in-wpf.aspx</a></p>

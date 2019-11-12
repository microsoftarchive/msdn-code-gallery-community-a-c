# Commanding Code Sample using the Prism Library 5.0 for WPF
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- .NET
- XAML
## Topics
- Prism
- WPF Commanding
- Prism Commanding
## Updated
- 08/21/2014
## Description

<h1>Introduction</h1>
<p class="ppBodyText">The Commanding QuickStart sample demonstrates how to build a Windows Presentation Foundation (WPF) application that uses delegate and composite commands provided by the Prism Library to handle UI actions in a decoupled way. This is useful
 when implementing the Model-View-ViewModel (MVVM) pattern. The Prism Library also provides an implementation of the ICommand interface.</p>
<p class="ppBodyText">The Commanding QuickStart is based on a fictitious product ordering system. The main window represents a subset of a larger system. In this window, the user can place customer orders and submit them.</p>
<p class="ppBodyText">The QuickStart highlights the key implementation details of an application that uses the Delegate and Composite Command.</p>
<p class="ppBodyText">By using the <strong>DelegateCommand</strong> command, you can supply delegates for the
<strong>Execute</strong> and <strong>CanExecute</strong> methods. This means that when the
<strong>Execute</strong> or <strong>CanExecute</strong> methods are invoked on the command, the delegates you supplied are invoked.</p>
<p class="ppBodyText">A <strong>CompositeCommand</strong> is a command that has multiple child commands. A
<strong>CompositeCommand</strong> is used in the Commanding QuickStart for the <strong>
Save All</strong> button on the main toolbar. When you click the <strong>Save All</strong> button, the
<strong>SaveAllOrdersCommand</strong> composite command executes, and in consequence, all its child commands&mdash;<strong>SaveOrderCommand
</strong>commands&mdash;execute for each pending order.</p>
<p class="ppBodyText">&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p class="ppBodyText">This QuickStart requires Microsoft Visual Studio 2012 or later and the .NET Framework 4.5.1.</p>
<p class="ppProcedureStart">To build and run the MVVM QuickStart</p>
<ol>
<li>In Visual Studio, open the solution file Commanding\Commanding_Desktop.sln. </li><li>In the&nbsp;<strong>Build</strong>&nbsp;menu, click&nbsp;<strong>Rebuild Solution</strong>.
</li><li>Press F5 to run the QuickStart </li></ol>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em><em>For more information on the QuickStart, see the associated&nbsp;<a href="http://aka.ms/prism-wpf-QSCommandingDoc">documentation&nbsp;</a>on MSDN.</em></em></p>

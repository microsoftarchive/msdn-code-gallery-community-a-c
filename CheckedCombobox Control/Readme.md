# CheckedCombobox Control
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- custom controls
## Topics
- Extending Controls + Handling Events
## Updated
- 03/11/2018
## Description

<p><span style="font-size:small">This is an extended ComboBox custom control i wrote to answer a Samples Gallery request.</span><br>
<span style="font-size:small">The Combobox is extended by inheriting and setting DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable,
</span><br>
<span style="font-size:small">then overriding the OnDrawItem event and drawing a CheckBox to the left of the item's text.</span></p>
<p><span style="font-size:small">Handling the CheckBox Checked/UnChecked event is more tricky, but I achieved it by catching the ComboBox dropdown
</span><span style="font-size:small">and item highlighted (WM_CTLCOLORLISTBOX) in the extended ComboBox's WndProc, creating a NativeWindow
</span><span style="font-size:small">class, and assigning the dropdown handle to the NativeWindow, then catching the WM_LBUTTONDOWN message</span><br>
<span style="font-size:small">in the NativeWindow's WndProc. Passing the event back to the control is accomplished with RaiseEvent and
</span><span style="font-size:small">passing the event from the control back to the parent form is accomplished by raising another public event.</span></p>
<p><span style="font-size:small">I'm pleased with the way this control emulates (so to speak) the System.Windows.Forms.CheckedListBox in it's
</span><span style="font-size:small">functionality and as always it's a pleasure to be able to contribute to the Samples Gallery with an interesting
</span><span style="font-size:small">and rewarding challenge such as this...</span></p>
<p><span style="font-size:small">If you find this submission useful or helpful in any way, please take the time to rate it. Thanks...</span></p>
<p><span style="font-size:small">(zip file updated 00:15 10/01/2013)</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">Here's a fix for an issue that was pointed out to me. The CheckedComboboxItems ObservableCollection isn't working quite as i hoped it would&nbsp;(at design time), so:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Protected Overrides Sub OnCreateControl()
    MyBase.OnCreateControl()
    Dim items() As String = MyBase.Items.Cast(Of String).ToArray
    If Not items.SequenceEqual(Me.CheckedComboboxItems) Then
        MyBase.Items.Clear()
        MyBase.Items.AddRange(Me.CheckedComboboxItems.ToArray)
    End If
    isCheckedItem.AddRange(Enumerable.Repeat(False, MyBase.Items.Count))
End Sub</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnCreateControl()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnCreateControl()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;items()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">MyBase</span>.Items.Cast(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>).ToArray&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;items.SequenceEqual(<span class="visualBasic__keyword">Me</span>.CheckedComboboxItems)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Items.Clear()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Items.AddRange(<span class="visualBasic__keyword">Me</span>.CheckedComboboxItems.ToArray)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;isCheckedItem.AddRange(Enumerable.Repeat(<span class="visualBasic__keyword">False</span>,&nbsp;<span class="visualBasic__keyword">MyBase</span>.Items.Count))&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>

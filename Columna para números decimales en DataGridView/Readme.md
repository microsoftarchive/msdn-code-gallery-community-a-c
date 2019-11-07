# Columna para números decimales en DataGridView
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Controls
- Windows Forms
- DataGridView
## Topics
- User Interface
## Updated
- 05/15/2016
## Description

<h1>Introducci&oacute;n</h1>
<p>En este ejemplo muestro c&oacute;mo crear un nuevo tipo de columna para el DataGridView para introducir n&uacute;meros decimales.</p>
<p>La columna tiene dos nuevas propiedades que permiten especificar el separador de decimales y el n&uacute;mero de d&iacute;gitos decimales a mostrar.</p>
<p>&nbsp;</p>
<h1>La clase NumericGridColumn</h1>
<p>La clase NumericGridColumn define las dos nuevas propiedades y especifica el tipo de celda NumericGridCell como tipo de celda de la columna.</p>
<h1 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">    public class NumericGridColumn : DataGridViewColumn
    {
        private NumberFormatInfo _numberFormat;
        private string _decimalSeparator;
        private int _decimalDigits = -1;

        public NumericGridColumn():base (new NumericGridCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &amp;&amp;
                        !value.GetType().IsAssignableFrom(typeof(NumericGridCell)))
                    throw new InvalidCastException(&quot;Debe especificar una instancia de NumericGridCell&quot;);
                base.CellTemplate = value;
            }
        }

        [Category(&quot;Appearance&quot;)]
        public string DecimalSeparator {
            get {
                if (string.IsNullOrEmpty(_decimalSeparator))
                    return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
                else
                    return _decimalSeparator;
            }
            set
            {
                if (value.Length != 1)
                    throw new ArgumentException(&quot;El separador decimal debe ser un &uacute;nico caracter&quot;);
                _decimalSeparator = value;
            }
        }

        [Category(&quot;Appearance&quot;)]
        public int DecimalDigits {
            get
            {
                if (_decimalDigits &lt; 0)
                    return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits;
                else
                    return _decimalDigits;
            }
            set { _decimalDigits = value; }
        }

        internal NumberFormatInfo NumberFormat
        {
            get
            {
                if (_numberFormat == null)
                    _numberFormat = new NumberFormatInfo();
                _numberFormat.NumberDecimalSeparator = DecimalSeparator;
                _numberFormat.NumberDecimalDigits = DecimalDigits;
                return _numberFormat;
            }
        }

        public override object Clone()
        {
            NumericGridColumn newColumn = (NumericGridColumn)base.Clone();
            newColumn.DecimalSeparator = DecimalSeparator;
            newColumn.DecimalDigits = DecimalDigits;
            return newColumn;
        }

    }
</pre>
<pre class="hidden">Public Class NumericGridColumn
    Inherits DataGridViewColumn

    Private _numberFormat As NumberFormatInfo
    Private _decimalSeparator As String
    Private _decimalDigits As Integer

    Public Sub New()
        MyBase.New(New NumericGridCell())
    End Sub

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(value As DataGridViewCell)
            If value IsNot Nothing AndAlso
                Not value.GetType().IsAssignableFrom(GetType(NumericGridCell)) Then
                Throw New InvalidCastException(&quot;Debe especificar una instancia de NumericGridCell&quot;)
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;)&gt;
    Public Property DecimalSeparator As String
        Get
            If String.IsNullOrEmpty(_decimalSeparator) Then
                Return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator
            Else
                Return _decimalSeparator
            End If
        End Get
        Set(ByVal value As String)
            If value.Length &lt;&gt; 1 Then
                Throw New ArgumentException(&quot;El separador decimal debe ser un &uacute;nico caracter&quot;)
            End If
            _decimalSeparator = value
        End Set
    End Property

    &lt;Category(&quot;Appearance&quot;)&gt;
    Public Property DecimalDigits As Integer
        Get
            If _decimalDigits &lt; 0 Then
                Return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits
            Else
                Return _decimalDigits
            End If
        End Get
        Set(ByVal value As Integer)
            _decimalDigits = value
        End Set
    End Property

    Friend ReadOnly Property NumberFormat As NumberFormatInfo
        Get
            If _numberFormat Is Nothing Then _numberFormat = New NumberFormatInfo()
            _numberFormat.NumberDecimalSeparator = DecimalSeparator
            _numberFormat.NumberDecimalDigits = DecimalDigits
            Return _numberFormat
        End Get
    End Property

    Public Overrides Function Clone() As Object
        Dim newColumn As NumericGridColumn = MyBase.Clone()
        newColumn.DecimalSeparator = DecimalSeparator
        newColumn.DecimalDigits = DecimalDigits
        Return newColumn
    End Function

End Class
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NumericGridColumn&nbsp;:&nbsp;DataGridViewColumn&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;NumberFormatInfo&nbsp;_numberFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;_decimalSeparator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;_decimalDigits&nbsp;=&nbsp;-<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;NumericGridColumn():<span class="cs__keyword">base</span>&nbsp;(<span class="cs__keyword">new</span>&nbsp;NumericGridCell())&nbsp;{&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;DataGridViewCell&nbsp;CellTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.CellTemplate;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;!<span class="cs__keyword">value</span>.GetType().IsAssignableFrom(<span class="cs__keyword">typeof</span>(NumericGridCell)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidCastException(<span class="cs__string">&quot;Debe&nbsp;especificar&nbsp;una&nbsp;instancia&nbsp;de&nbsp;NumericGridCell&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.CellTemplate&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Category(<span class="cs__string">&quot;Appearance&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;DecimalSeparator&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">string</span>.IsNullOrEmpty(_decimalSeparator))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_decimalSeparator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>.Length&nbsp;!=&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentException(<span class="cs__string">&quot;El&nbsp;separador&nbsp;decimal&nbsp;debe&nbsp;ser&nbsp;un&nbsp;&uacute;nico&nbsp;caracter&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_decimalSeparator&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Category(<span class="cs__string">&quot;Appearance&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DecimalDigits&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_decimalDigits&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_decimalDigits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;_decimalDigits&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;NumberFormatInfo&nbsp;NumberFormat&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_numberFormat&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_numberFormat&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NumberFormatInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_numberFormat.NumberDecimalSeparator&nbsp;=&nbsp;DecimalSeparator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_numberFormat.NumberDecimalDigits&nbsp;=&nbsp;DecimalDigits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_numberFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Clone()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NumericGridColumn&nbsp;newColumn&nbsp;=&nbsp;(NumericGridColumn)<span class="cs__keyword">base</span>.Clone();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newColumn.DecimalSeparator&nbsp;=&nbsp;DecimalSeparator;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newColumn.DecimalDigits&nbsp;=&nbsp;DecimalDigits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;newColumn;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</h1>
<p>Las propiedades DecimalSeparator y DecimalDigits permiten establecer el separador decimal y el n&uacute;mero de d&iacute;gitos decimales respectivamente.</p>
<p>La propiedad interna NumberFormat devuelve un objeto NumberFormatInfo con el formato n&uacute;merico a utilizar en la columna.&nbsp;</p>
<h1>La clase NumericGridCell</h1>
<p>La clase NumericGridCell define el funcionamiento de la celda.</p>
<p>A trav&eacute;s del evento KeyPress del control de edici&oacute;n comprueba que &uacute;nicamente se puedan introducir caracteres correspondientes a d&iacute;gitos o al separador decimal.</p>
<p>Es la responsable tambi&eacute;n de formatear el valor num&eacute;rico para ajustarse al formato especificado.</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">    public class NumericGridCell: DataGridViewTextBoxCell
    {
        public NumericGridCell() : base() { }

        private NumberFormatInfo NumberFormat
        {
            get
            {
                return ((NumericGridColumn)OwningColumn).NumberFormat;
            }
        }

        public override Type ValueType
        {
            get { return typeof(decimal?); }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                object defaultValue = base.DefaultNewRowValue;
                if (defaultValue is decimal)
                    return defaultValue;
                else
                    return null;
            }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            Control ctl = DataGridView.EditingControl;
            ctl.KeyPress &#43;= new KeyPressEventHandler(NumericCell_KeyPress);
        }

        private void NumericCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currentCell = ((IDataGridViewEditingControl)sender).EditingControlDataGridView.CurrentCell;
            if (!(currentCell is NumericGridCell)) return;

            DataGridViewTextBoxEditingControl ctl = (DataGridViewTextBoxEditingControl)sender;
            if (char.IsDigit(e.KeyChar))
            {
                int separatorPosition = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator);
                if (separatorPosition &gt;= 0 &amp;&amp; ctl.SelectionStart&gt;separatorPosition)
                {
                    int currentDecimals = ctl.Text.Length - separatorPosition 
                        - NumberFormat.NumberDecimalSeparator.Length - ctl.SelectionLength;
                    if (currentDecimals &gt;= NumberFormat.NumberDecimalDigits)
                        e.Handled = true;
                }
            }
            else if (e.KeyChar.ToString().Equals(NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator) &gt;= 0;                
            }
            else
            {
                e.Handled = !char.IsControl(e.KeyChar);
            }
        }

        public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle inheritedCellStyle, int rowIndex, bool includeColors)
        {
            DataGridViewCellStyle style= base.GetInheritedStyle(inheritedCellStyle, rowIndex, includeColors);
            style.FormatProvider = NumberFormat;
            return style;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
                return null;
            else
                return ((decimal)value).ToString(cellStyle.FormatProvider);
        }

    }
</pre>
<pre class="hidden">Public Class NumericGridCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    Private ReadOnly Property NumberFormat As NumberFormatInfo
        Get
            Return CType(OwningColumn, NumericGridColumn).NumberFormat
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(Decimal?)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Dim defaultValue As Object = MyBase.DefaultNewRowValue
            If TypeOf defaultValue Is Decimal Then
                Return defaultValue
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As Control = DataGridView.EditingControl
        AddHandler ctl.KeyPress, AddressOf NumericCell_KeyPress
    End Sub

    Private Sub NumericCell_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim currentCell As DataGridViewCell =
            CType(sender, IDataGridViewEditingControl).EditingControlDataGridView.CurrentCell
        If TypeOf currentCell IsNot NumericGridCell Then Return

        Dim ctl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
        If Char.IsDigit(e.KeyChar) Then
            Dim separatorPosition As Integer = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator)
            If separatorPosition &gt;= 0 AndAlso ctl.SelectionStart &gt; separatorPosition Then
                Dim currentDecimals = ctl.Text.Length - separatorPosition _
                    - NumberFormat.NumberDecimalSeparator.Length - ctl.SelectionLength
                If currentDecimals &gt;= NumberFormat.NumberDecimalDigits Then
                    e.Handled = True
                End If
            End If
        ElseIf e.KeyChar.ToString().Equals(NumberFormat.NumberDecimalSeparator) Then
            e.Handled = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator) &gt;= 0
        Else
            e.Handled = Not Char.IsControl(e.KeyChar)
        End If
    End Sub

    Public Overrides Function GetInheritedStyle(inheritedCellStyle As DataGridViewCellStyle, rowIndex As Integer, includeColors As Boolean) As DataGridViewCellStyle
        Dim style As DataGridViewCellStyle = MyBase.GetInheritedStyle(inheritedCellStyle, rowIndex, includeColors)
        style.FormatProvider = NumberFormat
        Return style
    End Function

    Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter, context As DataGridViewDataErrorContexts) As Object
        If value Is Nothing Then
            Return Nothing
        Else
            Return CType(value, Decimal).ToString(cellStyle.FormatProvider)
        End If
    End Function

End Class
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NumericGridCell:&nbsp;DataGridViewTextBoxCell&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;NumericGridCell()&nbsp;:&nbsp;<span class="cs__keyword">base</span>()&nbsp;{&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;NumberFormatInfo&nbsp;NumberFormat&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;((NumericGridColumn)OwningColumn).NumberFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Type&nbsp;ValueType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">decimal</span>?);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;DefaultNewRowValue&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;defaultValue&nbsp;=&nbsp;<span class="cs__keyword">base</span>.DefaultNewRowValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(defaultValue&nbsp;<span class="cs__keyword">is</span>&nbsp;<span class="cs__keyword">decimal</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;defaultValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InitializeEditingControl(<span class="cs__keyword">int</span>&nbsp;rowIndex,&nbsp;<span class="cs__keyword">object</span>&nbsp;initialFormattedValue,&nbsp;DataGridViewCellStyle&nbsp;dataGridViewCellStyle)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.InitializeEditingControl(rowIndex,&nbsp;initialFormattedValue,&nbsp;dataGridViewCellStyle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Control&nbsp;ctl&nbsp;=&nbsp;DataGridView.EditingControl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctl.KeyPress&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeyPressEventHandler(NumericCell_KeyPress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;NumericCell_KeyPress(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyPressEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewCell&nbsp;currentCell&nbsp;=&nbsp;((IDataGridViewEditingControl)sender).EditingControlDataGridView.CurrentCell;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!(currentCell&nbsp;<span class="cs__keyword">is</span>&nbsp;NumericGridCell))&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewTextBoxEditingControl&nbsp;ctl&nbsp;=&nbsp;(DataGridViewTextBoxEditingControl)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">char</span>.IsDigit(e.KeyChar))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;separatorPosition&nbsp;=&nbsp;ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(separatorPosition&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>&nbsp;&amp;&amp;&nbsp;ctl.SelectionStart&gt;separatorPosition)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;currentDecimals&nbsp;=&nbsp;ctl.Text.Length&nbsp;-&nbsp;separatorPosition&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;NumberFormat.NumberDecimalSeparator.Length&nbsp;-&nbsp;ctl.SelectionLength;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(currentDecimals&nbsp;&gt;=&nbsp;NumberFormat.NumberDecimalDigits)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.KeyChar.ToString().Equals(NumberFormat.NumberDecimalSeparator))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator)&nbsp;&gt;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;!<span class="cs__keyword">char</span>.IsControl(e.KeyChar);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;DataGridViewCellStyle&nbsp;GetInheritedStyle(DataGridViewCellStyle&nbsp;inheritedCellStyle,&nbsp;<span class="cs__keyword">int</span>&nbsp;rowIndex,&nbsp;<span class="cs__keyword">bool</span>&nbsp;includeColors)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewCellStyle&nbsp;style=&nbsp;<span class="cs__keyword">base</span>.GetInheritedStyle(inheritedCellStyle,&nbsp;rowIndex,&nbsp;includeColors);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style.FormatProvider&nbsp;=&nbsp;NumberFormat;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;style;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;GetFormattedValue(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;<span class="cs__keyword">int</span>&nbsp;rowIndex,&nbsp;<span class="cs__keyword">ref</span>&nbsp;DataGridViewCellStyle&nbsp;cellStyle,&nbsp;TypeConverter&nbsp;valueTypeConverter,&nbsp;TypeConverter&nbsp;formattedValueTypeConverter,&nbsp;DataGridViewDataErrorContexts&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;((<span class="cs__keyword">decimal</span>)<span class="cs__keyword">value</span>).ToString(cellStyle.FormatProvider);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<p>Los m&eacute;todos GetInheritedStyle y GetFormattedValue son los responsables de establecer el formato de los valores de las celdas cuando no se encuentra en modo de edici&oacute;n.</p>
<p>&nbsp;</p>
<h1>M&aacute;s informaci&oacute;n</h1>
<p>Se puede obtener una descripci&oacute;n m&aacute;s detallada del ejemplo en los art&iacute;culos:</p>
<p><a href="http://pildorasdotnet.blogspot.com/2015/11/datagridview-columna-numeros-decimales.html">DataGridView. Columna para n&uacute;meros con decimales (I)</a></p>
<p><a href="http://pildorasdotnet.blogspot.com/2015/12/datagridview-celda-numeros-decimales.html">DataGridView. Columna para n&uacute;meros con decimales (y II)</a></p>

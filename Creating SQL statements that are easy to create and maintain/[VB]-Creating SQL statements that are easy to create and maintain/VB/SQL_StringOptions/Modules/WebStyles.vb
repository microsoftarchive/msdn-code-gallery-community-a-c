''' <summary>
''' An attempt to cover most browsers to provide a gradient background for
''' the ViewStatements form web browser.
''' </summary>
''' <remarks>
''' Only have IE to test from
''' </remarks>
Module WebStyles
    Public Function Button1Style() As String
        Return _
            <T>
body{
background: #008800;
background: -moz-linear-gradient(top, #FFFFFF #90EE90);
background: -webkit-gradient(linear,  left top, left bottom, from(#FFFFFF), to(#90EE90);
filter: progid:DXImageTransform.Microsoft.Gradient(  StartColorStr='#FFFFFF', EndColorStr='#90EE90', GradientType=0); }                                           
            </T>.Value
    End Function
    Public Function Button2Style() As String
        Return _
            <T>
body{
background: #008800;
background: -moz-linear-gradient(top, #FFFFFF #FFFF00);
background: -webkit-gradient(linear,  left top, left bottom, from(#FFFFFF), to(#FFFF00);
filter: progid:DXImageTransform.Microsoft.Gradient(  StartColorStr='#FFFFFF', EndColorStr='#FFFF00', GradientType=0); }                                
            </T>.Value
    End Function
    Public Function Button3Style() As String
        Return _
            <T>
body{
background: #008800;
background: -moz-linear-gradient(top, #FFFFFF #666666);
background: -webkit-gradient(linear,  left top, left bottom, from(#FFFFFF), to(#666666);
filter: progid:DXImageTransform.Microsoft.Gradient(  StartColorStr='#FFFFFF', EndColorStr='#666666', GradientType=0); }
            </T>.Value
    End Function
    Public Function Button4Style() As String
        Return _
            <T>
body{
background: #008800;
background: -moz-linear-gradient(top, #FFFFFF #CC3300);
background: -webkit-gradient(linear,  left top, left bottom, from(#CC3300), to(#FFFF00);
filter: progid:DXImageTransform.Microsoft.Gradient(  StartColorStr='#FFFFFF', EndColorStr='#CC3300', GradientType=0); }
            </T>.Value
    End Function
    Public Function Button5Style() As String
        Return _
            <T>
body{
background: #008800;
background: -moz-linear-gradient(top, #FFFFFF #FF99CC);
background: -webkit-gradient(linear,  left top, left bottom, from(#FFFFFF), to(#FF99CC);
filter: progid:DXImageTransform.Microsoft.Gradient(  StartColorStr='#FFFFFF', EndColorStr='#FF99CC', GradientType=0); }
            </T>.Value
    End Function
End Module

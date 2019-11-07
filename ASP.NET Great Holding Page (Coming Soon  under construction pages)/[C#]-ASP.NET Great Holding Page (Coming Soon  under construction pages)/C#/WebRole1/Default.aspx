<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/HoldingPage.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebRole1._Default" %>



<asp:Content ID="Headstuff" runat="server" ContentPlaceHolderID="head">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <title>CCS LABS: Coming Soon</title>
  
    <!--[if IE 8]><script src="http://ie7-js.googlecode.com/svn/version/2.0(beta)/IE8.js" type="text/javascript"></script><![endif]-->

    <style fprolloverstyle>A:hover {color: #000}
a  {text-decoration:none;
            text-align: right;
            color: #000000;
        }
</style>



    <style type="text/css">
        .centered
        {
            text-align: left;
            
        }
        .style1
        {
            width: 100%;
            height: 100%;
        }
        .style2
        {
    }
    .alignleft
    {
        font-family: "Bradley Hand ITC";
        color: #FFFFFF;
    }
    .style3
    {
        font-family: "Bodoni MT Black";
        color: #FFFFFF;
    }
        .style5
        {
            color: Black;
            float:right;
            font-size: x-small;
            
        }
        .style6
        {
            color: #FFFFFF;
        }
        .style7
        {
            width: 40%;
        }
        .style8
        {
            color: #FFFFFF;
            text-align: left;
        }
    .style9
    {
        font-family: Fixedsys;
        color: #FFFFFF;
        font-size: larger;
    }
    .style10
    {
        color: #000000;
    }
    </style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <body>
    <div id="wrapper" style="height:auto">
        <!-- #wrapper -->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="aniTimer" runat="server" Interval="10000" OnTick="aniTimer_Tick">
        </asp:Timer>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                
                 
                    <table class="style1">
                        <tr>
                            <td style="text-align: center" class="style2" colspan="2">
                                </h1>
                                <h1>
                                    <span class="style9">CCS LABS DIGITAL FORENSICS AND COPYRIGHT MANAGEMENT </span>
                                    <br class="style9" />
                                    <span class="style9">IS COMING SOON</span></h1>
                                </h1></td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <img src="/holding/images/under_wraps2.gif"  class="alignleft" alt="image of a hole in the web site - showing the source code underneath."/></td>
                            <td>
                               
                                <% if (subText1.Text.Length > 0)
                                   {%>
                                    
                                        <h2>
                                            <asp:Label ID="subText1" runat="server" CssClass="alignleft" 
                                                Text="Coming very soon"></asp:Label>
                                   </h2>
                                    <br />
                                   
                                 <%  } %>
                                    
                                  
                                   <ul>
                                       <% if (subText2.Text.Length > 0)
                                   {%>
                                       <li>
                                           <asp:Label ID="subText2" runat="server" CssClass="style3" 
                                               text="21st Century Digital Forensics"></asp:Label>
                                           <br />
                                       </li>
                                       <%  } %><% if (subText3.Text.Length > 0)
                                   {%>
                                       <li>
                                           <asp:Label ID="subText3" runat="server" 
                                               text="21st Century Copyright Management" CssClass="style3"></asp:Label>
                                           <br />
                                       </li>
                                       <%  } %><% if (subText4.Text.Length > 0)
                                   {%>
                                       <li>
                                           <asp:Label ID="subText4" runat="server" 
                                               Text="21st Century Online Criminal Activity Reporting" CssClass="style3"></asp:Label>
                                       </li>
                                       <%  } %>
                                   </ul>
                                   
                                      
                                      
                                 </td>
                                 
                        </tr>
                        <tr>
                            <td class="style8" colspan="2" >
                                <span class="style10">Email:</span><a href="mailto:admin@ccs-labs.com"> </a>
                                <span class="style6"><a href="mailto:admin@ccs-labs.com">Administration</a></span></td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <h6>
                                    ©Copyright 2012 CCS LABS
                                </h6>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton2" runat="server" 
                                    PostBackUrl="~/Account/Login.aspx"><span class="style5">All Rights Reserved </span></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                 
                
               
            </ContentTemplate>
         
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="aniTimer" EventName="Tick" />
                
            </Triggers>
        </asp:UpdatePanel>
      
    </div>
    </body>
</asp:Content>

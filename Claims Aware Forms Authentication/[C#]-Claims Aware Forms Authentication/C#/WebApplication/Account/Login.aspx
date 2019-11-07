<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%:Page.Title %>.</h1>
        <h2>Enter your user name and password below.</h2>
    </hgroup>
    
    <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
        <LayoutTemplate>
            <p class="validation-summary-errors">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset>
                <legend>Log in Form</legend>
                <ol>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                             CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                    </li>
                    <li>
                        <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                             CssClass="field-validation-error" ErrorMessage="The password field is required." />--%>
                    </li>
                    <li>
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                    </li>
                </ol>
                <asp:Button runat="server" CommandName="Login" Text="Log in" />
            </fieldset>
        </LayoutTemplate>
    </asp:Login>
    <p>
        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink> if you don't have an account.
    </p>
</asp:Content>
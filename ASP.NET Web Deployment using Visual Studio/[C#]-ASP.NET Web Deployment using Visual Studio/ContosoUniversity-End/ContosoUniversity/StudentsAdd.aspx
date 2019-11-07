<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsAdd.aspx.cs" Inherits="ContosoUniversity.StudentsAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Students</h2> 
    <asp:ObjectDataSource ID="StudentsObjectDataSource" runat="server"
        TypeName="ContosoUniversity.BLL.SchoolBL" InsertMethod="InsertStudent" 
        DataObjectTypeName="ContosoUniversity.DAL.Student" > 
    </asp:ObjectDataSource> 
    <asp:DetailsView ID="StudentsDetailsView" runat="server" 
        DataSourceID="StudentsObjectDataSource" AutoGenerateRows="False"
        DefaultMode="Insert"> 
        <Fields> 
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" 
                SortExpression="FirstMidName" /> 
            <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                SortExpression="LastName" /> 
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" 
                SortExpression="EnrollmentDate" /> 
            <asp:CommandField ShowInsertButton="True" /> 
       </Fields> 
    </asp:DetailsView> 
</asp:Content>

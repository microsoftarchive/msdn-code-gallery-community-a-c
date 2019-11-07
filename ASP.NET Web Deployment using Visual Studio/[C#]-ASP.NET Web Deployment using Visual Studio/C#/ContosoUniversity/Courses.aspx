<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="ContosoUniversity.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Courses by Department</h2>
    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" TypeName="ContosoUniversity.BLL.SchoolBL"
        SelectMethod="GetDepartments" DataObjectTypeName="ContosoUniversity.DAL.Department">
    </asp:ObjectDataSource>
    Select a department:
    <asp:DropDownList ID="DepartmentsDropDownList" runat="server" DataSourceID="DepartmentsObjectDataSource"
        DataTextField="Name" DataValueField="DepartmentID" AutoPostBack="True">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="CoursesObjectDataSource" runat="server"  
        TypeName="ContosoUniversity.BLL.SchoolBL"  
        DataObjectTypeName="ContosoUniversity.DAL.Course"  
        SelectMethod="GetCoursesByDepartment" UpdateMethod="UpdateCourse" DeleteMethod="DeleteCourse"
        OnDeleted="CoursesObjectDataSource_Deleted"  
        OnUpdated="CoursesObjectDataSource_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="DepartmentsDropDownList" Name="DepartmentID" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <asp:ValidationSummary ID="CoursesValidationSummary" runat="server"  
        ShowSummary="true" DisplayMode="BulletList" style="color: Red; width: 40em;"  />
    <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CourseID,Title,Credits,DepartmentID"
        DataSourceID="CoursesObjectDataSource" >
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UpdateCredits.aspx" >Update Credits</asp:HyperLink>

</asp:Content>

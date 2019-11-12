<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Courses.aspx.cs" Inherits="ContosoUniversity.Courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Courses by Department</h2>
    <asp:EntityDataSource ID="DepartmentsEntityDataSource" runat="server" ContextTypeName="ContosoUniversity.DAL.SchoolEntities"
        EnableFlattening="false" EntitySetName="Departments" Select="it.[DepartmentID], it.[Name]">
    </asp:EntityDataSource>
    Select a department:
    <asp:DropDownList ID="DepartmentsDropDownList" runat="server" DataSourceID="DepartmentsEntityDataSource"
        DataTextField="Name" DataValueField="DepartmentID" AutoPostBack="True">
    </asp:DropDownList>
    <asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" ContextTypeName="ContosoUniversity.DAL.SchoolEntities"
        EnableFlattening="false" AutoGenerateWhereClause="True" EntitySetName="Courses"
        Where="">
        <WhereParameters>
            <asp:ControlParameter ControlID="DepartmentsDropDownList" Name="DepartmentID" PropertyName="SelectedValue"
                Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <br />
    <br />
    <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID"
        DataSourceID="CoursesEntityDataSource">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" ReadOnly="True" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
        </Columns>
    </asp:GridView>
    <h2>
        Courses by Name</h2>
    Enter a course name
    <asp:TextBox ID="SearchTextBox" runat="server" AutoPostBack="true"></asp:TextBox>
    &nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" />
    <br />
    <br />
    <asp:EntityDataSource ID="SearchEntityDataSource" runat="server" ContextTypeName="ContosoUniversity.DAL.SchoolEntities"
        EnableFlattening="False" EntitySetName="Courses" Include="Department">
    </asp:EntityDataSource>
    <asp:QueryExtender ID="SearchQueryExtender" runat="server" TargetControlID="SearchEntityDataSource">
        <asp:SearchExpression SearchType="StartsWith" DataFields="Title">
            <asp:ControlParameter ControlID="SearchTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression DataField="Department.Name" Direction="Ascending">
            <asp:ThenBy DataField="Title" Direction="Ascending" />
        </asp:OrderByExpression>
    </asp:QueryExtender>
    <asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID"
        DataSourceID="SearchEntityDataSource" AllowPaging="true">
        <Columns>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CourseID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" />
        </Columns>
    </asp:GridView>
</asp:Content>

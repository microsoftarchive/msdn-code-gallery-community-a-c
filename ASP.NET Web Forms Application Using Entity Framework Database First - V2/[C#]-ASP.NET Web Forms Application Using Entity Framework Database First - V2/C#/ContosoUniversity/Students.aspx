<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Students.aspx.cs" Inherits="ContosoUniversity.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Student List</h2>
    <asp:EntityDataSource ID="StudentsEntityDataSource" runat="server" ContextTypeName="ContosoUniversity.DAL.SchoolEntities"
        EnableFlattening="False" EntitySetName="People" EntityTypeFilter="Student" EnableDelete="True"
        EnableUpdate="True" Include="StudentGrades" OrderBy="it.LastName">
    </asp:EntityDataSource>
    <asp:GridView ID="StudentsGridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="StudentsEntityDataSource">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="Name" SortExpression="LastName">
                <EditItemTemplate>
                    <asp:DynamicControl ID="LastNameTextBox" runat="server" DataField="LastName" Mode="Edit" />
                    <asp:DynamicControl ID="FirstNameTextBox" runat="server" DataField="FirstMidName"
                        Mode="Edit" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DynamicControl ID="LastNameLabel" runat="server" DataField="LastName" Mode="ReadOnly" />,
                    <asp:DynamicControl ID="FirstNameLabel" runat="server" DataField="FirstMidName" Mode="ReadOnly" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="EnrollmentDate" HeaderText="Enrollment Date" SortExpression="EnrollmentDate" />
            <asp:TemplateField HeaderText="Number of Courses">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentGrades.Count") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ID="StudentsValidationSummary" runat="server" ShowSummary="true"
    DisplayMode="BulletList" Style="color: Red" />
    <h2>
        Find Students by Name</h2>
    Enter any part of the name
    <asp:TextBox ID="SearchTextBox" runat="server" AutoPostBack="true"></asp:TextBox>
    &nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" />
    <br />
    <br />
    <asp:EntityDataSource ID="SearchEntityDataSource" runat="server" ContextTypeName="ContosoUniversity.DAL.SchoolEntities"
        EnableFlattening="False" EntitySetName="People" EntityTypeFilter="Student" Where="it.FirstMidName Like '%' + @StudentName + '%' or it.LastName Like '%' + @StudentName + '%'">
        <WhereParameters>
            <asp:ControlParameter ControlID="SearchTextBox" Name="StudentName" PropertyName="Text"
                Type="String" DefaultValue="%" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="PersonID"
        DataSourceID="SearchEntityDataSource" AllowPaging="true">
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="LastName">
                <ItemTemplate>
                    <asp:DynamicControl ID="LastNameLabel" runat="server" DataField="LastName" Mode="ReadOnly" />,
                    <asp:DynamicControl ID="FirstNameLabel" runat="server" DataField="FirstMidName" Mode="ReadOnly" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="EnrollmentDate" HeaderText="Enrollment Date" SortExpression="EnrollmentDate" />
            <asp:TemplateField HeaderText="Number of Courses">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("StudentGrades.Count") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

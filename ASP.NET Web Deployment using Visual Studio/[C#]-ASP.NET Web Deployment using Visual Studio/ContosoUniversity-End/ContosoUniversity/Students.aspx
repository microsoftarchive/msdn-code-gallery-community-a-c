<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ContosoUniversity.Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Student List</h2>
    <asp:ObjectDataSource ID="StudentsObjectDataSource" runat="server" 
        TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Student"
        SelectMethod="GetStudents" SortParameterName="sortExpression"
        DeleteMethod="DeleteStudent" UpdateMethod="UpdateStudent">
    </asp:ObjectDataSource>
    <asp:GridView ID="StudentsGridView" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="StudentsObjectDataSource">
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
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Enrollments.Count") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ID="StudentsValidationSummary" runat="server" ShowSummary="true"
    DisplayMode="BulletList" Style="color: Red" />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StudentsAdd.aspx" >Add Student</asp:HyperLink>
</asp:Content>

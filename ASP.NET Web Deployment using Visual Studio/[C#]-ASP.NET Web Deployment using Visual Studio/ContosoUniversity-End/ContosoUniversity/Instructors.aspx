<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructors.aspx.cs" Inherits="ContosoUniversity.Instructors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Instructors</h2>
    <div style="float: left; margin-right: 20px;">
        <asp:ObjectDataSource ID="InstructorsObjectDataSource" runat="server"
            TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Instructor"
            SelectMethod="GetInstructors" UpdateMethod="UpdateInstructor"></asp:ObjectDataSource>
        <asp:GridView ID="InstructorsGridView" runat="server" AllowPaging="True" AllowSorting="False"
            AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="InstructorsObjectDataSource"
            OnSelectedIndexChanged="InstructorsGridView_SelectedIndexChanged"
            SelectedRowStyle-BackColor="LightGray"
            OnRowUpdating="InstructorsGridView_RowUpdating">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="Name" SortExpression="LastName">
                    <ItemTemplate>
                        <asp:Label ID="InstructorLastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>, 
                <asp:Label ID="InstructorFirstNameLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="InstructorLastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' Width="7em"></asp:TextBox>
                        <asp:TextBox ID="InstructorFirstNameTextBox" runat="server" Text='<%# Bind("FirstMidName") %>' Width="7em"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hire Date" SortExpression="HireDate">
                    <ItemTemplate>
                        <asp:Label ID="InstructorHireDateLabel" runat="server" Text='<%# Eval("HireDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="InstructorHireDateTextBox" runat="server" Text='<%# Bind("HireDate", "{0:d}") %>' Width="7em"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Birth Date" SortExpression="BirthDate">
                    <ItemTemplate>
                        <asp:Label ID="InstructorBirthDateLabel" runat="server" Text='<%# Eval("BirthDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="InstructorBirthDateTextBox" runat="server" Text='<%# Bind("BirthDate", "{0:d}") %>'
                            Width="7em"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Office Assignment" SortExpression="OfficeAssignment.Location">
                    <ItemTemplate>
                        <asp:Label ID="InstructorOfficeLabel" runat="server" Text='<%# Eval("OfficeAssignment.Location") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="InstructorOfficeTextBox" runat="server"
                            Text='<%# Eval("OfficeAssignment.Location") %>' Width="7em"
                            OnInit="InstructorOfficeTextBox_Init"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="LightGray"></SelectedRowStyle>
        </asp:GridView>
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false"></asp:Label>
        <h3>Courses Taught</h3>
        <asp:ObjectDataSource ID="CoursesObjectDataSource" runat="server" TypeName="ContosoUniversity.BLL.SchoolBL"
            DataObjectTypeName="ContosoUniversity.DAL.Course" SelectMethod="GetCoursesByInstructor">
            <SelectParameters>
                <asp:ControlParameter ControlID="InstructorsGridView" Name="PersonID" PropertyName="SelectedDataKey.Value"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="CoursesGridView" runat="server" DataSourceID="CoursesObjectDataSource"
            AllowSorting="True" AutoGenerateColumns="False" SelectedRowStyle-BackColor="LightGray"
            DataKeyNames="CourseID">
            <EmptyDataTemplate>
                <p>No courses found.</p>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:TemplateField HeaderText="Department" SortExpression="DepartmentID">
                    <ItemTemplate>
                        <asp:Label ID="GridViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Instructors.aspx.cs" Inherits="ContosoUniversity.Instructors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Instructors</h2>
    <div style="float: left; margin-right: 20px;">
        <asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
            ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
            EntitySetName="People" EntityTypeFilter="Instructor"
            Include="OfficeAssignment" EnableUpdate="True">
        </asp:EntityDataSource>
        <asp:GridView ID="InstructorsGridView" runat="server" AllowPaging="True" AllowSorting="True"
    AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="InstructorsEntityDataSource"
    OnSelectedIndexChanged="InstructorsGridView_SelectedIndexChanged" 
    SelectedRowStyle-BackColor="LightGray" 
    onrowupdating="InstructorsGridView_RowUpdating"> 
    <Columns> 
        <asp:CommandField ShowSelectButton="True" ShowEditButton="True" /> 
        <asp:TemplateField HeaderText="Name" SortExpression="LastName"> 
            <ItemTemplate> 
                <asp:Label ID="InstructorLastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>, 
                <asp:Label ID="InstructorFirstNameLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label> 
            </ItemTemplate> 
            <EditItemTemplate> 
                <asp:TextBox ID="InstructorLastNameTextBox" runat="server" Text='<%# Bind("FirstMidName") %>' Width="7em"></asp:TextBox> 
                <asp:TextBox ID="InstructorFirstNameTextBox" runat="server" Text='<%# Bind("LastName") %>' Width="7em"></asp:TextBox> 
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
        <asp:TemplateField HeaderText="Office Assignment" SortExpression="OfficeAssignment.Location"> 
            <ItemTemplate> 
                <asp:Label ID="InstructorOfficeLabel" runat="server" Text='<%# Eval("OfficeAssignment.Location") %>'></asp:Label> 
            </ItemTemplate> 
            <EditItemTemplate> 
                <asp:TextBox ID="InstructorOfficeTextBox" runat="server" 
                Text='<%# Eval("OfficeAssignment.Location") %>' Width="7em" 
                oninit="InstructorOfficeTextBox_Init"></asp:TextBox> 
            </EditItemTemplate> 
        </asp:TemplateField> 
    </Columns> 
    <SelectedRowStyle BackColor="LightGray"></SelectedRowStyle> 
</asp:GridView> 
<asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false" ViewStateMode="Disabled"></asp:Label> 
<h3>Courses Taught</h3> 
<asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" 
    ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
    EntitySetName="Courses" 
    Where="@PersonID IN (SELECT VALUE instructor.PersonID FROM it.People AS instructor)"> 
    <WhereParameters> 
        <asp:ControlParameter ControlID="InstructorsGridView" Type="Int32" Name="PersonID" PropertyName="SelectedValue" /> 
    </WhereParameters> 
</asp:EntityDataSource>
<asp:GridView ID="CoursesGridView" runat="server" 
    DataSourceID="CoursesEntityDataSource"
    AllowSorting="True" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor="LightGray" 
    DataKeyNames="CourseID"> 
    <EmptyDataTemplate> 
        <p>No courses found.</p> 
    </EmptyDataTemplate> 
    <Columns> 
        <asp:CommandField ShowSelectButton="True" /> 
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
    <div> 
    <h3>Course Details</h3> 
    <asp:EntityDataSource ID="CourseDetailsEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="Courses"
        AutoGenerateWhereClause="False" Where="it.CourseID = @CourseID" Include="Department,OnlineCourse,OnsiteCourse,StudentGrades.Person"
        OnSelected="CourseDetailsEntityDataSource_Selected"> 
        <WhereParameters> 
            <asp:ControlParameter ControlID="CoursesGridView" Type="Int32" Name="CourseID" PropertyName="SelectedValue" /> 
        </WhereParameters> 
    </asp:EntityDataSource> 
    <asp:DetailsView ID="CourseDetailsView" runat="server" AutoGenerateRows="False"
        DataSourceID="CourseDetailsEntityDataSource"> 
        <EmptyDataTemplate> 
            <p> 
                No course selected.</p> 
        </EmptyDataTemplate> 
        <Fields> 
            <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" /> 
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" /> 
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" /> 
            <asp:TemplateField HeaderText="Department"> 
                <ItemTemplate> 
                    <asp:Label ID="DetailsViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Location"> 
                <ItemTemplate> 
                    <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("OnsiteCourse.Location") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="URL"> 
                <ItemTemplate> 
                    <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("OnlineCourse.URL") %>'></asp:Label> 
                </ItemTemplate> 
            </asp:TemplateField> 
        </Fields> 
    </asp:DetailsView> 
    <h3>Student Grades</h3> 
<asp:ListView ID="GradesListView" runat="server"> 
    <EmptyDataTemplate> 
        <p>No student grades found.</p> 
    </EmptyDataTemplate> 
    <LayoutTemplate> 
        <table border="1" runat="server" id="itemPlaceholderContainer"> 
            <tr id="Tr1" runat="server"> 
                <th id="Th1" runat="server"> 
                    Name 
                </th> 
                <th id="Th2" runat="server"> 
                    Grade 
                </th> 
            </tr> 
            <tr id="itemPlaceholder" runat="server"> 
            </tr> 
        </table> 
    </LayoutTemplate> 
    <ItemTemplate> 
        <tr> 
            <td> 
                <asp:Label ID="StudentLastNameLabel" runat="server" Text='<%# Eval("Person.LastName") %>' />, 
                <asp:Label ID="StudentFirstNameLabel" runat="server" Text='<%# Eval("Person.FirstMidName") %>' /> 
            </td> 
            <td> 
                <asp:Label ID="StudentGradeLabel" runat="server" Text='<%# Eval("Grade") %>' /> 
            </td> 
        </tr> 
    </ItemTemplate> 
</asp:ListView>
</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="ContosoUniversity.Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Departments</h2> 
     Enter any part of the name or leave the box blank to see all names: 
    <asp:TextBox ID="SearchTextBox" runat="server" AutoPostBack="true"></asp:TextBox> 
    &nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" />
    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server"  
        TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Department"  
        SelectMethod="GetDepartmentsByName" DeleteMethod="DeleteDepartment" UpdateMethod="UpdateDepartment" 
        ConflictDetection="CompareAllValues" OldValuesParameterFormatString="orig{0}"  
        OnUpdated="DepartmentsObjectDataSource_Updated" SortParameterName="sortExpression"  
        OnDeleted="DepartmentsObjectDataSource_Deleted" > 
        <SelectParameters> 
            <asp:ControlParameter ControlID="SearchTextBox" Name="nameSearchString" PropertyName="Text" 
                Type="String" /> 
        </SelectParameters> 
    </asp:ObjectDataSource>
    <asp:ValidationSummary ID="DepartmentsValidationSummary" runat="server"  
        ShowSummary="true" DisplayMode="BulletList" style="color: Red; width: 40em;"  />
    <asp:GridView ID="DepartmentsGridView" runat="server" AutoGenerateColumns="False" 
        DataSourceID="DepartmentsObjectDataSource"  
        DataKeyNames="DepartmentID,Name,Budget,StartDate,Administrator"  
        OnRowUpdating="DepartmentsGridView_RowUpdating" 
        OnRowDataBound="DepartmentsGridView_RowDataBound" 
        AllowSorting="True" >
        <Columns> 
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" 
                ItemStyle-VerticalAlign="Top"> 
            </asp:CommandField> 
            <asp:DynamicField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-VerticalAlign="Top" /> 
            <asp:DynamicField DataField="Budget" HeaderText="Budget" SortExpression="Budget" ItemStyle-VerticalAlign="Top" /> 
            <asp:DynamicField DataField="StartDate" HeaderText="Start Date" ItemStyle-VerticalAlign="Top" /> 
            <asp:TemplateField HeaderText="Administrator" SortExpression="Person.LastName" ItemStyle-VerticalAlign="Top" > 
                <ItemTemplate> 
                    <asp:Label ID="AdministratorLastNameLabel" runat="server" Text='<%# Eval("Person.LastName") %>'></asp:Label>, 
                    <asp:Label ID="AdministratorFirstNameLabel" runat="server" Text='<%# Eval("Person.FirstMidName") %>'></asp:Label> 
                </ItemTemplate> 
                <EditItemTemplate> 
                    <asp:ObjectDataSource ID="InstructorsObjectDataSource" runat="server" DataObjectTypeName="ContosoUniversity.DAL.InstructorName" 
                        SelectMethod="GetInstructorNames" TypeName="ContosoUniversity.BLL.SchoolBL"> 
                    </asp:ObjectDataSource> 
                    <asp:DropDownList ID="InstructorsDropDownList" runat="server" DataSourceID="InstructorsObjectDataSource" 
                        SelectedValue='<%# Eval("Administrator")  %>' 
                        DataTextField="FullName" DataValueField="PersonID" OnInit="DepartmentsDropDownList_Init" > 
                    </asp:DropDownList> 
                </EditItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Courses"> 
                <ItemTemplate> 
                    <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False"> 
                        <Columns> 
                            <asp:BoundField DataField="CourseID" HeaderText="ID" /> 
                            <asp:BoundField DataField="Title" HeaderText="Title" /> 
                        </Columns> 
                    </asp:GridView> 
                </ItemTemplate> 
            </asp:TemplateField>        </Columns> 
    </asp:GridView>
</asp:Content>

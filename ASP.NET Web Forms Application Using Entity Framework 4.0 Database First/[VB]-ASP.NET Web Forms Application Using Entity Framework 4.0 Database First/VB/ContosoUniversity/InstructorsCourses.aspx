<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InstructorsCourses.aspx.vb" Inherits="ContosoUniversity.InstructorsCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Assign Instructors to Courses or Remove from Courses</h2>
	<br />
	<asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
		ContextTypeName="ContosoUniversity.SchoolEntities" EnableFlattening="False" 
		EntitySetName="People" EntityTypeFilter="Instructor"
		Select="it.LastName + ', ' + it.FirstMidName AS Name, it.PersonID">
	</asp:EntityDataSource>
	Select an Instructor:
	<asp:DropDownList ID="InstructorsDropDownList" runat="server" DataSourceID="InstructorsEntityDataSource"
		AutoPostBack="true" DataTextField="Name" DataValueField="PersonID">
	</asp:DropDownList>
	<h3>
		Assign a Course</h3>
	<br />
	Select a Course:
	<asp:DropDownList ID="UnassignedCoursesDropDownList" runat="server" DataTextField="Title"
		DataValueField="CourseID">
	</asp:DropDownList>
	<br />
	<asp:Button ID="AssignCourseButton" runat="server" Text="Assign"/>
	<br />
	<asp:Label ID="CourseAssignedLabel" runat="server" Visible="false" Text="Assignment successful"></asp:Label>
	<br />
	<h3>
		Remove a Course</h3>
	<br />
	Select a Course:
	<asp:DropDownList ID="AssignedCoursesDropDownList" runat="server" DataTextField="title"
		DataValueField="courseiD">
	</asp:DropDownList>
	<br />
	<asp:Button ID="RemoveCourseButton" runat="server" Text="Remove"/>
	<br />
	<asp:Label ID="CourseRemovedLabel" runat="server" Visible="false" Text="Removal successful"></asp:Label>
</asp:Content>
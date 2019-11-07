<%@ Page Title="About Us" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="About.aspx.vb" Inherits="ContosoUniversity.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>Student Body Statistics</h2>
	<asp:EntityDataSource ID="StudentStatisticsEntityDataSource" runat="server" 
		ContextTypeName="ContosoUniversity.SchoolEntities" EnableFlattening="False" 
		EntitySetName="People" EntityTypeFilter="Student"
		GroupBy="it.EnrollmentDate" OrderBy="it.EnrollmentDate" 
		Select="it.EnrollmentDate, Count(it.EnrollmentDate) AS NumberOfStudents">
	</asp:EntityDataSource>
	<asp:GridView ID="StudentStatisticsGridView" runat="server" AutoGenerateColumns="False" 
	DataSourceID="StudentStatisticsEntityDataSource"> 
	<Columns> 
		<asp:BoundField DataField="EnrollmentDate" DataFormatString="{0:d}" 
			HeaderText="Date of Enrollment" 
			ReadOnly="True" SortExpression="EnrollmentDate" /> 
		<asp:BoundField DataField="NumberOfStudents" HeaderText="Students" 
			ReadOnly="True" SortExpression="NumberOfStudents" /> 
	</Columns> 
</asp:GridView>
</asp:Content>
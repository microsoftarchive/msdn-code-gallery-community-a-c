<%@ Page  Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="articles.aspx.cs" Inherits="WebApplication1.Admin.articles" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<form id="form1" runat="server">
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
		BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
		CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
		EmptyDataText="There are no data records to display." GridLines="Horizontal">
		<AlternatingRowStyle BackColor="#F7F7F7" />
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
				SortExpression="ID" />
			<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
			<asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
				SortExpression="CategoryID" />
			<asp:BoundField DataField="MenuName" HeaderText="MenuName" 
				SortExpression="MenuName" />
			<asp:BoundField DataField="MenuNumber" HeaderText="MenuNumber" 
				SortExpression="MenuNumber" />
			<asp:BoundField DataField="SubTitle" HeaderText="SubTitle" 
				SortExpression="SubTitle" />
			<asp:BoundField DataField="MainBody" HeaderText="MainBody" 
				SortExpression="MainBody" />
			<asp:BoundField DataField="Footer" HeaderText="Footer" 
				SortExpression="Footer" />
			<asp:CheckBoxField DataField="Published" HeaderText="Published" 
				SortExpression="Published" />
		</Columns>
		<FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
		<HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
		<PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
		<RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
		<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
		<SortedAscendingCellStyle BackColor="#F4F4FD" />
		<SortedAscendingHeaderStyle BackColor="#5A4C9D" />
		<SortedDescendingCellStyle BackColor="#D8D8F0" />
		<SortedDescendingHeaderStyle BackColor="#3E3277" />
	</asp:GridView>
	<br />
    <asp:Panel ID="Panel1" runat="server" class="width_half">
    <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
	<asp:TextBox ID="tbTitle" runat="server" Width="304px"></asp:TextBox>
&nbsp;
	<asp:Label ID="Category" runat="server" Text="Title"></asp:Label>
	<asp:ListBox ID="lbCategory" runat="server" DataSourceID="SqlDataSource2" 
		DataTextField="CategoryName" DataValueField="CategoryName" Height="21px">
	</asp:ListBox>
	<br />
	<asp:Label ID="Label2" runat="server" Text="Menu Name"></asp:Label>
	<asp:TextBox ID="tbMenuName" runat="server" Width="304px"></asp:TextBox>
&nbsp;&nbsp;
	<asp:Label ID="tbMenuPosition" runat="server" Text="Menu Position"></asp:Label>
	<asp:TextBox ID="tbTitle1" runat="server" Width="109px"></asp:TextBox>
	<br />
	<asp:Label ID="Label4" runat="server" Text="Sub Title"></asp:Label>
	<asp:TextBox ID="tbSubTitle" runat="server" Width="304px"></asp:TextBox>
	<br />
	<p>
		<CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="100%" 
            Columns="200" EnterMode="BR" Rows="25" ToolbarCanCollapse="False" 
            UseComputedState="False" Toolbar="Full">
		&lt;p&gt;This is some &lt;strong&gt;sample text&lt;/strong&gt;. You are using &lt;a href="http://ckeditor.com/"&gt;CKEditor&lt;/a&gt;.&lt;/p&gt;
		</CKEditor:CKEditorControl>
		</p>
		<p>
			<input type="submit" />
		</p>

	<br />
	<asp:Label ID="Label6" runat="server" Text="Footer"></asp:Label>
	<asp:TextBox ID="tbFooter" runat="server" Width="304px"></asp:TextBox>
	<br />
	<asp:CheckBox ID="cbPublished" runat="server" Text="Published" />
	<br />
	<asp:LinkButton ID="lbSaveArticle" runat="server" onclick="lbSaveArticle_Click">Save Article</asp:LinkButton>
	<br />
    </asp:Panel>

	
	<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
		ConnectionString="<%$ ConnectionStrings:CMSServices %>" 
		SelectCommand="SELECT [CategoryName] FROM [Categories]"></asp:SqlDataSource>
	<br />
	<br />
	<br />
	<br />
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
		ConnectionString="<%$ ConnectionStrings:cmsConnectionString1 %>" 
		DeleteCommand="DELETE FROM [Content] WHERE [ID] = @ID" 
		InsertCommand="INSERT INTO [Content] ([Title], [CategoryID], [MenuName], [MenuNumber], [SubTitle], [MainBody], [Footer], [Published]) VALUES (@Title, @CategoryID, @MenuName, @MenuNumber, @SubTitle, @MainBody, @Footer, @Published)" 
		ProviderName="<%$ ConnectionStrings:cmsConnectionString1.ProviderName %>" 
		SelectCommand="SELECT [ID], [Title], [CategoryID], [MenuName], [MenuNumber], [SubTitle], [MainBody], [Footer], [Published] FROM [Content]" 
		UpdateCommand="UPDATE [Content] SET [Title] = @Title, [CategoryID] = @CategoryID, [MenuName] = @MenuName, [MenuNumber] = @MenuNumber, [SubTitle] = @SubTitle, [MainBody] = @MainBody, [Footer] = @Footer, [Published] = @Published WHERE [ID] = @ID">
		<DeleteParameters>
			<asp:Parameter Name="ID" Type="Int32" />
		</DeleteParameters>
		<InsertParameters>
			<asp:Parameter Name="Title" Type="String" />
			<asp:Parameter Name="CategoryID" Type="Int32" />
			<asp:Parameter Name="MenuName" Type="String" />
			<asp:Parameter Name="MenuNumber" Type="String" />
			<asp:Parameter Name="SubTitle" Type="String" />
			<asp:Parameter Name="MainBody" Type="String" />
			<asp:Parameter Name="Footer" Type="String" />
			<asp:Parameter Name="Published" Type="Boolean" />
		</InsertParameters>
		<UpdateParameters>
			<asp:Parameter Name="Title" Type="String" />
			<asp:Parameter Name="CategoryID" Type="Int32" />
			<asp:Parameter Name="MenuName" Type="String" />
			<asp:Parameter Name="MenuNumber" Type="String" />
			<asp:Parameter Name="SubTitle" Type="String" />
			<asp:Parameter Name="MainBody" Type="String" />
			<asp:Parameter Name="Footer" Type="String" />
			<asp:Parameter Name="Published" Type="Boolean" />
			<asp:Parameter Name="ID" Type="Int32" />
		</UpdateParameters>
	</asp:SqlDataSource>
	</form>


</asp:Content>

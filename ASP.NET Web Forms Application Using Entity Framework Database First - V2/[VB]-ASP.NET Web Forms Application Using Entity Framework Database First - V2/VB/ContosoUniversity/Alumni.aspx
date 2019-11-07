<%@ Page Title="" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumni.aspx.vb" Inherits="ContosoUniversity.Alumni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Alumni</h2> 
	<asp:EntityDataSource ID="AlumniEntityDataSource" runat="server"  
		ContextTypeName="ContosoUniversity.AlumniAssociationModelContainer" EnableFlattening="False"  
		EntitySetName="Alumni"> 
	</asp:EntityDataSource> 
	<asp:GridView ID="AlumniGridView" runat="server"  
		DataSourceID="AlumniEntityDataSource" AutoGenerateColumns="False" 
		DataKeyNames="AlumnusId"> 
		<Columns> 
			<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" /> 
			<asp:TemplateField HeaderText="Donations"> 
				<ItemTemplate> 
					<asp:GridView ID="DonationsGridView" runat="server" AutoGenerateColumns="False"> 
						<Columns> 
							<asp:BoundField DataField="DateAndAmount" HeaderText="Date and Amount" /> 
						</Columns> 
					</asp:GridView> 
				</ItemTemplate> 
			</asp:TemplateField> 
		</Columns> 
	</asp:GridView>
</asp:Content>
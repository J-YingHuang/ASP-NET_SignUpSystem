<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDelete.aspx.cs" Inherits="SignUpSystem.AccountDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <br/>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" SelectCommand="SELECT [Name]  FROM [Account]" DataTextField="Name" DataValueField="Name" >
       <asp:ListItem Selected="True">請選擇</asp:ListItem>
  
        </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name] FROM [Account]"></asp:SqlDataSource>
    <br/>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name], [Username], [Password], [Phone], [Email], [SchoolID], [IsVegetarian] FROM [Account]"></asp:SqlDataSource>

</asp:Content>

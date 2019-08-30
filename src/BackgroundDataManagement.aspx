<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    </br>
    </br>
<img src="images/square_add.png"  class="img-responsive" />
   
&nbsp;<div class="alert alert-info" role="alert">
       
 

        <asp:GridView AlternatingRowStyle-Css Class="col" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="SchoolID" HeaderText="SchoolID" SortExpression="SchoolID" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Username], [Password], [Name], [Phone], [Email], [SchoolID] FROM [Account]"></asp:SqlDataSource>
       
 
 
    </div>
   
        <asp:Button type="button" ID="btn_Export" runat="server" class="float-right btn btn-outline-info" Text="匯出Excel"/>
   

    
    <br/>
    <br/>
    <br/>
</asp:Content>

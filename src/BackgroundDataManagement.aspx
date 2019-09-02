<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="myListDropDown_Change">
        <asp:ListItem Value="0">EarthquakeTeam</asp:ListItem>
        <asp:ListItem Value="1">BridgeTeam</asp:ListItem>
        <asp:ListItem Value="2">FilmInfo</asp:ListItem>
         <asp:ListItem Value="3">Account</asp:ListItem>
    </asp:DropDownList>
    <div>
        <asp:GridView id="GridView1" method="post" runat="server" >
           <Columns>
               <asp:CommandField ShowDeleteButton="True" />
               <asp:CommandField ShowEditButton="True" />
            </Columns>
                </asp:GridView>
    </div>




    <asp:Button type="button" ID="btn_Export" runat="server" class="float-right btn btn-outline-info" Text="匯出Excel" />



    <br />
    <br />
    <br />
</asp:Content>

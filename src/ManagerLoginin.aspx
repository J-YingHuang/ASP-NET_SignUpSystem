<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerLoginin.aspx.cs" Inherits="SignUpSystem.ManagerLoginin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </br>
     </br>
     </br>
    <div class="alert alert-danger" role="alert">
        <div class="col">
            <h4 class="alert-heading">ManagerLogin</h4>
            <hr>
            <form>
                <div class="form-group">
                    <label class="col-2" for="inputemail">Account Name: </label>

                    <input type="text" class="form-control-label" id="account_name" placeholder="username" runat="server">
                    <div class="form-group">
                        <label class="col-2" for="inputemail">password: </label>

                        <input type="password" class="form-control-label" id="Text1" placeholder="password" runat="server">
                        <label id="serch_email" class="form-text text-muted smail" runat="server"></label>
                    </div>

                    <asp:Button id="btn_MangerLogin" type="button" class="btn btn-primary" runat="server" OnClick="btn_MangerLogin_Click" Text="Login" />
                    <div class="row">
            <div class="col-md-12">
                <label id="loginSession" runat="server"></label>
                     
                    <form>
    </br>

        


</asp:Content>


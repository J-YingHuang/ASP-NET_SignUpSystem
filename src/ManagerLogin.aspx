<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerLogin.aspx.cs" Inherits="SignUpSystem.ManagerLoginin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    </br>
    </br>
    <div class="alert alert-danger" role="alert">
        <div class="col">
            <h4 class="alert-heading">Manager Login</h4>
            <hr>
            <form>
                <div class="form-group">
                    <div class="row">
                        <div class="col-4"></div>
                        <label class="col-2 text-left" for="inputemail">Account Name: </label>
                        <div class="col-6">
                            <input type="text" class="form-control" id="account_name" placeholder="username" runat="server">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>

                        <label class="col-2 text-left" for="inputemail">password: </label>
                        <div class="col-6">
                            <input type="password" class="form-control" id="Text1" placeholder="password" runat="server">
                        </div>
                    </div>
                    <div class="row">
                        <label id="serch_email" class="form-text text-muted smail" runat="server"></label>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>
                        <asp:Button ID="btn_MangerLogin" type="button" class="btn btn-secondary col-4" runat="server" OnClick="btn_MangerLogin_Click" Text="Login" />
                        <div class="col-4"></div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label id="loginSession" runat="server"></label>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    </br>
    </br>
    </br>
</asp:Content>


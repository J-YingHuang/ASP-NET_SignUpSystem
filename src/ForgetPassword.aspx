<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="SignUpSystem.ForgetPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />

    <div class="alert alert-secondary" role="alert">
        <div class="col">
            <h4 class="alert-heading">忘記密碼</h4>
            <hr>

            <form>
                <div class="form-group row">
                    <div class="col-3"></div>
                    <label class="col-2 col-form-label" for="inputemail">Email address: </label>

                    <input type="text" class="form-control col-4" id="email_name" placeholder="Email..." runat="server">
                    <div class="col-3"></div>
                </div>
                <label id="serch_email" class="form-text text-muted smail" runat="server"></label>
                <asp:Button ID="btn_CheckEmail" type="button" class="btn btn-outline-info" runat="server" OnClick="btn_SendEmail_Click" Text="寄送密碼" />

                </form>
                    <br />
        </div>
    </div>
    <br />

</asp:Content>


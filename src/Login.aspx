<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SignUpSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <h3>國立高雄科技大學</h3>
                <h3>2019 第15屆抗震盃報名系統</h3>
                <br />
                <p>請登入或註冊帳號以便進行後續報名相關手續</p>
                <hr width="50%" />
                <br />
            </div>
        </div>
        <div class="row d-flex justify-content-center">
            <div class="col col-sm-12 col-md-12 col-lg-10 col-xl-4">
                <form class="d-flex justify-content-center">
                    <div class="form-group row">
                        <label for="staticEmail" class="col-sm-3 col-form-label text-left">Account</label>
                        <div class="col-sm-9">
                            <input type="text" class="form-control" id="account" placeholder="Username or Email" runat="server">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="inputPassword" class="col-sm-3 col-form-label text-left">Password</label>
                        <div class="col-sm-9">
                            <input type="password" class="form-control" id="password" placeholder="Password" runat="server">
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-12">
                            <asp:Button ID="btn_Login" runat="server" Text="Login" Width="100%" CssClass="btn btn-outline-secondary" OnClick="btn_Login_Click" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm" style="font-size: 12px;">                                                   
                            <a href="#" Id="btn_ForgetPassword" style="color: dimgray;" runat="server" onserverclick="btn_ForgetPassword_Click">
                                忘記密碼
                            </a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <label id="loginSession" runat="server"></label>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

            </div>

        </div>


    </div>



</asp:Content>




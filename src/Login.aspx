
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SignUpSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <br /><br /><br /><br /><br /><br /><br />
                <h3>國立高雄科技大學</h3>
                <h3>2019 第15屆抗震盃報名系統</h3>
                <br />
                <p>請登入或註冊帳號以便進行後續報名相關手續</p>
                <hr width="50%" />
                <br />
            </div>
        </div>
        <div class="row d-flex justify-content-center">
            <div class="col col-sm-12 col-md-12 col-lg-10 col-xl-4" >
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
                        <div class="col-sm-12" style="font-size: 12px;">
                            <a class="btn btn-outline-light btn-sm" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">
                                註冊  
                            </a>
                            |
                            <a class="btn btn-outline-light btn-sm"  data-toggle="modal" data-target="#exampleModal2">
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
                <br /><br /><br /><br /><br /><br />
            </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">首次登入</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        
          <div class="form-group">
            <label for="AccountName" class="col-form-label">Account:</label>
            <input type="text" class="form-control" id="AccountNname" runat="server">
          </div>
          <div class="form-group">
            <label for="PasswordText" class="col-form-label">Password:</label>
            <input type="text" class="form-control" id="PasswordText" runat="server">
          </div>
          <div class="form-group">
            <label for="EmailName" class="col-form-label">Email:</label>
            <input type="text" class="form-control" id="EmailName" runat="server">
          </div>
      
      </div>
      <div class="modal-footer">
        
        <button ID="btn_Sendmessage" type="button" class="btn btn-primary">Send message</button>
      </div>
    </div>
  </div>
</div>

  <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel2">忘記密碼</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        請至信箱領取密碼
      </div>
      <div class="modal-footer">
        
        <button type="button" class="btn btn-primary">Back</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>

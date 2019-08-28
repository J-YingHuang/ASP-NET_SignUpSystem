<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="SignUpSystem.ForgetPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     </br>
     </br>
     </br>

    <div class="container">
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <h2>忘記密碼</h2>
                <div class="row d-flex justify-content-center">
                    <div class="col col-sm-12 col-md-12 col-lg-10 col-xl-4">
                        <form class="d-flex justify-content-center">
                             </br>
                             </br>
                            <div class="form-group row">
                                <label for="staticEmail" class="col-sm-3 col-form-label text-left">Email:</label>
                                <div class="col-sm-9">
                                    <input type="text" class="form-control" id="email_name" placeholder="Your Email" runat="server">
                                </div>

                                <div class="row">
                                    <div class="col-md">
                                        <label id="serch_email" runat="server"></label>
                                    </div>
                                </div>
                        </form>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-12">
                            <button id="btn_CheckEmail" type="button" class="btn btn-primary" runat="server" onserverclick="btn_SendEmail_Click">Send Email</button>
                        </div>
                         </div>
                        </br>
                     </div>
                        
                     </div>
              </div>

</asp:Content>


﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="SignUpSystem.ForgetPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    </br>
     </br>
     </br>

    <div class="alert alert-secondary" role="alert">
        <div class="col">
            <h4 class="alert-heading">忘記密碼</h4>
            <hr>

            <form>
                <div class="form-group">
                    <label for="inputemail">Email address:</label>
                    <input type="text" class="form-control-label" id="email_name" placeholder="Your Email" runat="server">
                     <label  id = "serch_email" class="form-text text-muted smail" runat= "server"  > </label>
                </div>

                <button id="btn_CheckEmail" type="button" class="btn btn-primary" runat="server" onserverclick="btn_SendEmail_Click">Send Email</button>
             <form>
                </br>

        
        </div>
    </div>
    </br>
            </div>
    </div>
              </div>

</asp:Content>


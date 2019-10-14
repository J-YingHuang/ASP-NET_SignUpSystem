<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountAddin.aspx.cs" Inherits="SignUpSystem.AccountAddin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="form-group">
        <br />
        <label for="UsernameInput">Username</label>
        <input class="form-control" id="UsernameInput" type="text" runat="server">
        <label for="PasswordInput">Password</label>
        <input class="form-control" type="password" id="PasswordInput" runat="server">
        <label for="NameInput">Name</label>
        <input class="form-control" id="NameInput" type="text" runat="server">
        <label for="PhoneInput">Phone</label>
        <input class="form-control" id="PhoneInput" type="text" runat="server">
        <label for="EmailInput">Email</label>
        <input class="form-control" type="text" id="EmailInput" runat="server">
        <div class="form-group">
            <label for="DropDownList1">校名</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>

            <button id="AddSchool" type="button" class="  btn btn-secondary" data-toggle="modal" data-target="#exampleModal" data-whatever="+">+ </button>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">新增學校</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                    <div class="modal-body">
                        <div class="form-group ">

                            <label for="School_name" class="col-form-label">校名:</label>
                            <input type="text" class="form-control" id="School_name" runat="server">
                        </div>
                        <div class="form-group ">
                            <label for="Address" class="col-form-label">地址:</label>
                            <input type="text" class="form-control" id="Address" runat="server">
                        </div>
                        <div class="form-group ">
                            <label for="Area" class="col-form-label">區域:</label>
                            <input type="text" class="form-control" id="Area" runat="server">
                        </div>

                        <div class="form-group">
                            <label class="col-form-label" id="lab_Message" runat="server"></label>
                        </div>



                        <div id="MemberInfo" runat="server"></div>

                        <div class="modal-footer">
                            <asp:Button type="button" class="btn btn-secondary" Text="新增" runat="server" OnClick="btn_AddSchool_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="form-check form-check-inline">
        <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1" runat="server">
        <label class="form-check-label" for="inlineRadio1">葷</label>
    </div>
    <div class="form-check form-check-inline">
        <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
        <label class="form-check-label" for="inlineRadio2">素</label>
    </div>
    <asp:Button ID="btn_Save" type="button" class=" float-right btn btn-secondary"style="margin-bottom:10px;" runat="server" OnClick="btn_Save_Click" Text="Save" />
    <asp:Button ID="btn_Return" type="button" class="float-right btn btn-secondary" style="margin-right:10px; margin-bottom:10px;" runat="server" Onclick="btn_Return_Click" Text="回上一頁" />





</asp:Content>

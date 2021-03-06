﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountDelete.aspx.cs" Inherits="SignUpSystem.AccountDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <br />
        <br />

    </div>
    <div class="col-md-9">
        <h4>Account
                    
        </h4>
        <hr />
        <label for="Select_School">學校</label>
        <asp:DropDownList ID="Select_School" runat="server" AutoPostBack="true" class="form-control">
        </asp:DropDownList>
        <hr />
        <div class="card text-center">
            <div class="card-header">
                <ul class="nav nav-tabs card-header-tabs">
                    <li class="nav-item" id="card_">
                        <a id="Bridge" class="nav-link active" href="#" style="color: dimgray" runat="server">帳戶資料</a>
                    </li>
                </ul>
            </div>
            <div class="card-body">

                <div class="col-12">
                    <div id="div1" runat="server"></div>

                </div>
                <asp:Button ID="Button1" runat="server" Text="回上一頁" class="float-right btn btn-secondary" OnClick="Button1_Click" />
            </div>
        </div>
    </div>

    <div class="modal fade" id="TeamView" tabindex="-1" role="dialog" aria-labelledby="UpdateModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UpdateModal">變更資訊</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>



                <div class="modal-body">

                    <div class="form-group row">
                        <div class="col-sm-1"></div>
                        <label class="col-sm-4 col-form-label ">Name：</label>
                        <div class="col-sm-1">
                            <label class="col-sm-4 col-form-label" id="Div2" runat="server"></label>
                        </div>


                        <div id="MemberInfo" runat="server"></div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                    </div>
                </div>
            </div>





        </div>
    </div>


</asp:Content>

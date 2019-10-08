<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BridgeModify.aspx.cs" Inherits="SignUpSystem.BridgeModify_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <br />
        <br />

    </div>
    <div class="col-md-9">
        <h4>BridgeTeam
        </h4>
        <hr />
         <label for="Select_School">學校</label>
                <asp:DropDownList class="form-control" ID="Select_School" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select_School_SelectedIndexChanged">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>
         <hr />
        <div class="card text-center">
            <div class="card-header">
                <ul class="nav nav-tabs card-header-tabs">
                    <li class="nav-item" id="card_">
                        <a id="Bridge" class="nav-link active" href="#" style="color: dimgray" runat="server">橋梁變變變</a>
                    </li>
                </ul>
            </div>

            <div class="card-body">
                <div class="row">
                </div>
                <div class="row">
                    <div class="col-12">
                        <div id="div1" runat="server"></div>
                    </div>
                </div>
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
                        <div class="col-sm-2"></div>
                        <label class="col-sm-4 col-form-label ">Name：</label>
                        <div class="col-sm-2">
                            <label class="col-sm-4 col-form-label" id="Div2" runat="server"></label>
                        </div>

                    </div>
                    <div id="MemberInfo" runat="server"></div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>


                    </div>
                </div>
            </div>
        </div>
    </div>









</asp:Content>

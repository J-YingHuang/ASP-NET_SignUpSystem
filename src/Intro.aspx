<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Intro.aspx.cs" Inherits="SignUpSystem.Intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container h-100">
        <div class="row">
            <br />
            <br />
            <br />
            <br />

        </div>
        <div class="row">
            <div class="col-md-3">
                <h4>帳戶資訊</h4>
                <hr />
                <p>姓名：</p>
                <p id="user_Name" style="color: darkgray" runat="server"></p>
                <p>學校：</p>
                <p id="user_School" style="color: darkgray" runat="server"></p>
                <p>聯絡電話：</p>
                <p id="user_Phone" style="color: darkgray" runat="server"></p>
                <p>聯絡信箱：</p>
                <p id="user_Email" style="color: darkgray" runat="server"></p>
                <button type="button" class="btn btn-outline-secondary" width="100%" data-toggle="modal" data-target="#UpdateModal"> 
                    更改帳戶資訊
                </button>
                <%--                <p style="text-align: right;" id="earthquakeStute" runat="server">123</p>
                <% if (Session["Login"].ToString() == "Y")
                    {%>
                <p>前往報名</p>
                <a class="btn btn-default" href=""><img /></a>
                <%  }
                    else {%>

                <%  }%>--%>
            </div>
            <div class="col-md-9">
                <h4>參賽隊伍
                </h4>
                <hr />
                <div class="card text-center">
                    <div class="card-header">
                        <ul class="nav nav-tabs card-header-tabs">
                            <li class="nav-item" id="card_">
                                <a id="a_Earthquake" class="nav-link active" href="#" style="color: dimgray" runat="server" onserverclick="a_Earthquake_Click">團隊來對震</a>
                            </li>
                            <li class="nav-item">
                                <a id="a_Bridge" class="nav-link" href="#" style="color: dimgray" runat="server" onserverclick="a_Bridge_Click">橋梁變變變</a>
                            </li>
                            <li class="nav-item">
                                <a id="a_Film" class="nav-link" href="#" tabindex="-1" aria-disabled="true" style="color: dimgray" runat="server" onserverclick="a_Film_Click">影領創視界</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12">
                                <asp:Button ID="btn_NewTeam" runat="server" CssClass="btn btn-outline-secondary float-right" Style="margin-bottom: 15px;" Text="新增隊伍" OnClick="btn_NewTeam_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div id="div_TeamInfo" runat="server"></div>
                                <%--      Cardtemplate            <div class="card">
                                    <div class="card-body" style="text-align: left;">
                                        <div class="row">
                                            <div class="col-7">
                                                <h6 style="margin-top: 5px;">隊伍名稱</h6>
                                            </div>
                                            <div class="col-5 ">

                                                <a id="edit_team1" class="btn btn-outline-secondary float-right" style="height: 32px; font-size: 12px; width: 70px;">
                                                    <img width="15px" style="margin-bottom: 4px;" src="https://img.icons8.com/ios-glyphs/64/000000/edit.png">
                                                    <span>Edit</span>
                                                </a>
                                                <a id="view_team1" class="btn btn-outline-secondary float-right" style="height: 32px; font-size: 12px; margin-right: 5px; width: 70px;">
                                                    <img width="15px" style="margin-bottom: 4px;" src="https://img.icons8.com/ios-glyphs/24/000000/visible.png">
                                                    <span>View</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <br />
            <br />
        </div>
    </div>
    <div class="modal fade" id="UpdateModal" tabindex="-1" role="dialog" aria-labelledby="UpdateModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalCenterTitle">變更帳戶資訊</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group row">
                            <div class="col-sm-1"></div>
                            <label for="updatePhone" class="col-sm-3 col-form-label float-left">連絡電話：</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control  float-left" id="updatePhone" runat="server">
                            </div>
                            <div class="col-sm-1"></div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-1"></div>
                            <label for="updateEmail" class="col-sm-3 col-form-label">聯絡信箱：</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" id="updateEmail" runat="server">
                            </div>
                            <div class="col-sm-1"></div>
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-info" data-dismiss="modal" id="btn_updateAccount" runat="server" onserverclick="Btn_updateAccount_ServerClick">儲存變更</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



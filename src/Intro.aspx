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
            <div class="col-md-3" style="text-align: left;">
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
                <button type="button" class="btn btn-outline-secondary" style="width: 100%" data-toggle="modal" data-target="#UpdateModal">
                    更改帳戶資訊
               
                </button>
                <button type="button" class="btn btn-outline-secondary" style="width: 100%; margin-top: 10px;" runat="server" onserverclick="Unnamed_ServerClick">
                    登出
               
                </button>
            </div>
            <div class="col-md-9">
                <h4>便當
                </h4>
                <hr />
                <div class="form-group row" style="font-size: 18px">
                    <div class="col">
                        <div class="col">
                            <p id="Lunch" runat="server">便當數量 (葷):   0</p>
                        </div>
                        <div class="col">
                            <p id="VegLunch" runat="server">便當數量 (素):    0</p>
                        </div>
                    </div>
                    <div class="col-1">
                        <p id="num_Lunch" runat="server"></p>
                        <p id="num_VegLunch" runat="server"></p>
                        <p id="id_Lunch" runat="server"></p>
                    </div>
                    <div class="col-3">
                        <button id="to_update_Lunch" type="button" class="btn btn-outline-secondary " style="width: 100%" data-toggle="modal" data-target="#UpdateLunch" runat="server" >
                            更改便當數量
                        </button>
                    </div>
                </div>
                <br />
                <br />
                <h4>參賽隊伍
                </h4>
                <hr />
                <div class="card text-center">
                    <div class="card-header">
                        <ul class="nav nav-tabs card-header-tabs">
                            <li class="nav-item" id="card_">
                                <a id="a_Earthquake" class="nav-link active" href="#" style="color: dimgray" runat="server" onserverclick="a_Earthquake_Click">一起來抑震</a>
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

    <%--變更帳戶資訊--%>
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
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-info" data-dismiss="modal" id="btn_updateAccount" runat="server" onserverclick="Btn_updateAccount_ServerClick">儲存變更</button>
                </div>
            </div>
        </div>
    </div>

    <%--更改便當數量--%>
    <div class="modal fade" id="UpdateLunch" tabindex="-1" aria-labelledby="UpdateLunchLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="updateLunchTitle">更改便當數量</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-sm-1"></div>
                        <label for="text_uLunch" class="col-sm-5 col-form-label float-left">便當數量（葷）：</label>
                        <div class="col-sm-5">
                            <input type="text" class="form-control  float-left" id="text_uLunch" runat="server">
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-1"></div>
                        <label for="text_uVegLunch" class="col-sm-5 col-form-label">便當數量（素）：</label>
                        <div class="col-sm-5">
                            <input type="text" class="form-control" id="text_uVegLunch" runat="server">
                        </div>
                        <div class="col-sm-1"></div>
                    </div>

                </div>
                <div class="modal-footer">

<%--                    <button type="button" class="btn btn-outline-info" data-dismiss="modal" id="btn_updateLunch" runat="server" onserverclick="Btn_Confirm_Click">儲存變更</button>--%>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="MsgBox" tabindex="-1" role="dialog" aria-labelledby="MsgBoxTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="MsgBoxTitle">隊伍組數已滿</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="MsgBox_Data" runat="server">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="TeamViewer" tabindex="-1" role="dialog" aria-labelledby="BridgeTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered  modal-lg" role="document" id="MsgBoxDia" runat="server">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="BridgeTitle">隊伍資訊</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-sm-2"></div>
                        <label class="col-sm-4 col-form-label">隊伍名稱：</label>
                        <label class="col-sm-4 col-form-label" id="lab_TeamName" runat="server"></label>
                        <div class="col-sm-2"></div>

                    </div>
                    <div id="MemberInfo" runat="server"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="Msg_AddLink" tabindex="-1" role="dialog" aria-labelledby="AddLinkTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AddLinkTitle" runat="server">作品繳交</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="FilmLink">雲端作品連結</label>
                        <input type="text" class="form-control" id="FilmLink" style="min-width: 100%;" placeholder="輸入作品雲端連結網址..." runat="server">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" id="btn_AddFilmLink" runat="server" onserverclick="btn_AddFilmLink_ServerClick">繳交</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



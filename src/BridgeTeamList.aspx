<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BridgeTeamList.aspx.cs" Inherits="SignUpSystem.BridgeTeamList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12 text-left">
                <br />
                <br />
                <h3 id="lab_Title" runat="server">橋梁變變變報名資訊</h3>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-6">
            </div>
            <div class="col-6 text-right">
                <p id="p_UpdateTime" runat="server">報名隊伍清單更新時間：2019/09/02 12:00:00</p>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="form-group">
                    <label for="select_Area">區域</label>
                    <hr style="margin-top: 0px;" color="dimGray" />
                    <asp:DropDownList class="form-control" ID="select_Area" runat="server" AutoPostBack="true" OnSelectedIndexChanged="select_Area_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="form-group">
                    <label for="select_School">學校</label>
                    <hr style="margin-top: 0px;" color="dimGray" />
                    <asp:DropDownList class="form-control" ID="select_School" runat="server" AutoPostBack="true" OnSelectedIndexChanged="select_School_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="form-group">
                    <label for="select_Teacher">指導老師</label>
                    <hr style="margin-top: 0px;" color="dimGray" />
                    <asp:DropDownList class="form-control" ID="select_Teacher" runat="server" AutoPostBack="true" OnSelectedIndexChanged="select_Teacher_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="form-group">
                    <label for="lab_Count">總報名隊數</label>
                    <hr style="margin-top: 0px;" color="dimGray" />
                    <h5 class="form-control" id="lab_Count" runat="server"></h5>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <hr color="dimGray" />
            </div>
        </div>
        <div class="row mx-auto">
            <div id="div_TeamCard"  class="card-columns"  runat="server"></div>
            <%--            <div class="col-4 text-left ">
                <div class="card w-100" style="width: 18rem; margin-bottom: 15px;">
                    <div class="card-body text-left">
                        <h5 class="card-title">I'm Team Name.</h5>
                        <h6 class="card-subtitle mb-2 text-muted">國立高雄科技大學</h6>
                        <p class="card-subtitle mb-2 text-muted">指導老師：XXX</p>
                        <a href="#" class="card-link">隊伍人數：5人</a>
                        <a href="#" class="card-link">吃素人數：3人</a>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>

</asp:Content>

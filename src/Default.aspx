<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SignUpSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>國立高雄科技大學 第十五屆 抗震大作戰</h1>
        <p class="lead">抗震大作戰 X 橋梁變變變 X 點燃拍攝魂</p>
        <p>報名開放時間：2019/09/30 (一) ~ 2019/10/14 (一)</p>
        <p><a href="Login" class="btn btn-outline-danger btn-lg">前往報名 &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>團隊來對震</h2>
            <br />
            <h5 style="text-align: left;">目前報名隊數：</h5>
            <p style="text-align: right;" id="p_Earthquake_Count" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">參與學校數目：</h5>
            <p style="text-align: right;" id="p_Earthquake_SchoolCount" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">報名資訊：</h5>
            <p style="text-align: right;">
                <a class="btn btn-default" href="EarthquakeTeamList.aspx">Read more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>橋梁變變變</h2>
            <br />
            <h5 style="text-align: left;" >目前報名隊數：</h5>
            <p style="text-align: right;" id="p_Bridge_Count" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">參與學校數目：</h5>
            <p style="text-align: right;" id="p_Birdge_SchoolCount" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">報名資訊：</h5>
            <p style="text-align: right;">
                <a class="btn btn-default" href="BridgeTeamList.aspx">Read more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>影領創視界</h2>
            <br />
            <h5 style="text-align: left;">目前報名隊數：</h5>
            <p style="text-align: right;" id="p_Film_Count" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">參與學校數目：</h5>
            <p style="text-align: right;" id="p_Film_SchoolCount" runat="server">尚未開始報名</p>
            <h5 style="text-align: left;">報名資訊：</h5>
            <p style="text-align: right;">
                <a class="btn btn-default" href="FilmTeamList.aspx">Read more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>

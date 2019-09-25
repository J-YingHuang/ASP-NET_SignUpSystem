<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     
    <asp:Button ID="btn_DataUpdate" runat="server" Text="年度資料更換"  class=" float-right btn btn-outline-info" OnClick="btn_DataUpdate_Click" />
    <p class="text-info">會員資料</p>
    
    <asp:Button ID="btn_Addin" runat="server" Text="新增"  class=" float btn btn-outline-info" OnClick="btn_Addin_Click"/>
    <asp:Button ID="btn_AccountModify" runat="server" Text="修改"  class=" float btn btn-outline-info" OnClick="btn_AccountModify_Click" />
    <asp:Button ID="btn_AccountDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="AccountDelete_Click" />
    <div/>
    <div p class="text-info" >-------------------------------------------------------</div>
    <p class="text-info">團隊來對震</p>
    <asp:Button ID="btn_EearthquakeModify" runat="server" Text="修改"  class=" float btn btn-outline-info" OnClick="btn_EearthquakeModify_Click" />
    <asp:Button ID="btn_EearthquakeDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_EearthquakeDelete_Click" />
    <div/>
    <div p class="text-info" >-------------------------------------------------------</div>
    <p class="text-info">橋梁變變變</p>
    <asp:Button ID="btn_BridgeModify" runat="server" Text="修改"  class=" float btn btn-outline-info" OnClick="btn_BridgeModify_Click" />
    <asp:Button ID="btn_BridgeDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_BridgeDelete_Click" />
    <div/>
    <div p class="text-info" >-------------------------------------------------------</div>
    <p class="text-info">影領創世界</p>
    <asp:Button ID="btn_FilmModify" runat="server" Text="修改"  class=" float btn btn-outline-info" OnClick="btn_FilmModify_Click" />
    <asp:Button ID="btn_FilmDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_FilmDelete_Click" />
        
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Intro.aspx.cs" Inherits="SignUpSystem.Intro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container h-100">
        <div class="row">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <div class="row">
            <div class="col-md-3">
                <h4 id="username" runat="server"></h4>
                <hr />
                <br />
                <p>報名狀況：</p>
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
                <h2>本次賽程
                </h2>
                <hr />
                <br />
            </div>
        </div>
        <div class="row">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>

    </div>
</asp:Content>

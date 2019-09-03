<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">EarthquakeTeam</asp:LinkButton>
    <br/>
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">BridgeTeam</asp:LinkButton>
    <br/>
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">FilmInfo</asp:LinkButton>
    <br/>

 
          <div>
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Vegetarian" HeaderText="Vegetarian" SortExpression="Vegetarian" />
                            <asp:BoundField DataField="LeaderName" HeaderText="LeaderName" SortExpression="LeaderName" />
                            <asp:BoundField DataField="PlayerName1" HeaderText="PlayerName1" SortExpression="PlayerName1" />
                            <asp:BoundField DataField="PlayerName2" HeaderText="PlayerName2" SortExpression="PlayerName2" />
                            <asp:BoundField DataField="PlayerName3" HeaderText="PlayerName3" SortExpression="PlayerName3" />
                            <asp:BoundField DataField="PlayerName4" HeaderText="PlayerName4" SortExpression="PlayerName4" />
                            <asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID" />
                            <asp:BoundField DataField="PlayerName5" HeaderText="PlayerName5" SortExpression="PlayerName5" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Count], [Name], [Vegetarian], [LeaderName], [PlayerName1], [PlayerName2], [PlayerName3], [PlayerName4], [PlayerName5], [AccountID] FROM [EarthquakeTeam]"></asp:SqlDataSource>

                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                            <asp:BoundField DataField="Vegetarian" HeaderText="Vegetarian" SortExpression="Vegetarian" />
                            <asp:BoundField DataField="LeaderName" HeaderText="LeaderName" SortExpression="LeaderName" />
                            <asp:BoundField DataField="PlayerName1" HeaderText="PlayerName1" SortExpression="PlayerName1" />
                            <asp:BoundField DataField="PlayerID1" HeaderText="PlayerID1" SortExpression="PlayerID1" />
                            <asp:BoundField DataField="PlayerName2" HeaderText="PlayerName2" SortExpression="PlayerName2" />
                            <asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID" />
                            <asp:BoundField DataField="LeaderID" HeaderText="LeaderID" SortExpression="LeaderID" />
                            <asp:BoundField DataField="PlayerID4" HeaderText="PlayerID4" SortExpression="PlayerID4" />
                            <asp:BoundField DataField="PlayerID3" HeaderText="PlayerID3" SortExpression="PlayerID3" />
                            <asp:BoundField DataField="PlayerName4" HeaderText="PlayerName4" SortExpression="PlayerName4" />
                            <asp:BoundField DataField="PlayerName3" HeaderText="PlayerName3" SortExpression="PlayerName3" />
                            <asp:BoundField DataField="PlayerID2" HeaderText="PlayerID2" SortExpression="PlayerID2" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name], [Count], [Vegetarian], [LeaderName], [PlayerName1], [PlayerID1], [PlayerName2], [AccountID], [LeaderID], [PlayerID4], [PlayerID3], [PlayerName4], [PlayerName3], [PlayerID2] FROM [BridgeTeam]"></asp:SqlDataSource>

                </asp:View>

                <asp:View ID="View3" runat="server">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="DesignConcept" HeaderText="DesignConcept" SortExpression="DesignConcept" />
                            <asp:BoundField DataField="Outline" HeaderText="Outline" SortExpression="Outline" />
                            <asp:BoundField DataField="FileLink" HeaderText="FileLink" SortExpression="FileLink" />
                            <asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>

                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name], [DesignConcept], [Outline], [FileLink], [AccountID] FROM [FilmInfo]"></asp:SqlDataSource>
                </asp:View>
            </asp:MultiView>
        </div>
    



    <asp:Button type="button" ID="btn_Export" runat="server" class="float-right btn btn-outline-info" Text="匯出Excel" />



    <br />
    <br />
    <br />
</asp:Content>

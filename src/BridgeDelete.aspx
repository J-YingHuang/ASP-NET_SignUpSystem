<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BridgeDelete.aspx.cs" Inherits="SignUpSystem.BridgeDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-3">
            <div class="form-group">
                <label for="select_Name">查詢</label>
                <asp:DropDownList class="form-control" ID="select_Name" runat="server" AutoPostBack="true" OnSelectedIndexChanged="select_Name_SelectedIndexChanged">
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList>

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDeleteing="GridView1_RowDeleteing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                        <asp:BoundField DataField="Vegetarian" HeaderText="Vegetarian" SortExpression="Vegetarian" />
                        <asp:BoundField DataField="LeaderName" HeaderText="LeaderName" SortExpression="LeaderName" />
                        <asp:BoundField DataField="LeaderID" HeaderText="LeaderID" SortExpression="LeaderID" />
                        <asp:BoundField DataField="LeaderBirthday" HeaderText="LeaderBirthday" SortExpression="LeaderBirthday" />
                        <asp:BoundField DataField="PlayerName1" HeaderText="PlayerName1" SortExpression="PlayerName1" />
                        <asp:BoundField DataField="PlayerID1" HeaderText="PlayerID1" SortExpression="PlayerID1" />
                        <asp:BoundField DataField="PlayerBirthday1" HeaderText="PlayerBirthday1" SortExpression="PlayerBirthday1" />
                        <asp:BoundField DataField="PlayerName2" HeaderText="PlayerName2" SortExpression="PlayerName2" />
                        <asp:BoundField DataField="PlayerID2" HeaderText="PlayerID2" SortExpression="PlayerID2" />
                        <asp:BoundField DataField="PlayerBirthday2" HeaderText="PlayerBirthday2" SortExpression="PlayerBirthday2" />
                        <asp:BoundField DataField="PlayerName3" HeaderText="PlayerName3" SortExpression="PlayerName3" />
                        <asp:BoundField DataField="PlayerID3" HeaderText="PlayerID3" SortExpression="PlayerID3" />
                        <asp:BoundField DataField="PlayerBirthday3" HeaderText="PlayerBirthday3" SortExpression="PlayerBirthday3" />
                        <asp:BoundField DataField="PlayerName4" HeaderText="PlayerName4" SortExpression="PlayerName4" />
                        <asp:BoundField DataField="PlayerID4" HeaderText="PlayerID4" SortExpression="PlayerID4" />
                        <asp:BoundField DataField="PlayerBirthday4" HeaderText="PlayerBirthday4" SortExpression="PlayerBirthday4" />
                        <asp:BoundField DataField="SecondTeacher" HeaderText="SecondTeacher" SortExpression="SecondTeacher" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>




                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name], [Count], [Vegetarian], [LeaderName], [LeaderID], [LeaderBirthday], [PlayerName1], [PlayerID1], [PlayerBirthday1], [PlayerName2], [PlayerID2], [PlayerBirthday2], [PlayerName3], [PlayerID3], [PlayerBirthday3], [PlayerName4], [PlayerID4], [PlayerBirthday4], [SecondTeacher] FROM [BridgeTeam] "  
                    DeleteCommand="DELETE FROM[Bridge] WHERE  [Name]=@name AND [Count]=@count AND [Vegetarian]=@vegetarian AND [LeaderName]=@leadername AND [LeaderID]=@leaderid AND [LeaderBirthday]=@lb AND [PlayName1]=@pn1 AND [PlayerID1]=@pd1 AND [PlayerBirthday1]=@pb1 AND [PlayName2]=@pn2 AND [PlayerID2]=@pd2 AND [PlayerBirthday2]=@pb2 AND [PlayName3]=@pn3 AND [PlayerID3]=@pd3 AND [PlayerBirthday3]=@pb3 AND [PlayName4]=@pn4 AND [PlayerID4]=@pd4 AND [PlayerBirthday4]=@pb4 AND [SecondTeacher]=@st">
                    <DeleteParameters>
                    </DeleteParameters>



                </asp:SqlDataSource>




            </div>
        </div>
    </div>
</asp:Content>

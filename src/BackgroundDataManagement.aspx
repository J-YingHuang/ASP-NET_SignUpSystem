<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">EarthquakeTeam</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">BridgeTeam</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">FilmInfo</asp:LinkButton>
    <br />


    <div>
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="AccountID" OnRowCommand="GridView2_RowCommand" OnRowCancelingEdit="GridView2_RowCancelingEdit"  OnRowUpdating="GridView2_RowUpdating" OnRowEditing="GridView2_RowEditing" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                    <Columns>
                       
                       
                       
                        <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Vegetarian" HeaderText="Vegetarian" SortExpression="Vegetarian" />
                        <asp:BoundField DataField="LeaderName" HeaderText="LeaderName" SortExpression="LeaderName" />
                        <asp:BoundField DataField="PlayerName1" HeaderText="PlayerName1" SortExpression="PlayerName1" />
                        <asp:BoundField DataField="PlayerName2" HeaderText="PlayerName2" SortExpression="PlayerName2" />
                        <asp:BoundField DataField="PlayerName3" HeaderText="PlayerName3" SortExpression="PlayerName3" />
                        <asp:BoundField DataField="PlayerName4" HeaderText="PlayerName4" SortExpression="PlayerName4" />
                        <asp:BoundField DataField="PlayerName5" HeaderText="PlayerName5" SortExpression="PlayerName5" />
                        <asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID" />
                        <asp:ButtonField CommandName="GridInsert" Text="新增" />
                         <asp:TemplateField ShowHeader="False">
                             <EditItemTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Update" Text="更新"></asp:LinkButton>
                                 &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                             </EditItemTemplate>
                             
                             <ItemTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                                 &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                             </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                    <EmptyDataTemplate>
                        <asp:LinkButton ID="Button4" runat="server" OnClick="Button4_Click" Text="回上一頁"></asp:LinkButton>
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
                            <Fields>
                                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"  />
                                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                                <asp:BoundField DataField="Vegetarian" HeaderText="Vegetarian" SortExpression="Vegetarian" />
                                <asp:BoundField DataField="LeaderName" HeaderText="LeaderName" SortExpression="LeaderName" />
                                <asp:BoundField DataField="PlayerName1" HeaderText="PlayerName1" SortExpression="PlayerName1" />
                                <asp:BoundField DataField="PlayerName2" HeaderText="PlayerName2" SortExpression="PlayerName2" />
                                <asp:BoundField DataField="PlayerName3" HeaderText="PlayerName3" SortExpression="PlayerName3" />
                                <asp:BoundField DataField="PlayerName5" HeaderText="PlayerName5" SortExpression="PlayerName5" />
                                <asp:BoundField DataField="PlayerName4" HeaderText="PlayerName4" SortExpression="PlayerName4" />
                                <asp:BoundField DataField="AccountID" HeaderText="AccountID" SortExpression="AccountID" />
                                <asp:TemplateField ShowHeader="False">
                                    <InsertItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Insert" Text="插入"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" Visible="False"></asp:LinkButton>
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="New" Text="新增"></asp:LinkButton>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Fields>
                        </asp:DetailsView>
                    </EmptyDataTemplate>
                                    </asp:GridView>
                <br/>
                <asp:label ID="lb1SuccessMessage" Text="" runat="server" ForeColor="Green"/>
                <br/>
                <asp:label ID="lb1ErrorMessage" Text="" runat="server" ForeColor="Red"/>

                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" ></asp:SqlDataSource>
                <asp:Button type="button" ID="btn_Export" runat="server" class="float-right btn btn-outline-info" OnClick="btn_Export_Click" Text="匯出Excel" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Id], [Name], [Count], [Vegetarian], [LeaderName], [PlayerName1], [PlayerName2], [PlayerName3], [PlayerName5], [PlayerName4], [AccountID] FROM [EarthquakeTeam]" InsertCommand="INSERT INTO [EarthquakeTeam] ([Name], [Count], [Vegetarian], [LeaderName], [PlayerName1], [PlayerName2], [PlayerName3], [PlayerName5], [PlayerName4], [AccountID]) VALUES (@Name, @Count, @Vegetarian, @LeaderName, @PlayerName1, @PlayerName2, @PlayerName3, @PlayerName5, @PlayerName4, @AccountID)"
                     UpdateCommand="UPDATE [EarthquakeTeam] SET [Name] = @Name, [Count] = @Count, [Vegetarian] = @Vegetarian, [LeaderName] = @LeaderName, [PlayerName1] = @PlayerName1, [PlayerName2] = @PlayerName2, [PlayerName3] = @PlayerName3, [PlayerName5] = @PlayerName5, [PlayerName4] = @PlayerName4, [AccountID] = @AccountID WHERE [Id] = @original_Id AND [Name] = @original_Name AND [Count] = @original_Count AND [Vegetarian] = @original_Vegetarian AND [LeaderName] = @original_LeaderName AND [PlayerName1] = @original_PlayerName1 AND (([PlayerName2] = @original_PlayerName2) OR ([PlayerName2] IS NULL AND @original_PlayerName2 IS NULL)) AND (([PlayerName3] = @original_PlayerName3) OR ([PlayerName3] IS NULL AND @original_PlayerName3 IS NULL)) AND (([PlayerName5] = @original_PlayerName5) OR ([PlayerName5] IS NULL AND @original_PlayerName5 IS NULL)) AND (([PlayerName4] = @original_PlayerName4) OR ([PlayerName4] IS NULL AND @original_PlayerName4 IS NULL)) AND [AccountID] = @original_AccountID" 
                    ConflictDetection="CompareAllValues" 
                    DeleteCommand="DELETE FROM [EarthquakeTeam] WHERE [Id] = @original_Id AND [Name] = @original_Name AND [Count] = @original_Count AND [Vegetarian] = @original_Vegetarian AND [LeaderName] = @original_LeaderName AND [PlayerName1] = @original_PlayerName1 AND (([PlayerName2] = @original_PlayerName2) OR ([PlayerName2] IS NULL AND @original_PlayerName2 IS NULL)) AND (([PlayerName3] = @original_PlayerName3) OR ([PlayerName3] IS NULL AND @original_PlayerName3 IS NULL)) AND (([PlayerName5] = @original_PlayerName5) OR ([PlayerName5] IS NULL AND @original_PlayerName5 IS NULL)) AND (([PlayerName4] = @original_PlayerName4) OR ([PlayerName4] IS NULL AND @original_PlayerName4 IS NULL)) AND [AccountID] = @original_AccountID" 
                    OldValuesParameterFormatString="original_{0}">
                    <DeleteParameters>
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Name" Type="String" />
                        <asp:Parameter Name="original_Count" Type="Int32" />
                        <asp:Parameter Name="original_Vegetarian" Type="Int32" />
                        <asp:Parameter Name="original_LeaderName" Type="String" />
                        <asp:Parameter Name="original_PlayerName1" Type="String" />
                        <asp:Parameter Name="original_PlayerName2" Type="String" />
                        <asp:Parameter Name="original_PlayerName3" Type="String" />
                        <asp:Parameter Name="original_PlayerName5" Type="String" />
                        <asp:Parameter Name="original_PlayerName4" Type="String" />
                        <asp:Parameter Name="original_AccountID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Count" Type="Int32" />
                        <asp:Parameter Name="Vegetarian" Type="Int32" />
                        <asp:Parameter Name="LeaderName" Type="String" />
                        <asp:Parameter Name="PlayerName1" Type="String" />
                        <asp:Parameter Name="PlayerName2" Type="String" />
                        <asp:Parameter Name="PlayerName3" Type="String" />
                        <asp:Parameter Name="PlayerName5" Type="String" />
                        <asp:Parameter Name="PlayerName4" Type="String" />
                        <asp:Parameter Name="AccountID" Type="Int32" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Count" Type="Int32" />
                        <asp:Parameter Name="Vegetarian" Type="Int32" />
                        <asp:Parameter Name="LeaderName" Type="String" />
                        <asp:Parameter Name="PlayerName1" Type="String" />
                        <asp:Parameter Name="PlayerName2" Type="String" />
                        <asp:Parameter Name="PlayerName3" Type="String" />
                        <asp:Parameter Name="PlayerName5" Type="String" />
                        <asp:Parameter Name="PlayerName4" Type="String" />
                        <asp:Parameter Name="AccountID" Type="Int32" />
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Name" Type="String" />
                        <asp:Parameter Name="original_Count" Type="Int32" />
                        <asp:Parameter Name="original_Vegetarian" Type="Int32" />
                        <asp:Parameter Name="original_LeaderName" Type="String" />
                        <asp:Parameter Name="original_PlayerName1" Type="String" />
                        <asp:Parameter Name="original_PlayerName2" Type="String" />
                        <asp:Parameter Name="original_PlayerName3" Type="String" />
                        <asp:Parameter Name="original_PlayerName5" Type="String" />
                        <asp:Parameter Name="original_PlayerName4" Type="String" />
                        <asp:Parameter Name="original_AccountID" Type="Int32" />
                    </UpdateParameters>


                </asp:SqlDataSource>

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
                        <%--<asp:LinkButton ID="lbInsert" runat="server" Width="70px"  onclick="lbInsert_Click">新增</asp:LinkButton>--%>
                    </Columns>

                </asp:GridView>
                <asp:Button type="button" ID="Button1" runat="server" class="float-right btn btn-outline-info" OnClick="btn1_Export_Click" Text="匯出Excel" />
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
                <asp:Button type="button" ID="Button2" runat="server" class="float-right btn btn-outline-info" OnClick="btn2_Export_Click" Text="匯出Excel" />
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Name], [DesignConcept], [Outline], [FileLink], [AccountID] FROM [FilmInfo]"></asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
    </div>








    <br />
    <br />
    <br />
</asp:Content>

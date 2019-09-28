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
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="SchoolID" HeaderText="SchoolID" SortExpression="SchoolID" />
                        <asp:BoundField DataField="IsVegetarian" HeaderText="IsVegetarian" SortExpression="IsVegetarian" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>




                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CTCSignUpConnectionString %>" SelectCommand="SELECT [Username], [Password], [Name], [Phone], [Email], [SchoolID], [IsVegetarian] FROM [Account]" DeleteCommand="DELETE  FROM [Account] WHERE Name=name">
                    <DeleteParameters>
                        <asp:Parameter Name="name" Type="string" />
                    </DeleteParameters>



                </asp:SqlDataSource>




            </div>
        </div>
    </div>
</asp:Content>

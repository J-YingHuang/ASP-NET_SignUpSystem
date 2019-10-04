<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountAddin.aspx.cs" Inherits="SignUpSystem.AccountAddin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>

  <div class="form-group">
      <br/>
    <label for="UsernameInput">Username</label>
    <input  class="form-control" id="UsernameInput"  type="text" runat="server">
    <label for="PasswordInput">Password</label>
    <input  class="form-control" type="password" id="PasswordInput" runat="server">
    <label for="NameInput">Name</label>
    <input  class="form-control" id="NameInput"  type="text" runat="server">
    <label for="PhoneInput">Phone</label>
    <input  class="form-control" id="PhoneInput"  type="text" runat="server">
    <label for="EmailInput">Email</label>
    <input  class="form-control" type="text" id="EmailInput" runat="server" >
    <div class="form-group">
    <label for="DropDownList1" >校名</label>
  <asp:DropDownList ID="DropDownList1" runat="server"   >
    <asp:ListItem>All</asp:ListItem>    
  </asp:DropDownList>
        
        <asp:Button id="AddSchool" type="button" class="  btn btn-secondary" runat="server" OnClick="btn_AddSchool_Click" Text="+" />      
     
   <div/>
    <div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1" runat="server">
  <label class="form-check-label" for="inlineRadio1">葷</label>
</div>
<div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
  <label class="form-check-label" for="inlineRadio2">素</label>
</div>
<asp:Button id="btn_Save" type="button" class=" float-right btn btn-secondary" runat="server" OnClick="btn_Save_Click" Text="Save" />
      </form>

    


   
</asp:Content>

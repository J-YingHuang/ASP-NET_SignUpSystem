<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountAddin.aspx.cs" Inherits="SignUpSystem.AccountAddin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>

  <div class="form-group">
    <label for="UsernameInput">Username</label>
    <input  class="form-control" id="UsernameInput" >
    <label for="PasswordInput">Username</label>
    <input  class="form-control" id="PassInput" >
    <label for="NameInput">Name</label>
    <input  class="form-control" id="NameInput" >
    <label for="PhoneInput">Phone</label>
    <input  class="form-control" id="PhoneInput" >
    <label for="EmailInput">Email</label>
    <input  class="form-control" id="EmailInput" >
    <div class="form-group">
    <label for="DropDownList1">校名</label>
  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
         
         </div>
    <div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
  <label class="form-check-label" for="inlineRadio1">葷</label>
</div>
<div class="form-check form-check-inline">
  <input class="form-check-input" type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2">
  <label class="form-check-label" for="inlineRadio2">素</label>
</div>
      </form>

    


   
</asp:Content>

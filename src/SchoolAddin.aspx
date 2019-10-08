<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchoolAddin.aspx.cs" Inherits="SignUpSystem.SchoolAddin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <br />
    <br />
    <br />

    <div class="alert alert-secondary" role="alert">
        <div class="col">
            <h4 class="alert-heading">新增學校</h4>
            <hr>

     
               
                    <div class="col"></div>
                    <label class=" col-form-label" for="inputemail">校名: </label>
                    <input type="text" class="form-control " id="School_name"  runat="server">
                    <div/>
                    <div class="col"></div>
                    <label class=" col-form-label" for="inputemail">地址: </label>
                    <input type="text" class="form-control " id="Address"  runat="server">
                    <div/>
                    <div class="col"></div>
                    <label class=" col-form-label" for="inputemail">區域: </label>
                    <input type="text" class="form-control " id="Area" runat="server">
                    
                <div/>
                
                    <div class="col-4"></div>
                <label id="serch_email" class="form-text text-muted smail" runat="server"></label>
                <asp:Button ID="btn_CheckEmail" type="button" class="btn btn-outline-info" runat="server" OnClick="btn_SendEmail_Click" Text="儲存" />

                </form>
                    <br />
        </div>
    </div>
    <br />
  
</asp:Content>

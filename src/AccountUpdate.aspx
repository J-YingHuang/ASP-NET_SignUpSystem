<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountUpdate.aspx.cs" Inherits="SignUpSystem.AccountUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-group row" style="font-size: 18px">
            <div class="col-4">
                <p align="left">
                    1.帳號：
                </p>
                <input id="input_Username" class="form-control form-control-sm" type="text"  style="font-size: 8px;" maxlength="10" runat="server">
            </div>

            <div class="col-4">
                <p align="left">
                    2. 密碼：
                </p>
                 <input id="Text1" class="form-control form-control-sm" type="text"  style="font-size: 8px;" maxlength="10" runat="server">
               
                  </div> 
                

            </div>
            <div class="col-4">
                <p align="left">
                    3. 名稱：
                </p>
                <input id="input_Name" class="form-control form-control-sm" type="text" style="font-size: 8px;" maxlength="10" runat="server">
            </div>
       

        <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                    4.手機：
                     </p>
                <input id="Text2" class="form-control form-control-sm" type="text" style="font-size: 8px;" maxlength="10" runat="server">
            </div>
            <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                    5.E-mail:
                
                        

                


        


        <p align="right">
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="Submit" runat="server" onserverclick="btn_Submit_ServerClick">提交</button>
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="btn_Close" runat="server" onserverclick="btn_Close_ServerClick">取消</button>
        </p>

</asp:Content>

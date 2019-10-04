<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountUpdate.aspx.cs" Inherits="SignUpSystem.AccountUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 80%; margin-left: 10%; margin-right: 10%;">

        <div class="form-group row" style="font-size: 30px">
            <div class="col">
                <br />
                <div id="lab_Title" runat="server" class="row justify-content-center">
                    5.帳戶資訊
                </div>
            </div>
        </div>
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
                    </p>
                <input id="Text3" class="form-control form-control-sm" type="text" style="font-size: 8px;"  runat="server">
            </div>
            <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                    </div>
          
                    6.SchoolID:
                    </p>
                <input id="Text4" class="form-control form-control-sm" type="text" style="font-size: 8px;" maxlength="10" runat="server">
            </div>
            <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                     7.ID:
                    </p>
                <input id="Text5" class="form-control form-control-sm" type="text" style="font-size: 8px;" maxlength="10" runat="server" disabled>
            </div>
            <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                
                
                        

                


        


        <p align="right">
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="Submit" runat="server" onserverclick="btn_Submit_ServerClick">提交</button>
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="btn_Close" runat="server" onserverclick="btn_Close_ServerClick">取消</button>
        </p>
                 </div>
    <!-- Modal -->
    <div class="modal fade" id="Modal_ErrMsg" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalCenterTitle">報名表填寫錯誤</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="Modal_Body" runat="server">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

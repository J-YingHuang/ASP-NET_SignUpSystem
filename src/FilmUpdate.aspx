<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmUpdate.aspx.cs" Inherits="SignUpSystem.FilmUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 80%; margin-left: 10%; margin-right: 10%;">



        <div class="form-group row" style="font-size: 30px">
            <div class="col">
                <br />
                <div class="row justify-content-center">
                    影領創視界報名資訊
                </div>
            </div>
        </div>


        <div class="form-group row" style="font-size: 20px">
            <div class="col">
                <hr />
            </div>
        </div>

        <div class="form-group row" style="font-size: 16px">
            <div class="col">
                <div class="card text-white bg-light mb-3" style="max-width: 1300rem; background-color: transparent;">
                    <font color="#FF3333" />
                    <div class="card-header" style="font-size: 20px">注意事項</div>
                    <h5 class="card-title"></h5>
                    <p class="card-text" align="left" style="margin-left: 15px;">
                        1. 作品設計理念請濃縮至200字以內。
                    </p>
                    <p class="card-text" align="left" style="margin-left: 15px; margin-bottom: 20px;">
                        2. ​故事大綱請濃縮至500字以內。
                    </p>
                </div>
                </font>
            </div>
        </div>

        <div class="form-group row" style="font-size: 18px">
            <div class="col-md-3" style="margin-left: 0px;">
                1. 隊伍名稱：
            </div>
            <div class="col" style="margin-left: 5px;">
                <select class="form-control" id="select_Team" runat="server" disabled>
                    <option>請選擇隊伍</option>
                </select>
            </div>
        </div>


        <div class="form-group row" style="font-size: 18px">
            <div class="col-md-3" style="margin-left: 0px;">
                2. 設計理念：
            </div>
            <div class="col">
                <textarea class="form-control" id="text_Design" runat="server" style="min-width: 100%; margin-left: 5px;" rows="7" placeholder=" 限200字以內" maxlength="200"></textarea>
            </div>
        </div>

        <div class="form-group row" style="font-size: 18px">
            <div class="col-md-3" style="margin-left: 0px;">
                3. 故事大綱：
            </div>
            <div class="col">
                <div class="form-group">
                    <textarea class="form-control" id="text_Outline" runat="server" style="min-width: 100%; margin-left: 5px;" rows="15" placeholder=" 限500字以內" maxlength="10"></textarea>
                </div>
            </div>
        </div>
        <div class="form-group row" style="font-size: 18px">
            <div class="col-md-3" style="margin-left: 0px;">
                4. 作品連結：
            </div>
            <div class="col">
                <div class="form-group">
                    <input class="form-control" id="input_Link" runat="server" style="margin-left: 5px; min-width: 100%" placeholder="報名時非必填" />
                </div>
            </div>
        </div>
        <p align="right">
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="btn_Submit" runat="server" onserverclick="btn_Submit_ServerClick">更新</button>
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark" id="btn_Cancel" runat="server" onserverclick="btn_Cancel_ServerClick">取消</button>

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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EarthquakeRegistration.aspx.cs" Inherits="SignUpSystem.EarthquakeRegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="width: 80%; margin-left: 10%; margin-right: 10%;">

        <div class="form-group row" style="font-size: 30px">
            <div class="col">
                <br />
                <div class="row justify-content-center">
                    高科大克震報名資訊 
                </div>
            </div>
        </div>



        <div class="form-group row" style="font-size: 16px">
            <div class="col">
                <hr />
                <div class="card text-white bg-light mb-3" style="max-width: 1300rem; background-color: transparent;">
                    <font color="#FF3333" />
                    <div class="card-header text-center" style="font-size: 20px">注意事項</div>
                    <h5 class="card-title"></h5>
                    <p class="card-text" align="left" style="margin-left: 25px;">
                        1. 每隊人數含隊長在內為3-6名。
                    </p>
                    <p class="card-text" align="left" style="margin-left: 25px;">
                        2. 隊伍名稱不得超過10個中文字，同時報名完成後非特殊緣由不得更改，若必須更改請透過"聯繫我們"提供之聯繫方式
                    </p>
                    <p class="card-text" align="left" style="margin-left: 40px;">
                        ，詢問相關承辦人員。
                    </p>
                    <p class="card-text" align="left" style="margin-bottom: 20px; margin-left: 25px;">
                        3. 吃素人數統計不包含帶隊老師。
                    </p>
                </div>
                </font>
            </div>

            <hr />
        </div>

        <div class="form-group row" style="font-size: 25px">
            <div class="col">
                <p align="center">
                    隊伍資訊
                </p>
            </div>
        </div>
        <div class="form-group row" style="font-size: 18px">
            <div class="col">
                <p align="left">
                    1.隊伍名稱：
                </p>
                <input class="form-control" type="text" placeholder="不得超過10個字" style="font-size: 8px;" maxlength="10" id="input_TeamName" runat="server" />
            </div>


            <div class="col">
                <p align="left">
                    2.吃素人數：(不含老師)
                </p>
                <select class="form-control" style="font-size: 12px;" id="select_Veg" runat="server">
                    <option>無</option>
                    <option>1人</option>
                    <option>2人</option>
                    <option>3人</option>
                    <option>4人</option>
                    <option>5人</option>
                    <option>6人</option>
                </select>

            </div>
        </div>

        <div class="form-group row" style="font-size: 18px;">
            <div class="col ">
                <p align="left">
                    3.隊員資訊：
                </p>
                <div class="form-group row " style="font-size: 18px;">
                    <div class="col-4"></div>
                    <div class="col-2" style="margin-left: 65px;">
                        隊員名字
                    </div>
                    <div class="col-1"></div>
                    <div class="col-2" style="margin-left: 53px;">
                        隊長
                    </div>
                    <div class="col-2"></div>

                </div>

                <div id="fieldSpace" runat="server"></div>
                <p align="center">
                    <br />
                    <button id="btn_Add" type="button" class="btn btn-light" runat="server" onserverclick="btn_Add_ServerClick">
                        <img src="https://img.icons8.com/ios/50/000000/add.png" style="width: 30px;"></button>
                    <button id="btn_Delete" type="button" class="btn btn-light" runat="server" onserverclick="btn_Delete_ServerClick">
                        <img src="https://img.icons8.com/ios/50/000000/minus.png" style="width: 30px"></button>
                </p>
            </div>


        </div>


        <p align="right">
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark"  id="Submit" runat="server" onserverclick="btn_Submit_ServerClick">提交</button>
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


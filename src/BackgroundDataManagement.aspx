<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackgroundDataManagement.aspx.cs" Inherits="SignUpSystem.BackgroundDataManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />
    <!-- Button trigger modal -->
    <button type="button" class="float-right btn btn-outline-info" data-toggle="modal" data-target="#UpdateNextYear">
        年度資料更換
    </button>
    <p class="text-info">會員資料</p>
    <asp:Button ID="btn_Addin" runat="server" Text="新增" class=" float btn btn-outline-info" OnClick="btn_Addin_Click" />
    <asp:Button ID="btn_AccountModify" runat="server" Text="修改" class=" float btn btn-outline-info" OnClick="btn_AccountModify_Click" />
    <asp:Button ID="btn_AccountDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="AccountDelete_Click" />
    <div />
    <div p class="text-info">-------------------------------------------------------</div>
    <p class="text-info">抗震大作戰</p>
    <asp:Button ID="btn_EearthquakeModify" runat="server" Text="修改" class=" float btn btn-outline-info" OnClick="btn_EearthquakeModify_Click" />
    <asp:Button ID="btn_EearthquakeDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_EearthquakeDelete_Click" />
    <div />
    <div p class="text-info">-------------------------------------------------------</div>
    <p class="text-info">橋梁變變變</p>
    <asp:Button ID="btn_BridgeModify" runat="server" Text="修改" class=" float btn btn-outline-info" OnClick="btn_BridgeModify_Click" />
    <asp:Button ID="btn_BridgeDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_BridgeDelete_Click" />
    <div />
    <div p class="text-info">-------------------------------------------------------</div>
    <p class="text-info">微電影</p>
    <asp:Button ID="btn_FilmModify" runat="server" Text="修改" class=" float btn btn-outline-info" OnClick="btn_FilmModify_Click" />
    <asp:Button ID="btn_FilmDelete" runat="server" Text="刪除" class=" float btn btn-outline-info" OnClick="btn_FilmDelete_Click" />
    <div p class="text-info">-------------------------------------------------------</div>
    <p class="text-info">報名資訊匯出</p>
    <asp:Button ID="btn_ExportExcel" runat="server" Text="匯出Excel" class=" float btn btn-outline-info" OnClick="btn_ExportExcel_Click" />
    <br />
    <br />

    <!-- Modal -->
    <div class="modal fade" id="UpdateNextYear" tabindex="-1" role="dialog" aria-labelledby="UpdateNextYearTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UpdateNextYearTitle">更換至下個年度</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-1"></div>
                        <label>1. 第幾屆比賽(ex.第十五屆)：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <input id="input_GameNumber" runat="server" class="form-control col-10" />
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>2. 抗震大作戰比賽名稱：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <input id="input_EarthquakeName" runat="server" class="form-control col-10" />
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>3. 橋梁變變變比賽名稱：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <input id="input_BridgeName" runat="server" class="form-control col-10" />
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>4. 微電影比賽名稱：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <input id="input_FilmName" runat="server" class="form-control col-10" />
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>5. 報名開始日期(時間預設為18:00)：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div class='input-group date' id='datePicker_StartSignUp'>
                                <input id="input_StartSignUp" runat="server" type='text' style="width: 80px;" class="form-control" />
                                <span class="input-group-addon">
                                    <button type="button" class="btn btn-outline-secondary">
                                        <img width="20" src="https://img.icons8.com/android/50/000000/calendar.png">
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>6. 報名截止日期(時間預設為18:00)：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div class='input-group date' id='datePicker_EndSignUp'>
                                <input id="input_EndSignUp" runat="server" type='text' style="width: 80px;" class="form-control" />
                                <span class="input-group-addon">
                                    <button type="button" class="btn btn-outline-secondary">
                                        <img width="20" src="https://img.icons8.com/android/50/000000/calendar.png">
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>7. 隊伍更新截止日期(時間預設為18:00)：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div class='input-group date' id='datePicker_EndUpdateInfo'>
                                <input id="input_EndUpdateInfo" runat="server" type='text' style="width: 80px;" class="form-control" />
                                <span class="input-group-addon">
                                    <button type="button" class="btn btn-outline-secondary">
                                        <img width="20" src="https://img.icons8.com/android/50/000000/calendar.png">
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-1"></div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <label>8. 微電影繳交截止日期(時間預設為18:00)：</label>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div class='input-group date' id='datePicker_EndFilmUpdate'>
                                <input id="input_EndFilmUpdate" runat="server" type='text' style="width: 80px;" class="form-control" />
                                <span class="input-group-addon">
                                    <button type="button" class="btn btn-outline-secondary">
                                        <img width="20" src="https://img.icons8.com/android/50/000000/calendar.png">
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-1"></div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btn_UpdateToNextYear" runat="server" onserverclick="btn_UpdateToNextYear_ServerClick">更換資訊</button>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/moment-with-locales.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('#datePicker_StartSignUp').datepicker({
                format: 'yyyy-mm-dd'
            });
        });
        $(function () {
            $('#datePicker_EndSignUp').datepicker({
                format: 'yyyy-mm-dd'
            });
        });
        $(function () {
            $('#datePicker_EndUpdateInfo').datepicker({
                format: 'yyyy-mm-dd'
            });
        });
        $(function () {
            $('#datePicker_EndFilmUpdate').datepicker({
                format: 'yyyy-mm-dd'
            });
        });
    </script>
</asp:Content>


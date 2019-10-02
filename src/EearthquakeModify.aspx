<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EearthquakeModify.aspx.cs" Inherits="SignUpSystem.EearthquakeModify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container h-100">
        <div class="row">
            <br />
            <br />
            <br />
            <br />
               
            </div>
            <div class="col-md-9">
                <h4>EarthquakeTeam
                </h4>
                <hr />
                <div class="card text-center">
                    <div class="card-header">
                        <ul class="nav nav-tabs card-header-tabs">
                            <li class="nav-item" id="card_">
                                <a id="a_Earthquake" class="nav-link active" href="#" style="color: dimgray" runat="server">團隊來對震</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div id="div1" runat="server"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      

    <div class="modal fade" id="UpdateModal" tabindex="-1" role="dialog" aria-labelledby="UpdateModal" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalCenterTitle">變更資訊</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>



                <div class="modal-body">
                    <form>
                        <div class="form-group row">
                            <div class="col-sm-1"></div>
                            <label for="updateName" class="col-sm-3 col-form-label float-left">Name：</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control  float-left" id="Div2" runat="server">
                            </div>

                        </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1"></div>
                <label for="updatecount" class="col-sm-3 col-form-label">Count：</label>
                <div class="col-sm-8">
                    <input type="text" class="form-control" id="updatecount" runat="server">
                </div>
                <div class="form-group row">
                    <div class="col-sm-1"></div>
                    <label for="updatevegetarian" class="col-sm-3 col-form-label">Vegetarian：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="updatevegetarian" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1"></div>
                    <label for="updateleadername" class="col-sm-3 col-form-label">LeaderName：</label>
                    <div class="col-sm-7">
                        <input type="text" class="form-control" id="updateleadername" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1"></div>
                    <label for="updateplayername1" class="col-sm-3 col-form-label">PlayerName1：</label>
                    <div class="col-sm-7">
                        <input type="text" class="form-control" id="updateplayername1" runat="server">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1"></div>
                    <label for="updateplayername2" class="col-sm-3 col-form-label">PlayerName2：</label>
                    <div class="col-sm-7">
                        <input type="text" class="form-control" id="updateplayername2" runat="server">
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-1"></div>
                        <label for="updateplayername3" class="col-sm-3 col-form-label">PlayerName3：</label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control" id="updateplayername3" runat="server">
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-2"></div>
                            <label for="updateplayername4" class="col-sm-3 col-form-label">PlayerName4：</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="updateplayername4" runat="server">
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <label for="updateplayername5" class="col-sm-3 col-form-label">PlayerName5：</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control" id="updateplayername5" runat="server">
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-2"></div>
                                    <label for="updatesecondteacher" class="col-sm-3 col-form-label">SecondTeacher：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="updatesecondteacher" runat="server">
                                    </div>
                                </div>
                            </div>
                            <div id="MemberInfo" runat="server"></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>


                <div class="col-sm-1"></div>
            </div>

        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-outline-info" data-dismiss="modal" id="btn_updateAccount" runat="server" onserverclick="btn_updateAccount_ServerClick">儲存變更</button>
        </div>
    </div>
</asp:Content>

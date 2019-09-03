<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EarthquakeRegistrationPage.aspx.cs" Inherits="SignUpSystem.EarthquakeRegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container"  style="width:80%; margin-left:10%; margin-right:10%;">

  <div class="form-group row" style="font-size:30px">
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
            <font color="#FF3333	" />
              <div class="card-header" style="font-size: 20px">注意事項</div>
                <h5 class="card-title"></h5>
                    <p class="card-text" align="left" style="margin-left:15px;">
                        1. 每隊人數含隊長在內為3-6名。
                     </p>
                    <p class="card-text" align="left" style="margin-left:15px;">
                        2. 隊伍名稱不得超過10個中文字，同時報名完成後非特殊緣由不得更改，若必須更改請透過"聯繫我們"提供之聯繫方
                    </p>
                    <p class="card-text" align="left" style="margin-left:30px;">
                        式，詢問相關承辦人員。
                    </p>
                    <p class="card-text" align="left" style="margin-bottom: 20px; margin-left:15px;">                
                        3. 吃素人數統計不包含帶隊老師。
                    </p>
                </div>         
             </font>
         </div>

        <hr />
      </div>

    <div class="form-group row" style="font-size: 25px">
        <div class="col">
        <p align="center" >
                隊伍資訊
            </p>
            </div>
        </div>
        <div class="form-group row" style="font-size: 18px">
            <div class="col">
                <p align="left">
                    1.隊伍名稱：
                </p>
                <input class="form-control form-control-sm" type="text" placeholder="不得超過10個字" style="font-size: 8px;" maxlength="10">
            </div>


            <div class="col">
                <p align="left">
                    2.吃素人數：(不含老師)
                </p>
                <select class="form-control form-control-sm" style="font-size: 12px;">
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
                    <div class="col" style="margin-right: 20px;"></div>
                    <div class="col " style="margin-right: 20px;">
                        隊員名字
                    </div>
                    <div class="col">
                        隊長
                    </div>
                </div>
                <div class="form-group row " style="font-size: 18px;">
                    <div class="col" style="margin-right: 0px;">
                        隊員1：
                    </div>
                    <div class="col" style="margin-right: 0px;">
                        <input type="text" style="font-size: 8px;" name="N1" />
                    </div>
                    <div class="col" style="margin-left: 80px;">
                        <input type="radio" name="radiobutton" />
                    </div>
                </div>
                <div class="form-group row " style="font-size: 18px;">
                    <div class="col" style="margin-right: 0px;">
                        隊員2：
                    </div>
                    <div class="col" style="margin-right: 0px;">
                        <input type="text" style="font-size: 8px;" name="N1" />
                    </div>
                    <div class="col" style="margin-left: 80px;">
                        <input type="radio" name="radiobutton" />
                    </div>
                </div>
                <div class="form-group row " style="font-size: 18px;">
                    <div class="col" style="margin-right: 0px;">
                        隊員3：
                    </div>
                    <div class="col" style="margin-right: 0px;">
                        <input type="text" style="font-size: 8px;" name="N1" />
                    </div>
                    <div class="col" style="margin-left: 80px;">
                        <input type="radio" name="radiobutton" />
                    </div>
                </div>

        <span id="fieldSpace"></span>
        <p align="center" >
        <br />
            <button type="button" class="btn btn-light" onclick="addField()"> <img src="https://img.icons8.com/ios/50/000000/add.png" style="width:30px;" ></button>
            <button type="button" class="btn btn-light" onclick="delField()"><img src="https://img.icons8.com/ios/50/000000/minus.png" style="width:30px"></button>
        </p>
        </div>


        </div>


        <p align="right">
            <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark">提交</button>
            <button type="reset" class="btn btn-outline-dark">重新設定</button>
        </p>



        <script> 
            var countMin = 3;
            var countMax = 6;
            var count = countMin
            function addField() {
                if (count == countMax)
                    alert("最多" + countMax + "個欄位");
                else
                    //document.getElementById("fieldSpace").innerHTML = document.getElementById("fieldSpace").innerHTML
                    //    + "<div class=\"form-group row \" style = \"font-size: 18px;\" >"
                    //    + "<div class=\"col\"> 第" + (++count) + "個隊員：</div> "
                    //    + "< div class=\"col\" ><input type=\"text\" style=\"font-size:px;width:148px\" name=\""
                    //    + "N\"" + count + "\"></div>" 
                    //    + "< div class=\"col\" ><input type=\"text\" style=\"font-size:px;width:148px\" name=\""
                    //    + "T\"" + count + "\"></div>" 
                    //    + "< div class=\"col\" ><input type=\"radio\" name=\"radiobutton\"><\div>";
                    document.getElementById("fieldSpace").innerHTML +=
                        "<div class=\"form-group row \" style=\"font-size:18px;\">"
                        + "<div class=\"col\" style=\"margin-right:0px;\">\隊員" + (++count) + "："
                        + "</div><div class=\"col\" style=\"margin-right:0px;\">"
                        + "<input type=\"text\"style=\"font-size:8px;\" name=\"N\"" + count + "/>"
                        + "</div><div class=\"col\" style=\"margin-left:80px;\">"
                        + "<input type=\"radio\" name=\"radiobutton\" />"
                        + "</div></div>"

            }
            function delField() {
                if (count > countMin) {
                    document.getElementById("fieldSpace").removeChild(document.getElementById("fieldSpace").lastChild);
                    count--;


                }


            }

         
            

        
    
</script>
</div>
</asp:Content>


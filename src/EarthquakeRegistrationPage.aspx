<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EarthquakeRegistrationPage.aspx.cs" Inherits="SignUpSystem.EarthquakeRegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container"  style="width:60%; margin-left:20%; margin-right:20%;">

  <div class="form-group row" style="font-size:30px">
    <div class="col">
        <br />
        <div class="row justify-content-center">     
                高科大克震報名資訊 
        </div>     
    </div>
  </div>
  <div class="form-group row" style="font-size:20px">
    <div class="col">
        <hr  color="black" />
    </div>
  </div>


     
  <div class="form-group row" style="font-size:20px">
     <div class="col">
        一,指導老師資訊
     </div>
  </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        1.指導老師姓名:
        <select class="form-control form-control-sm" style="font-size: 12px; ">
            <option>姓名</option>
        </select>
     </div>
     <div class="col">
        2.指導老師Email:
        <select class="form-control form-control-sm" style="font-size: 12px; ">
            <option>Email</option>
        </select>
     </div>
   </div>


  <div class="form-group row " style="font-size: 18px; ">
     <div class="col  ">
        3.指導老師電話:
        <select class="form-control form-control-sm" style="font-size: 12px; " >
            <option>電話</option>
        </select>
     </div>
     <div class="col">
        4.車牌號碼:
         <input class="form-control form-control-sm" type="text" placeholder="車牌"style="font-size:8px;">
     </div>
   </div>
  



  <div class="form-group row" style="font-size:20px">
     <div class="col">
        二,隊伍資訊
     </div>
  </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        1.隊伍名稱:
          <input class="form-control form-control-sm" type="text" placeholder="不得超過10個字"style="font-size:8px;"maxlength="10">
     </div>
  <div class="col">
        2.隊伍人數:(含隊長最多6人)
           <select class="form-control form-control-sm" style="font-size: 12px;">
               <option>1人</option>
               <option>2人</option>
               <option>3人</option>
               <option>4人</option>
               <option>5人</option>
               <option>6人</option>
           </select>
           </div>
  </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        3.吃素人數:(含老師及隊長)
           <select class="form-control form-control-sm" style="font-size: 12px; ">
               <option>無</option>
               <option>1人</option>
               <option>2人</option>
               <option>3人</option>
               <option>4人</option>
               <option>5人</option>
               <option>6人</option>
               <option>7人</option>
           </select>
     </div>
     <div class="col">
        4.隊長電話:
         <input class="form-control form-control-sm" type="text" placeholder="電話"style="font-size:8px;">
     </div>
   </div>

  <div class="form-group row" style="font-size:18px">
     <div class="col">
        5.隊員1姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;">
     </div>
     <div class="col">
        6.隊員2姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;"> 
     </div>
   </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        7.隊員3姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;">
     </div>
     <div class="col">
        8.隊員4姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;">
     </div>
   </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        9.隊員5姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;">
     </div>
     <div class="col">
        10.隊員6姓名:
         <input class="form-control form-control-sm" type="text" placeholder="姓名"style="font-size:8px;">
     </div>
   </div>





<form> 
<div>1<input type="text" name="T1"></div> 
<span id="fieldSpace"></span> 
<a href="javascript:" onclick="addField()">新增欄位</a>
<a href="javascript:" onclick="delField()">刪除欄位</a>
<p><input type="submit" value="提交"><input type="reset" value="重新設定"></p> 
</form> 
<script> 
    var countMin = 1;
    var countMax = 6;
    var count = countMin
    function addField() {
        if (count == countMax)
            alert("最多" + countMax + "個欄位");
        else
            document.getElementById("fieldSpace").innerHTML = document.getElementById("fieldSpace").innerHTML
                + "<div>第" + (++count) + '個隊員：<input class="form-control form-control-sm" type="text" name="T' + count + '"></div>';
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


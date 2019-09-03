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
  <div class="form-group row" style="font-size:20px">
    <div class="col">
        <hr/>
    </div>
  </div>

    <div class="form-group row" style="font-size:20px">
     <div class="col">
        一,隊伍資訊
        </div>
    </div>
      <div class="form-group row" style="font-size:18px">
     <div class="col">
        1.隊伍名稱：
          <input class="form-control form-control-sm" type="text" placeholder="不得超過10個字"style="font-size:8px;"maxlength="10">
     </div>
          <div class="col  ">
        2.吃素人數：(含老師及隊長)
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
     
              
      
          </div>
<div class="form-group row " style="font-size: 18px; ">
    <div class="col">
   3.隊員資訊：
          <div>
<table>
　<tr>
　<td >隊員名字</td>
　<td>隊長</td>
　</tr>
　<tr>
　<td >第1個隊員：<input type="text" style="font-size:8px;"  name="T1"  /></td>
　<td><input type="radio" name="radiobutton" /></td>
　</tr>
    <tr>
    <td>第2個隊員：<input type="text" style="font-size:8px" name="T2" /></td>
　<td><input type="radio" name="radiobutton" /></td>
    </tr>
    <tr>
    <td>第3個隊員：<input type="text" style="font-size:8px" name="T3" /></td>
　<td><input type="radio" name="radiobutton" /></td>
    </tr>
    
   
     
</table>
<span id="fieldSpace"></span>
   
              
 
<p></p>
<button type="button" class="btn btn-outline-dark" onclick="addField()">+</button>
<button type="button" class="btn btn-outline-dark" onclick="delField()">-</button>
              </div>

          </div>
     
   </div>
     
  
  

<p align="right">
<button type="submit" class="btn btn-outline-dark"  >提交</button>
<button type="reset" class="btn btn-outline-dark"  >重新設定</button>
</p>



  <script> 
    var countMin = 3;
    var countMax = 6;
    var count = countMin
      function addField() {
          if (count == countMax)
              alert("最多" + countMax + "個欄位");
          else
              document.getElementById("fieldSpace").innerHTML = document.getElementById("fieldSpace").innerHTML
                  + "<table><tr><td>第" + (++count) + '個隊員：<input type="text" style="font-size:8px;" name="T' + count + '"></td><td><input type="radio" name="radiobutton"></td></tr></table>';
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


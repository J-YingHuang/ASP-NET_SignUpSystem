<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EarthquakeRegistrationPage.aspx.cs" Inherits="SignUpSystem.EarthquakeRegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container"  style="width:80%; margin-left:10%; margin-right:10%;">

  <div class="form-group row" style="font-size:30px">
    <div class="col">
        <br />
        <div class="row justify-content-center">     
                ����j�J�_���W��T 
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
        �@,���ɦѮv��T
     </div>
  </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        1.���ɦѮv�m�W:
        <select class="form-control form-control-sm" style="font-size: 12px; ">
            <option>�m�W</option>
        </select>
     </div>
     <div class="col">
        2.���ɦѮvEmail:
        <select class="form-control form-control-sm" style="font-size: 12px; ">
            <option>Email</option>
        </select>
     </div>
   </div>



  <div class="form-group row " style="font-size: 18px; ">
     <div class="col  ">
        3.���ɦѮv�q��:
        <select class="form-control form-control-sm" style="font-size: 12px; " >
            <option>�q��</option>
        </select>
     </div>
     
   </div>
  



  <div class="form-group row" style="font-size:20px">
     <div class="col">
        �G,�����T
     </div>
  </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        1.����W��:
          <input class="form-control form-control-sm" type="text" placeholder="���o�W�L10�Ӧr"style="font-size:8px;"maxlength="10">
     </div>
 
  </div>

<form> 
        2.������T:
<div>����:<input type="text" name="T1"></div> 
<span id="fieldSpace"></span> 
<p></p>
<button type="button" class="btn btn-outline-dark" onclick="addField()">+</button>
<button type="button" class="btn btn-outline-dark" onclick="delField()">-</button>

    <div class="form-group row" style="font-size:18px">
     <div class="col">
        3.�Y���H��:(�t�Ѯv�ζ���)
           <select class="form-control form-control-sm" style="font-size: 12px; ">
               <option>�L</option>
               <option>1�H</option>
               <option>2�H</option>
               <option>3�H</option>
               <option>4�H</option>
               <option>5�H</option>
               <option>6�H</option>
               <option>7�H</option>
           </select>
     </div>
     
   </div>

<p>
<button type="submit" class="btn btn-outline-dark" >����</button>
<button type="reset" class="btn btn-outline-dark" >���s�]�w</button>
</p>
</form> 


  <script> 
    var countMin = 1;
    var countMax = 6;
    var count = countMin
    function addField() {
        if (count == countMax)
            alert("�̦h" + countMax + "�����");
        else
            document.getElementById("fieldSpace").innerHTML = document.getElementById("fieldSpace").innerHTML
                + "<div>��" + (++count) + '�Ӷ����G<input class="form-control form-control-sm" type="text" name="T' + count + '"></div>';
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


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EarthquakeRegistrationPage.aspx.cs" Inherits="SignUpSystem.EarthquakeRegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container"  style="width:60%; margin-left:20%; margin-right:20%;">

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
        <hr  color="black" />
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
     <div class="col">
        4.���P���X:
         <input class="form-control form-control-sm" type="text" placeholder="���P"style="font-size:8px;">
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
  <div class="col">
        2.����H��:(�t�����̦h6�H)
           <select class="form-control form-control-sm" style="font-size: 12px;">
               <option>1�H</option>
               <option>2�H</option>
               <option>3�H</option>
               <option>4�H</option>
               <option>5�H</option>
               <option>6�H</option>
           </select>
           </div>
  </div>


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
     <div class="col">
        4.�����q��:
         <input class="form-control form-control-sm" type="text" placeholder="�q��"style="font-size:8px;">
     </div>
   </div>

  <div class="form-group row" style="font-size:18px">
     <div class="col">
        5.����1�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;">
     </div>
     <div class="col">
        6.����2�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;"> 
     </div>
   </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        7.����3�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;">
     </div>
     <div class="col">
        8.����4�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;">
     </div>
   </div>


  <div class="form-group row" style="font-size:18px">
     <div class="col">
        9.����5�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;">
     </div>
     <div class="col">
        10.����6�m�W:
         <input class="form-control form-control-sm" type="text" placeholder="�m�W"style="font-size:8px;">
     </div>
   </div>





<form> 
<div>1<input type="text" name="T1"></div> 
<span id="fieldSpace"></span> 
<a href="javascript:" onclick="addField()">�s�W���</a>
<a href="javascript:" onclick="delField()">�R�����</a>
<p><input type="submit" value="����"><input type="reset" value="���s�]�w"></p> 
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


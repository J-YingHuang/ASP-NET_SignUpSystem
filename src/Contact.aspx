<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SignUpSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container"  style="width:80%; margin-left:10%; margin-right:10%;">

  <div class="row">
    <div class="col">
        <br />
        <div class="row justify-content-center">     
            <font size="+3">
                聯絡我們<br />
            </font>
        </div>      
    </div>
  </div>

  <div id="carouselExampleInterval" class="carousel slide carousel-fade" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active" data-interval="10000">
      <img src="images/聯絡我們_建工門口1.jpg" width="300" height="500" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item" data-interval="2000">
      <img src="images/高科大%20地圖.jpg" width="300" height="500" class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="images/聯絡我們_建工門口3.jpg" width="300" height="500" class="d-block w-100" alt="...">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleInterval" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleInterval" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
  </div>
  <div class="row">
    <div class="col">
        <hr  color="black" />
    </div>
  </div>


  <div class="row">
    <div class="col">  
       國立高雄科技大學土木工程系    蔡宛蓁    小姐<br />
       Email：civilkuas@gmail.com<br />
       Phone：07-381-4526 #15202<br />
       Address：高雄市三民區建工路415號<br />       
    </div>
  </div>

   <div class="row">  
    <div class="col">
        <div class="row justify-content-center">
           <font color="#C4C4C4">高 雄 科 技 大 學</font><br>
        </div>
    </div>
   </div>
</div>
</asp:Content>

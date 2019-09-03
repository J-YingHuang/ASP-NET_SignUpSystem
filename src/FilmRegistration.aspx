<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmRegistration.aspx.cs" Inherits="SignUpSystem.FilmRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container" style="width: 80%; margin-left: 10%; margin-right: 10%;">



  <div class="form-group row" style="font-size:30px">
    <div class="col">
        <br />
        <div class="row justify-content-center">     
                點燃拍攝魂報名表 
        </div>     
    </div>
  </div>

  <div class="form-group row" style="font-size:20px">
    <div class="col">
        <hr/>
    </div>
  </div>

  <div class="form-group row" style="font-size: 16px">
     <div class="col">
           <hr />
         <div class="card text-white bg-light mb-3" style="max-width: 1300rem; background-color: transparent;">
             <font color="#FF3333" />
                    <div class="card-header" style="font-size: 20px">注意事項</div>
                    <h5 class="card-title"></h5>
                    <p class="card-text" align="left" style="margin-left:15px;">
                        1. 作品設計理念請濃縮至200字以內。
                     </p>
                    <p class="card-text" align="left" style="margin-left:15px; margin-bottom:20px;">
                        2. ​故事大綱請濃縮至500字以內。
                    </p>
                </div>
           </font>
      </div>
   </div>

    
   
    
    <div class="form-group row" style="font-size:18px">
      <div class="col-md-3" style="margin-left:5px;">
          1.隊伍名稱：
      </div>
      <div class="col" style="margin-right:0px">
        <select class="form-control form-control-sm" style="font-size: 12px; ">
               <option>請選擇隊伍</option>
           </select>
      </div>
    </div>
    

    <div class="form-group row" style="font-size:18px" >
      <div class="col-md-3" style="margin-left:0px;">
          2.設計理念:
      </div>
      <div class="col" style="margin-right:15px">
              <textarea class="form-control" style="min-width:600px;" id="concept" rows="7" placeholder =" 限200字以內" maxlength="200" ></textarea>
      </div>
    </div>
    
    <div class="form-group row" style="font-size:18px" >
      <div class="col-md-3"style="margin-left: 0px;">
          3.故事大綱:
      </div>
      <div class="col" style="margin-right:15px">
            <div class="form-group">
              <textarea class="form-control" style="min-width:600px;" id="outline" rows="15" placeholder =" 限500字以內" maxlength="10"></textarea>
            </div>
      </div>
    </div>

    <p align="right">
        <button type="submit" style="margin-right: 5px;" class="btn btn-outline-dark">提交</button>
    </p>

</div>
</asp:Content>

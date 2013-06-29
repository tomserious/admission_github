<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="Honors.aspx.cs" Inherits="Users_Honors" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">学生获奖情况</div>
  <asp:Table ID="HonorsList" CssClass="HonorsList" runat="server"></asp:Table>
  <div id="AddLink"><!--<a href="HonorsAdd.aspx">添加获奖情况</a>-->不可更改<br />
    <span style="color: #F00">注：获奖情况为选填项，好的获奖背景可以提高入选机率。如果无任何市级及以上获奖信息，可以不填写。</span></div>
</asp:Content>

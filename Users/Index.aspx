<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Users_Index" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">报名管理首页</div>
  <table id="AdminTable">
    <tr>
      <td><asp:Literal ID="BasicInfoLink" runat="server" /></td>
    </tr>
    <tr>
      <td><asp:Literal ID="FamilyMembersLink" runat="server" /></td>
    </tr>
    <tr>
      <td><asp:Literal ID="PerformanceLink" runat="server" /></td>
    </tr>
    <tr>
      <td><asp:Literal ID="HeadmasterLink" runat="server" /></td>
    </tr>
    <tr>
      <td><asp:Literal ID="HonorsLink" runat="server" /></td>
    </tr>
    <tr>
      <td><asp:Literal ID="PrintLink" runat="server" /></td>
    </tr>
  </table>
</asp:Content>

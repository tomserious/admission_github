<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="Headmaster.aspx.cs" Inherits="Users_Headmaster" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">校长联系方式</div>
  <table id="HeadmasterTable">
    <tr>
      <td style="width: 15%">校长姓名</td>
      <td style="width: 35%"><asp:TextBox ID="Name" runat="server" CssClass="Text" /></td>
      <td style="width: 50%">请填写所在学校校长的姓名<br />
        如遇无法输入的生僻字，请以拼音代替</td>
    </tr>
    <tr>
      <td>办公电话</td>
      <td><asp:TextBox ID="OfficePhone" runat="server" CssClass="Text" /></td>
      <td>请填写校长的办公电话，格式为“区号-电话号码”<br />
        此项为选填项，可以留空</td>
    </tr>
    <tr>
      <td>传真</td>
      <td><asp:TextBox ID="Fax" runat="server" CssClass="Text" /></td>
      <td>请填写校长的传真号码，格式为“区号-电话号码”<br />
        此项为选填项，可以留空</td>
    </tr>
    <tr>
      <td>手机</td>
      <td><asp:TextBox ID="Mobile" runat="server" CssClass="Text" /></td>
      <td>请填写校长的手机号码<br />
        此项为选填项，可以留空</td>
    </tr>
    <tr>
      <td colspan="3"><asp:Button ID="Submit" Text="提交" runat="server" OnClick="OnSubmit_Click" class="Button" disabled /></td>
    </tr>
  </table>
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Name" required="true" expression="numeric " mode="deny"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_OfficePhone,ctl00_ctl00_MainContent_UserContent_Fax" regex="^0\d{2,3}-\d{7,8}$" expression="numeric-" mode="allow" required="false"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Mobile" regex="^1[358]\d{9}$" expression="numeric" mode="allow" required="false"> -->
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="HonorsModify.aspx.cs" Inherits="Users_HonorsModify" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">修改获奖情况</div>
  <table id="HonorsModifyTable">
    <tr>
      <td style="width: 15%">获奖年月</td>
      <td style="width: 35%"><asp:TextBox ID="HonorDate" runat="server" CssClass="Text" /></td>
      <td style="width: 50%">请填写获奖时间，格式为“年-月”<br />
        举例：2000-3</td>
    </tr>
    <tr>
      <td>奖项名称</td>
      <td><asp:TextBox ID="HonorName" runat="server" CssClass="Text" TextMode="MultiLine" Rows="2" /></td>
      <td>请详细填写获得奖项的全称(必须是市级或市级以上)<br />
        举例：第二届“未来杯”全国中学生创意设计竞赛</td>
    </tr>
    <tr>
      <td>获奖等级</td>
      <td><asp:TextBox ID="HonorRank" runat="server" CssClass="Text" /></td>
      <td>请填写获得奖项的等级<br />
        举例：一等奖、金牌</td>
    </tr>
    <tr>
      <td colspan="3"><asp:Button ID="Submit" Text="提交" runat="server" OnClick="OnSubmit_Click" class="Button" disabled /></td>
    </tr>
  </table>
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_HonorDate" regex="^((19[89])|20[01])\d-([1-9]|(1[012]))$" required="true" expression="numeric-" mode="allow"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_HonorName,ctl00_ctl00_MainContent_UserContent_HonorRank" required="true"> -->
</asp:Content>

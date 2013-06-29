<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" Runat="Server">
  <!--
  <table id="AdminViewTable">
    <tr>
      <td>序号</td>
      <td>用户名</td>
      <td>基本信息</td>
      <td>家庭成员</td>
      <td>在校排名</td>
      <td>校长信息</td>
      <td>获奖情况</td>
      <td>操作</td>
    </tr>
    <asp:Literal ID="UserRows" runat="server" />
  </table>
  -->
  <div id="ClassTitle" >      
      <asp:Button runat="server" Text="导出Excel"  OnClick="ExportToExcel" />
      <a href="ToSchool.aspx">导出上报学校报表</a>
      <a href ="ForExpert.aspx">导出专家审核报表</a>
      <a href="finalExport.aspx">导出最终表格</a>
  </div>
    <div id="export" runat="server">
        <asp:Literal ID="PageIndex" runat="server"></asp:Literal>
        <table id="AdminViewTable">
         <tr>
      <td>报名号</td>
      <td>用户名</td>
      <td>姓名</td>
      <td>学校</td>
      <td>家庭电话</td>
      <td>其它电话</td>
      <td>状态</td>
      <td>操作</td>
    </tr>
         <asp:Literal ID="UserRowsTemp" runat="server" />
        </table>
    </div>
  
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master"  CodeFile="finalExport.aspx.cs" Inherits="Admin_finalExport" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" Runat="Server">
    <div id="expert_button" >      
      <asp:Button runat="server" Text="导出Excel"  onClick="ExportToExcel" />
      <a href="Index.aspx">返回</a>
  </div>
    <div id="export_for" runat="server">
        <asp:Literal ID="PageIndex" runat="server"></asp:Literal>
        <table id="AdminViewTable">
         <tr>
      <td>报名表号</td>      
      <td>姓名</td>
      <td>性别</td>
      <td>民族</td>
      <td>身份证号</td>
      <td>省份</td>
      <td>就读学校</td>
      <td>联系电话</td>
             <td>其他电话</td>
             <td>高一排名</td>
             <td>高二排名</td>
             <td>高三排名</td>
             <td>高一成绩</td>
             <td>高二成绩</td>
             <td>高三成绩</td>
             <td>获奖情况</td>
             <td>备注信息</td>
    </tr>
         <asp:Literal ID="UserRowsTemp" runat="server" />
        </table>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.master" CodeFile="ToSchool.aspx.cs" Inherits="Admin_ToSchool" %>

<asp:Content ID="AdminContent" ContentPlaceHolderID="AdminContent" Runat="Server">

  <div id="school_button" >      
      <asp:Button runat="server" Text="导出Excel"  OnClick="ExportToExcel" />  
      <a href="Index.aspx">返回</a>    
  </div>
    <div id="for_school" runat="server">
        <asp:Literal ID="PageIndex" runat="server"></asp:Literal>
        <table id="AdminViewTable">
         <tr>
      <td>报名表号</td>      
      <td>姓名</td>
      <td>性别</td>
      <td>民族</td>      
      <td>学历</td>
      <td>身份证号</td>
      <td>学校</td>      
    </tr>
         <asp:Literal ID="UserRowsTemp_school" runat="server" />
        </table>
    </div>
  
</asp:Content>

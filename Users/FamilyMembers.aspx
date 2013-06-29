<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="FamilyMembers.aspx.cs" Inherits="Users_FamilyMembers" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">主要家庭成员</div>
  <asp:Table ID="FamilyMembersList" CssClass="FamilyMembersList" runat="server">
    <asp:TableHeaderRow>
      <asp:TableHeaderCell Width="14%">与本人关系</asp:TableHeaderCell>
      <asp:TableHeaderCell Width="9%">姓名</asp:TableHeaderCell>
      <asp:TableHeaderCell Width="40%">工作单位</asp:TableHeaderCell>
      <asp:TableHeaderCell Width="10%">职务</asp:TableHeaderCell>
      <asp:TableHeaderCell Width="20%">联系电话</asp:TableHeaderCell>
      <asp:TableHeaderCell Width="7%">操作</asp:TableHeaderCell>
    </asp:TableHeaderRow>
  </asp:Table>
  <div id="AddLink"><!--<a href="FamilyMembersAdd.aspx">添加家庭成员</a>-->不可更改</div>
</asp:Content>

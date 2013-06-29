<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="FamilyMembersModify.aspx.cs" Inherits="Users_FamilyMembersModify" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">修改家庭成员</div>
  <table id="FamilyMembersModifyTable">
    <tr>
      <td style="width: 15%">与本人关系</td>
      <td style="width: 35%"><asp:TextBox ID="RelationType" runat="server" CssClass="Text" /></td>
      <td style="width: 50%">请填写此家庭成员与本人的关系<br />
        举例：父子、母女</td>
    </tr>
    <tr>
      <td>姓名</td>
      <td><asp:TextBox ID="MemberName" runat="server" CssClass="Text" /></td>
      <td>如遇无法输入的生僻字，请以拼音代替</td>
    </tr>
    <tr>
      <td>工作单位</td>
      <td><asp:TextBox ID="Organization" runat="server" CssClass="Text" TextMode="MultiLine" Rows="3" /></td>
      <td>请填写此家庭成员供职的单位全称<br />
        如无工作单位，请填“无”<br />
        举例：中国核工业集团公司</td>
    </tr>
    <tr>
      <td>职务</td>
      <td><asp:TextBox ID="Title" runat="server" CssClass="Text" /></td>
      <td>请填写此家庭成员在工作单位的职务<br />
        如无工作单位，请按实际情况填写<br />
        举例：总经理、职员、家庭主妇、务农、自由职业</td>
    </tr>
    <tr>
      <td>联系电话</td>
      <td><asp:TextBox ID="Phone" runat="server" CssClass="Text" /></td>
      <td>请填写此家庭成员的固定电话或手机<br />
        固定电话格式为“区号-电话号码”</td>
    </tr>
    <tr>
      <td colspan="3"><asp:Button ID="Submit" Text="提交" runat="server" OnClick="OnSubmit_Click" class="Button" disabled /></td>
    </tr>
  </table>
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_RelationType,ctl00_ctl00_MainContent_UserContent_MemberName" required="true" expression="numeric " mode="deny"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Organization,ctl00_ctl00_MainContent_UserContent_Title" required="true"> -->
  <!-- <validanguage target="ctl00_ctl00_MainContent_UserContent_Phone" regex="(^0\d{2,3}-\d{7,8}$)|(^1[358]\d{9}$)" required="true" expression="numeric-" mode="allow"> -->
</asp:Content>

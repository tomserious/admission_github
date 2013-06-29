<%@ Page Language="C#" MasterPageFile="~/Users/Users.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Users_ChangePassword" %>

<asp:Content ID="UserContent" ContentPlaceHolderID="UserContent" Runat="Server">
  <div id="ClassTitle">修改密码</div>
  <table id="LoginTable">
    <tr>
      <td>原密码：</td>
      <td><input name="OldPassword" type="password" id="OldPassword" class="Text" /></td>
      <td>请正确输入原来的密码</td>
    </tr>
    <tr>
      <td>新密码：</td>
      <td><input name="NewPassword" type="password" id="NewPassword" class="Text" /></td>
      <td>请选择方便记忆的密码，此密码区分大小写</td>
    </tr>
    <tr>
      <td>确认新密码：</td>
      <td><input name="RepeatPassword" type="password" id="RepeatPassword" class="Text" /></td>
      <td>请重复输入新密码以进行确认</td>
    </tr>
    <tr>
      <td colspan="3"><input type="submit" name="SubmitForm" value="修改" id="SubmitForm" class="Button" />
        <span id="ErrorSpan" runat="server" visible="false" style="color: #F00"></span></td>
    </tr>
  </table>
  <!-- <validanguage target="NewPassword" required="true" errorMsg="密码不能为空"> -->
  <script language="javascript" type="text/javascript">
  validanguage.settings.defaultValidationHandlers = ['submit', 'blur'];
  validanguage.el =
  {
	  RepeatPassword:
	  {
		  field: 'RepeatPassword',
		  validations:
		  [{
			  name: function () { return this.value == document.getElementById('NewPassword').value; },
			  errorMsg: '两次输入的密码不一致'
		  }]
	  }
  }
  </script>
</asp:Content>

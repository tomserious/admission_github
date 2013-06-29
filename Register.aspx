<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ Register Src="Controls/VerifyCode.ascx" TagName="VerifyCode" TagPrefix="Admission" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
  <div id="ClassTitle">新用户注册</div>
  <table id="RegisterTable">
    <tr>
      <td>用户名</td>
      <td><input name="Username" type="text" id="Username" class="Text" /></td>
      <td>用户名由1~20位的英文字母、阿拉伯数字和下划线组成</td>
    </tr>
    <tr>
      <td>密码</td>
      <td><input name="Password" type="password" id="Password" class="Text" /></td>
      <td>请选择方便记忆的密码，此密码区分大小写</td>
    </tr>
    <tr>
      <td>确认密码</td>
      <td><input name="RepeatPassword" type="password" id="RepeatPassword" class="Text" /></td>
      <td>请重复输入密码以进行确认</td>
    </tr>
    <tr>
      <td>验证码</td>
      <td><input name="VerifyCodeText" type="text" id="VerifyCodeText" class="Text" /></td>
      <td id="VerifyCodeContainer"><Admission:VerifyCode id="VerifyCode" runat="server" /></td>
    </tr>
    <tr>
      <td colspan="3"><input type="submit" name="SubmitForm" value="确认" id="SubmitForm" class="Button" disabled />
        <input type="reset" name="ResetForm" value="重填" id="ResetForm" class="Button" />
        [<a href="/">用户登录</a>]</td>
    </tr>
  </table>
  <script language="javascript" type="text/javascript">
  validanguage.settings.defaultValidationHandlers = ['submit', 'blur'];
  validanguage.el =
  {
	  Username:
	  {
		  field: 'Username',
		  required: true,
		  maxlength: 20,
		  validations:
		  [{
			  name: validateUsername,
			  isAjax: true
		  }],
		  characters:
		  {
			  mode: 'allow',
			  expression: 'alphanumeric_',
			  suppress: true,
			  errorMsg: '用户名只能由英文字母、阿拉伯数字和下划线组成'
		  }
	  },
	  Password:
	  {
		  field: 'Password',
		  required: true
	  },
	  RepeatPassword:
	  {
		  field: 'RepeatPassword',
		  validations:
		  [{
			  name: function () { return this.value == document.getElementById('Password').value; },
			  errorMsg: '两次输入的密码不一致'
		  }]
	  },
	  VerifyCodeText:
	  {
		  field: 'VerifyCodeText',
		  required: true,
		  minlength: 4,
		  maxlength: 4,
		  validations:
		  [{
			  name: validateVerifyCode,
			  isAjax: true
		  }],
		  characters:
		  {
			  mode: 'allow',
			  expression: 'numericabcdef',
			  suppress: true,
			  errorMsg: '验证码只能是阿拉伯数字和小写字母a-f'
		  }
	  }
  }
  </script>
</asp:Content>

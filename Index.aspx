<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs"
    Inherits="Index" %>

<%@ Register Src="Controls/VerifyCode.ascx" TagName="VerifyCode" TagPrefix="Admission" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top; padding: 5px 2px">
                <a href="Intro.aspx" target="_blank">
                    <img src="Images/Intro.gif" /></a><br />
                <a href="CheckIn.aspx" target="_blank">
                    <img src="Images/CheckIn.gif" /></a><div style="width: 132px; border: 1px solid #CCC; background-color: #FFC; padding: 5px; text-align: justify; text-justify: inter-ideograph">
                    <p style="text-align: center; font-weight: bold; font-size: 14px; color: #B22; margin: 5px 0">公 告</p>
                        亲爱的各位中学生朋友：<br />
                        　　2013年北京大学全国中学生信息科学夏令营选拔结果延期到7月1日公布。</div>
            </td>
            <td>
                <div id="ClassTitle">
                    用户登录</div>
                <table id="LoginTable">
                    <tr>
                        <td>
                            用户名</td>
                        <td>
                            <input name="Username" type="text" id="Username" class="Text" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码</td>
                        <td>
                            <input name="Password" type="password" id="Password" class="Text" /></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码</td>
                        <td>
                            <input name="VerifyCodeText" type="text" id="VerifyCodeText" class="Text" /></td>
                        <td id="VerifyCodeContainer">
                            <Admission:VerifyCode ID="VerifyCode" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input type="submit" name="SubmitForm" value="登录" id="SubmitForm" class="Button" />
                            <!--<a href="/Register.aspx">新用户注册</a>--><span id="ErrorSpan" runat="server" visible="false"
                                style="color: #F00">登录失败—错误的用户名或密码</span></td>
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

            </td>
        </tr>
    </table>
</asp:Content>

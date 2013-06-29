<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>系统管理登录</title>
<link href="Admin.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #C0C0C0">
<form id="MainForm" runat="server">
  <div class="LoginDiv">
    <div class="EnterArea">用户名：
      <asp:TextBox ID="UsernameBox" CssClass="TextBox" runat="server" />
      密码：
      <asp:TextBox ID="PasswordBox" TextMode="Password" CssClass="TextBox" runat="server" />
      <asp:Button ID="LoginButton" runat="server" Text="登录" CssClass="Button" OnClick="LoginButton_Click" />
    </div>
  </div>
  <div id="Footer">北京大学信息科学技术学院 版权所有<br />
    Copyright &copy; School of Electronics Engineering & Computer Science, Peking University.</div>
</form>
</body>
</html>

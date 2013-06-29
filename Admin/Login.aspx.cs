using System;

public partial class Admin_Login : System.Web.UI.Page
{
    /// <summary>
    /// 验证用户名和密码，通过则重定向到管理员根目录，否则session重新赋空值
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        Session["AdminIdent"] = Admin.Verify(UsernameBox.Text.Trim(), PasswordBox.Text);
        if (Session["AdminIdent"] != null && (bool)Session["AdminIdent"] == true)
        {
             int record_count = Users.GetAllUsers().Length;
             int pages = (record_count % 200 != 0 ? record_count / 200 + 1 : record_count / 200);
             Session["page_count"] = pages;             
            Response.Redirect("/Admin/");
        }
        else
        {
            Session["AdminIdent"] = null;
        }
    }
}

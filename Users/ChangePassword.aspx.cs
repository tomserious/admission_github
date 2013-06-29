using System;

public partial class Users_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Users user = (Users)Session["Identify"];
            if (Users.VerifyIdentity(user.Username, Request["OldPassword"]) == null)
            {
                ErrorSpan.InnerText = "原密码不正确";
                ErrorSpan.Visible = true;
                return;
            }
            else if (Request["NewPassword"] == "")
            {
                ErrorSpan.InnerText = "新密码不能为空";
                ErrorSpan.Visible = true;
                return;
            }
            else if (Request["NewPassword"] != Request["RepeatPassword"])
            {
                ErrorSpan.InnerText = "新密码与确认密码不一致";
                ErrorSpan.Visible = true;
                return;
            }
            Users.ChangePassword(user.UserID, Request["NewPassword"]);
            Response.Redirect("/Users/");
        }
    }
}

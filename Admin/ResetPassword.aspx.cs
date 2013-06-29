using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_ResetPassword : System.Web.UI.Page
{
    /// <summary>
    /// 当前用户的密码更改为135246？然后重定向到上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Users.ChangePassword(int.Parse(Request["UserID"]), "135246");
        Response.Redirect(Request.UrlReferrer.ToString());
    }
}

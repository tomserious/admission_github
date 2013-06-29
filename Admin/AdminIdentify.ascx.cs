using System;

public partial class Admin_AdminIdentify : System.Web.UI.UserControl
{
    /// <summary>
    /// 无用户session时返回登录页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["AdminIdent"] == null || (bool)Session["AdminIdent"] != true)
        {
            Response.Redirect("/Admin/Login.aspx");
        }
    }
}

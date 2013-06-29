using System;

public partial class Controls_Identify : System.Web.UI.UserControl
{
    /// <summary>
    /// 如果Identify的session不存在，重定向到index
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["Identify"] == null)
        {
            Response.Redirect("/Index.aspx");
        }
    }
}

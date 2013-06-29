using System;

public partial class Users_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Identify"] = null;
        Response.Redirect("/");
    }
}

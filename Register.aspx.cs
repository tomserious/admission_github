using System;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack && Users.IsUserExist(Request["Username"].Trim()) == false)
        {
            Users.AddUser(Request["Username"].Trim(), Request["Password"]);
            Session["Identify"] = Users.VerifyIdentity(Request["Username"].Trim(), Request["Password"]);
            Response.Redirect("/Users/Index.aspx");
        }
    }
}

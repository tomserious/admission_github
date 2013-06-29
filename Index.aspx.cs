using System;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (IsPostBack)
        {            
            Users user = Users.VerifyIdentity(Request["Username"].Trim(), Request["Password"]);
            if (user != null)
            {                
                Session["Identify"] = user;
                Response.Redirect("/Users/Result.aspx");
               // Response.Redirect("/Users/Index.aspx");
            }
            else
            {
                ErrorSpan.Visible = true;
            }
        }
    }
}

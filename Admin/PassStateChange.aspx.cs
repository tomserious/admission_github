using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PassStateChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(Request["UserID"]);
        string statenow=(string)Request["StateNow"];
        Users.changeState(statenow,userID);
        Response.Redirect("Index.aspx");
    }
}
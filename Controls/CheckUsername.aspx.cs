using System;

public partial class Controls_CheckUsername : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(string.Format("{{ \"returnCode\": \"{0}\", \"ajaxCounter\": {1} }}", Request["Username"] != null && Users.IsUserExist(Request["Username"]) == false, Request["AjaxCounter"]));
    }
}

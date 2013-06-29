using System;

public partial class Controls_CheckVerifyCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(string.Format("{{ \"returnCode\": \"{0}\", \"ajaxCounter\": {1} }}", Request["VerifyCode"] != null && Request["VerifyCode"] == Session["VerifyCode"].ToString(), Request["AjaxCounter"]));
    }
}

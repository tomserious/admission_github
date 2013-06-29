using System;

public partial class Users_HonorsDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["HonorID"] != null && Honor.GetHonorByID(int.Parse(Request["HonorID"])).UserID == ((Users)Session["Identify"]).UserID)
            Honor.DeleteHonor(int.Parse(Request["HonorID"]));
        Response.Redirect("Honors.aspx");
    }
}

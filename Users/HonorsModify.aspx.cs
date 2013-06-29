using System;

public partial class Users_HonorsModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Honor honor = null;
        if (!IsPostBack)
        {
            if (Request["HonorID"] != null && (honor = Honor.GetHonorByID(int.Parse(Request["HonorID"]))).UserID == ((Users)Session["Identify"]).UserID)
            {
                HonorDate.Text = honor.HonorDate.ToString("yyyy-M");
                HonorName.Text = honor.HonorName;
                HonorRank.Text = honor.HonorRank;
            }
            else
                Response.Redirect("Honors.aspx");

        }
    }

    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        Honor honor = new Honor();
        honor.HonorDate = DateTime.Parse(HonorDate.Text);
        honor.HonorName = HonorName.Text.Trim();
        honor.HonorRank = HonorRank.Text.Trim();
        if (Request["HonorID"] != null && Honor.GetHonorByID(int.Parse(Request["HonorID"])).UserID == ((Users)Session["Identify"]).UserID)
        {
            Honor.UpdateHonor(int.Parse(Request["HonorID"]), honor);
        }
        Response.Redirect("Honors.aspx");
    }
}

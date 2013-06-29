using System;

public partial class Users_HonorsAdd : System.Web.UI.Page
{
    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        Honor honor = new Honor();
        honor.UserID = ((Users)Session["Identify"]).UserID;
        honor.HonorDate = DateTime.Parse(HonorDate.Text);
        honor.HonorName = HonorName.Text.Trim();
        honor.HonorRank = HonorRank.Text.Trim();
        Honor.AddHonor(honor.UserID, honor);
        Response.Redirect("Honors.aspx");
    }
}

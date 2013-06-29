using System;

public partial class Users_Headmaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Headmaster hm;
        if (!IsPostBack && (hm = Headmaster.GetHeadmasterByID(((Users)Session["Identify"]).UserID)) != null)
        {
            Name.Text = hm.Name;
            OfficePhone.Text = hm.OfficePhone;
            Fax.Text = hm.Fax;
            Mobile.Text = hm.Mobile;
        }
    }

    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        Headmaster hm = new Headmaster();
        hm.UserID = ((Users)Session["Identify"]).UserID;
        hm.Name = Name.Text.Trim();
        hm.OfficePhone = OfficePhone.Text.Trim();
        hm.Fax = Fax.Text.Trim();
        hm.Mobile = Mobile.Text.Trim();
        Headmaster.SetHeadmasterByID(hm.UserID, hm);
        Response.Redirect("/Users/Index.aspx");
    }
}

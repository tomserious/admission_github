using System;

public partial class Users_FamilyMembersModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FamilyMember fm = null;
        if (!IsPostBack)
        {
            if (Request["MemberID"] != null && (fm = FamilyMember.GetMemberByID(int.Parse(Request["MemberID"]))).UserID == ((Users)Session["Identify"]).UserID)
            {
                RelationType.Text = fm.RelationType;
                MemberName.Text = fm.MemberName;
                Organization.Text = fm.Organization;
                Title.Text = fm.Title;
                Phone.Text = fm.Phone;
            }
            else
                Response.Redirect("FamilyMembers.aspx");

        }
    }

    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        FamilyMember fm = new FamilyMember();
        fm.RelationType = RelationType.Text.Trim();
        fm.MemberName = MemberName.Text.Trim();
        fm.Organization = Organization.Text.Trim();
        fm.Title = Title.Text.Trim();
        fm.Phone = Phone.Text.Trim();
        if (Request["MemberID"] != null && FamilyMember.GetMemberByID(int.Parse(Request["MemberID"])).UserID == ((Users)Session["Identify"]).UserID)
        {
            FamilyMember.UpdateMember(int.Parse(Request["MemberID"]), fm);
        }
        Response.Redirect("FamilyMembers.aspx");
    }
}

using System;

public partial class Users_FamilyMembersAdd : System.Web.UI.Page
{
    protected void OnSubmit_Click(object sender, EventArgs e)
    {
        FamilyMember fm = new FamilyMember();
        fm.UserID = ((Users)Session["Identify"]).UserID;
        fm.RelationType = RelationType.Text.Trim();
        fm.MemberName = MemberName.Text.Trim();
        fm.Organization = Organization.Text.Trim();
        fm.Title = Title.Text.Trim();
        fm.Phone = Phone.Text.Trim();
        FamilyMember.AddMember(fm.UserID, fm);
        Response.Redirect("FamilyMembers.aspx");
    }
}

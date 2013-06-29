using System;

public partial class Users_FamilyMembersDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["MemberID"] != null && FamilyMember.GetMemberByID(int.Parse(Request["MemberID"])).UserID == ((Users)Session["Identify"]).UserID)
            FamilyMember.DeleteMember(int.Parse(Request["MemberID"]));
        Response.Redirect("FamilyMembers.aspx");
    }
}

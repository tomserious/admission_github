using System;
using System.Web.UI.WebControls;

public partial class Users_FamilyMembers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (FamilyMember fm in FamilyMember.GetAllMembers(((Users)Session["Identify"]).UserID))
        {
            TableRow row = new TableRow();
            TableCell[] cells = new TableCell[6];
            for (int i = 0; i < 6; i++)
            {
                cells[i] = new TableCell();
            }
            cells[0].Text = fm.RelationType;
            cells[1].Text = fm.MemberName;
            cells[2].Text = fm.Organization;
            cells[3].Text = fm.Title;
            cells[4].Text = fm.Phone;
            cells[5].Text = string.Format("<a href=\"FamilyMembersModify.aspx?MemberID={0}\">修改</a> <a href=\"FamilyMembersDelete.aspx?MemberID={0}\">删除</a>", fm.MemberID);
           // cells[5].Text = "不可更改";
            row.Cells.AddRange(cells);
            FamilyMembersList.Rows.Add(row);
        }
        if (FamilyMembersList.Rows.Count == 1)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.ColumnSpan = 6;
            cell.CssClass = "NoData";
            cell.Text = "没有数据";
            row.Cells.Add(cell);
            FamilyMembersList.Rows.Add(row);
        }
    }
}

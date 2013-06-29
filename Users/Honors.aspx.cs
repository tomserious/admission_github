using System;
using System.Web.UI.WebControls;

public partial class Users_Honors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Honor honor in Honor.GetAllHonors(((Users)Session["Identify"]).UserID))
        {
            TableRow row = new TableRow();
            TableCell[] cells = new TableCell[3];
            cells[0] = new TableCell();
            cells[0].Width = Unit.Percentage(15);
            cells[0].Text = string.Format("{0:yyyy年M月}", honor.HonorDate);
            cells[1] = new TableCell();
            cells[1].Width = Unit.Percentage(78);
            cells[1].Text = string.Format("{0} {1}", honor.HonorName, honor.HonorRank);
            cells[2] = new TableCell();
            cells[2].Width = Unit.Percentage(7);
            cells[2].Text = string.Format("<a href=\"HonorsModify.aspx?HonorID={0}\">修改</a> <a href=\"HonorsDelete.aspx?HonorID={0}\">删除</a>", honor.HonorID);
            row.Cells.AddRange(cells);
            HonorsList.Rows.Add(row);
        }
        if (HonorsList.Rows.Count == 0)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.ColumnSpan = 6;
            cell.CssClass = "NoData";
            cell.Text = "没有数据";
            row.Cells.Add(cell);
            HonorsList.Rows.Add(row);
        }
    }
}

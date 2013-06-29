using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ToSchool : System.Web.UI.Page
{
    /// <summary>
    /// 初始化页面，通过与不通过用不同底色表示；相邻行用不同格式
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        int counter = 0;
        
        string page = Request.QueryString["current_page"];
        int current_page = Convert.ToInt32(page)==0?1:Convert.ToInt32(page);
        int page_count = (int)Session["page_count"];

       string pageIndex="第 ";
       for (int i = 1; i <= page_count;i++ )
       {
           pageIndex += string.Format("<a href ='/Admin/ToSchool.aspx?current_page={0}'>{1}  </a>",i,i);          
       }
       pageIndex += " 页";
       PageIndex.Text = pageIndex;
        #region 新的，分页放
        int from=(current_page-1)*200+1;
        int to=current_page*200;
        foreach (Users user in Users.GetPartialUsers(from, to))
        {
            counter++;
            string buff;
            if (counter % 2 != 0)
                buff = "<tr class=\"RowA\">";
            else
                buff = "<tr class=\"RowB\">";
            buff += string.Format("<td>A2013{0:d4}</td>", user.UserID);
            BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
            if (bi == null)
                buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
            else
                buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", bi.Name, bi.Gender ? "男" : "女", bi.Race, "高中", bi.IDCard, bi.SchoolName);

            buff += "</tr>";
            UserRowsTemp_school.Text += buff;
        }
    #endregion

        #region 原来的，全部放一页
        //foreach (Users user in Users.GetAllUsers())
        //{
        //    counter++;
        //    string buff;
        //    if (counter % 2 != 0)
        //        buff = "<tr class=\"RowA\">";
        //    else
        //        buff = "<tr class=\"RowB\">";
        //    buff += string.Format("<td>A2013{0:d4}</td>", user.UserID);
        //    BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
        //    if (bi == null)
        //        buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
        //    else
        //        buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", bi.Name, bi.Gender ? "男" : "女", bi.Race, "高中", bi.IDCard, bi.SchoolName);

        //    buff += "</tr>";
        //    UserRowsTemp_school.Text += buff;
        //}
        #endregion 
    }


    public GridView creatView()
    {
        GridView gv = new GridView();
        gv.AutoGenerateColumns = false;

        BoundField user_ID = new BoundField();
        user_ID.DataField = "user_ID";
        user_ID.HeaderText = "报名号";        
        BoundField name = new BoundField();
        name.DataField = "name";
        name.HeaderText = "姓名";
        BoundField user_gender = new BoundField();
        user_gender.DataField = "user_gender";
        user_gender.HeaderText = "性别";
        BoundField user_race = new BoundField();
        user_race.DataField = "user_race";
        user_race.HeaderText = "民族";
        BoundField education = new BoundField();
        education.DataField = "education";
        education.HeaderText = "学历";
        BoundField user_IDcard = new BoundField();
        user_IDcard.DataField = "user_IDcard";
        user_IDcard.HeaderText = "身份证号";
        BoundField user_school = new BoundField();
        user_school.DataField = "user_school";
        user_school.HeaderText = "学校";

        gv.Columns.Add(user_ID);
        gv.Columns.Add(name);
        gv.Columns.Add(user_gender);
        gv.Columns.Add(user_race);
        gv.Columns.Add(education);
        gv.Columns.Add(user_IDcard);
        gv.Columns.Add(user_school);

        DataTable userList = new DataTable();
        userList = createTable();
        //string test = userList.Rows[0][1].ToString();

        gv.DataSource = userList.DefaultView;
        gv.DataBind();

        return gv;

    }

    /// <summary>
    /// 从数据库中查询数据，动态生成datatable
    /// </summary>
    /// <returns></returns>
    public DataTable createTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("user_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("user_gender", typeof(string)));
        dt.Columns.Add(new DataColumn("user_race", typeof(string)));
        dt.Columns.Add(new DataColumn("education", typeof(string)));
        dt.Columns.Add(new DataColumn("user_IDcard", typeof(string)));
        dt.Columns.Add(new DataColumn("user_school", typeof(string)));

        foreach (Users user in Users.GetAllUsers())
        {
            //为创建的DataTable添加列
            DataRow dr = dt.NewRow();
            BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
            if (bi == null)
            {
                dr["user_ID"] = string.Format("A2013{0:d4}", user.UserID);
                dr["name"] = "未填写";//
                dr["user_gender"] = "未填写";//
                dr["user_race"] = "未填写";// 
                dr["education"] = "未填写";
                dr["user_IDcard"] = "未填写";//
                dr["user_school"] = "未填写";//"TOM";//
                
            }
            else
            {
                dr["user_ID"] = string.Format("A2013{0:d4}", user.UserID);
                dr["name"] = bi.Name;//
                dr["user_gender"] = bi.Gender?"男":"女";//
                dr["user_race"] = bi.Race;// 
                dr["education"] = "高中";
                dr["user_IDcard"] = bi.IDCard;//
                dr["user_school"] = bi.SchoolName;//"TOM";//
            }

            dt.Rows.Add(dr);

        }

        return dt;
    }
    /// <summary>
    /// 导出gridview为EXCEL
    /// </summary>
    /// <param name="GridView1"></param>
    public void Export(GridView GridView1)
    {
        //Excel.ApplicationClass oExcel = new Excel.ApplicationClass();
        Excel.ApplicationClass oExcel = new Excel.ApplicationClass();
        object oMissing = System.Reflection.Missing.Value;
        oExcel.Workbooks.Add(oMissing);
        Excel.Workbook oBook = oExcel.Workbooks[1];
        Excel.Worksheet oSheet = (Excel.Worksheet)oBook.Sheets[1];
        oSheet.Name = "上报学校名单";//this.Title;

        Excel.Range rg;

        //String test = GridView1.Rows[0].Cells[0].Text;


        for (int j = 0; j < GridView1.HeaderRow.Cells.Count; j++)
        {
            rg = ((Excel.Range)oSheet.Cells[1, j + 1]);           
            rg.FormulaR1C1 = GridView1.HeaderRow.Cells[j].Text;
        }

        
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[0].Cells.Count; j++)
            {
                rg = ((Excel.Range)oSheet.Cells[i + 2, j + 1]);
                rg.NumberFormatLocal = "@";//设置单元格格式为字符型
                rg.FormulaR1C1 = GridView1.Rows[i].Cells[j].Text;
            }
        }
        rg = null;

        string VirFileName = Guid.NewGuid().ToString() + ".xls";
        oBook.SaveAs(Server.MapPath(VirFileName), Excel.XlFileFormat.xlExcel9795, oMissing, oMissing, oMissing, oMissing, Excel.XlSaveAsAccessMode.xlExclusive,
        oMissing, oMissing, oMissing, oMissing, oMissing);
        oExcel.Workbooks.Close();
        oExcel.Quit();

        oSheet = null;
        oBook = null;
        oExcel = null;

        GC.Collect();

        Response.Redirect(VirFileName);
    }


    /// <summary>
    /// button触发事件，调用方法导出EXCEL
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ExportToExcel(object sender, EventArgs e)
    {
        //ToExcel(this.export); 
        GridView mine = creatView();
        Export(mine);

    }
}
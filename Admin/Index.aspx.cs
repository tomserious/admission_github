using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;




public partial class Admin_Index : System.Web.UI.Page
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
           pageIndex += string.Format("<a href ='/Admin/Index.aspx?current_page={0}'>{1}  </a>",i,i);          
       }
       pageIndex += " 页";
       PageIndex.Text = pageIndex;
    #region 新的，分页放
        int from=(current_page-1)*200+1;
        int to=current_page*200;
        foreach(Users user in Users.GetPartialUsers(from,to))
        {
            string buff;
            if (counter % 2 != 0)
                buff = "<tr class=\"RowA\">";
            else
                buff = "<tr class=\"RowB\">";
            buff += string.Format("<td>A2013{0:d4}</td><td>{1}</td>", user.UserID, user.Username);
            BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
            if (bi == null)
                buff += "<td>-</td><td>-</td><td>-</td><td>-</td>";
            else
                buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", bi.Name, bi.SchoolName, bi.FamilyPhone, bi.OtherPhone);
            if (user.Result == Users.VerifyResult.Pass)
            {
                buff += string.Format("<td style=\"background-color: #090; color: #FFF\"><a href=\"PassStateChange.aspx?UserID={0}&StateNow={1}\">通过</a></td>", user.UserID, "通过");
            }
            else
            {
                buff += string.Format("<td style=\"background-color: #900; color: #FFF\"><a href=\"PassStateChange.aspx?UserID={0}&StateNow={1}\">未通过</a></td>", user.UserID, "未通过");
            }
            buff += string.Format("<td><a href=\"ResetPassword.aspx?UserID={0}\">重置密码</a></td>", user.UserID);
            buff += "</tr>";
            UserRowsTemp.Text += buff;
        }
#endregion 

       #region 原来的，全部记录放一页
       //foreach (Users user in Users.GetAllUsers())
       // {
            
       //     string buff;
       //     if (counter % 2 != 0)
       //         buff = "<tr class=\"RowA\">";
       //     else
       //         buff = "<tr class=\"RowB\">";
       //     buff += string.Format("<td>A2013{0:d4}</td><td>{1}</td>", user.UserID, user.Username);
       //     BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
       //     if (bi == null)
       //         buff += "<td>-</td><td>-</td><td>-</td><td>-</td>";
       //     else
       //         buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", bi.Name, bi.SchoolName, bi.FamilyPhone, bi.OtherPhone);
       //     if (user.Result == Users.VerifyResult.Pass)
       //     {
       //         buff += string.Format("<td style=\"background-color: #090; color: #FFF\"><a href=\"PassStateChange.aspx?UserID={0}&StateNow={1}\">通过</a></td>", user.UserID,"通过");
       //     }
       //     else
       //     {
       //         buff += string.Format("<td style=\"background-color: #900; color: #FFF\"><a href=\"PassStateChange.aspx?UserID={0}&StateNow={1}\">未通过</a></td>", user.UserID,"未通过");
       //     }
       //     buff += string.Format("<td><a href=\"ResetPassword.aspx?UserID={0}\">重置密码</a></td>", user.UserID);
       //     buff += "</tr>";
       //     UserRowsTemp.Text += buff;
       // }
       #endregion
        #region
        /*
        foreach (Users user in Users.GetAllUsers())
        {
            counter++;
            string buff;
            if (counter % 2 != 0)
                buff = "<tr class=\"RowA\">";
            else
                buff = "<tr class=\"RowB\">";
            buff += string.Format("<td>{0}</td><td>{1}</td>", counter, user.Username);
            bool allPass = true;
            if (BasicInfo.HasBasicInfo(user.UserID))
            {
                buff += "<td class=\"Pass\">已填</td>";
            }
            else
            {
                buff += "<td class=\"NotPass\">未填</td>";
                allPass = false;
            }
            if (FamilyMember.GetAllMembers(user.UserID).Length != 0)
            {
                buff += "<td class=\"Pass\">已填</td>";
            }
            else
            {
                buff += "<td class=\"NotPass\">未填</td>";
                allPass = false;
            }
            if (Performance.HasPerformance(user.UserID))
            {
                buff += "<td class=\"Pass\">已填</td>";
            }
            else
            {
                buff += "<td class=\"NotPass\">未填</td>";
                allPass = false;
            }
            if (Headmaster.HasHeadmaster(user.UserID))
            {
                buff += "<td class=\"Pass\">已填</td>";
            }
            else
            {
                buff += "<td class=\"NotPass\">未填</td>";
                allPass = false;
            }
            if (Honor.GetAllHonors(user.UserID).Length != 0)
            {
                buff += "<td class=\"Pass\">已填</td>";
            }
            else
            {
                buff += "<td class=\"NotPass\">未填</td>";
            }
            if (allPass)
            {
                buff += string.Format("<td><a href=\"Audit.aspx?UserID={0}\">审核</a></td>", user.UserID);
            }
            else
            {
                buff += "<td></td>";
            }
            buff += "</tr>";
            UserRows.Text += buff;
        }
        */
#endregion 
    }
    /// <summary>
    /// button触发事件，调用方法导出EXCEL
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ExportToExcel(object sender,EventArgs e)
    {
        //ToExcel(this.export); 
        GridView mine = creatView();
        Export(mine);
        
    }
    /// <summary>
    /// 不好用这个
    /// </summary>
    /// <param name="ctl"></param>
    public void ToExcel(System.Web.UI.Control ctl)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        string filename = "Report" + System.DateTime.Now.ToString("_yyyyMMddHHmm");
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" +
        System.Web.HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) + ".xls");
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HttpContext.Current.Response.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 

        ctl.Page.EnableViewState = false;
        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        ctl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();

    }
    /// <summary>
    /// 创建dataview，用于下一步导出EXCEL
    /// </summary>
    /// <returns></returns>
    public GridView creatView()
    {       
        GridView gv = new GridView();
        gv.AutoGenerateColumns = false;

        BoundField user_ID = new BoundField();
        user_ID.DataField = "user_ID";
        user_ID.HeaderText = "报名号";
        BoundField user_name = new BoundField();
        user_name.DataField = "user_name";
        user_name.HeaderText = "用户名";
        BoundField name = new BoundField();
        name.DataField = "name";
        name.HeaderText = "姓名";
        BoundField school = new BoundField();
        school.DataField = "school";
        school.HeaderText = "学校";
        BoundField home_phone = new BoundField();
        home_phone.DataField = "home_phone";
        home_phone.HeaderText = "家庭电话";
        BoundField other_phone = new BoundField();
        other_phone.DataField = "other_phone";
        other_phone.HeaderText = "其他电话";
        BoundField state = new BoundField();
        state.DataField = "state";
        state.HeaderText = "状态";

        gv.Columns.Add(user_ID);
        gv.Columns.Add(user_name);
        gv.Columns.Add(name);
        gv.Columns.Add(school);
        gv.Columns.Add(home_phone);
        gv.Columns.Add(other_phone);
        gv.Columns.Add(state);

        DataTable userList=new DataTable();
        userList=createTable();
        //string test = userList.Rows[0][1].ToString();

        gv.DataSource = userList.DefaultView;
        gv.DataBind();

        return gv;

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
        oSheet.Name = "报名情况统计";//this.Title;

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
    /// 从数据库中查询数据，动态生成datatable
    /// </summary>
    /// <returns></returns>
    public DataTable createTable()
    {        
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("user_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("user_name", typeof(string)));
        dt.Columns.Add(new DataColumn("name", typeof(string)));
        dt.Columns.Add(new DataColumn("school", typeof(string)));
        dt.Columns.Add(new DataColumn("home_phone", typeof(string)));
        dt.Columns.Add(new DataColumn("other_phone", typeof(string)));
        dt.Columns.Add(new DataColumn("state", typeof(string)));

        foreach (Users user in Users.GetAllUsers())
        {
            //为创建的DataTable添加列
            DataRow dr = dt.NewRow();
            BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
            if (bi == null)
            {
                dr["user_ID"] = string.Format("A2013{0:d4}", user.UserID);
                dr["user_name"] = user.Username;//"TOM";//
                dr["name"] = "未填写";//
                dr["school"] = "未填写";// 
                dr["home_phone"] = "未填写";// 
                dr["other_phone"] = "未填写";//
                if (user.Result == Users.VerifyResult.Pass)
                {
                    dr["state"] = "通过";
                }
                else
                {
                    dr["state"] = "未通过";
                }
            }
            else
            {
                dr["user_ID"] = string.Format("A2013{0:d4}", user.UserID);
                dr["user_name"] = user.Username;//"TOM";//
                dr["name"] = bi.Name;//"马晓伟";//
                dr["school"] = bi.SchoolName;//"北京大学附属中学";// 
                dr["home_phone"] = bi.FamilyPhone;//"010-51683664";// 
                dr["other_phone"] = bi.OtherPhone;//"010-51683664";//
                if (user.Result == Users.VerifyResult.Pass)
                {
                    dr["state"] = "通过";
                }
                else
                {
                    dr["state"] = "未通过";
                }
            }
           
            dt.Rows.Add(dr);

        }       
        
        return dt;
    }
    
}

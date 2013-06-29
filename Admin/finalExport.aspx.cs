using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_finalExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int counter = 0;

        string page = Request.QueryString["current_page"];
        int current_page = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);
        int page_count = (int)Session["page_count"];

        string pageIndex = "第 ";
        for (int i = 1; i <= page_count; i++)
        {
            pageIndex += string.Format("<a href ='/Admin/ForExpert.aspx?current_page={0}'>{1}  </a>", i, i);
        }
        pageIndex += " 页";
        PageIndex.Text = pageIndex;
        #region 新的，分页放
        int from = (current_page - 1) * 200 + 1;
        int to = current_page * 200;
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
            Honor[] hi = Honor.GetAllHonors(user.UserID);
            Performance pi = Performance.GetPerformanceByID(user.UserID);
            if (bi == null)
                buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
            else
                buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>", bi.Name, bi.Gender ? "男" : "女", bi.Race, bi.IDCard, bi.Province, bi.SchoolName, bi.FamilyPhone, bi.OtherPhone);

            if (pi == null)
                buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
            else
            {
                buff += string.Format("<td>{0}/{1}</td><td>{2}/{3}</td><td>{4}/{5}</td>", pi.Term1Rank, pi.Term1Total, pi.Term2Rank, pi.Term2Total, pi.Term3Rank, pi.Term3Total);
                buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term1Chinese, pi.Term1English, pi.Term1Math, pi.Term1Physics, pi.Term1Chemistry);
                buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term2Chinese, pi.Term2English, pi.Term2Math, pi.Term2Physics, pi.Term2Chemistry);
                buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term3Chinese, pi.Term3English, pi.Term3Math, pi.Term3Physics, pi.Term3Chemistry);
            }

            if (hi.Length == 0)
                buff += "<td>-</td>";
            else
            {
                string temp = "";
                for (int i = 0; i < hi.Length; i++)
                {
                    temp += hi[i].HonorDate.ToString("yyyy-MM") + " " + hi[i].HonorName + " " + hi[i].HonorRank + "; ";
                }
                buff += string.Format("<td>{0}</td>", temp);
            }

            buff += "<td>-</td>";

            buff += "</tr>";
            UserRowsTemp.Text += buff;
        }
        #endregion
        #region 原来的，全部一页
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
        //    Honor[] hi = Honor.GetAllHonors(user.UserID);
        //    Performance pi = Performance.GetPerformanceByID(user.UserID);
        //    if (bi == null)
        //        buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
        //    else
        //        buff += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>", bi.Name, bi.Gender ? "男" : "女", bi.Race, bi.IDCard, bi.Province, bi.SchoolName, bi.FamilyPhone, bi.OtherPhone);

        //    if (pi == null)
        //        buff += "<td>-</td><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td>";
        //    else
        //    {
        //        buff += string.Format("<td>{0}/{1}</td><td>{2}/{3}</td><td>{4}/{5}</td>", pi.Term1Rank, pi.Term1Total, pi.Term2Rank, pi.Term2Total, pi.Term3Rank, pi.Term3Total);
        //        buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term1Chinese, pi.Term1English, pi.Term1Math, pi.Term1Physics, pi.Term1Chemistry);
        //        buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term2Chinese, pi.Term2English, pi.Term2Math, pi.Term2Physics, pi.Term2Chemistry);
        //        buff += string.Format("<td>语文：{0}，英语：{1}，数学：{2}，物理：{3}，化学：{4}</td>", pi.Term3Chinese, pi.Term3English, pi.Term3Math, pi.Term3Physics, pi.Term3Chemistry);
        //    }

        //    if (hi.Length == 0)
        //        buff += "<td>-</td>";
        //    else
        //    {
        //        string temp = "";
        //        for (int i = 0; i < hi.Length; i++)
        //        {
        //            temp += hi[i].HonorDate.ToString("yyyy-MM") + " " + hi[i].HonorName + " " + hi[i].HonorRank + "; ";
        //        }
        //        buff += string.Format("<td>{0}</td>", temp);
        //    }

        //    buff += "<td>-</td>";

        //    buff += "</tr>";
        //    UserRowsTemp.Text += buff;
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
        BoundField user_birth = new BoundField();
        user_birth.DataField = "user_birth";
        user_birth.HeaderText = "出生日期";
        BoundField user_IDcard = new BoundField();
        user_IDcard.DataField = "user_IDcard";
        user_IDcard.HeaderText = "身份证号";
        BoundField user_Province = new BoundField();
        user_Province.DataField = "user_Province";
        user_Province.HeaderText = "省份";
        BoundField user_school = new BoundField();
        user_school.DataField = "user_school";
        user_school.HeaderText = "学校";
        BoundField user_schoolAddr = new BoundField();
        user_schoolAddr.DataField = "user_schoolAddr";
        user_schoolAddr.HeaderText = "学校地址";
        BoundField user_schoolPC = new BoundField();
        user_schoolPC.DataField = "user_schoolPC";
        user_schoolPC.HeaderText = "学校邮编";
        BoundField user_familyAddr = new BoundField();
        user_familyAddr.DataField = "user_familyAddr";
        user_familyAddr.HeaderText = "家庭住址";
        BoundField user_familyPC = new BoundField();
        user_familyPC.DataField = "user_familyPC";
        user_familyPC.HeaderText = "家庭邮编";
        BoundField user_familyMember = new BoundField();
        user_familyMember.DataField = "user_familyMember";
        user_familyMember.HeaderText = "家庭成员";
        BoundField user_phone = new BoundField();
        user_phone.DataField = "user_phone";
        user_phone.HeaderText = "联系电话";
        BoundField other_phone = new BoundField();
        other_phone.DataField = "other_phone";
        other_phone.HeaderText = "其他电话";
        BoundField headmaster = new BoundField();
        headmaster.DataField = "headmaster";
        headmaster.HeaderText = "校长姓名";
        BoundField headmaster_phone = new BoundField();
        headmaster_phone.DataField = "headmaster_phone";
        headmaster_phone.HeaderText = "校长办公电话";
        BoundField headmaster_fax = new BoundField();
        headmaster_fax.DataField = "headmaster_fax";
        headmaster_fax.HeaderText = "校长传真";
        BoundField headmaster_mobile = new BoundField();
        headmaster_mobile.DataField = "headmaster_mobile";
        headmaster_mobile.HeaderText = "校长手机";
        BoundField term1_rank = new BoundField();
        term1_rank.DataField = "term1_rank";
        term1_rank.HeaderText = "高一排名";
        BoundField term2_rank = new BoundField();
        term2_rank.DataField = "term2_rank";
        term2_rank.HeaderText = "高二排名";
        BoundField term3_rank = new BoundField();
        term3_rank.DataField = "term3_rank";
        term3_rank.HeaderText = "高三排名";
        BoundField term1_perfo = new BoundField();
        term1_perfo.DataField = "term1_perfo";
        term1_perfo.HeaderText = "高一成绩";
        BoundField term2_perfo = new BoundField();
        term2_perfo.DataField = "term2_perfo";
        term2_perfo.HeaderText = "高二成绩";
        BoundField term3_perfo = new BoundField();
        term3_perfo.DataField = "term3_perfo";
        term3_perfo.HeaderText = "高三成绩";
        BoundField user_honor = new BoundField();
        user_honor.DataField = "user_honor";
        user_honor.HeaderText = "获奖情况";
        BoundField user_note = new BoundField();
        user_note.DataField = "user_note";
        user_note.HeaderText = "备注信息";

        gv.Columns.Add(user_ID);
        gv.Columns.Add(name);
        gv.Columns.Add(user_gender);
        gv.Columns.Add(user_race);
        gv.Columns.Add(user_IDcard);
        gv.Columns.Add(user_birth);
        gv.Columns.Add(user_Province);
        gv.Columns.Add(user_school);
        gv.Columns.Add(user_schoolAddr);
        gv.Columns.Add(user_schoolPC);
        gv.Columns.Add(user_familyAddr);
        gv.Columns.Add(user_familyPC);
        gv.Columns.Add(user_familyMember);
        gv.Columns.Add(user_phone);
        gv.Columns.Add(other_phone);
        gv.Columns.Add(headmaster);
        gv.Columns.Add(headmaster_phone);
        gv.Columns.Add(headmaster_fax);
        gv.Columns.Add(headmaster_mobile);
        gv.Columns.Add(term1_rank);
        gv.Columns.Add(term2_rank);
        gv.Columns.Add(term3_rank);
        gv.Columns.Add(term1_perfo);
        gv.Columns.Add(term2_perfo);
        gv.Columns.Add(term3_perfo);
        gv.Columns.Add(user_honor);
        gv.Columns.Add(user_note);

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
        dt.Columns.Add(new DataColumn("user_birth", typeof(string)));
        dt.Columns.Add(new DataColumn("user_IDcard", typeof(string)));
        dt.Columns.Add(new DataColumn("user_Province", typeof(string)));
        dt.Columns.Add(new DataColumn("user_school", typeof(string)));
        dt.Columns.Add(new DataColumn("user_schoolAddr", typeof(string)));
        dt.Columns.Add(new DataColumn("user_schoolPC", typeof(string)));
        dt.Columns.Add(new DataColumn("user_familyAddr", typeof(string)));
        dt.Columns.Add(new DataColumn("user_familyPC", typeof(string)));
        dt.Columns.Add(new DataColumn("user_familyMember", typeof(string)));
        dt.Columns.Add(new DataColumn("user_phone", typeof(string)));
        dt.Columns.Add(new DataColumn("other_phone", typeof(string)));
        dt.Columns.Add(new DataColumn("headmaster", typeof(string)));
        dt.Columns.Add(new DataColumn("headmaster_phone", typeof(string)));
        dt.Columns.Add(new DataColumn("headmaster_fax", typeof(string)));
        dt.Columns.Add(new DataColumn("headmaster_mobile", typeof(string)));
        dt.Columns.Add(new DataColumn("term1_rank", typeof(string)));
        dt.Columns.Add(new DataColumn("term2_rank", typeof(string)));
        dt.Columns.Add(new DataColumn("term3_rank", typeof(string)));
        dt.Columns.Add(new DataColumn("term1_perfo", typeof(string)));
        dt.Columns.Add(new DataColumn("term2_perfo", typeof(string)));
        dt.Columns.Add(new DataColumn("term3_perfo", typeof(string)));
        dt.Columns.Add(new DataColumn("user_honor", typeof(string)));
        dt.Columns.Add(new DataColumn("user_note", typeof(string)));

        //int tempcount = 0;
        foreach (Users user in Users.GetAllUsers())
        {
            //为创建的DataTable添加列
            DataRow dr = dt.NewRow();
            BasicInfo bi = BasicInfo.GetBasicInfoByID(user.UserID);
            Performance pi = Performance.GetPerformanceByID(user.UserID);
            Honor[] hi = Honor.GetAllHonors(user.UserID);
            Headmaster headi = Headmaster.GetHeadmasterByID(user.UserID);
            FamilyMember[] fi = FamilyMember.GetAllMembers(user.UserID);
            #region 查询数据库，填充datatable
            if (bi == null)
            {
                dr["user_ID"] = "A20130000";//string.Format("A2013{0:d4}", user.UserID);
                dr["name"] = "未填写";//
                dr["user_gender"] = "未填写";//
                dr["user_race"] = "未填写";// 
                dr["user_birth"] = "未填写";
                dr["user_IDcard"] = "未填写";//
                dr["user_Province"] = "未填写";// 
                dr["user_school"] = "未填写";//"TOM";//
                dr["user_schoolAddr"] = "未填写";
                dr["user_schoolPC"] = "未填写";
                dr["user_familyAddr"] = "未填写";
                dr["user_familyPC"] = "未填写";                
                dr["user_phone"] = "未填写";
                dr["other_phone"] = "未填写";
            }
            else
            {
                dr["user_ID"] = string.Format("A2013{0:d4}", user.UserID);
                dr["name"] = bi.Name;//
                dr["user_gender"] = bi.Gender ? "男" : "女";//
                dr["user_race"] = bi.Race;//  
                dr["user_birth"] = bi.Birthday;
                dr["user_IDcard"] = bi.IDCard;//   
                dr["user_Province"] = bi.Province;
                dr["user_school"] = bi.SchoolName;//"TOM";//
                dr["user_schoolAddr"] = bi.SchoolAddr;
                dr["user_schoolPC"] = bi.SchoolPC;
                dr["user_familyAddr"] = bi.FamilyAddr;
                dr["user_familyPC"] = bi.FamilyPC;
                dr["user_phone"] = bi.FamilyPhone;
                dr["other_phone"] = bi.OtherPhone;
            }
            if (headi == null)
            {
                dr["headmaster"] = "未填写";
                dr["headmaster_phone"] = "未填写";
                dr["headmaster_fax"] = "未填写";
                dr["headmaster_mobile"] = "未填写";
            }
            else
            {
                dr["headmaster"] = headi.Name;
                dr["headmaster_phone"] = headi.OfficePhone;
                dr["headmaster_fax"] = headi.Fax;
                dr["headmaster_mobile"] = headi.Mobile;
            }

            if (pi == null)
            {
                dr["term1_rank"] = "未填写";//"A20130001";//
                dr["term2_rank"] = "未填写";//
                dr["term3_rank"] = "未填写";//
                dr["term1_perfo"] = "未填写";//                 
                dr["term2_perfo"] = "未填写";//
                dr["term3_perfo"] = "未填写";
            }
            else
            {
                dr["term1_rank"] = pi.Term1Rank + "/" + pi.Term1Total;//"A20130001";//
                dr["term2_rank"] = pi.Term2Rank + "/" + pi.Term2Total;//
                dr["term3_rank"] = pi.Term3Rank + "/" + pi.Term3Total;
                dr["term1_perfo"] = "语文：" + pi.Term1Chinese + "，英语：" + pi.Term1English + "数学：" + pi.Term1Math + "，物理：" + pi.Term1Physics + "，化学：" + pi.Term1Chemistry;
                dr["term2_perfo"] = "语文：" + pi.Term2Chinese + "，英语：" + pi.Term2English + "数学：" + pi.Term2Math + "，物理：" + pi.Term2Physics + "，化学：" + pi.Term2Chemistry;
                dr["term3_perfo"] = "语文：" + pi.Term3Chinese + "，英语：" + pi.Term3English + "数学：" + pi.Term3Math + "，物理：" + pi.Term3Physics + "，化学：" + pi.Term3Chemistry;
            }

            if (hi.Length == 0)
            {
                dr["user_honor"] = "未填写";
                dr["user_note"] = "无";
            }
            else
            {
                string temp = "";
                string dd = "";
                DateTime tt = new DateTime();
                for (int i = 0; i < hi.Length; i++)
                {
                    tt = (DateTime)hi[i].HonorDate;
                    dd = tt.ToString("yyyy-MM");
                    temp += dd + " " + hi[i].HonorName + " " + hi[i].HonorRank + "; ";
                }
                dr["user_honor"] = temp;
                dr["user_note"] = "无";
            }

            if (fi.Length == 0)
            {
                dr["user_familyMember"] = "未填写";
            }
            else
            {
                string temp = "";                
                for (int i = 0; i < fi.Length; i++)
                {
                    temp += fi[i].RelationType + "(" + fi[i].MemberName + "--" + fi[i].Organization + "--" + fi[i].Title + "--" + fi[i].Phone + ")" + ";";
                }
                dr["user_familyMember"] = temp;
                
            }
            #endregion

            dt.Rows.Add(dr);
            // tempcount++;
            //if (tempcount > 1000)
            //{
            //    break;
            //}

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
        oSheet.Name = "最终名单";//this.Title;

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
                rg.NumberFormatLocal = "@";//设置单元格格式为文本
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
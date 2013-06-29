using System;

public partial class Users_Application : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Users user = (Users)Session["Identify"];
        int userID = user.UserID;
        if (!BasicInfo.HasBasicInfo(userID) || FamilyMember.GetAllMembers(userID).Length == 0 || !Performance.HasPerformance(userID) || !Headmaster.HasHeadmaster(userID))
        {
            Response.Write(string.Format("<div>对不起，您的信息填写不完整，无法预览或打印报名表。[<a href=\"{0}\">返回</a>]</div>", Request.UrlReferrer));
            Response.End();
            return;
        }
        BasicInfo bi = BasicInfo.GetBasicInfoByID(userID);
        //if (user.UserID <= 1182)
        //    AppID.Text = string.Format("A2013{0:d4}", bi.UserID);
        //else
        //    AppID.Text = string.Format("B2013{0:d4}", bi.UserID - 1182);
        AppID.Text = string.Format("A2013{0:d4}", bi.UserID);
        NameA.Text = NameB.Text = bi.Name;
        Gender.Text = bi.Gender ? "男" : "女";
        Race.Text = bi.Race;
        Birthday.Text = bi.Birthday.ToString("yyyy年M月d日");
        IDCard.Text = bi.IDCard;
        SchoolName.Text = bi.SchoolName;
        SchoolAddr.Text = string.Format("{0}({1})", bi.SchoolAddr, bi.SchoolPC);
        FamilyAddr.Text = string.Format("{0}({1})", bi.FamilyAddr, bi.FamilyPC);
        FamilyPhone.Text = bi.FamilyPhone;
        OtherPhone.Text = bi.OtherPhone;
        foreach (FamilyMember fm in FamilyMember.GetAllMembers(userID))
        {
            FamilyMembers.Text += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>", fm.RelationType, fm.MemberName, fm.Organization, fm.Title, fm.Phone);
        }
        Performance pf = Performance.GetPerformanceByID(userID);
        Term1Perf.Text = string.Format("{0}/{1}", pf.Term1Rank, pf.Term1Total);
        Term2Perf.Text = string.Format("{0}/{1}", pf.Term2Rank, pf.Term2Total);
        Term3Perf.Text = string.Format("{0}/{1}", pf.Term3Rank, pf.Term3Total);
        Term1Chinese.Text = pf.Term1Chinese.ToString();
        Term1Math.Text = pf.Term1Math.ToString();
        Term1English.Text = pf.Term1English.ToString();
        Term1Physics.Text = pf.Term1Physics.ToString();
        Term1Chemistry.Text = pf.Term1Chemistry.ToString();
        Term2Chinese.Text = pf.Term2Chinese.ToString();
        Term2Math.Text = pf.Term2Math.ToString();
        Term2English.Text = pf.Term2English.ToString();
        Term2Physics.Text = pf.Term2Physics.ToString();
        Term2Chemistry.Text = pf.Term2Chemistry.ToString();
        Term3Chinese.Text = pf.Term3Chinese.ToString();
        Term3Math.Text = pf.Term3Math.ToString();
        Term3English.Text = pf.Term3English.ToString();
        Term3Physics.Text = pf.Term3Physics.ToString();
        Term3Chemistry.Text = pf.Term3Chemistry.ToString();
        Headmaster hm = Headmaster.GetHeadmasterByID(userID);
        HeadmasterName.Text = hm.Name;
        HeadmasterOP.Text = hm.OfficePhone;
        HeadmasterFax.Text = hm.Fax;
        HeadmasterMP.Text = hm.Mobile;
        int nCount = 0;
        foreach (Honor honor in Honor.GetAllHonors(userID))
        {
            nCount++;
            Honors.Text += string.Format("<tr><td class=\"Date\">{0:yyyy年M月}</td><td class=\"Desc\">{1} {2}</td></tr>", honor.HonorDate, honor.HonorName, honor.HonorRank);
        }
        if (nCount == 0)
        {
            Honors.Text += "<tr><td colspan=\"2\" style=\"text-align: center; font-size: 14px\">（无获奖信息）</td></tr>";
        }
        //Response.Write("<script>alert('友情提示：为保证邮寄材料安全送达，请尽量使用EMS或者顺丰!')</script>");        
    }
}

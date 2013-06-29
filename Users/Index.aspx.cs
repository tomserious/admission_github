using System;
using System.Web.UI.WebControls;

public partial class Users_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Users user = (Users)Session["Identify"];
        bool finish = true;
        if (BasicInfo.HasBasicInfo(user.UserID))
        {
            BasicInfoLink.Text = "<a href=\"BasicInfo.aspx\">学生基本信息</a><br /><span class=\"Pass\">(已填写)</span>";
        }
        else
        {
            BasicInfoLink.Text = "<a href=\"BasicInfo.aspx\">学生基本信息</a><br /><span class=\"NotPass\">(未填写)</span>";
            finish = false;
        }
        if (FamilyMember.GetAllMembers(user.UserID).Length != 0)
        {
            FamilyMembersLink.Text = "<a href=\"FamilyMembers.aspx\">主要家庭成员</a><br /><span class=\"Pass\">(已填写)</span>";
        }
        else
        {
            FamilyMembersLink.Text = "<a href=\"FamilyMembers.aspx\">主要家庭成员</a><br /><span class=\"NotPass\">(未填写)</span>";
            finish = false;
        }
        if (Performance.HasPerformance(user.UserID))
        {
            PerformanceLink.Text = "<a href=\"Performance.aspx\">学生在校成绩</a><br /><span class=\"Pass\">(已填写)</span>";
        }
        else
        {
            PerformanceLink.Text = "<a href=\"Performance.aspx\">学生在校成绩</a><br /><span class=\"NotPass\">(未填写)</span>";
            finish = false;
        }
        if (Headmaster.HasHeadmaster(user.UserID))
        {
            HeadmasterLink.Text = "<a href=\"Headmaster.aspx\">校长联系方式</a><br /><span class=\"Pass\">(已填写)</span>";
        }
        else
        {
            HeadmasterLink.Text = "<a href=\"Headmaster.aspx\">校长联系方式</a><br /><span class=\"NotPass\">(未填写)</span>";
            finish = false;
        }
        bool bHonors;
        if (Honor.GetAllHonors(user.UserID).Length != 0)
        {
            HonorsLink.Text = "<a href=\"Honors.aspx\">学生获奖情况</a><br /><span class=\"Pass\">(已填写)</span>";
            bHonors = true;
        }
        else
        {
            HonorsLink.Text = "<a href=\"Honors.aspx\">学生获奖情况</a><br /><span class=\"NotPass\">(未填写)</span>";
            bHonors = false;
        }
        if (finish == false)
            PrintLink.Text = "报名表预览打印<br /><span class=\"NotPass\">(报名信息未填写完整，无法打印)</span>";
        else
        {
            if (!bHonors)
                PrintLink.Text = "<a href=\"Application.aspx\">报名表预览打印</a><br /><span class=\"Pass\">(除获奖外的信息填写完整，可以打印)</span>";
            else
                PrintLink.Text = "<a href=\"Application.aspx\">报名表预览打印</a><br /><span class=\"Pass\">(报名信息填写完整，可以打印)</span>";
        }
    }
}

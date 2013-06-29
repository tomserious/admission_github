using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_NewsList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List.Text = "<ul class=\"NewsList\">";
        foreach (NewsListItem item in News.GetNewsListByClass(ClassID, PageSize, nPage, false))
        {
            List.Text += string.Format("<li><span class=\"TitleSpan\" style=\"width: {2}px\"><a href=\"/ReadNews.aspx?NewsID={0}\" target=\"_blank\">{1}</a></span>{3}</li>", item.ID, item.Title, TitleWidth, ShowDate ? string.Format("<span class=\"DateSpan\">({0:M-d})</span>", item.PressTime) : "");
        }
        List.Text += "</ul>";
        if (ShowPager)
        {
            int newsCount = News.GetNewsCountByClass(ClassID, false);
            int pageCount = (newsCount + PageSize - 1) / PageSize;
            List.Text += "<p class=\"NewsListPager\">"
                + string.Format("本类共有新闻 {0} 条，每页显示 {1} 条，共 {2} 页。页码：", newsCount, PageSize, pageCount);
            string[] url = new string[] { "EECS.aspx", "Branch.aspx", "Materials.aspx" };
            for (int i = 1; i <= pageCount; i++)
                List.Text += string.Format("[<a href=\"{0}?Page={1}\">{1}</a>]", url[ClassID - 1], i);
            List.Text += "</p>";
        }
    }

    public int ClassID;
    public bool ShowPager;
    public int PageSize;
    public int nPage;
    public int TitleWidth;
    public bool ShowDate = true;
}

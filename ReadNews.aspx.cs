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

public partial class ReadNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int newsID = int.Parse(Request["NewsID"]);
        News.AddNewsCounter(newsID);
        News news = News.GetNewsByID(newsID);
        Title.Text = news.Title;
        NewsDate.Text = news.PressTime.ToString("yyyy年M月d日");
        ViewCounter.Text = news.ViewCounter.ToString();
        Content.Text = news.Content;
    }
}

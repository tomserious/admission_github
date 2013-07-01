using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Users_Result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Users user = (Users)Session["Identify"];       
        string name = BasicInfo.GetBasicInfoByID(user.UserID).Name;
        if (user.Result == Users.VerifyResult.Pass)
        {
            NameLitPass.Text = name;
            //if (user.UserID <= 1182)
            //    IDLitPass.Text = string.Format("A2013{0:d4}", user.UserID);
            //else
            //    IDLitPass.Text = string.Format("B2013{0:d4}", user.UserID - 1182);
            IDLitPass.Text = string.Format("A2013{0:d4}", user.UserID);
            Pass.Visible = true;
            NotPass.Visible = false;//设置可见div层
        }
        else
        {
            NameLitNotPass.Text = name;
            Pass.Visible = false;
            NotPass.Visible = true;
        }
    }
    /// <summary>
    /// 根据ID 返回考核成绩及排名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="simple"></param>
    /// <returns></returns>
    private string GetScoreStringByID(int id, out string simple)
    {
        StreamReader sr = new StreamReader(Server.MapPath("/Users/Score.mdf"));
        SortedList<int, Info> list = new SortedList<int, Info>();
        while (sr.EndOfStream == false)
        {
            string[] buff = sr.ReadLine().Split('\t');
            Info info = new Info();
            info.ID = int.Parse(buff[0]);
            info.Pass = bool.Parse(buff[1]);
            info.Math = int.Parse(buff[2]);
            info.Physics = int.Parse(buff[3]);
            info.Practice = int.Parse(buff[4]);
            info.Interview = int.Parse(buff[5]);
            info.Total = int.Parse(buff[6]);
            info.Rank = int.Parse(buff[7]);
            list.Add(info.ID, info);
        }
        sr.Close();
        if (list.Keys.Contains(id))
        {
            simple = string.Format("考核成绩为 {0} 分，排名 {1} ", list[id].Total, list[id].Rank);
            return string.Format("具体成绩为:<br />　　数学和计算机基础{0} 物理和电子学基础{1} 上机考核{2} 面试{3} 总分{4} 排第{5}名", list[id].Math, list[id].Physics, list[id].Practice, list[id].Interview, list[id].Total, list[id].Rank);
        }
        else
        {
            simple = string.Empty;
            return string.Empty;
        }
    }

    class Info
    {
        public int ID;
        public bool Pass;
        public int Math;
        public int Physics;
        public int Practice;
        public int Interview;
        public int Total;
        public int Rank;
    }
}

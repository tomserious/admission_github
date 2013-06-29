using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class News
{
    /// <summary>
    /// 根据新闻ID 返回新闻对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static News GetNewsByID(int id)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [News] WHERE [NewsID] = @NewsID", conn);
        cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = id;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (!sdr.Read())
            return null;
        News news = new News(id);
        news.Title = (string)sdr["NewsTitle"];
        news.ClassID = (sdr["NewsClassID"] is DBNull ? 0 : (int)sdr["NewsClassID"]);
        news.IsURL = (bool)sdr["IsURL"];
        news.Content = (string)sdr["Content"];
        news.PressTime = (DateTime)sdr["PressTime"];
        news.ViewCounter = (int)sdr["ViewCounter"];
        sdr.Close();
        conn.Close();
        return news;
    }

    /// <summary>
    /// 根据新闻类别ID返回该类别新闻数量
    /// </summary>
    /// <param name="classID"></param>
    /// <param name="includeChild"></param>
    /// <returns></returns>
    public static int GetNewsCountByClass(int classID, bool includeChild)
    {
        if (classID == 0 && includeChild == false)
        {
            return 0;
        }
        string cmdStr = "SELECT COUNT(*) FROM [News]";
        string classFilter = string.Empty;
        if (classID != 0)
        {
            if (includeChild)
            {
                foreach (int id in NewsClass.GetSubClassByID(classID))
                {
                    classFilter += string.Format("{0}, ", id);
                }
            }
            classFilter += classID.ToString();
        }
        if (classFilter != string.Empty)
            cmdStr += string.Format(" WHERE [NewsClassID] IN ({0})", classFilter);
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(cmdStr, conn);
        conn.Open();
        int ret = (int)cmd.ExecuteScalar();
        conn.Close();
        return ret;
    }
    /// <summary>
    /// 根据新闻类别ID获取某一页的新闻列表
    /// </summary>
    /// <param name="classID"></param>
    /// <param name="pageSize"></param>
    /// <param name="nPage"></param>
    /// <param name="includeChild"></param>
    /// <returns></returns>
    public static NewsListItem[] GetNewsListByClass(int classID, int pageSize, int nPage, bool includeChild)
    {
        List<NewsListItem> list = new List<NewsListItem>();
        string classFilter = string.Empty;
        if (classID == 0)
        {
            if (!includeChild)
                return list.ToArray();
        }
        else
        {
            if (includeChild)
            {
                foreach (int id in NewsClass.GetSubClassByID(classID))
                {
                    classFilter += string.Format("{0}, ", id);
                }
            }
            classFilter += classID.ToString();
        }
        string cols = "[NewsID], [NewsTitle], [NewsClassID], [IsUrl], [PressTime], [ViewCounter]";
        string cmdStr = string.Format("SELECT TOP {0} {1} FROM [News] WHERE [NewsID] NOT IN (SELECT TOP {2} [NewsID] FROM [News] {3} ORDER BY [PressTime] DESC) {4} ORDER BY [PressTime] DESC", pageSize, cols, pageSize * (nPage - 1), classFilter == string.Empty ? "" : string.Format("WHERE [NewsClassID] IN ({0})", classFilter), classFilter == string.Empty ? "" : string.Format("AND [NewsClassID] IN ({0})", classFilter));
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand(cmdStr, conn);
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            list.Add(new NewsListItem((int)sdr["NewsID"], (string)sdr["NewsTitle"], (int)sdr["NewsClassID"], (bool)sdr["IsURL"], (DateTime)sdr["PressTime"], (int)sdr["ViewCounter"]));
        }
        sdr.Close();
        conn.Close();
        return list.ToArray();
    }
    /// <summary>
    /// 插入新的类别新闻
    /// </summary>
    /// <param name="title"></param>
    /// <param name="classID"></param>
    /// <param name="isUrl"></param>
    /// <param name="content"></param>
    public static void InsertNews(string title, int classID, bool isUrl, string content)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("INSERT INTO [News] ([NewsTitle], [NewsClassID], [IsURL], [Content], [PressTime], [ViewCounter]) VALUES (@NewsTitle, @NewsClassID, @IsURL, @Content, @PressTime, @ViewCounter)", conn);
        cmd.Parameters.Add("@NewsTitle", SqlDbType.NVarChar).Value = title;
        if (classID == 0)
            cmd.Parameters.Add("@NewsClassID", SqlDbType.Int).Value = DBNull.Value;
        else
            cmd.Parameters.Add("@NewsClassID", SqlDbType.Int).Value = classID;
        cmd.Parameters.Add("@IsURL", SqlDbType.Bit).Value = isUrl;
        cmd.Parameters.Add("@Content", SqlDbType.NText).Value = content;
        cmd.Parameters.Add("@PressTime", SqlDbType.SmallDateTime).Value = DateTime.Now;
        cmd.Parameters.Add("@ViewCounter", SqlDbType.Int).Value = 0;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 更新新闻类别等信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="classID"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    public static void UpdateNewsByID(int id, int classID, string title, string content)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("UPDATE [News] SET [NewsClassID] = @NewsClassID, [NewsTitle] = @NewsTitle, [Content] = @Content WHERE [NewsID] = @NewsID", conn);
        cmd.Parameters.Add("@NewsClassID", SqlDbType.Int).Value = classID;
        cmd.Parameters.Add("@NewsTitle", SqlDbType.NVarChar).Value = title;
        cmd.Parameters.Add("@Content", SqlDbType.NText).Value = content;
        cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = id;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 根据新闻ID删除新闻
    /// </summary>
    /// <param name="id"></param>
    public static void DeleteNewsByID(int id)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("DELETE [News] WHERE [NewsID] = @NewsID", conn);
        cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = id;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 更新某新闻的计数器
    /// </summary>
    /// <param name="id"></param>
    public static void AddNewsCounter(int id)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("UPDATE [News] SET [ViewCounter] = [ViewCounter] + 1 WHERE [NewsID] = @NewsID", conn);
        cmd.Parameters.Add("@NewsID", SqlDbType.Int).Value = id;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    #region 自动变量
    public News()
    {
    }

    public News(int id)
    {
        this.id = id;
    }

    public int ID
    {
        get
        {
            return id;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }

    public int ClassID
    {
        get
        {
            return classID;
        }
        set
        {
            classID = value;
        }
    }

    public bool IsURL
    {
        get
        {
            return isUrl;
        }
        set
        {
            isUrl = value;
        }
    }

    public string Content
    {
        get
        {
            return content;
        }
        set
        {
            content = value;
        }
    }

    public DateTime PressTime
    {
        get
        {
            return pressTime;
        }
        set
        {
            pressTime = value;
        }
    }

    public int ViewCounter
    {
        get
        {
            return viewCounter;
        }
        set
        {
            viewCounter = value;
        }
    }
    #endregion
    private int id;
    private string title;
    private int classID;
    private bool isUrl;
    private string content;
    private DateTime pressTime;
    private int viewCounter;

    private static string connStr = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

public class NewsClass
{
    /// <summary>
    /// 根据类别ID 返回类别对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static NewsClass GetNewsClassByID(int id)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [NewsClass] WHERE [NewsClassID] = @NewsClassID", conn);
        cmd.Parameters.Add("@NewsClassID", SqlDbType.Int).Value = id;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (!sdr.Read())
            return null;
        NewsClass newsClass = new NewsClass(id);
        newsClass.Name = (string)sdr["NewsClassName"];
        newsClass.ParentID = (sdr["ParentClassID"] is DBNull ? 0 : (int)sdr["ParentClassID"]);
        sdr.Close();
        conn.Close();
        return newsClass;
    }
    /// <summary>
    /// 根据新闻类别ID返回子类ID列表
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static int[] GetSubClassByID(int id)
    {
        List<int> list = new List<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(id);
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        while (queue.Count > 0)
        {
            int parentID = queue.Dequeue();
            SqlCommand cmd = new SqlCommand("SELECT [NewsClassID] FROM [NewsClass] WHERE [ParentClassID] = @ParentClassID", conn);
            cmd.Parameters.Add("@ParentClassID", SqlDbType.Int).Value = parentID;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                list.Add((int)sdr["NewsClassID"]);
                queue.Enqueue((int)sdr["NewsClassID"]);
            }
            sdr.Close();
        }
        conn.Close();
        return list.ToArray();
    }

    public NewsClass()
    {
    }

    public NewsClass(int id)
    {
        newsClassID = id;
    }

    public int ID
    {
        get
        {
            return newsClassID;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int ParentID
    {
        get
        {
            return parentClassID;
        }
        set
        {
            parentClassID = value;
        }
    }

    private int newsClassID;
    private string name;
    private int parentClassID;

    private static string connStr = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

public class NewsListItem
{
    /// <summary>
    /// 新闻列表构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="title"></param>
    /// <param name="classID"></param>
    /// <param name="isUrl"></param>
    /// <param name="pressTime"></param>
    /// <param name="viewCounter"></param>
    public NewsListItem(int id, string title, int classID, bool isUrl, DateTime pressTime, int viewCounter)
    {
        this.id = id;
        this.title = title;
        this.classID = classID;
        this.isUrl = isUrl;
        this.pressTime = pressTime;
        this.viewCounter = viewCounter;
    }

    public int ID
    {
        get
        {
            return id;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
    }

    public int ClassID
    {
        get
        {
            return classID;
        }
    }

    public bool IsURL
    {
        get
        {
            return isUrl;
        }
    }

    public DateTime PressTime
    {
        get
        {
            return pressTime;
        }
    }

    public int ViewCounter
    {
        get
        {
            return viewCounter;
        }
    }

    private int id;
    private string title;
    private int classID;
    private bool isUrl;
    private DateTime pressTime;
    private int viewCounter;
}

public class NewsAdmin
{
    /// <summary>
    /// 查询确定用户名密码是否存在，存在返回真
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool VerifyIdentity(string username, string password)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [NewsUsers] WHERE [Username] = @Username AND [PasswordHash] = @PasswordHash", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        bool ret = (int)cmd.ExecuteScalar() == 1;
        conn.Close();
        return ret;
    }

    /// <summary>
    /// 添加管理员
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>

    public static void AddAdmin(string username, string password)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("INSERT INTO [NewsUsers] ([Username], [PasswordHash]) VALUES (@Username, @PasswordHash)", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 更改用户密码
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public static void ChangePassword(string username, string password)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("UPDATE [NewsUsers] SET [PasswordHash] = @PasswordHash WHERE [Username] = @Username", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 密码加密
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetHashCode(string str)
    {
        return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(str)));
    }

    private static string connStr = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

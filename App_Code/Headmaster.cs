using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Headmaster
{
    /// <summary>
    /// 根据ID更新或插入校长对象
    /// </summary>
    /// <param name="id"></param>
    /// <param name="hm"></param>
    public static void SetHeadmasterByID(int id, Headmaster hm)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd;
        if (HasHeadmaster(id))
        {
            cmd = new SqlCommand("UPDATE [HeadMaster] SET [Name] = @Name, [OfficePhone] = @OfficePhone, [Fax] = @Fax, [Mobile] = @Mobile WHERE [UserID] = @UserID", conn);
        }
        else
        {
            cmd = new SqlCommand("INSERT INTO [HeadMaster] ([UserID], [Name], [OfficePhone], [Fax], [Mobile]) VALUES (@UserID, @Name, @OfficePhone, @Fax, @Mobile)", conn);
        }
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = hm.Name;
        cmd.Parameters.Add("@OfficePhone", SqlDbType.VarChar).Value = hm.OfficePhone;
        cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = hm.Fax;
        cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = hm.Mobile;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 根据ID获取校长对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Headmaster GetHeadmasterByID(int id)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [HeadMaster] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        Headmaster hm = null;
        if (sdr.Read())
        {
            hm = new Headmaster();
            hm.UserID = (int)sdr["UserID"];
            hm.Name = (string)sdr["Name"];
            hm.OfficePhone = (string)sdr["OfficePhone"];
            hm.Fax = (string)sdr["Fax"];
            hm.Mobile = (string)sdr["Mobile"];
        }
        sdr.Close();
        conn.Close();
        return hm;
    }

    /// <summary>
    /// 判断某ID校长是否已存在，存在返回真
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool HasHeadmaster(int id)
    {
        bool ret;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [HeadMaster] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        ret = (int)cmd.ExecuteScalar() > 0;
        conn.Close();
        return ret;
    }

    public int UserID;
    public string Name, OfficePhone, Fax, Mobile;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

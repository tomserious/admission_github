using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class BasicInfo
{
    /// <summary>
    /// 更新或插入记录，根据ID
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <param name="bi">基本信息对象</param>
    public static void SetBasicInfoByID(int id, BasicInfo bi)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd;
        if (HasBasicInfo(id))
        {
            cmd = new SqlCommand("UPDATE [BasicInfo] SET [Name] = @Name, [Gender] = @Gender, [Race] = @Race, [Birthday] = @Birthday, [IDCard] = @IDCard, [SchoolName] = @SchoolName, [SchoolAddr] = @SchoolAddr, [SchoolPC] = @SchoolPC, [FamilyAddr] = @FamilyAddr, [FamilyPC] = @FamilyPC, [FamilyPhone] = @FamilyPhone, [OtherPhone] = @OtherPhone,[Province]=@Province WHERE [UserID] = @UserID", conn);
        }
        else
        {
            cmd = new SqlCommand("INSERT INTO [BasicInfo] ([UserID], [Name], [Gender], [Race], [Birthday], [IDCard], [SchoolName], [SchoolAddr], [SchoolPC], [FamilyAddr], [FamilyPC], [FamilyPhone], [OtherPhone],[Province]) VALUES (@UserID, @Name, @Gender, @Race, @Birthday, @IDCard, @SchoolName, @SchoolAddr, @SchoolPC, @FamilyAddr, @FamilyPC, @FamilyPhone, @OtherPhone,@Province)", conn);
        }
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = bi.Name;
        cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = bi.Gender;
        cmd.Parameters.Add("@Race", SqlDbType.NVarChar).Value = bi.Race;
        cmd.Parameters.Add("@Birthday", SqlDbType.SmallDateTime).Value = bi.Birthday;
        cmd.Parameters.Add("@IDCard", SqlDbType.Char).Value = bi.IDCard;
        cmd.Parameters.Add("@SchoolName", SqlDbType.NVarChar).Value = bi.SchoolName;
        cmd.Parameters.Add("@SchoolAddr", SqlDbType.NVarChar).Value = bi.SchoolAddr;
        cmd.Parameters.Add("@SchoolPC", SqlDbType.Char).Value = bi.SchoolPC;
        cmd.Parameters.Add("@FamilyAddr", SqlDbType.NVarChar).Value = bi.FamilyAddr;
        cmd.Parameters.Add("@FamilyPC", SqlDbType.Char).Value = bi.FamilyPC;
        cmd.Parameters.Add("@FamilyPhone", SqlDbType.VarChar).Value = bi.FamilyPhone;
        cmd.Parameters.Add("@OtherPhone", SqlDbType.VarChar).Value = bi.OtherPhone;
        cmd.Parameters.Add("@Province",SqlDbType.VarChar).Value=bi.Province;
       
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据ID返回个人基本信息
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns>基本信息实体</returns>
    public static BasicInfo GetBasicInfoByID(int id)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [BasicInfo] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        BasicInfo bi = null;
        if (sdr.Read())
        {
            bi = new BasicInfo();
            bi.UserID = (int)sdr["UserID"];
            bi.Name = (string)sdr["Name"];
            bi.Gender = (bool)sdr["Gender"];
            bi.Race = (string)sdr["Race"];
            bi.Birthday = (DateTime)sdr["Birthday"];
            bi.IDCard = ((string)sdr["IDCard"]).Trim();
            bi.SchoolName = (string)sdr["SchoolName"];
            bi.SchoolAddr = (string)sdr["SchoolAddr"];
            bi.SchoolPC = ((string)sdr["SchoolPC"]).Trim();
            bi.FamilyAddr = (string)sdr["FamilyAddr"];
            bi.FamilyPC = ((string)sdr["FamilyPC"]).Trim();
            bi.FamilyPhone = (string)sdr["FamilyPhone"];
            bi.OtherPhone = (string)sdr["OtherPhone"];
            bi.Province = (string)sdr["Province"];
        }
        sdr.Close();
        conn.Close();
        return bi;
    }

    /// <summary>
    /// 判断特定ID是否已存在，存在返回真
    /// </summary>
    /// <param name="id">用户ID</param>
    /// <returns></returns>
    public static bool HasBasicInfo(int id)
    {
        
        bool ret;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [BasicInfo] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        ret = (int)cmd.ExecuteScalar() > 0;
        conn.Close();
        return ret;
    }

    public int UserID;
    public string Name;
    public bool Gender;
    public string Race;
    public DateTime Birthday;
    public string IDCard;
    public string SchoolName;
    public string SchoolAddr;
    public string SchoolPC;
    public string FamilyAddr;
    public string FamilyPC;
    public string FamilyPhone;
    public string OtherPhone;
    public string Province;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

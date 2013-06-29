using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class FamilyMember
{
    /// <summary>
    /// 根据用户ID 返回家庭成员对象列表
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public static FamilyMember[] GetAllMembers(int userID)
    {
        List<FamilyMember> list = new List<FamilyMember>();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [FamilyMember] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            FamilyMember fm = new FamilyMember();
            fm.UserID = (int)sdr["UserID"];
            fm.MemberID = (int)sdr["MemberID"];
            fm.RelationType = (string)sdr["RelationType"];
            fm.MemberName = (string)sdr["MemberName"];
            fm.Organization = (string)sdr["Organization"];
            fm.Title = (string)sdr["Title"];
            fm.Phone = (string)sdr["Phone"];
            list.Add(fm);
        }
        sdr.Close();
        conn.Close();
        return list.ToArray();
    }

    /// <summary>
    /// 根据成员ID 返回成员对象
    /// </summary>
    /// <param name="memberID"></param>
    /// <returns></returns>
    public static FamilyMember GetMemberByID(int memberID)
    {
        FamilyMember ret = null;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [FamilyMember] WHERE [MemberID] = @MemberID", conn);
        cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = memberID;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            ret = new FamilyMember();
            ret.UserID = (int)sdr["UserID"];
            ret.MemberID = (int)sdr["MemberID"];
            ret.RelationType = (string)sdr["RelationType"];
            ret.MemberName = (string)sdr["MemberName"];
            ret.Organization = (string)sdr["Organization"];
            ret.Title = (string)sdr["Title"];
            ret.Phone = (string)sdr["Phone"];
        }
        sdr.Close();
        conn.Close();
        return ret;
    }

    /// <summary>
    /// 为特定ID用户添加家庭成员
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="fm"></param>
    public static void AddMember(int userID, FamilyMember fm)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("INSERT INTO [FamilyMember] ([UserID], [RelationType], [MemberName], [Organization], [Title], [Phone]) VALUES (@UserID, @RelationType, @MemberName, @Organization, @Title, @Phone)", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        cmd.Parameters.Add("@RelationType", SqlDbType.NVarChar).Value = fm.RelationType;
        cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = fm.MemberName;
        cmd.Parameters.Add("@Organization", SqlDbType.NVarChar).Value = fm.Organization;
        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = fm.Title;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fm.Phone;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据成员ID更新家庭成员对象
    /// </summary>
    /// <param name="memberID"></param>
    /// <param name="fm"></param>
    public static void UpdateMember(int memberID, FamilyMember fm)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("UPDATE [FamilyMember] SET [RelationType] = @RelationType, [MemberName] = @MemberName, [Organization] = @Organization, [Title] = @Title, [Phone] = @Phone WHERE [MemberID] = @MemberID", conn);
        cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = memberID;
        cmd.Parameters.Add("@RelationType", SqlDbType.NVarChar).Value = fm.RelationType;
        cmd.Parameters.Add("@MemberName", SqlDbType.NVarChar).Value = fm.MemberName;
        cmd.Parameters.Add("@Organization", SqlDbType.NVarChar).Value = fm.Organization;
        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = fm.Title;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = fm.Phone;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据成员ID删除家庭成员
    /// </summary>
    /// <param name="memberID"></param>
    public static void DeleteMember(int memberID)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("DELETE [FamilyMember] WHERE [MemberID] = @MemberID", conn);
        cmd.Parameters.Add("@MemberID", SqlDbType.Int).Value = memberID;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public int UserID, MemberID;
    public string RelationType, MemberName, Organization, Title, Phone;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

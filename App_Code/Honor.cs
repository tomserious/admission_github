using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Honor
{
    /// <summary>
    /// 根据ID 返回相应的荣誉列表
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public static Honor[] GetAllHonors(int userID)
    {
        List<Honor> list = new List<Honor>();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Honors] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            Honor honor = new Honor();
            honor.UserID = (int)sdr["UserID"];
            honor.HonorID = (int)sdr["HonorID"];
            honor.HonorDate = (DateTime)sdr["HonorDate"];
            honor.HonorName = (string)sdr["HonorName"];
            honor.HonorRank = (string)sdr["HonorRank"];
            list.Add(honor);
        }
        sdr.Close();
        conn.Close();
        return list.ToArray();
    }

    /// <summary>
    /// 根据荣誉ID 返回荣誉对象
    /// </summary>
    /// <param name="honorID"></param>
    /// <returns></returns>
    public static Honor GetHonorByID(int honorID)
    {
        Honor ret = null;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Honors] WHERE [HonorID] = @HonorID", conn);
        cmd.Parameters.Add("@HonorID", SqlDbType.Int).Value = honorID;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            ret = new Honor();
            ret.UserID = (int)sdr["UserID"];
            ret.HonorID = (int)sdr["HonorID"];
            ret.HonorDate = (DateTime)sdr["HonorDate"];
            ret.HonorName = (string)sdr["HonorName"];
            ret.HonorRank = (string)sdr["HonorRank"];
        }
        sdr.Close();
        conn.Close();
        return ret;
    }
    /// <summary>
    /// 为某ID用户添加荣誉
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="honor"></param>
    public static void AddHonor(int userID, Honor honor)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("INSERT INTO [Honors] ([UserID], [HonorDate], [HonorName], [HonorRank]) VALUES (@UserID, @HonorDate, @HonorName, @HonorRank)", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        cmd.Parameters.Add("@HonorDate", SqlDbType.SmallDateTime).Value = honor.HonorDate;
        cmd.Parameters.Add("@HonorName", SqlDbType.NVarChar).Value = honor.HonorName;
        cmd.Parameters.Add("@HonorRank", SqlDbType.NVarChar).Value = honor.HonorRank;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据荣誉ID 返回荣誉对象
    /// </summary>
    /// <param name="honorID"></param>
    /// <param name="honor"></param>
    public static void UpdateHonor(int honorID, Honor honor)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("UPDATE [Honors] SET [HonorDate] = @HonorDate, [HonorName] = @HonorName, [HonorRank] = @HonorRank WHERE [HonorID] = @HonorID", conn);
        cmd.Parameters.Add("@HonorID", SqlDbType.Int).Value = honorID;
        cmd.Parameters.Add("@HonorDate", SqlDbType.SmallDateTime).Value = honor.HonorDate;
        cmd.Parameters.Add("@HonorName", SqlDbType.NVarChar).Value = honor.HonorName;
        cmd.Parameters.Add("@HonorRank", SqlDbType.NVarChar).Value = honor.HonorRank;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    /// <summary>
    /// 根据荣誉ID 删除荣誉对象
    /// </summary>
    /// <param name="honorID"></param>
    public static void DeleteHonor(int honorID)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("DELETE [Honors] WHERE [HonorID] = @HonorID", conn);
        cmd.Parameters.Add("@HonorID", SqlDbType.Int).Value = honorID;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public int UserID, HonorID;
    public DateTime HonorDate;
    public string HonorName, HonorRank;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

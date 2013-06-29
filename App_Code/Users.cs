using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class Users
{
    /// <summary>
    /// 确认用户名及密码，返回用户对象，包括是否通过审核
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static Users VerifyIdentity(string username, string password)
    {
        Users ret;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT [UserID], [Username], [IsCandidate], [Result] FROM [Users] WHERE [Username] = @Username AND [PasswordHash] = @PasswordHash", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            VerifyResult result;
            if (sdr["Result"] is DBNull)
            {
                result = VerifyResult.None;
            }
            else if ((bool)sdr["Result"])
            {
                result = VerifyResult.Pass;
            }
            else
            {
                result = VerifyResult.NotPass;
            }
            ret = new Users((int)sdr["UserID"], (string)sdr["Username"], (bool)sdr["IsCandidate"], result);
        }
        else
        {
            ret = null;
        }
        sdr.Close();
        conn.Close();
        return ret;
    }

    /// <summary>
    /// 根据用户名判断用户是否退出，未退出返回真
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public static bool IsUserExist(string username)
    {
        bool ret;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE [Username] = @Username", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        conn.Open();
        if ((int)cmd.ExecuteScalar() > 0)
        {
            ret = true;
        }
        else
        {
            ret = false;
        }
        conn.Close();
        return ret;
    }

    /// <summary>
    /// 添加新用户（用户名，密码）
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public static void AddUser(string username, string password)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("INSERT INTO [Users] ([Username], [PasswordHash]) VALUES (@Username, @PasswordHash)", conn);
        cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// /更改用户密码
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="password"></param>
    public static void ChangePassword(int userID, string password)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("UPDATE [Users] SET [PasswordHash] = @PasswordHash WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        cmd.Parameters.Add("@PasswordHash", SqlDbType.Char).Value = GetHashCode(password);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据用户ID返回用户对象
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public static Users GetUserByID(int userID)
    {
        Users ret = null;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            VerifyResult result;
            if (sdr["Result"] is DBNull)
            {
                result = VerifyResult.None;
            }
            else if ((bool)sdr["Result"])
            {
                result = VerifyResult.Pass;
            }
            else
            {
                result = VerifyResult.NotPass;
            }
            ret = new Users((int)sdr["UserID"], (string)sdr["Username"], (bool)sdr["IsCandidate"], result);
        }
        sdr.Close();
        conn.Close();
        return ret;
    }
    /// <summary>
    /// 返回所有用户对象
    /// </summary>
    /// <returns></returns>
    public static Users[] GetAllUsers()
    {
        List<Users> users = new List<Users>();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Users]", conn);
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            VerifyResult result;
            if (sdr["Result"] is DBNull)
            {
                result = VerifyResult.None;
            }
            else if ((bool)sdr["Result"])
            {
                result = VerifyResult.Pass;
            }
            else
            {
                result = VerifyResult.NotPass;
            }
            users.Add(new Users((int)sdr["UserID"], (string)sdr["Username"], (bool)sdr["IsCandidate"], result));
        }
        sdr.Close();
        conn.Close();
        return users.ToArray();
    }
    /// <summary>
    /// 返回指定位置的用户
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static Users[] GetPartialUsers(int from,int to)
    {
        List<Users> users = new List<Users>();        
        string sql = " select * from (select row_number() over (order by UserID) as rowNum,* from Users) as t where rowNum between " + from + "and " + to;
        SqlConnection conn = new SqlConnection(connString); 
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            VerifyResult result;
            if (sdr["Result"] is DBNull)
            {
                result = VerifyResult.None;
            }
            else if ((bool)sdr["Result"])
            {
                result = VerifyResult.Pass;
            }
            else
            {
                result = VerifyResult.NotPass;
            }
            users.Add(new Users((int)sdr["UserID"], (string)sdr["Username"], (bool)sdr["IsCandidate"], result));
        }
        sdr.Close();
        conn.Close();
        return users.ToArray();
    }

    public static Users[] GetValidUsers()
    {
        List<Users> users = new List<Users>();
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("select [Users].* from [Users],[BasicInfo] where [Users].UserID=[BasicInfo].UserID", conn);
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            VerifyResult result;
            if (sdr["Result"] is DBNull)
            {
                result = VerifyResult.None;
            }
            else if ((bool)sdr["Result"])
            {
                result = VerifyResult.Pass;
            }
            else
            {
                result = VerifyResult.NotPass;
            }
            users.Add(new Users((int)sdr["UserID"], (string)sdr["Username"], (bool)sdr["IsCandidate"], result));
        }
        sdr.Close();
        conn.Close();
        return users.ToArray();
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
    /// <summary>
    /// 用户构造函数
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="username"></param>
    /// <param name="isCandidate"></param>
    /// <param name="result"></param>
    public Users(int userID, string username, bool isCandidate, VerifyResult result)
    {
        this.userID = userID;
        this.username = username;
        this.isCandidate = isCandidate;
        this.result = result;
    }
    /// <summary>
    /// 根据修改当前审核状态
    /// </summary>
    /// <param name="originState"></param>
    /// <param name="userID"></param>
    public static void changeState(string originState,int userID)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("UPDATE [Users] SET [Result] = @originState WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
        if(originState=="通过")
        {
            cmd.Parameters.Add("@originState", SqlDbType.Bit).Value = 0;
        }
        else
        {
            cmd.Parameters.Add("@originState", SqlDbType.Bit).Value = 1;
        }
        
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public int UserID
    {
        get
        {
            return userID;
        }
    }

    public string Username
    {
        get
        {
            return username;
        }
    }

    public bool IsCandidate
    {
        get
        {
            return isCandidate;
        }
    }

    public VerifyResult Result
    {
        get
        {
            return result;
        }
    }

    private int userID;
    private string username;
    private bool isCandidate;
    private VerifyResult result;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;

    public enum VerifyResult { None, Pass, NotPass }
}

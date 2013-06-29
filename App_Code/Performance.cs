using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Performance
{
    /// <summary>
    /// 更新或插入新的用户成绩及排名
    /// </summary>
    /// <param name="id"></param>
    /// <param name="perf"></param>
    public static void SetPerformanceByID(int id, Performance perf)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd;
        if (HasPerformance(id))
        {
            cmd = new SqlCommand("UPDATE [Performance] SET [Term1Rank] = @Term1Rank, [Term1Total] = @Term1Total, [Term2Rank] = @Term2Rank, [Term2Total] = @Term2Total, [Term3Rank] = @Term3Rank, [Term3Total] = @Term3Total, [Term1Chinese] = @Term1Chinese, [Term1Math] = @Term1Math, [Term1English] = @Term1English, [Term1Physics] = @Term1Physics, [Term1Chemistry] = @Term1Chemistry, [Term2Chinese] = @Term2Chinese, [Term2Math] = @Term2Math, [Term2English] = @Term2English, [Term2Physics] = @Term2Physics, [Term2Chemistry] = @Term2Chemistry, [Term3Chinese] = @Term3Chinese, [Term3Math] = @Term3Math, [Term3English] = @Term3English, [Term3Physics] = @Term3Physics, [Term3Chemistry] = @Term3Chemistry WHERE [UserID] = @UserID", conn);
        }
        else
        {
            cmd = new SqlCommand("INSERT INTO [Performance] ([UserID], [Term1Rank], [Term1Total], [Term2Rank], [Term2Total], [Term3Rank], [Term3Total], [Term1Chinese], [Term1Math], [Term1English], [Term1Physics], [Term1Chemistry], [Term2Chinese], [Term2Math], [Term2English], [Term2Physics], [Term2Chemistry], [Term3Chinese], [Term3Math], [Term3English], [Term3Physics], [Term3Chemistry]) VALUES (@UserID, @Term1Rank, @Term1Total, @Term2Rank, @Term2Total, @Term3Rank, @Term3Total, @Term1Chinese, @Term1Math, @Term1English, @Term1Physics, @Term1Chemistry, @Term2Chinese, @Term2Math, @Term2English, @Term2Physics, @Term2Chemistry, @Term3Chinese, @Term3Math, @Term3English, @Term3Physics, @Term3Chemistry)", conn);
        }
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@Term1Rank", SqlDbType.Int).Value = perf.Term1Rank;
        cmd.Parameters.Add("@Term1Total", SqlDbType.Int).Value = perf.Term1Total;
        cmd.Parameters.Add("@Term2Rank", SqlDbType.Int).Value = perf.Term2Rank;
        cmd.Parameters.Add("@Term2Total", SqlDbType.Int).Value = perf.Term2Total;
        cmd.Parameters.Add("@Term3Rank", SqlDbType.Int).Value = perf.Term3Rank;
        cmd.Parameters.Add("@Term3Total", SqlDbType.Int).Value = perf.Term3Total;
        cmd.Parameters.Add("@Term1Chinese", SqlDbType.Float).Value = perf.Term1Chinese;
        cmd.Parameters.Add("@Term1Math", SqlDbType.Float).Value = perf.Term1Math;
        cmd.Parameters.Add("@Term1English", SqlDbType.Float).Value = perf.Term1English;
        cmd.Parameters.Add("@Term1Physics", SqlDbType.Float).Value = perf.Term1Physics;
        cmd.Parameters.Add("@Term1Chemistry", SqlDbType.Float).Value = perf.Term1Chemistry;
        cmd.Parameters.Add("@Term2Chinese", SqlDbType.Float).Value = perf.Term2Chinese;
        cmd.Parameters.Add("@Term2Math", SqlDbType.Float).Value = perf.Term2Math;
        cmd.Parameters.Add("@Term2English", SqlDbType.Float).Value = perf.Term2English;
        cmd.Parameters.Add("@Term2Physics", SqlDbType.Float).Value = perf.Term2Physics;
        cmd.Parameters.Add("@Term2Chemistry", SqlDbType.Float).Value = perf.Term2Chemistry;
        cmd.Parameters.Add("@Term3Chinese", SqlDbType.Float).Value = perf.Term3Chinese;
        cmd.Parameters.Add("@Term3Math", SqlDbType.Float).Value = perf.Term3Math;
        cmd.Parameters.Add("@Term3English", SqlDbType.Float).Value = perf.Term3English;
        cmd.Parameters.Add("@Term3Physics", SqlDbType.Float).Value = perf.Term3Physics;
        cmd.Parameters.Add("@Term3Chemistry", SqlDbType.Float).Value = perf.Term3Chemistry;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    /// <summary>
    /// 根据用户ID返回该用户的成绩及排名
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Performance GetPerformanceByID(int id)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM [Performance] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        SqlDataReader sdr = cmd.ExecuteReader();
        Performance perf = null;
        if (sdr.Read())
        {
            perf = new Performance();
            perf.UserID = (int)sdr["UserID"];
            perf.Term1Rank = (int)sdr["Term1Rank"];
            perf.Term1Total = (int)sdr["Term1Total"];
            perf.Term2Rank = (int)sdr["Term2Rank"];
            perf.Term2Total = (int)sdr["Term2Total"];
            perf.Term3Rank = (int)sdr["Term3Rank"];
            perf.Term3Total = (int)sdr["Term3Total"];
            perf.Term1Chinese = (double)sdr["Term1Chinese"];
            perf.Term1Math = (double)sdr["Term1Math"];
            perf.Term1English = (double)sdr["Term1English"];
            perf.Term1Physics = (double)sdr["Term1Physics"];
            perf.Term1Chemistry = (double)sdr["Term1Chemistry"];
            perf.Term2Chinese = (double)sdr["Term2Chinese"];
            perf.Term2Math = (double)sdr["Term2Math"];
            perf.Term2English = (double)sdr["Term2English"];
            perf.Term2Physics = (double)sdr["Term2Physics"];
            perf.Term2Chemistry = (double)sdr["Term2Chemistry"];
            perf.Term3Chinese = (double)sdr["Term3Chinese"];
            perf.Term3Math = (double)sdr["Term3Math"];
            perf.Term3English = (double)sdr["Term3English"];
            perf.Term3Physics = (double)sdr["Term3Physics"];
            perf.Term3Chemistry = (double)sdr["Term3Chemistry"];
        }
        sdr.Close();
        conn.Close();
        return perf;
    }
    /// <summary>
    /// 根据ID 获取用户的成绩及排名记录，存在则返回真值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool HasPerformance(int id)
    {
        bool ret;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [Performance] WHERE [UserID] = @UserID", conn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
        conn.Open();
        ret = (int)cmd.ExecuteScalar() > 0;
        conn.Close();
        return ret;
    }

    public int UserID, Term1Rank, Term1Total, Term2Rank, Term2Total, Term3Rank, Term3Total;
    public double Term1Chinese, Term1Math, Term1English, Term1Physics, Term1Chemistry, Term2Chinese, Term2Math, Term2English, Term2Physics, Term2Chemistry, Term3Chinese, Term3Math, Term3English, Term3Physics, Term3Chemistry;

    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class Admin
{
    /// <summary>
    /// 验证用户名密码，通过返回真
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool Verify(string username, string password)
    {
        StreamReader sr = new StreamReader(conf);
        string[] buff = sr.ReadLine().Split('\t');
        sr.Close();
        if (string.Compare(username, buff[0], true) == 0 && GetHashCode(password) == buff[1])
            return true;
        else
            return false;
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
    
    private static string conf = HttpContext.Current.Server.MapPath("Admin.mdf");
}

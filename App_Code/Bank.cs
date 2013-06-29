using System;
using System.Security.Cryptography;
using System.Text;

public class Bank
{
    public static string ComputeHmacString(string key, string data)
    {
        HMACMD5 hmac = new HMACMD5(Encoding.ASCII.GetBytes(key));
        return BitConverter.ToString(hmac.ComputeHash(Encoding.ASCII.GetBytes(data))).Replace("-", "").ToLower();
    }

    public static string Get_V_OID(int userID)
    {
        return string.Format("{0:yyyyMMdd}-{1}-{2}-{0:HHmmss}", DateTime.Now, V_MID, GetUserNumber(userID));
    }

    public static string GetUserNumber(int userID)
    {
        return string.Format("2013{0:d4}", userID);
    }

    public const string Pay_URL = "http://pay.beijing.com.cn/prs/user_payment.checkit";

    public const string HMAC_KEY = "g7w9n9A1p1s9R2G7";

    public const string V_MID = "5631";
    public const string V_AMOUNT = "3000.00";//缴费金额
    public const string V_ORDERSTATUS = "1";
    public const string V_MONEYTYPE = "0";

    public const string V_URL = "http://admission.pkugrad.cn/onlinepay/result.aspx";
}

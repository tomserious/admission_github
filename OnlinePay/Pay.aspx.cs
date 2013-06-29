using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class OnlinePay_Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JS.Text = string.Format(@"<script language=""javascript"">document.getElementById(""aspnetForm"").action = ""{0}"";</script>", Bank.Pay_URL);
        int userID = ((Users)Session["Identify"]).UserID;
        string userNumber = Bank.GetUserNumber(userID);

        string mid = Bank.V_MID;
        string oid = Bank.Get_V_OID(userID);
        string rcvname = userNumber;
        string amount = Bank.V_AMOUNT;
        string ymd = DateTime.Now.ToString("yyyyMMdd");
        string moneytype = Bank.V_MONEYTYPE;
        string url = Bank.V_URL;

        v_mid.Text = MakeHiddenField("v_mid", mid);
        v_oid.Text = MakeHiddenField("v_oid", oid);

        v_rcvname.Text = MakeHiddenField("v_rcvname", rcvname);
        v_rcvaddr.Text = MakeHiddenField("v_rcvaddr", userNumber);
        v_rcvtel.Text = MakeHiddenField("v_rcvtel", userNumber);
        v_rcvpost.Text = MakeHiddenField("v_rcvpost", userNumber);

        v_amount.Text = MakeHiddenField("v_amount", amount);
        v_ymd.Text = MakeHiddenField("v_ymd", ymd);
        v_orderstatus.Text = MakeHiddenField("v_orderstatus", Bank.V_ORDERSTATUS);
        v_ordername.Text = MakeHiddenField("v_ordername", userNumber);

        v_moneytype.Text = MakeHiddenField("v_moneytype", moneytype);
        v_url.Text = MakeHiddenField("v_url", url);

        string serial = moneytype + ymd + amount + rcvname + oid + mid + url;
        v_md5info.Text = MakeHiddenField("v_md5info", Bank.ComputeHmacString(Bank.HMAC_KEY, serial));

        if (userID <= 1182)
            UserNumber.Text = string.Format("A2012{0:d4}", userID);
        else
            UserNumber.Text = string.Format("B2012{0:d4}", userID - 1182);
        BillNumber.Text = oid;
        BillAmount.Text = amount;
    }

    private string MakeHiddenField(string name, string value)
    {
        return string.Format(@"<input type=""hidden"" name=""{0}"" value=""{1}"" />", name, value);
    }
}

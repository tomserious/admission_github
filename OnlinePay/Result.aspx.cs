using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class OnlinePay_Result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string v_oid = Request["v_oid"];
        string v_pstatus = Request["v_pstatus"];
        string v_pstring = Request["v_pstring"];
        string v_pmode = Request["v_pmode"];
        string v_md5info = Request["v_md5info"];
        string v_amount = Request["v_amount"];
        string v_moneytype = Request["v_moneytype"];
        string v_md5money = Request["v_md5money"];
        string v_sign = Request["v_sign"];

        string infoSerial = v_oid + v_pstatus + v_pstring + v_pmode;
        string md5info = Bank.ComputeHmacString(Bank.HMAC_KEY, infoSerial);

        string moneySerial = v_amount + v_moneytype;
        string md5money = Bank.ComputeHmacString(Bank.HMAC_KEY, moneySerial);

        StreamWriter sw = new StreamWriter(Server.MapPath("/OnlinePay/Log.txt"), true);

        if (md5money == v_md5money)
        {
            if (v_pstatus == "1")
                Message.Text = string.Format("您编号为 {0} 的订单已提交", v_oid);
            else if (v_pstatus == "20")
                Message.Text = string.Format("您编号为 {0} 的订单支付成功。支付金额为：人民币 {1} 元", v_oid, v_amount);
            else if (v_pstatus == "30")
                Message.Text = string.Format("您编号为 {0} 的订单支付失败", v_oid);
            sw.WriteLine("#{0}\t{1}\t{2}", v_pstatus, v_oid, v_amount);
        }
        else
        {
            Message.Text = string.Format("您编号为 {0} 的订单数据校验失败，请联系客服", v_oid);
            sw.WriteLine("#MD5\t{0}\t{1}\t{2}", v_pstatus, v_oid, v_amount);
        }

        sw.Close();
    }
}

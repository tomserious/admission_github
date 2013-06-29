using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Debug_Secret : System.Web.UI.Page
{
    private static string connString = ConfigurationManager.ConnectionStrings["AdmissionConnString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["SecretKey"] == null || Request["SecretKey"] != "13811943930")
        {
            Response.Write("Something you will NEVER know!");
            Response.End();
        }
    }
}

using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;


public partial class Contract : System.Web.UI.Page
{

    DAL objdal = new DAL();
    SQLManager objsql = new SQLManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Label1.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            Int64 nipno = Convert.ToInt64(txtnipno.Text.ToString());


            bool flag = GetData(nipno);

            if (flag == true)

                Response.Redirect("PlacementLetter.aspx?nipno=" + nipno);

            else

            Label1.Visible = true;
            Label1.Text = "Reference/Tracking Number does not exist";
        }
        catch(Exception ex)
        {

            Label1.Visible = true;
            Label1.Text = "Enter Valid Reference number!";
        }

        

    }

    public bool GetData(Int64 nipid)
    {

        DataTable dt;

        dt = objdal.ExecuteQuery("select * from DiplomaHolder where NIPNO=" + nipid);

      if( dt.Rows.Count >0)
          return true;
      else
          return false;
    }

}
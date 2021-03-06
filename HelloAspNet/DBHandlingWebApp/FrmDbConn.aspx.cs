using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBHandlingWebApp
{
    public partial class FrmDbconn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConn_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                //LblResult.Text = conn.State.ToString();
                var query = @"Insert Memos 
              Values('박효진', 'redplus@devlec.com', '박효진입니다.', GetDate(), '127.0.0.1')";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    LblResult.Text = "데이터 저장 완료";
                }
                catch (Exception ex)
                {
                    LblResult.Text = $"오류{ex}";
                }

            }
        }
    }
}
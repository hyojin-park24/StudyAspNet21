using System;
using System.Web.UI;
namespace FirstWebApp
{
    public partial class FrmResponseWrite : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("안녕하세요.<br/>");
        }

        protected void BtnMsg_Click(object sender, EventArgs e)
        {
            Response.Write("<span style='color:blue;'>반갑습니다.</span>");
        }

        protected void BtnJs_Click(object sender, EventArgs e)
        {
            string strScript = @"<script language = 'javascript'>
                                   window.alert('안녕하세요!');
                                    </script>";
            Response.Write(strScript);
        }

        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.naver.com"); //화면 전환 자바의 location redirect와 같음
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmPageLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "제목변경";
            Page.Title = "또 제목변경";

            //동적으로 css 추가할 수 있음 
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = "Content/main.css";
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type","text/css");

            HtmlHead htmlHead = Page.Header;
            htmlHead.Controls.Add(cssLink);

            //제일 중요
            if (!Page.IsPostBack)
                Response.Write("[1] 폼이 최초로드되었습니다.<br />");
            else
                Response.Write("[2] 폼이 다시 로드되었습니다.<br />");

            Response.Write("[3] 항상 실행.<br/>");
        }

        protected void BtnPostBack_Click(object sender, EventArgs e)
        {
            var strScript = @"<script> window.alert('PostBack!'); </script>";
            // Response.Write(strScript); 단순 작업
            // 실제 스크립트 작업
            ClientScript.RegisterClientScriptBlock(this.GetType(), "postScript", strScript);
        }

        protected void BtnNewLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
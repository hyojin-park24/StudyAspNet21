using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardView : System.Web.UI.Page
    {
        private string _Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDelete.NavigateUrl = $"BoardDelete.aspx?Id={Request["Id"]}";
            lnkModify.NavigateUrl = $"BoardModify.aspx?Id={Request["Id"]}";
            lnkReply.NavigateUrl = $"BoardReply.aspx?Id={Request["Id"]}";

            _Id = Request["Id"];
            if (_Id == null) Response.Redirect("BoardList.aspx");
            if (!Page.IsPostBack) DisplayData();
        }

        private void DisplayData()
        {
            var repo = new DBRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            lblNum.Text = _Id;
            lblName.Text = note.Name;
            lblEmail.Text = string.Format("<a href='mailto:{0}'>{0}</a>", note.Email);
            lblTitle.Text = note.Title;

            string content = note.Content;

            // 인코딩 방식 : Text, Html, Mixed
            string encoding = note.Encoding;
            if(encoding == "Text")
            {
                lblContent.Text = Helpers.HtmUtillity.EncodeWithTabAndSpace(content);
            }
            else if (encoding == "Mixed")
            {
                lblContent.Text = content.Replace("\r\n", "<br />");
            }
            else //Html
            {
                lblContent.Text = content; //변환없이 찍어주기 
            }

            lblReadCount.Text = note.ReadCount.ToString();
            lblHomepage.Text = $"<a href='{note.Homepage}' target='_blank'>{note.Homepage}</a>";
            lblPostDate.Text = note.PostDate.ToString();
            lblPostIP.Text = note.PostIp;
        }
    }
}
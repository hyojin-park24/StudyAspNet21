using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        private string _Id; //리스트에서 넘겨주는 번호
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write; // 기본값:글쓰기
        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"]; //Get/Post값 다 받음

            if (!Page.IsPostBack) //최초 로드시
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDescription.Text = "글쓰기 - 다음 필드들을 입력하세요";
                        break;
                    case BoardWriteFormType.Modify:
                        LblTitleDescription.Text = "글수정 - 아래 필드들을 수정하세요";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        LblTitleDescription.Text = "글답변 - 다음 필드들을 입력하세요";
                        DisplayDataForModify();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayDataForModify()
        {
            throw new NotImplementedException();
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if(IsImageTextCorrect())
            {
                //TODO: 파일업로드

                Note note = new Note();
                note.Id = Convert.ToInt32(_Id); //없으면 0
                note.Name = txtName.Text;
                note.Email = txtEmail.Text;
                note.Title = txtTitle.Text;
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text;
                note.FileName = "";
                note.FileSize = 0;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue; // Text, Html, Mixed

                DBRepository repo = new DBRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        break;
                    case BoardWriteFormType.Reply:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        private bool IsImageTextCorrect()
        {
          if(Page.User.Identity.IsAuthenticated) //이미
            {
                return true;
            }
          else
            {
                if(Session["ImageText"] !=null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false; // 보안코드 일치하지 않음
        }
    }
}
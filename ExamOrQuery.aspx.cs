using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ExamOrQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(Session["UserRole"].ToString() == "students")
        {
            PageBtn.Visible = false;
        }
        else
        {
            string teacher = Session["UserJob"].ToString();
            string lessonName = teacher.Substring(0, teacher.IndexOf("老师"));
            Session["TeacherSubject"] = lessonName;
            ExamBtn.Visible = false;
        }    
    }

    protected void ExamBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student/StudentExam.aspx");
        //Response.Write("<script>window.open('Student/StudentExam.aspx')</script>");
    }

    protected void QueryBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryScore.aspx");
    }

    protected void PageBtn_Click(object sender, EventArgs e)
    {
        if (Session["UserRole"].ToString() == "managers")
        {
            Response.Redirect("Teacher/managers.aspx");
        }
        else
        {
            Response.Redirect("Admin/admins.aspx");
        }
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        Session["UserRole"] = null;
        Session["UserName"] = null;
        Response.Redirect("login.aspx");
    }
}
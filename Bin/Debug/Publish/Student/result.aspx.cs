using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int score = 0;
        string correct = Session["CorrectAnswer"].ToString();
        string student = Session["StudentAnswer"].ToString();
        CorrAnsLabel.Text = correct;
        StuAnsLabel.Text = student;
        for (int i = 0; i < Convert.ToInt32(Request.QueryString["BInt"]); i++)
        {
            if (correct.Substring(i, 1).Equals(student.Substring(i, 1)))
            {
                // 题目分值
                score += 5;
            }
        }
        CourseLabel.Text = Session["UserCourse"].ToString();
        IdLabel.Text = Session["UserCode"].ToString();
        NameLabel.Text = Session["UserName"].ToString();
        ScoreLabel.Text = score.ToString();
        string sql = string.Format("update Score set StudentScore='{0}' where UserCode='{1}' and LessonName='{2}'",
            score.ToString(), Session["UserCode"].ToString(), Session["UserCourse"].ToString());
        SqlOperation.QueryOperate(sql);
    }
}
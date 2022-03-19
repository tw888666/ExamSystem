using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
// dr.read 有坑！！！
public partial class QueryScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserRole"].ToString() == "students")
            {
                StudentBox.Visible = true;
                StudentBtn.Visible = true;
                StudentLabel.Visible = true;
                StudentLabel.Text = "请输入学号";
            }
            if (Session["UserRole"].ToString() == "managers")
            {
                TeacherBtn.Visible = true;
                TeacherLabel.Visible = true;
                TeacherLabel.Visible = true;
                TeacherLabel.Text = Session["UserJob"].ToString() + Session["UserName"].ToString() + "你好！";
            }
            if (Session["UserRole"].ToString() == "admins")
            {
                string sql = "select * from Score";
                SqlDataReader dr = SqlOperation.ReaderOperate(sql);
                ScoreView.DataSource = dr;
                ScoreView.DataBind();
                ScoreView.Visible = true;
                RootBox.Visible = true;
                RootBtn.Visible = true;
                RootLabel.Visible = true;
                RootLabel.Text = "请输入学号或课程名";
                dr.Close();
            }
        }
    }

    protected void RootBtn_Click(object sender, EventArgs e)
    {
        string sql = "select UserCode as 学号, UserName as 姓名,LessonName as 课程," +
    "StudentScore as 总分,StudentAnswer as 学生答案,CorrectAnswer as 正确答案 from Score " +
    "where LessonName='" + RootBox.Text + "' or UserCode='" + RootBox.Text + "'";
        string sql1 = "select Code from Users where Code='" + RootBox.Text + "'";
        string sql2 = "select Name from Lesson where Name='" + RootBox.Text + "'";
        if (SqlOperation.ScalarOperate(sql1) == null && SqlOperation.ScalarOperate(sql2) == null)
        {
            RootLabel.Text = "请输入正确的学号或课程名";
        }
        else
        {
            SqlDataReader dr = SqlOperation.ReaderOperate(sql);
            if (dr.HasRows)
            {
                ScoreView.DataSource = dr;
                ScoreView.DataBind();
                ScoreView.Visible = true;
                RootLabel.Text = "";
            }
            else
            {

                RootLabel.Text = "暂无考试成绩！";
            }
            dr.Close();
        }
    }

    protected void TeacherBtn_Click(object sender, EventArgs e)
    {
        string sql = "select UserCode as 学号, UserName as 姓名,LessonName as 课程," +
            "StudentScore as 总分,StudentAnswer as 学生答案,CorrectAnswer as 正确答案 from Score where LessonName='" + Session["TeacherSubject"] + "'";
        SqlDataReader dr = SqlOperation.ReaderOperate(sql);
        ScoreView.DataSource = dr;
        ScoreView.DataBind();
        ScoreView.Visible = true;
        dr.Close();
    }

    protected void StudentBtn_Click(object sender, EventArgs e)
    {
        string sql = "select UserCode as 学号, UserName as 姓名,LessonName as 课程," +
            "StudentScore as 总分,StudentAnswer as 学生答案,CorrectAnswer as 正确答案 from Score where UserCode='" + Session["UserCode"] + "'";
        SqlDataReader dr = SqlOperation.ReaderOperate(sql);
        if (StudentBox.Text == Session["UserCode"].ToString())
        {
            if (dr.HasRows)
            {
                ScoreView.DataSource = dr;
                ScoreView.DataBind();
                ScoreView.Visible = true;
                StudentBox.Text = "";
            }
            else
            {
                StudentLabel.Text = "暂无考试记录！";
            }
        }
        else
        {
            StudentLabel.Text = "请输入本人正确的学号";
        }
        dr.Close();
    }
}

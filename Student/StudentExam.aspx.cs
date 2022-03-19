using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Student_StudentExam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            //不能一个页面考两次哦①
            // 已解决!
            if (!Page.IsPostBack)
            {
                if (Session["UserRole"].ToString() == "students")
                {
                    LabelCode.Text = Session["UserCode"].ToString();
                    LabelName.Text = Session["UserName"].ToString();
                    LabelSex.Text = Session["UserSex"].ToString();
                    BindDropDownList();
                }
                else
                {
                    Response.Redirect("../login.aspx");
                }
            }
        }
    }

    private void BindDropDownList()
    {
        string sql = "select * from Lesson";
        SqlDataReader dr = SqlOperation.ReaderOperate(sql, CourseList, "Name");
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        Session["UserRole"] = null;
        Session["UserName"] = null;
        Response.Redirect("../login.aspx");
    }

    protected void SelectTopic_Click(object sender, EventArgs e)
    {
        if (HaveRead.Checked)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            MessageLabel.Text = "";
        }
        else
        {
            MessageLabel.Text = "请接受考试规则";
        }
    }

    protected void StartExam_Click(object sender, EventArgs e)
    {
        string userCode = Session["UserCode"].ToString();
        string lessonName = CourseList.SelectedValue;
        string sql = "select LessonName from Score where UserCode=@uc and LessonName=@ln";
        SqlParameter[] pms = new SqlParameter[]
        {
            new SqlParameter("uc",userCode),
            new SqlParameter("ln",lessonName)
        };
        object studentLesson = SqlOperation.ScalarOperate(sql, pms);
        if (studentLesson != null)
        {
            MessageLabel.Text = "你已经参加过此科目的考试了！";
            AgainLabel.Visible = true;
            PasswordText.Visible = true;
            AgainBtn.Visible = true;
            AgainMsgLabel.Visible = true;
            Panel2.Visible = false;
            Session["UserCourse"] = lessonName;
        }
        else
        {
            sql = "select count(*) from Topic where Course=@cs and isPublic=1";
            pms = new SqlParameter[]
            {
                new SqlParameter("cs",lessonName)
            };
            int n = Convert.ToInt32(SqlOperation.ScalarOperate(sql, pms));
            if (n > 0)
            {
                sql = "insert into Score(UserCode,LessonName,UserName) values('" + userCode + "','" + lessonName + "','" + LabelName.Text + "')";
                SqlOperation.QueryOperate(sql);
                Session["UserCourse"] = lessonName;
                //第三个参数没啥用
                // 能不能完全全屏呢？
                Response.Write("<script>window.open('StartExam.aspx','newWindow','status=0,scrollbars=1,resizable=1,depended=1')</script>");
                //能否清除back键？或者关闭整个浏览器？
                //open=创建新选项卡 redirect=当前页面输入网站
                // open无back记录，redirect有back记录.

                // ②的暂时解决方案
                Response.Write("<script>var mywinodw = window.open('../ExamOrQuery.aspx','_self');mywindow.close();</script>");
                //close 只能关闭由open打开的窗口！
            }
            else
            {
                MessageLabel.Text = "此科目没有考试题！";
            }
        }
    }
    // 如果考完一次再选择重考界面并返回前一个页面会有bug！会显示前一次考试的试卷！②
    // bug为能直接重考
    protected void AgainBtn_Click(object sender, EventArgs e)
    {
        string pwd = PasswordText.Text;
        string sql = "select ResitPassword from Lesson where Name='" + Session["UserCourse"].ToString() + "'";
        if (pwd == SqlOperation.ScalarOperate(sql).ToString())
        {
            sql = "delete from Score where UserName='" + Session["UserName"].ToString() + "' and LessonName='" + Session["UserCourse"].ToString() + "'";
            SqlOperation.QueryOperate(sql);
            Response.Redirect("../login.aspx");

        }
        else
        {
            AgainMsgLabel.Text = "重考密码不正确！";
        }
    }
}
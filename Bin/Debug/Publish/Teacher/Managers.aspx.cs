using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Teacher_Managers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            if (Session["UserRole"].ToString() == "managers")
            {
                Label1.Text = "欢迎" + Session["UserJob"] + Session["UserName"] + "登录！";
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }

    protected void Exit_Click(object sender, EventArgs e)
    {
        Session["UserRole"] = null;
        Session["UserName"] = null;
        Response.Redirect("../login.aspx");
    }
    // 需要题号! id好像可以！
    protected void AddBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTopic.aspx");
    }

    protected void DelBtn_Click(object sender, EventArgs e)
    {
        string sql = "delete from Topic where Id='" + DelText.Text + "' and Course='" + Session["TeacherSubject"].ToString() + "'";
        if (SqlOperation.QueryOperate(sql) > 0)
        {
            DelLabel.Text = "删除成功!";
        }
        else
        {
            DelLabel.Text = "题号不存在或该题不是您所教学的科目!";
        }
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateTopic.aspx");
    }

    protected void QueryBtn_Click(object sender, EventArgs e)
    {
        string sql = "select Id as 题号,Content as 题目内容," +
            "Option1 as A,Option2 as B,Option3 as C,Option4 as D," +
            "CorrectAnswer as 正确答案,IsPublic as 发布状态,Course as 课程 " +
            "from Topic where Id='" + QueryText.Text + "' and Course='" + Session["TeacherSubject"].ToString() + "'";
        SqlDataReader dr = SqlOperation.ReaderOperate(sql);
        if (dr.HasRows)
        {
            QueryLabel.Text = "";
            TopicView.DataSource = dr;
            TopicView.DataBind();
        }
        else
        {
            QueryLabel.Text = "题号不存在或该题不是您所教学的科目!";
        }
    }
}
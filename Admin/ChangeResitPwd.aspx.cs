using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChangeResitPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "update Lesson set ResitPassword='" + Pwd2Text.Text + "' where Name='" + CourseText.Text + "' or Code='" + CourseText.Text + "'";
        if(SqlOperation.QueryOperate(sql) > 0)
        {
            Label1.Text = "修改成功！";
        }
        else
        {
            Label1.Text = "修改失败！课程名或课程号错误！";
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admins.aspx");
    }
}
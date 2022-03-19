using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ResetPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "update Users set Password=123 where Code='"+TextBox1.Text+"'";
        if(SqlOperation.QueryOperate(sql) > 0)
        {
            Label1.Text = "重置成功！新密码为123";
        }
        else
        {
            Label1.Text = "重置失败！用户编号不存在！";
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("admins.aspx");
    }
}
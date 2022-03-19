using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Admins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            if (Session["UserRole"].ToString() == "admins")
            {
                Response.Write(Session["UserJob"].ToString() + Session["UserName"].ToString() + "你好！");
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }

    protected void ResetPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("resetpwd.aspx");
    }

    protected void ChangeResitPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("changeresitpwd.aspx");
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../ExamOrQuery.aspx");
    }
}
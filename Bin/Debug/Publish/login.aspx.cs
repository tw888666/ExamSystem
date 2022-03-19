using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_yzm.ImageUrl = "ImageCode.aspx";
    }

    public string cons = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

    protected void Button1_Click(object sender, EventArgs e)
    {
        string code = tbx_yzm.Text;
        HttpCookie htco = Request.Cookies["ImageV"];
        string scode = htco.Value.ToString();
        string scode_lower = scode.ToLower();
        string code_lower = code.ToLower();
        if (code_lower != scode_lower)
        {//如果验证码不正确，则弹出提示对话框
            Response.Write("<script>alert('验证码输入不正确！')</script>");
        }
        else
        {
            string userCode = UserNameBox.Text;
            string userPwd = PasswordBox.Text;
            string sqlRole = "select Role.Name from Role,Users where Users.Code=@c and Password=@p and Role.Code = RoleCode";
            string sqlCode = "select Code from Users where Code=@c and Password=@p";
            string sqlSex = "select Sex from Users where Code=@c and Password=@p";
            string sqlName = "select Name from Users where Code=@c and Password=@p";
            string sqlJob = "select Job from Users where Code=@c and Password=@p";
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@c",userCode),
                new SqlParameter("@p",userPwd)
            };
            object role = SqlOperation.ScalarOperate(sqlRole, pms);
            object uCode = SqlOperation.ScalarOperate(sqlCode, pms);
            object name = SqlOperation.ScalarOperate(sqlName, pms);
            object sex = SqlOperation.ScalarOperate(sqlSex, pms);
            object job = SqlOperation.ScalarOperate(sqlJob, pms);
            if (role != null)
            {
                Session["UserRole"] = role.ToString();
                Session["UserName"] = name.ToString();
                Session["UserSex"] = sex.ToString();
                Session["UserCode"] = uCode.ToString();
                Session["UserJob"] = job.ToString();
                string userRole = role.ToString();
                if (userRole == "admins" || userRole == "managers" || userRole == "students")
                {
                    Response.Redirect("ExamOrQuery.aspx");
                    //Response.Write("<script>location.replace(ExamOrQuery.aspx)</script>");
                }
                else
                {
                    Response.Write("<script>alert('用户角色错误！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误，请重新输入！')</script>");
            }
        }
    }



    protected void reset_Click(object sender, EventArgs e)
    {
        UserNameBox.Text = "";
        PasswordBox.Text = "";
        tbx_yzm.Text = "";
        UserNameBox.Focus();
    }
}
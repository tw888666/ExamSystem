using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
// 所谓的回发就是在页面加载以后,在本页有提交服务器的动作 this.IsPostBack == true 表示是回发
// 例如:点击按钮 即带有server的控件事件
// 调用回发函数时先执行Page_Load在执行回发函数
public partial class Student_StartExam : System.Web.UI.Page
{
    // 每一次age_Load都是重建Page类
    // static成员只有关闭窗口才会重新初始化
    public int topicNum = 0;
    static public int num = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        IdLabel.Text = Session["UserCode"].ToString();
        NameLabel.Text = Session["UserName"].ToString();
        SexLabel.Text = Session["UserSex"].ToString();
        TitleLabel.Text = Session["UserCourse"].ToString() + "考试试题";
        // 题目数
        string sql = "select top "+num+" * from Topic where Course='" + Session["UserCourse"].ToString() + "' order by newid()";
        //string sql = string.Format("select top 10 * from Topic where Course='{0}' order by newid()", Session["UserCourse"]);
        SqlDataReader dr = SqlOperation.ReaderOperate(sql);
        int serial = 1;
        string ans = "";
        // 生成所有题目
        while (dr.Read())
        {
            Literal topicLiteral = new Literal();
            RadioButtonList options = new RadioButtonList();
            options.ID = "topic" + serial.ToString();
            topicLiteral.Text = serial.ToString() + "、" + Server.HtmlEncode(dr["Content"].ToString()) + "\n";
            options.Items.Add("A. " + Server.HtmlEncode(dr["Option1"].ToString()));
            options.Items.Add("B. " + Server.HtmlEncode(dr["Option2"].ToString()));
            options.Items.Add("C. " + Server.HtmlEncode(dr["Option3"].ToString()));
            options.Items.Add("D. " + Server.HtmlEncode(dr["Option4"].ToString()));
            options.Font.Size = 11;
            for (int i = 0; i < 4; i++)
            {
                //topic1_0.value=A 给4个选项赋值
                switch (i)
                {
                    case 0:
                        options.Items[i].Value = "A";
                        break;
                    case 1:
                        options.Items[i].Value = "B";
                        break;
                    case 2:
                        options.Items[i].Value = "C";
                        break;
                    case 3:
                        options.Items[i].Value = "D";
                        break;
                }
            }
            ans += dr["CorrectAnswer"].ToString();
            // 这里很关键！
            if (Session["isFirst"] == null)
            {
                Session["CorrectAnswer"] = ans;
            }
            Panel1.Controls.Add(topicLiteral);
            Panel1.Controls.Add(options);
            serial++;
            topicNum++;
        }
        Session["isFirst"] = "No";
        dr.Close();

    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        string ans = "";
        for (int i = 1; i <= topicNum; i++)
        {
            // 此处有大坑！
            RadioButtonList list = (RadioButtonList)Panel1.FindControl("topic" + i.ToString());
            if (list != null)
            {
                if (list.SelectedValue != "")
                {
                    ans += list.SelectedValue;
                }
                else
                {
                    ans += "K";
                }
            }
        }
        Session["StudentAnswer"] = ans;
        string sql = "update Score set CorrectAnswer='" + Session["CorrectAnswer"].ToString() + "' " +
            "where UserCode='" + Session["UserCode"].ToString() + "' and LessonName ='" + Session["UserCourse"].ToString() + "'";
        SqlOperation.QueryOperate(sql);
        sql = "update Score set StudentAnswer='" + Session["StudentAnswer"].ToString() + "' " +
            "where UserCode='" + Session["UserCode"].ToString() + "'  and LessonName ='" + Session["UserCourse"].ToString() + "'";
        SqlOperation.QueryOperate(sql);
        // 在这里解决问题①
        Session["isFirst"] = null;
        Response.Redirect("result.aspx?BInt=" + topicNum);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Teacher_AddTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string answer = DropDownList1.SelectedValue;
        string sql = "insert into Topic values" +
            "('" + ContentText.Text + "','" + TextBoxA.Text + "','" + TextBoxB.Text + "','" + TextBoxC.Text + "','" + TextBoxD.Text + "','" +
            answer + "',1,'" + Session["TeacherSubject"].ToString() + "')";
        if (SqlOperation.QueryOperate(sql) > 0)
        {
            OptionRadio.Items.Add("A. " + TextBoxA.Text);
            OptionRadio.Items.Add("B. " + TextBoxB.Text);
            OptionRadio.Items.Add("C. " + TextBoxC.Text);
            OptionRadio.Items.Add("D. " + TextBoxD.Text);
            ContentLabel.Text = ContentText.Text;
            JudgeLabel.Text = "添加题目成功！";
            Panel1.Visible = true;
            ContentText.Text = "";
            TextBoxA.Text = "";
            TextBoxB.Text = "";
            TextBoxC.Text = "";
            TextBoxD.Text = "";
        }
        else
        {
            JudgeLabel.Text = "该题目已存在，添加失败！";
        }
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Managers.aspx");
    }
}
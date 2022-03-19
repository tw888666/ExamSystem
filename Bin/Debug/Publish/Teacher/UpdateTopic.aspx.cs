using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class Teacher_UpdateTopic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(IdText.Text);
        string sql = "select Content,Option1,Option2,Option3,Option4 from Topic where Id=@id and Course=@course";
        SqlParameter[] pms = new SqlParameter[]
        {
            new SqlParameter("id",id),
            new SqlParameter("course",Session["TeacherSubject"].ToString())
        };
        SqlDataReader dr = SqlOperation.ReaderOperate(sql, pms);
        if (dr.Read())
        {
            OptionRadio.Items.Clear();
            submitLabel.Text = "";
            IsUpdateLabel.Text = "原题目如下：";
            ContentLabel.Text = dr.GetString(0);
            OptionRadio.Items.Add("A. " + dr.GetString(1));
            OptionRadio.Items.Add("B. " + dr.GetString(2));
            OptionRadio.Items.Add("C. " + dr.GetString(3));
            OptionRadio.Items.Add("D. " + dr.GetString(4));
            ContentPanel.Visible = true;
            UpdatePanel.Visible = true;
            IdPanel.Visible = false;
        }
        else
        {
            submitLabel.Text = "题号不存在或该题不是您所教学的科目！";
        }
        dr.Close();
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(IdText.Text);
        string answer = DropDownList1.SelectedValue;
        string sql = string.Format("update Topic set Content='{0}'," +
            "Option1='{1}',Option2='{2}',Option3='{3}',Option4='{4}',CorrectAnswer='{5}' where Id='{6}'",
            ContentText.Text, TextBoxA.Text, TextBoxB.Text, TextBoxC.Text, TextBoxD.Text, answer, id);
        try
        {
            SqlOperation.QueryOperate(sql);
            OptionRadio.Items.Clear();
            OptionRadio.Items.Add("A. " + TextBoxA.Text);
            OptionRadio.Items.Add("B. " + TextBoxB.Text);
            OptionRadio.Items.Add("C. " + TextBoxC.Text);
            OptionRadio.Items.Add("D. " + TextBoxD.Text);
            ContentLabel.Text = ContentText.Text;
            IsUpdateLabel.Text = "修改后的题目如下：";
            JudgeLabel.Text = "";
            IdText.Text = "";
            ContentText.Text = "";
            TextBoxA.Text = "";
            TextBoxB.Text = "";
            TextBoxC.Text = "";
            TextBoxD.Text = "";
            ContentPanel.Visible = true;
            UpdatePanel.Visible = false;
            IdPanel.Visible = true;
        }
        catch
        {
            JudgeLabel.Text = "修改失败，题库中已有该题目！";
        }
    }

}

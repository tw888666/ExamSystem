using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NameSession 的摘要说明
/// 记录Session[Name] 的含义
/// </summary>
public class NameSession
{
    Dictionary<string, string> Session;
    public NameSession()
    {
        //
        // 带注释的为可不要的！
        //
        Session["UserName"] = "用户名";
        Session["UserCode"] = "用户编号";
        Session["UserRole"] = "用户角色";
        Session["UserSex"] = "用户性别";
        Session["UserCourse"] = "用户考试科目";
        Session["isFirst"] = "判断是否是第一次的题目";
        Session["StudentAnswer"] = "学生答案";
        Session["CorrectAnswer"] = "正确答案";
        Session["UserJob"] = "用户职位";
        Session["TeacherSubject"] = "老师教学科目";
        //Session["TopicId"] = "题号";
    }
}
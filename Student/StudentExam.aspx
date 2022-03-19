<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentExam.aspx.cs" Inherits="Student_StudentExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>考号:<asp:Label ID="LabelCode" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; 姓名：<asp:Label ID="LabelName" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; 性别：<asp:Label ID="LabelSex" runat="server"></asp:Label>
            </div>
            <br />
            <%--            <asp:Button ID="Exit" runat="server" Height="27px" OnClick="Exit_Click" Text="退出" />--%>
            <div>
                <asp:Label ID="MessageLabel" runat="server" Text="考试规则"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="AgainLabel" runat="server" Text="请输入重考密码：" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="PasswordText" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="AgainBtn" runat="server" Text="重新考一次" Visible="False" OnClick="AgainBtn_Click" />
                <asp:Label ID="AgainMsgLabel" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="Panel1" runat="server" Height="222px" Width="1275px">
                <div style="height: 163px; width: 1284px;">
                    一、自觉服从监考员等考试工作人员管理，不得以任何理由妨碍监考员等考试工作人员履行职责，不得扰乱考场及其他考试工作地点的秩序。<br />
                    二、凭准考证和与注册类型一致的有效身份证件，按规定时间和地点参加考试。
                    <div style="height: 120px; width: 1283px">

                        <asp:CheckBox ID="HaveRead" runat="server" Text="已阅读考试规则" />
                        <asp:Button ID="SelectTopic" runat="server" OnClick="SelectTopic_Click" Text="进入选题" />
                    </div>
                    </div>
                    
                    
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Height="234px" style="margin-right: 0px" Width="1280px" Visible="False">
                <div>请选择考试科目：<asp:DropDownList ID="CourseList" runat="server" Height="17px">
                    </asp:DropDownList>
                    <asp:Button ID="StartExam" runat="server" OnClick="StartExam_Click" Text="开始考试" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

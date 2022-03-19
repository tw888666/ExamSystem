<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeResitPwd.aspx.cs" Inherits="Admin_ChangeResitPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            请输入课程代码或课程名：<asp:TextBox ID="CourseText" runat="server"></asp:TextBox>
            <br />
            请输入新的重考密码：<asp:TextBox ID="PwdText" runat="server"></asp:TextBox>
            <br />
            请再次输入密码：<asp:TextBox ID="Pwd2Text" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="PwdText" ControlToValidate="Pwd2Text" Display="Dynamic" ErrorMessage="CompareValidator" ForeColor="Red">两次密码不一样！</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Pwd2Text" Display="Dynamic" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改密码" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" Text="返回主页" CausesValidation="False" />
        </div>
    </form>
</body>
</html>

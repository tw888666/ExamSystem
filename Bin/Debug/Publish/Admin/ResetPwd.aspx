<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPwd.aspx.cs" Inherits="Admin_ResetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        请输入用户编号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="重置密码" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" Text="返回主页" />
        </div>
    </form>
</body>
</html>


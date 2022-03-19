<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admins.aspx.cs" Inherits="Admin_Admins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ResetPwd" runat="server" OnClick="ResetPwd_Click" Text="重置密码" />
            <br />
            <br />
            <asp:Button ID="ChangeResitPwd" runat="server" OnClick="ChangeResitPwd_Click" Text="修改重考密码" />
            <br />
            <br />
            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" Text="返回主页" CausesValidation="False" />
        </div>
    </form>
</body>
</html>

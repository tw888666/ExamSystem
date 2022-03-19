<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TW</title>
    <link rel="stylesheet" href="CSS/StyleSheet.css" />
    <script src="https://cdn.bootcdn.net/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="JS/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="page">
            用户名：<asp:TextBox ID="UserNameBox" runat="server" Height="29px" Width="150px"></asp:TextBox>
            <br />
            <br />
            密　码：<asp:TextBox ID="PasswordBox" runat="server" Height="29px" Width="150px"></asp:TextBox>
            <br />
            <br />
            验证码：<asp:TextBox ID="tbx_yzm" runat="server" Width="70px"></asp:TextBox>
            <!--换普通的image控件 注意这里在使用外部css时会出现element.style-->
            <asp:Image ID="ibtn_yzm" runat="server" style="cursor:pointer" onclick="changeCode()"/>

            <!--click事件跟keyup从哪里来的呢？暂时猜测重新加载页面了-->
            <%--<asp:ImageButton ID="ibtn_yzm" runat="server"/>--%>
            <!--执行js代码changeCode()-->
            <a href="javascript:changeCode()" style="text-decoration: underline; font-size: 10px;">换一张</a>
            <br />
            <br />
            <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtn_Click" Text="登录" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ResetBtn" runat="server" OnClick="ResetBtn_Click" Text="重置" />
        </div>
    </form>
</body>
    <script>bodyEnter();</script>
</html>

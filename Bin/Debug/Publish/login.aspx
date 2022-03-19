<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TW</title>
    <link rel="stylesheet" href="CSS/StyleSheet.css" />
    <script language="javascript">
        self.moveTo(0, 0);
        self.resizeTo(screen.availWidth, screen.availHeight);
    </script>
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
            <asp:ImageButton ID="ibtn_yzm" runat="server" />
            <a href="javascript:changeCode()" style="text-decoration: underline; font-size: 10px;">换一张</a>
            <script type="text/javascript">
                function changeCode() {
                    document.getElementById('ibtn_yzm').src = document.getElementById('ibtn_yzm').src + '?';
                    //;这一句使服务器重新生成图片, 问号的作用是忽悠浏览器, 不要让浏览器缓存
                }
            </script>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登录" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="reset" runat="server" OnClick="reset_Click" Text="重置" />
        </div>
    </form>
</body>
</html>

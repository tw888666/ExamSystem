<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartExam.aspx.cs" Inherits="Student_StartExam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../CSS/exam.css" />
    <%--导入js包--%>
    <script src="../JS/main.js"></script>
    <script language="javascript">
        self.moveTo(0, 0);
        self.resizeTo(screen.availWidth, screen.availHeight);
    </script>
</head>
<body onkeydown="keyDown()" onload="init()">
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div>考号：<asp:Label ID="IdLabel" runat="server"></asp:Label></div>
                <div>姓名：<asp:Label ID="NameLabel" runat="server"></asp:Label></div>
                <div>性别：<asp:Label ID="SexLabel" runat="server"></asp:Label></div>
                <div>
                    <asp:Button ID="SubmitBtn" runat="server" Text="交卷" OnClick="SubmitBtn_Click" />
                </div>
            </div>
            <div style="text-align: center">
                <asp:Label ID="TitleLabel" runat="server"></asp:Label>
            </div>
            <%--注意使用innerHTML盒子里的asp控件也会被替换!!!!--%>
            <div id="examText">
                <asp:Label ID="ExamLabel" runat="server"></asp:Label>
                <asp:Label ID="TimeLabel" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="Panel1" runat="server" Height="234px" Width="1808px">
            </asp:Panel>
        </div>
    </form>
</body>
</html>

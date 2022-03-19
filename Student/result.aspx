<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="Student_result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../CSS/result.css" />
</head>
<body>
    <%--css布局已完成！--%>
    <form id="form1" runat="server">
        <div>
            <div>
                你的答案：<asp:Label ID="StuAnsLabel" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 正确答案：<asp:Label ID="CorrAnsLabel" runat="server"></asp:Label>
            </div>
            <div class="container1">
                <div>考试科目</div>
                <div>考生考号</div>
                <div>考生姓名</div>
                <div>考试成绩</div>
            </div>

            <div class="container2">
                <div>
                    <asp:Label ID="CourseLabel" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="IdLabel" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="NameLabel" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" ID="ScoreLabel"></asp:Label>
                </div>
            </div>

        </div>
    </form>
</body>
</html>

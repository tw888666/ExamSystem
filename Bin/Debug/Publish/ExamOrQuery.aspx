<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamOrQuery.aspx.cs" Inherits="ExamOrQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ExamBtn" runat="server" OnClick="ExamBtn_Click" Text="考试" />
            <br />
            <br />
            <asp:Button ID="QueryBtn" runat="server" OnClick="QueryBtn_Click" Text="查分" />
            <br />
            <br />
            <asp:Button ID="PageBtn" runat="server" OnClick="PageBtn_Click" Text="主页" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>

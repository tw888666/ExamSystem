<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryScore.aspx.cs" Inherits="QueryScore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="RootLabel" runat="server" Visible="False"></asp:Label>
            <asp:TextBox ID="RootBox" runat="server" Visible="False"></asp:TextBox>
            <asp:Button ID="RootBtn" runat="server" OnClick="RootBtn_Click" Text="查分" Visible="False" />
            <br />
            <asp:Label ID="TeacherLabel" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="TeacherBtn" runat="server" OnClick="TeacherBtn_Click" Text="查分" Visible="False" />
            <br />
            <asp:Label ID="StudentLabel" runat="server" Visible="False"></asp:Label>
            <asp:TextBox ID="StudentBox" runat="server" Visible="False"></asp:TextBox>
            <asp:Button ID="StudentBtn" runat="server" Height="27px" OnClick="StudentBtn_Click" Text="查分" Visible="False" />
            <br />
            <br />
            <asp:GridView ID="ScoreView" runat="server" Visible="False">
            </asp:GridView>
            <br />
            <asp:Button ID="BackBtn" runat="server" OnClick="BackBtn_Click" Text="返回上一页" />
        </div>
    </form>
</body>
</html>

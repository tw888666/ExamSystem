<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managers.aspx.cs" Inherits="Teacher_Managers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:pink">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="AddBtn" runat="server" Text="增加题目" OnClick="AddBtn_Click" />
        <br />
        <br />
        <asp:Label ID="DelLabel" runat="server" Text="请输入需要删除的题号"></asp:Label>
        <asp:TextBox ID="DelText" runat="server"></asp:TextBox>
        <asp:Button ID="DelBtn" runat="server" Text="删除题目" OnClick="DelBtn_Click" Height="28px" Width="102px" />
        <br />
        <br />
        <asp:Button ID="UpdateBtn" runat="server" Text="修改题目" OnClick="UpdateBtn_Click" />
        <br />
        <br />
        <asp:Label ID="QueryLabel" runat="server" Text="请输入需要查询的题号"></asp:Label>
        <asp:TextBox ID="QueryText" runat="server"></asp:TextBox>
        <asp:Button ID="QueryBtn" runat="server" Text="查询题目" OnClick="QueryBtn_Click" />
        <br />
        <br />
        <asp:GridView ID="TopicView" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Exit" runat="server" Height="27px" OnClick="Exit_Click" Text="退出" />
    
    </div>
    </form>
</body>
</html>

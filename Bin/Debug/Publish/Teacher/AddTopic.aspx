<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTopic.aspx.cs" Inherits="Teacher_AddTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="请输入题目内容"></asp:Label>
            <asp:TextBox ID="ContentText" runat="server" Width="188px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            请输入选项A的内容：<asp:TextBox ID="TextBoxA" runat="server"></asp:TextBox>
            <br />
            请输入选项B的内容：<asp:TextBox ID="TextBoxB" runat="server"></asp:TextBox>
            <br />
            请输入选项C的内容：<asp:TextBox ID="TextBoxC" runat="server"></asp:TextBox>
            <br />
            请输入选项D的内容：<asp:TextBox ID="TextBoxD" runat="server"></asp:TextBox>
            <br />
            请选择该题目的正确答案：<asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="A"></asp:ListItem>
                <asp:ListItem Value="B"></asp:ListItem>
                <asp:ListItem Value="C"></asp:ListItem>
                <asp:ListItem Value="D"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="添加题目" OnClick="Button1_Click" />
            <asp:Label ID="JudgeLabel" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="246px" Visible="False" Width="1739px">
            <asp:Label ID="ContentLabel" runat="server"></asp:Label>
            <asp:RadioButtonList ID="OptionRadio" runat="server">
            </asp:RadioButtonList>
        </asp:Panel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateTopic.aspx.cs" Inherits="Teacher_UpdateTopic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:Panel ID="IdPanel" runat="server">
                请输入要修改的题号：<asp:TextBox ID="IdText" runat="server"></asp:TextBox>
                <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="提交" />
                <asp:Label ID="submitLabel" runat="server"></asp:Label>
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="UpdatePanel" runat="server" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="请输入修改后的题目内容"></asp:Label>
                <asp:TextBox ID="ContentText" runat="server" Width="188px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidContent" runat="server" ControlToValidate="ContentText" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                请输入选项A的内容：<asp:TextBox ID="TextBoxA" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidA" runat="server" ControlToValidate="TextBoxA" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
                <br />
                请输入选项B的内容：<asp:TextBox ID="TextBoxB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidB" runat="server" ControlToValidate="TextBoxB" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
                <br />
                请输入选项C的内容：<asp:TextBox ID="TextBoxC" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidC" runat="server" ControlToValidate="TextBoxC" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
                <br />
                请输入选项D的内容：<asp:TextBox ID="TextBoxD" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidD" runat="server" ControlToValidate="TextBoxD" ErrorMessage="RequiredFieldValidator">*必填</asp:RequiredFieldValidator>
                <br />
                请选择该题目的正确答案：<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="A"></asp:ListItem>
                    <asp:ListItem Value="B"></asp:ListItem>
                    <asp:ListItem Value="C"></asp:ListItem>
                    <asp:ListItem Value="D"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Button ID="UpdateBtn" runat="server" Text="修改题目" OnClick="UpdateBtn_Click" />
                <asp:Label ID="JudgeLabel" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="backBtn" runat="server" OnClick="BackBtn_Click" Text="返回上一页" CausesValidation="False" />
            </asp:Panel>
            <br />
            <br />
        </div>
        <asp:Panel ID="ContentPanel" runat="server" Height="246px" Visible="False" Width="1739px">
            <asp:Label ID="IsUpdateLabel" runat="server"></asp:Label>
            <br />
            <asp:Label ID="ContentLabel" runat="server"></asp:Label>
            <asp:RadioButtonList ID="OptionRadio" runat="server">
            </asp:RadioButtonList>
        </asp:Panel>
        </div>
    </form>
</body>
</html>

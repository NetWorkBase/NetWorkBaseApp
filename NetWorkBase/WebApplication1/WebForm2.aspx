<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="Update1">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" Text="测试" OnClick="Button1_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="Button2" runat="server" Text="测试" OnClick="Button2_Click" />
    </form>
</body>
</html>

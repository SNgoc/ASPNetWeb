<%-- Phần đầu là directive page --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="D1Hello.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="lbDisplay" runat="server" Text="HELLO WORLD"></asp:Label></h1>
            <p>
                <asp:Label ID="lbUser" runat="server" Text="User" style="margin-left: 321px"></asp:Label>
                <asp:TextBox ID="TextUser" runat="server" style="margin-left: 80px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lbPassword" runat="server" Text="Password" style="margin-left: 321px"></asp:Label>
                <asp:TextBox ID="TextPassword" runat="server" style="margin-left: 40px" TextMode="Password"></asp:TextBox>
            </p>
        </div>
        <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change text" />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" style="margin-left: 310px" />

        <div><asp:Label ID="lbResult" runat="server" Text="Check login result" style="margin-left: 380px"></asp:Label>
        </div>
        <div>
            <asp:CheckBox ID="chkRemember" Text ="Remember me?" style="margin-left: 380px" runat="server" />
        </div>
    </form>
</body>
</html>

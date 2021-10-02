<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebFormEF.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="textUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="textPassword" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbFullname" runat="server" Text="Fullname"></asp:Label>
            <asp:TextBox ID="textFullname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbBirthday" runat="server" Text="Birthday"></asp:Label>
            <asp:TextBox ID="textBirthday" runat="server" TextMode ="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbGender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="1">Male</asp:ListItem>
                <asp:ListItem Value="0">Female</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnCreate" Text="Create" runat="server" OnClick="btnCreate_Click" />
        </div>
    </form>
</body>
</html>

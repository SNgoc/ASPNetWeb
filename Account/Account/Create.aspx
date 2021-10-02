<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Account.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous"/>

</head>
<body>
    <div class="container">
        <div class="row">

        <form id="form1" runat="server">
            <h1 class="text-center">Create Account</h1>
                <div class="mb-3">
                        <asp:Label ID="Label1" runat="server" Text="Username" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pls input UserName" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>

                </div>
                <div class="mb-3">
                     <asp:Label ID="Label2" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-3">
                     <asp:Label ID="Label3" runat="server" Text="ConfirmPassword" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pls input Confirm Password same as password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    
                </div>
                <div class="mb-3">
                        <asp:Label ID="Label4" runat="server" Text="Fullname" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFullname" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pls input FullName" ControlToValidate="txtFullname"></asp:RequiredFieldValidator>

                </div>
                <div class="mb-3">
                        <asp:Label ID="Label5" runat="server" Text="Birthday" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtBirthDay" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pls input yourBirthday" ControlToValidate="txtBirthday"></asp:RequiredFieldValidator>

                </div>

            <div class="mb-3">
                        <asp:Label ID="Label6" runat="server" Text="Gender" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">Male</asp:ListItem>
                    <asp:ListItem Value="0">Female</asp:ListItem>
                        </asp:DropDownList>
                      

                </div>


                <div class="mb-3">
                    <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
        </form>

        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</body>
</html>

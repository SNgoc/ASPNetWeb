<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Account.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
.container,.container-lg,.container-md,.container-sm,.container-xl,.container-xxl{max-width:1320px}.container,.container-lg,.container-md,.container-sm,.container-xl{max-width:1140px}.container,.container-lg,.container-md,.container-sm{max-width:960px}.container,.container-md,.container-sm{max-width:720px}.container,.container-sm{max-width:540px}.container,.container-fluid,.container-lg,.container-md,.container-sm,.container-xl,.container-xxl{width:100%;padding-right:var(--bs-gutter-x,.75rem);padding-left:var(--bs-gutter-x,.75rem);margin-right:auto;margin-left:auto}*,::after,::before{box-sizing:border-box}.row{--bs-gutter-x:1.5rem;--bs-gutter-y:0;display:flex;flex-wrap:wrap;margin-top:calc(var(--bs-gutter-y) * -1);margin-right:calc(var(--bs-gutter-x) * -.5);margin-left:calc(var(--bs-gutter-x) * -.5)}.row>*{flex-shrink:0;width:100%;max-width:100%;padding-right:calc(var(--bs-gutter-x) * .5);padding-left:calc(var(--bs-gutter-x) * .5);margin-top:var(--bs-gutter-y)}.text-center{text-align:center!important}.h1,h1{font-size:2.5rem}.h1,h1{font-size:calc(1.375rem + 1.5vw)}.h1,.h2,.h3,.h4,.h5,.h6,h1,h2,h3,h4,h5,h6{margin-top:0;margin-bottom:.5rem;font-weight:500;line-height:1.2}.mb-3{margin-bottom:1rem!important}.form-label{margin-bottom:.5rem}.form-control{transition:none}.form-control{display:block;width:100%;padding:.375rem .75rem;font-size:1rem;font-weight:400;line-height:1.5;color:#212529;background-color:#fff;background-clip:padding-box;border:1px solid #ced4da;-webkit-appearance:none;-moz-appearance:none;appearance:none;border-radius:.25rem;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out}button,input,optgroup,select,textarea{margin:0;font-family:inherit;font-size:inherit;line-height:inherit}select{word-wrap:normal}button,select{text-transform:none}.btn-primary{color:#fff;background-color:#0d6efd;border-color:#0d6efd}.btn{transition:none}.btn{display:inline-block;font-weight:400;line-height:1.5;color:#212529;text-align:center;text-decoration:none;vertical-align:middle;cursor:pointer;-webkit-user-select:none;-moz-user-select:none;user-select:none;background-color:transparent;border:1px solid transparent;padding:.375rem .75rem;font-size:1rem;border-radius:.25rem;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out}[type=button],[type=reset],[type=submit],button{-webkit-appearance:button}</style>
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
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </div>
        </form>

        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</body>
</html>

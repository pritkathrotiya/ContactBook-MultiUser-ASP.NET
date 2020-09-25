<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/AdminPanel/Assets/css/bootstrap.min.css" />
    <script> src = "~/Content/AdminPanel/Assets/js/bootstrap.min.js"</script>
    <title></title>
    <style>
        .log-form {
            width: 40%;
            min-width: 320px;
            max-width: 475px;
            background: #fff;
            position: absolute;
            top: 50%;
            left: 50%;
            border-radius:3%;
            -webkit-transform: translate(-50%,-50%);
            -moz-transform: translate(-50%,-50%);
            -o-transform: translate(-50%,-50%);
            -ms-transform: translate(-50%,-50%);
            transform: translate(-50%,-50%);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container shadow log-form">
            <div class="row mt-5 mb-4">
                <div class="col-md-12 text-center">
                    <h2>Login To Address Book...</h2>
                </div>
            </div>
            <div class="form-group col-md-10 offset-md-1">
                <label>Username<span class="text-danger">*</span></label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                    ControlToValidate="txtUsername"
                    ErrorMessage="Enter Username"
                    Display="Dynamic"
                    CssClass="text-danger"
                    ValidationGroup="Login" />
            </div>
            <div class="form-group col-md-10 offset-md-1">
                <label>Password<span class="text-danger">*</span></label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                    ControlToValidate="txtPassword"
                    ErrorMessage="Enter Password"
                    Display="Dynamic"
                    CssClass="text-danger"
                    ValidationGroup="Login" />
            </div>
            <div class="row offset-md-1">
                <div class="col-md-5">
                    <asp:Button runat="server" ID="btnLogin" ValidationGroup="Login" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
                </div>
                <div class="col-md-6 text-right">
                    <asp:LinkButton runat="server" ID="lbRegisterUser" Text="Sign Up..." CssClass="mr-3" OnClick="lbRegisterUser_Click" />
                </div>
            </div>
            <div class="row mt-2 mb-5">
                <div class="col-md-12 text-center">
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

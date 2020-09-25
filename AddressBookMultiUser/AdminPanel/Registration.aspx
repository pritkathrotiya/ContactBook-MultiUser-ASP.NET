<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Admin_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="~/Content/AdminPanel/Assets/css/bootstrap.min.css" />
    <script> src = "~/Content/AdminPanel/Assets/js/bootstrap.min.js"</script>
    <title></title>
    <style>
        .log-form {
            width: 100%;
            min-width: 800px;
            max-width: 1000px;
            background: #fff;
            position: absolute;
            padding:3%;
            top: 50%;
            left: 50%;
            border-radius:2%;
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
            <div class="row mb-4">
                <div class="col-md-12">
                    <h3>Register Into Address Book</h3>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-md-2 col-form-label">Username<span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                        ControlToValidate="txtUsername"
                        ErrorMessage="Enter Username"
                        Display="Dynamic"
                        CssClass="text-danger"
                        ValidationGroup="Register" />
                </div>
                <label class="col-md-2 col-form-label">Password<span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="Enter Password"
                        Display="Dynamic"
                        CssClass="text-danger"
                        ValidationGroup="Register" />
                </div>
            </div>
            <div class="form-group row">
                <label class="col-md-2 col-form-label">Display Name<span class="text-danger">*</span></label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDisplayName" runat="server"
                        ControlToValidate="txtDisplayName"
                        ErrorMessage="Enter Display Name"
                        Display="Dynamic"
                        CssClass="text-danger"
                        ValidationGroup="Register" />
                </div>
                <label class="col-md-2 col-form-label">MobileNo</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMobileNo" runat="server"
                        ControlToValidate="txtMobileNo"
                        ErrorMessage="Enter Proper Mobile No"
                        Display="Dynamic"
                        CssClass="text-danger"
                        ValidationExpression="[0-9]{10}"
                        ValidationGroup="Register" />
                </div>
            </div>
            <div class="form-group row">
                <label class="col-md-2 col-form-label">Address</label>
                <div class="col-md-4">
                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 offset-2">
                    <asp:Button runat="server" ID="btnRegister" ValidationGroup="Register" CssClass="btn btn-primary" Text="Register" OnClick="btnRegister_Click" />
                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger ml-2" Text="Cancel" OnClick="btnCancel_Click" />
                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

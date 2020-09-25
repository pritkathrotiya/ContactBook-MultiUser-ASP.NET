<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="form-group row mt-5">
        <label class="col-md-2 col-form-label">Username</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtUsername" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Passwod</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtPassword" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">DisplayName</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtDisplayName" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Address</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtAddress" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">MobileNo</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtMobileNo" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row mb-4">
        <div class="col-md-4 offset-md-2">
            <asp:Label ID="lblErrorMessage" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


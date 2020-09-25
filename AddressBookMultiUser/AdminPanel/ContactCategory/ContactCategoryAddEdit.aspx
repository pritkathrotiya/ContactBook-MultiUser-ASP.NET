<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="row">
        <div class="col-md-3">
            <h6 class="font-weight-bold">
                <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
            </h6>
            <hr />
        </div>
    </div>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
    <div class="form-group row">
        <label class="col-md-3 col-form-label">Contact Category Name<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:TextBox ID="txtContactCategoryName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvContactCategoryName" runat="server"
                ErrorMessage="Enter Contact Category Name"
                CssClass="text-danger"
                ControlToValidate="txtContactCategoryName"
                SetFocusOnError="True"
                Display="Dynamic" ValidationGroup="Save" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-md-2 offset-md-3">
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" Runat="Server">
</asp:Content>


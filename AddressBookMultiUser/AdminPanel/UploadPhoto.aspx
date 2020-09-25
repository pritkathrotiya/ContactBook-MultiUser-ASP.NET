<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="UploadPhoto.aspx.cs" Inherits="AdminPanel_UploadPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6>Upload Contact Photo</h6>
            <hr />
        </div>
    </div>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
    <div class="form-group row">
        <label class="col-md-2">Select Contact</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlContact" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvContact" runat="server"
                ErrorMessage="Select Contact"
                CssClass="text-danger"
                ControlToValidate="ddlContact"
                SetFocusOnError="True"
                Display="Dynamic" InitialValue="-1" ValidationGroup="Upload" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2">Upload Photo</label>
        <div class="col-md-6">
            <asp:FileUpload ID="fuContatcPhoto" runat="server" />
            <asp:RequiredFieldValidator ID="rfvContactPhoto" runat="server"
                ErrorMessage="Select Contact Photo"
                CssClass="text-danger"
                ControlToValidate="fuContatcPhoto"
                SetFocusOnError="True"
                Display="Dynamic" ValidationGroup="Upload" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-8 offset-md-2">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" ValidationGroup="Upload" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


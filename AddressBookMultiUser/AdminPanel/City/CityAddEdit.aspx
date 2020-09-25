<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6 class="font-weight-bold">
                <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
            </h6>
            <hr />
        </div>
    </div>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
    <div class="form-group row">
        <label class="col-md-2 col-form-label">City Name<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvCityName" runat="server"
                ErrorMessage="Enter City Name"
                CssClass="text-danger"
                ControlToValidate="txtCityName"
                SetFocusOnError="True"
                Display="Dynamic" ValidationGroup="Save" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Pincode</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtPincode" TextMode="Number" runat="server" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">State<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvState" runat="server"
                ControlToValidate="ddlState"
                ErrorMessage="Please Select State"
                Display="Dynamic"
                CssClass="text-danger"
                SetFocusOnError="True" ValidationGroup="Save" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-md-2 offset-md-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


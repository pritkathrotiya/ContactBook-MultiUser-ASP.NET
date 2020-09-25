<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

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
        <label class="col-md-2 col-form-label">Contact Name<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvContactName" runat="server"
                ErrorMessage="Enter Contact Name"
                CssClass="text-danger"
                ControlToValidate="txtContactName"
                SetFocusOnError="True"
                Display="Dynamic" ValidationGroup="Save" />
        </div>
        <label class="col-md-2 col-form-label">Mobile No<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server"
                ErrorMessage="Enter Mobile No"
                CssClass="text-danger"
                ControlToValidate="txtMobileNo"
                SetFocusOnError="True"
                Display="Dynamic" ValidationGroup="Save" />
            <asp:RegularExpressionValidator ID="revMobileNo" runat="server"
                ErrorMessage="Enter Proper Mobile No"
                CssClass="text-danger"
                Display="Dynamic"
                ControlToValidate="txtMobileNo"
                ValidationExpression="[0-9]{10}"
                SetFocusOnError="True" ValidationGroup="Save" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Address</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control" />
        </div>
        <label class="col-md-2">Email<span class="text-danger">*</span></label>
        <div class="col-md-4">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Please Enter Email"
                CssClass="text-danger"
                Display="Dynamic"
                SetFocusOnError="True" ValidationGroup="Save"/>
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ErrorMessage="Enter Proper Email"
                CssClass="text-danger"
                Display="Dynamic"
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                SetFocusOnError="True" ValidationGroup="Save"/>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Pincode</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtPincode" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <label class="col-md-2 col-form-label">Bith Date</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revBirthDate" runat="server"
                ErrorMessage="Enter Proper Birth Date"
                CssClass="text-danger"
                Display="Dynamic"
                ControlToValidate="txtBirthDate" 
                ValidationExpression="^(?:0[1-9]|[12]\d|3[01])([-])(?:0[1-9]|1[012])\1(?:19|20)\d\d$"
                SetFocusOnError="True" ValidationGroup="Save"/>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Country</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <label class="col-md-2 col-form-label">Gender</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">State</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <label class="col-md-2 col-form-label">Blood Group</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">City</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <label class="col-md-2 col-form-label">Profession</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtProfession" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <label class="col-md-2 col-form-label">Contact Category</label>
        <div class="col-md-4">
            <asp:DropDownList ID="ddlContactContactCategory" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-md-2 offset-md-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        </div>
        <div class="col-md-3">
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


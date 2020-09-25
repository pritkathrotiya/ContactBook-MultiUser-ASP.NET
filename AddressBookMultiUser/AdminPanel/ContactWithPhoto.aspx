<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactWithPhoto.aspx.cs" Inherits="AdminPanel_ContactWithPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
    <div class="row mb-5">
        <div class="card-deck">
            <asp:Repeater ID="rptContactWithPhoto" runat="server">
                <ItemTemplate>
                    <div class="card shadow" style="width: 18rem;">
                        <asp:Image ID="imgContactPhoto" runat="server" AlternateText="Contact Photo" ImageUrl='<%# Eval("PhotoPath") %>' CssClass="card-img-top" Height="224px"/>
                        <div class="card-body">
                            <h5 class="card-title">
                                Name: <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContactName") %>'></asp:Label>
                            </h5>
                            <p class="card-text">
                                Mobile No: <asp:Label ID="lblText" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label><br />
                                Email: <asp:Label ID="Label1" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


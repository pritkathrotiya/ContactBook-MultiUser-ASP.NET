<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6>Contact Category List</h6>
            <hr />
        </div>
        <div class="col-md-3 offset-md-7 text-right">
            <asp:Button ID="btnAdd" runat="server" Text="Add Contact Category" CssClass="btn btn-info" OnClick="btnAdd_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
            <asp:GridView ID="gvContactCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvContactCategory_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category" ItemStyle-Width="250px"/>
                    <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID") %>'/>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning" CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


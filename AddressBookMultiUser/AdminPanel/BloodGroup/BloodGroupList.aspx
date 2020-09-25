<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="BloodGroupList.aspx.cs" Inherits="AdminPanel_BloodGroup_BloodGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6>Blood Group List</h6>
            <hr />
        </div>
        <div class="col-md-2 offset-md-8 text-right">
            <asp:Button ID="btnAdd" runat="server" Text="Add Blood Group" CssClass="btn btn-info" OnClick="btnAdd_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
            <asp:GridView ID="gvBloodGroup" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnRowCommand="gvBloodGroup_RowCommand">
                <Columns>
                    <asp:BoundField DataField="BloodGroupName" HeaderText="Blood Group" ItemStyle-Width="250px"/>
                    <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("BloodGroupID") %>'/>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning" CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/BloodGroup/BloodGroupAddEdit.aspx?BloodGroupID=" + Eval("BloodGroupID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


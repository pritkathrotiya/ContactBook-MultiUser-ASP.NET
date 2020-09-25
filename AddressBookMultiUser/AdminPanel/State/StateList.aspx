<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6>State List</h6>
            <hr />
        </div>
        <div class="col-md-2 offset-md-8 text-right">
            <asp:Button ID="btnAdd" runat="server" Text="Add State" CssClass="btn btn-info" OnClick="btnAdd_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
            <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvState_RowCommand">
                <Columns>
                    <asp:BoundField DataField="StateName" HeaderText="State Name" ItemStyle-Width="200px" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" ItemStyle-Width="150px" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Country Code" ItemStyle-Width="50px"/>
                    <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>'/>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning" CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


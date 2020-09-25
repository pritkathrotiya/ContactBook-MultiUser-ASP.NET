<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="row">
        <div class="col-md-2">
            <h6>City List</h6>
            <hr />
        </div>
        <div class="col-md-2 offset-md-8 text-right">
            <asp:Button ID="btnAdd" runat="server" Text="Add City" CssClass="btn btn-info" OnClick="btnAdd_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
            <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvCity_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CityName" HeaderText="City Name" ItemStyle-Width="150px"/>
                    <asp:BoundField DataField="Pincode" HeaderText="Pincode" ItemStyle-Width="100px"/>
                    <asp:BoundField DataField="StateName" HeaderText="State Name" ItemStyle-Width="150px"/>
                    <asp:BoundField DataField="CountryName" HeaderText="Country Name" ItemStyle-Width="150px"/>
                    <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>'/>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-warning" CommandName="EditRecord" CommandArgument='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScript" runat="Server">
</asp:Content>


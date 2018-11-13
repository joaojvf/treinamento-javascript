<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PaginaMestra.Master" AutoEventWireup="true" CodeBehind="VwVendaPorCliente.aspx.cs" Inherits="Views.Views.VwVendaPorCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <br />
        <center><h3>Venda por Cliente</h3></center>
        <br />
        <br />

        <div class="row">
            <div class="form-group">
                <asp:Button ID="btnNovaVenda" runat="server" OnClick="btnNovaVenda_Click" Text="Nova Venda" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="table">
            <asp:GridView ID="gdvVendaCliente" runat="server" AutoGenerateColumns="False" CssClass="table table-hover view-table"
                OnRowCommand="gdvVendaCliente_RowCommand" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField HeaderText="Data da Venda">
                        <ItemTemplate>
                            <asp:Label ID="lblDataVenda" runat="server" Text='<%# Bind("data_venda") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalVenda" runat="server" Text='<%# Bind("total_venda") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbAbrir" runat="server" Text="Abrir" CommandArgument='<%# Bind("id") %>' CommandName="Abrir"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbFinalizar" runat="server" Text="Finalizar Venda" CommandArgument='<%# Bind("id") %>' CommandName="FinalizarVenda"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

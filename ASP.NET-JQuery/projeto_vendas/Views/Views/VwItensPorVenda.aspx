<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PaginaMestra.Master" AutoEventWireup="true" CodeBehind="VwItensPorVenda.aspx.cs" Inherits="Views.Views.VwItensPorVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <br />
        <center><h3>Carrinho de Compra</h3></center>
        <br />
        <br />
        <div class="tabela">
            <h5>Adicionar Itens</h5>
            <asp:GridView ID="gdvProdutos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover view-table"
                OnRowUpdating="gdvProdutos_RowUpdating" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label ID="lblNomeProduto" runat="server" Text='<%# Bind("nome_produto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <ItemTemplate>
                            <asp:Label ID="lblValorProduto" runat="server" Text='<%# Bind("valor_produto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantidade">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantidadeProduto" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnAdd" runat="server" Text="Adicionar" CommandName="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div id="divItensAdicionados" runat="server" class="tabela">
            <br />
            <h5>Itens já adicionados:</h5>
            <asp:GridView ID="gdvItensVenda" runat="server" AutoGenerateColumns="False" CssClass="table table-hover view-table"
                OnRowCommand="gdvItensVenda_RowCommand" DataKeyNames="id">
                <Columns>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label ID="lblNomeItens" runat="server" Text='<%# Bind("nome_produto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantidade Total">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantidadeItens" runat="server" Text='<%# Bind("quantidade") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor Total">
                        <ItemTemplate>
                            <asp:Label ID="lblValorItens" runat="server" Text='<%# Bind("valor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbRemover" runat="server" Text="Remover" CommandArgument='<%# Bind("id") %>' CommandName="Remover"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbEditar" runat="server" Text="Editar" CommandArgument='<%# Bind("id") %>' CommandName="Editar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

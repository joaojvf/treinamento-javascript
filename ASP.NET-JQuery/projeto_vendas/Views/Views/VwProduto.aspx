<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PaginaMestra.Master" AutoEventWireup="true" CodeBehind="VwProduto.aspx.cs" Inherits="Views.VwProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <br />
        <center><h3>Produtos</h3></center>
        <br />
        <br />

        <div class="row">
            <div class="col-sm-8">
                <div class="form-group">
                    <label>Nome</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Valor</label>
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control txtDinheiro"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:Label ID="lblFornecedor" runat="server" Text="Selecione o Fornecedor: "></asp:Label>
                    <asp:DropDownList ID="ddlFornecedor" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Button ID="btnCadastrarProduto" runat="server" OnClick="btnCadastrarProduto_Click" Text="Cadastrar" CssClass="btn btn-primary" />
            </div>
        </div>


        <asp:GridView ID="gdvProduto" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
            OnRowCommand="gdvProduto_RowCommand" DataKeyNames="id">
            <Columns>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Bind("nome_produto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Valor">
                    <ItemTemplate>
                        <asp:Label ID="lblValor" runat="server" Text='<%# Bind("valor_produto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fornecedor">
                    <ItemTemplate>
                        <asp:Label ID="lblFornecedor" runat="server" Text='<%# Bind("nome_fornecedor") %>'></asp:Label>
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
</asp:Content>

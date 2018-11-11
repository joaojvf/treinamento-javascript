<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PaginaMestra.Master" AutoEventWireup="true" CodeBehind="VwFornecedor.aspx.cs" Inherits="Views.Views.VwFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <br />
        <center><h3>Fornecedores</h3></center>
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
                    <label>Empresa</label>
                    <asp:TextBox ID="txtEmpresa" runat="server" CssClass="form-control "></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label>Telefone</label>
                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control txtFone"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Button ID="btnCadastrarFornecedor" runat="server" OnClick="btnCadastrarFornecedor_Click" Text="Cadastrar" CssClass="btn btn-primary" />
            </div>
        </div>

        <asp:GridView ID="gdvFornecedor" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
            OnRowCommand="gdvFornecedor_RowCommand" DataKeyNames="id">
            <Columns>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Bind("nome_fornecedor") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Empresa">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpresa" runat="server" Text='<%# Bind("nome_empresa") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefone">
                    <ItemTemplate>
                        <asp:Label ID="lblTelefone" runat="server" Text='<%# Bind("telefone_fornecedor") %>'></asp:Label>
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

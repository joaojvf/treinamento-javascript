<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PaginaMestra.Master" AutoEventWireup="true" CodeBehind="VwCliente.aspx.cs" Inherits="Views.Views.VwCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <br />
        <center><h3>Clientes</h3></center>
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
                    <label>CPF</label>
                    <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control txtCpf"></asp:TextBox>
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

            <div class="col">
                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Button ID="btnCadastrarCliente" runat="server" OnClick="btnCadastrarCliente_Click" Text="Cadastrar" CssClass="btn btn-primary" />
            </div>
        </div>



        <asp:GridView ID="gdvCliente" runat="server" AutoGenerateColumns="False" CssClass="table table-hover"
            OnRowCommand="gdvCliente_RowCommand" DataKeyNames="id">
            <Columns>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Bind("nome_cliente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CPF">
                    <ItemTemplate>
                        <asp:Label ID="lblCpf" runat="server" Text='<%# Bind("cpf_cliente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefone">
                    <ItemTemplate>
                        <asp:Label ID="lblTelefone" runat="server" Text='<%# Bind("telefone_cliente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("email_cliente") %>'></asp:Label>
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbAbrir" runat="server" Text="Abrir" CommandArgument='<%# Bind("id") %>' CommandName="Abrir"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="AspNetMarket.Vendedor" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vendedores</title>
    <link href="css/vendedor.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <h2>Novo Vendedor</h2>
    <form id="formAddVendedor" runat="server">
        <!-- Campos para adicionar um novo vendedor -->
        <asp:TextBox ID="txtRazaoSocial" runat="server" placeholder="Razão Social" />
        <asp:TextBox ID="txtNomeFantasia" runat="server" placeholder="Nome Fantasia" />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Email" />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Senha" />
        <asp:TextBox ID="txtCnpj" runat="server" placeholder="CNPJ" />
        <asp:TextBox ID="txtComissao" runat="server" TextMode="Number" placeholder="Comissão" />
        <asp:TextBox ID="txtEndereco" runat="server" placeholder="Endereço" />
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar Vendedor" OnClick="btnAdicionar_Click" />
    </form>

    <h2>Listagem Vendedores</h2>
    <asp:GridView ID="gridVendedores" runat="server" AutoGenerateColumns="False">
        <!-- Definição das colunas -->
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="RazaoSocial" HeaderText="Razão Social" />
            <asp:BoundField DataField="NomeFantasia" HeaderText="Nome Fantasia" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Cnpj" HeaderText="CNPJ" />
            <asp:BoundField DataField="Comissao" HeaderText="Comissão" />
            <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                    <asp:Button ID="btnExcluir" runat="server" CommandName="Delete" CommandArgument="<%# Bind('ID') %>" Text="Excluir" OnClientClick="return confirm('Tem certeza que deseja excluir este produto?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</body>
</html>

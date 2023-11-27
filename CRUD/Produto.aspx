<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produto.aspx.cs" Inherits="AspNetMarket.Produto" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Produtos</title>
    <link href="css/produto.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <h2>Novo Produto</h2>
    <form id="formAddProduto" runat="server">
        <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descrição do Produto" />
        <asp:TextBox ID="txtPreco" runat="server" TextMode="Number" placeholder="Preço" />
        <asp:TextBox ID="txtImagem" runat="server" placeholder="URL da Imagem" />
        <asp:TextBox ID="txtStatus" runat="server" placeholder="Status" />
        <asp:TextBox ID="txtVendedorID" runat="server" TextMode="Number" placeholder="ID do Vendedor" />
        <asp:TextBox ID="txtCategoriaID" runat="server" TextMode="Number" placeholder="ID da Categoria" />
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar Produto" OnClick="btnAdicionar_Click" />
    </form>

    <h2>Listagem Produtos</h2>
    <asp:GridView ID="gridProdutos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Preco" HeaderText="Preço" />
            <asp:BoundField DataField="Imagem" HeaderText="Imagem" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="VendedorID" HeaderText="ID do Vendedor" />
            <asp:BoundField DataField="CategoriaID" HeaderText="ID da Categoria" />
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

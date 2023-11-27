<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="AspNetMarket.Carrinho" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrinho</title>
    <link href="css/carrinho.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <h2>Novo Carrinho</h2>
        <asp:TextBox ID="txtDataPedido" runat="server" TextMode="DateTime" />
        <asp:TextBox ID="txtValorTotal" runat="server" TextMode="Number" />
        <asp:TextBox ID="txtStatusPedido" runat="server" />
        <asp:TextBox ID="txtClienteId" runat="server" TextMode="Number" />
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar ao Carrinho" OnClick="btnAdicionar_Click" />

        <h2>Listagem de Carrinho</h2>
        <asp:GridView ID="gridCarrinhos" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="DataPedido" HeaderText="Data Pedido" />
                <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" />
                <asp:BoundField DataField="StatusPedido" HeaderText="Status Pedido" />
                <asp:BoundField DataField="ClienteId" HeaderText="ID do Cliente" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                        <asp:Button ID="btnExcluir" runat="server" CommandName="Delete" CommandArgument="<%# Bind('Id') %>" Text="Excluir" OnClientClick="return confirm('Tem certeza que deseja excluir este item?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

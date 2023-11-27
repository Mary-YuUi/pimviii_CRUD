<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="AspNetMarket.Cliente" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clientes</title>
    <link href="css/cliente.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Novo Cliente</h2>
        <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" />
        <asp:TextBox ID="txtCPF" runat="server" placeholder="CPF" />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Email" />
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" placeholder="Senha" />
        <asp:TextBox ID="txtEndereco" runat="server" placeholder="Endereço" />
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar Cliente" OnClick="btnAdicionar_Click" />

        <h2>Listagem de Clientes</h2>
        <asp:GridView ID="gridClientes" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Senha" HeaderText="Senha" />
                <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                        <asp:Button ID="btnExcluir" runat="server" CommandName="Delete" CommandArgument="<%# Bind('ID') %>" Text="Excluir" OnClientClick="return confirm('Tem certeza que deseja excluir este cliente?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

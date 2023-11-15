<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acesso.aspx.cs" Inherits="CRUD.script.acesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Seja Bem-Vindo</title>
    <link href="css/inicial.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form class="form-acesso" runat="server" id="formAcesso">
        <table class="tab-principal">
            <tr>
                <td class="td-esquerda">&nbsp;</td>
                <td class="td-centro">
                    <asp:Panel CssClass="estilo-painel-acesso" runat="server" HorizontalAlign="Center">
                        <br />
                        <br />
                        <asp:TextBox CssClass="estilo-caixa-texto" placeholder="Endereço de E-Mail" runat="server" MaxLength="150" TabIndex="1" ValidateRequestMode="Enabled" ID="entrada_login"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox CssClass="estilo-caixa-texto" placeholder="Senha Secreta" runat="server"  MaxLength="8" TabIndex="2" TextMode="Password" ID="entrada_senha"></asp:TextBox>
                        <br />
                        <asp:Label ID="mensagem_erro" runat="server" ForeColor="#CC3300"></asp:Label>
                        <br />
                        <asp:Button CssClass="estilo-botao-entrar" runat="server" Text="Entrar" TabIndex="3" ID="botao_entrar" OnClick="botao_entrar_Click" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" />
                        <br />
                        <asp:LinkButton ID="linklembrar" runat="server" CssClass="estilo-txt-lembrar" PostBackUrl="~/script/lembrar-senha.aspx" TabIndex="5">Esqueceu a senha ?</asp:LinkButton>
                        <br />
                        <br />                        
                        <asp:Button CssClass="estilo-botao-registrar" runat="server" TabIndex="4" Text="Registrar" ID="botao_registrar" Font-Bold="True" Font-Size="Medium" PostBackUrl="~/script/registro.aspx" />
                        <br />
                        <br />
                    </asp:Panel>
                </td>
                <td class="td-direita"></td>
            </tr>
        </table>
    </form>
</body>
</html>

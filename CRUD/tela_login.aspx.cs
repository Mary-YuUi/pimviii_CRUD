using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace CRUD.script
{
    public partial class acesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void botao_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                BancoDeDados bancoDeDados = new BancoDeDados();
                bancoDeDados.AbrirConexao();

                MySqlCommand cmd = new MySqlCommand("select * from usuario where email=@email and senha=@password", bancoDeDados.ObterConexao());

                cmd.Parameters.AddWithValue("@email", entrada_login.Text);
                cmd.Parameters.AddWithValue("@password", entrada_senha.Text);

                var resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    Response.Redirect("painel-usuario.aspx", false);
                }
                else
                {
                    if (string.IsNullOrEmpty(entrada_login.Text))
                    {
                        entrada_login.Focus();
                        mensagem_erro.Text = "Email em branco";
                    }
                    else if (string.IsNullOrEmpty(entrada_senha.Text))
                    {
                        entrada_senha.Focus();
                        mensagem_erro.Text = "Senha em branco";
                    }
                    else
                    {
                        mensagem_erro.Text = "Email/Senha não encontrados";
                    }
                }

                bancoDeDados.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

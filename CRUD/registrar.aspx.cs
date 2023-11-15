using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CRUD.WSCorreios;

namespace CRUD.script
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void bt_save_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterError();       
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected void bt_search_Click(object sender, EventArgs e)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(input_zip.Text);
                    input_address.Text = resultado.end;
                    input_city.Text = resultado.cidade;
                    input_neighborhood.Text = resultado.bairro;
                    input_state.Text = resultado.uf;

                    error.Text = "";
                }
                catch
                {
                    if (String.IsNullOrEmpty(input_zip.Text))
                    {
                        error.Text = "* Preencha o seu CEP";
                        input_zip.Focus();
                        input_zip.Text = "";
                    }

                    error.Text = "CEP não encontrado !";
                }
            }
        }

        private void Register()
        {
            database database = new database();

            database.openConnection();
            
            MySqlCommand comandoEndereco = new MySqlCommand("insert into endereco (id, logradouro, numero, cep, bairro, cidade, estado) value(null, ?, ?, ?, ?, ?, ?)", database.getConnection());
                        
            comandoEndereco.Parameters.Add("@logradouro", MySqlDbType.VarChar, 256).Value = input_address.Text;
            comandoEndereco.Parameters.Add("@numero", MySqlDbType.Int32).Value = input_address_number.Text;
            comandoEndereco.Parameters.Add("@cep", MySqlDbType.Int32).Value = input_zip.Text;
            comandoEndereco.Parameters.Add("@bairro", MySqlDbType.VarChar, 50).Value = input_neighborhood.Text;
            comandoEndereco.Parameters.Add("@cidade", MySqlDbType.VarChar, 30).Value = input_city.Text;
            comandoEndereco.Parameters.Add("@estado", MySqlDbType.VarChar, 20).Value = input_state.Text;

            comandoEndereco.ExecuteNonQuery();

            long idEndereco = comandoEndereco.LastInsertedId;

            MySqlCommand comandoPessoa = new MySqlCommand("insert into pessoa (id, nome, cpf, email, senha, endereco) value(null, ?, ?, ?, ?, ?)", database.getConnection());

            comandoPessoa.Parameters.Add("@nome", MySqlDbType.VarChar, 256).Value = input_name.Text;
            comandoPessoa.Parameters.Add("@cpf", MySqlDbType.Int64).Value = input_cpf.Text;
            comandoPessoa.Parameters.Add("@email", MySqlDbType.VarChar, 256).Value = input_email.Text;
            comandoPessoa.Parameters.Add("@senha", MySqlDbType.VarChar, 10).Value = input_password.Text;
            comandoPessoa.Parameters.Add("@endereco", MySqlDbType.Int32).Value = idEndereco;

            comandoPessoa.ExecuteNonQuery();
            long idPessoa = comandoPessoa.LastInsertedId;

            MySqlCommand comandoTelefoneTipo = new MySqlCommand("insert into telefone_tipo (id, tipo) value(null, ?)", database.getConnection());
            comandoTelefoneTipo.Parameters.Add("@tipo", MySqlDbType.VarChar, 10).Value = input_phone_type.Text;

            comandoTelefoneTipo.ExecuteNonQuery();
            long idTelefoneTipo = comandoTelefoneTipo.LastInsertedId;

            MySqlCommand comandoTelefone = new MySqlCommand("insert into telefone (id, numero, ddd, tipo) value(null, ?, ?, ?)", database.getConnection());
            comandoTelefone.Parameters.Add("@numero", MySqlDbType.Int32).Value = input_phone.Text;
            comandoTelefone.Parameters.Add("@ddd", MySqlDbType.Int32).Value = input_ddd.Text;
            comandoTelefone.Parameters.Add("@tipo", MySqlDbType.Int32).Value = idTelefoneTipo;

            comandoTelefone.ExecuteNonQuery();
            long idTelefone = comandoTelefone.LastInsertedId;

            MySqlCommand comandoPessoaTelefone = new MySqlCommand("insert into pessoa_telefone (id_pessoa, id_telefone) value(?, ?)", database.getConnection());
            comandoPessoaTelefone.Parameters.Add("@id_pessoa", MySqlDbType.Int32).Value = idPessoa;
            comandoPessoaTelefone.Parameters.Add("@id_telefone", MySqlDbType.Int32).Value = idTelefone;

            comandoPessoaTelefone.ExecuteNonQuery();
            database.closeConnection();            
        }

        private void RegisterError()
        {
            if (String.IsNullOrEmpty(input_name.Text))
            {
                input_name.Focus();
                error.Text = "* Preencha o seu Nome";
            }
            else if (String.IsNullOrEmpty(input_cpf.Text))
            {
                input_cpf.Focus();
                error.Text = "* Preencha o seu CPF";
            }
            else if (String.IsNullOrEmpty(input_ddd.Text))
            {
                input_ddd.Focus();
                error.Text = "* Preencha o seu DDD";
            }
            else if (String.IsNullOrEmpty(input_phone.Text))
            {
                input_phone.Focus();
                error.Text = "* Preencha o seu Telefone";
            }
            else if (String.IsNullOrEmpty(input_phone_type.Text))
            {
                input_phone_type.Focus();
                error.Text = "* Selecione o seu telefone";
            }
            else if (String.IsNullOrEmpty(input_zip.Text))
            {
                input_zip.Focus();
                error.Text = "* Preencha o seu CEP";
            }
            else if (String.IsNullOrEmpty(input_address.Text))
            {
                input_address.Focus();
                error.Text = "* Preencha o seu Endereço";
            }
            else if (String.IsNullOrEmpty(input_address_number.Text))
            {
                input_address_number.Focus();
                error.Text = "* Preencha o seu Numero";
            }
            else if (String.IsNullOrEmpty(input_neighborhood.Text))
            {
                input_neighborhood.Focus();
                error.Text = "* Preencha o Bairro";
            }
            else if (String.IsNullOrEmpty(input_city.Text))
            {
                input_city.Focus();
                error.Text = "* Preencha o Cidade";
            }
            else if (String.IsNullOrEmpty(input_state.Text))
            {
                input_state.Focus();
                error.Text = "* Preencha o Estado";
            }
            else if (String.IsNullOrEmpty(input_email.Text))
            {
                input_email.Focus();
                error.Text = "* Preencha o E-Mail";
            }
            else if (String.IsNullOrEmpty(input_email_confirm.Text))
            {
                input_email_confirm.Focus();
                error.Text = "* O E-Mail é diferente";
            }
            else if (String.IsNullOrEmpty(input_password.Text))
            {
                input_password.Focus();
                error.Text = "* Preencha a Senha";
            }
            else if (String.IsNullOrEmpty(input_password_confirm.Text))
            {
                input_password_confirm.Focus();
                error.Text = "* A Senha e diferente";
            }
            else
            {
                Register();
                Response.Redirect("panel-user.aspx", false);                
            }
        }
    }
}





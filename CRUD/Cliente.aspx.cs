using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNetMarket.Models;

namespace CRUD.script
{
    public partial class Cliente : System.Web.UI.Page
    {
        private static List<ClienteModel> clientes = new List<ClienteModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarClientes();
            }
        }

        private void CarregarClientes()
        {
            // Carrega os clientes para o GridView
            GridView1.DataSource = clientes;
            GridView1.DataBind();
        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            ClienteModel novoCliente = new ClienteModel
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text, 
                Endereco = txtEndereco.Text
            };

            clientes.Add(novoCliente);
            CarregarClientes();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            if (e.CommandName == "Edit")
            {
                var clienteEditado = clientes.FirstOrDefault(c => c.ID == id);
            }
            else if (e.CommandName == "Delete")
            {
                var cliente = clientes.FirstOrDefault(c => c.ID == id);
                clientes.Remove(cliente);
            }

            CarregarClientes();
        }

    }
}

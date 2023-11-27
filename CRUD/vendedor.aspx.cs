using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNetMarket.Models;

namespace CRUD.script
{
    public partial class Vendedor : System.Web.UI.Page
    {
        private static List<VendedorModel> vendedores = new List<VendedorModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarVendedores();
            }
        }

        private void CarregarVendedores()
        {
            // Carrega os vendedores para o GridView
            GridView1.DataSource = vendedores;
            GridView1.DataBind();
        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            // Cria um novo vendedor
            VendedorModel novoVendedor = new VendedorModel
        {
        RazaoSocial = txtRazaoSocial.Text,   // txtRazaoSocial é o ID de um TextBox para Razão Social
        NomeFantasia = txtNomeFantasia.Text, // txtNomeFantasia é o ID de um TextBox para Nome Fantasia
        Email = txtEmail.Text,               // txtEmail é o ID de um TextBox para Email
        Senha = txtSenha.Text,               // txtSenha é o ID de um TextBox para Senha
        Cnpj = txtCnpj.Text,                 // txtCnpj é o ID de um TextBox para CNPJ
        Comissao = decimal.Parse(txtComissao.Text), // txtComissao é o ID de um TextBox para Comissão
        Endereco = txtEndereco.Text          // txtEndereco é o ID de um TextBox para Endereço
        };

            novoVendedor.Id = vendedores.Any() ? vendedores.Max(v => v.Id) + 1 : 1;
            vendedores.Add(novoVendedor);

            CarregarVendedores();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            if (e.CommandName == "Edit")
            {
                // Código para editar vendedor baseado no ID
                var vendedorEditado = vendedores.FirstOrDefault(v => v.Id == id);
            }
            else if (e.CommandName == "Delete")
            {
                // Código para deletar vendedor
                var vendedor = vendedores.FirstOrDefault(v => v.Id == id);
                if (vendedor != null)
                {
                    vendedores.Remove(vendedor);
                }
            }
            CarregarVendedores();
        }
    }
}

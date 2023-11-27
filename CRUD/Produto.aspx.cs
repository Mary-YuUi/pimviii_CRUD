using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNetMarket.Models;

namespace CRUD.script
{
    public partial class Produto : System.Web.UI.Page
    {
        private static List<ProdutoModel> produtos = new List<ProdutoModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarProdutos();
            }
        }

        private void CarregarProdutos()
        {
            // Carrega os produtos para o GridView
            GridView1.DataSource = produtos;
            GridView1.DataBind();
        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            ProdutoModel novoProduto = new ProdutoModel
            {
                Nome = txtNome.Text,
                Preco = decimal.Parse(txtPreco.Text),
                Categoria = txtCategoria.Text,
                Quantidade = int.Parse(txtQuantidade.Text),
            };

            produtos.Add(novoProduto);
            CarregarProdutos();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            if (e.CommandName == "Edit")
            {
                var produtoEditado = produtos.FirstOrDefault(p => p.ID == id);
            }
            else if (e.CommandName == "Delete")
            {
                var produto = produtos.FirstOrDefault(p => p.ID == id);
                produtos.Remove(produto);
            }

            CarregarProdutos();
        }
    }
}

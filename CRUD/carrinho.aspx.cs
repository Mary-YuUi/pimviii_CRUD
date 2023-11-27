using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AspNetMarket.Models;

namespace CRUD.script
{
    public partial class Carrinho : System.Web.UI.Page
    {
        private static List<CarrinhoModel> carrinhos = new List<CarrinhoModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCarrinhos();
            }
        }

        private void CarregarCarrinhos()
        {
            GridView1.DataSource = carrinhos;
            GridView1.DataBind();
        }

        protected void bt_create_Click(object sender, EventArgs e)
        {
            CarrinhoModel novoCarrinho = new CarrinhoModel
            {
                DataPedido = DateTime.Parse(txtDataPedido.Text),
                ValorTotal = decimal.Parse(txtValorTotal.Text),
                StatusPedido = txtStatusPedido.Text,
                ClienteId = int.Parse(txtClienteId.Text)
            };

            novoCarrinho.Id = carrinhos.Any() ? carrinhos.Max(c => c.Id) + 1 : 1;
            carrinhos.Add(novoCarrinho);
            CarregarCarrinhos();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            if (e.CommandName == "Edit")
            {
                var carrinhoEditado = carrinhos.FirstOrDefault(c => c.Id == id);
                // Atualize carrinhoEditado com dados do formulário
            }
            else if (e.CommandName == "Delete")
            {
                var carrinho = carrinhos.FirstOrDefault(c => c.Id == id);
                carrinhos.Remove(carrinho);
            }

            CarregarCarrinhos();
        }
    }
}

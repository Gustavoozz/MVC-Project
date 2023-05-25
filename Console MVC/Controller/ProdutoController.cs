using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console_MVC.Model;
using Console_MVC.View;

namespace Console_MVC.Controller
{
    public class ProdutoController
    {
        // Instância das classes produto e produtoView.
        Produto produto = new Produto();

        ProdutoView produtoView = new ProdutoView();

        // Método controlador para acessar a listagem de produtos.
        public void ListarProdutos()
        {
            List<Produto> produtos = produto.Ler();

            produtoView.Listar(produtos);
        }

        // Método controlador para cadastrar o produto.
        public void CadastrarProdutos()
        {
            produto.Inserir(produtoView.Cadastrar());
        }
    }
}
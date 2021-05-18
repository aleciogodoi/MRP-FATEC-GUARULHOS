using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRP_SacoCarvao
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            ProdutoDAO produtoDAO = new ProdutoDAO();

            Produto produto = produtoDAO.getLastProduto();
            produtoDAO.InsertProduto(new Produto(produto.idProduto+1, "Produto "+ (produto.idProduto + 1)));
            List<Produto> produtos = new List<Produto>();
            produtos = produtoDAO.ListaTodosProdutos();

            foreach (Produto p in produtos){
                Console.WriteLine("{0} - {1}", p.idProduto, p.nomeProduto);
            }

            produto = produtoDAO.getProduto(10);
            Console.WriteLine("{0} - {1}", produto.idProduto, produto.nomeProduto);
            

            (new ProdutoDAO()).Delete(51);
            (new ProdutoDAO()).Update(new Produto(50, "Produto XX"));
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMenu frmMenu = new frmMenu();
            Application.Run(frmMenu);
        }
    }
}

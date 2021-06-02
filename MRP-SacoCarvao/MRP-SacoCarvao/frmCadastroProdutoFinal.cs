using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRP_SacoCarvao
{
    public partial class frmCadastroProdutoFinal : Form
    {
        public frmCadastroProdutoFinal()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            GrupoDAO computer = new GrupoDAO();
            computer.Insert(new Grupo(4, "Cadastro de Produtos Finais"));
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}

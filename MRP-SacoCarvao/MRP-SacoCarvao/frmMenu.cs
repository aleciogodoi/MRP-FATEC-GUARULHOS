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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        // funcoes dos objetos
        private void ComponentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroComponentes objFrmCadastroComps = new frmCadastroComponentes();
            objFrmCadastroComps.MdiParent = this;
            objFrmCadastroComps.Show();
        }

        private void GruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            produtosFinaisToolStripMenuItem.Checked = true;
            frmCadastroGrupos frmCadastroGrupos = new frmCadastroGrupos();
            frmCadastroGrupos.MdiParent = this;
            frmCadastroGrupos.Show();
        }
    }
}

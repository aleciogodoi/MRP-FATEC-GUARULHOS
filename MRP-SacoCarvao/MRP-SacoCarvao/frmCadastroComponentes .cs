using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace MRP_SacoCarvao
{
    public partial class frmCadastroComponentes : Form
    {
        public frmCadastroComponentes()
        {
            InitializeComponent();
        }

        // funcoes do formulario
        private void FormCadastroComponentes_Load(object sender, EventArgs e)
        {
            ComponenteDAO objCompDAO = new ComponenteDAO();
            List<Componente> listaComponentes = new List<Componente>();
            listaComponentes = objCompDAO.GetComponentes();

            var lista = new BindingList<Componente>(listaComponentes);
            ListaComps_dgv.DataSource = lista;
        }
        
        // funcoes dos objetos
        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 )
            {
                Editar_btn.Enabled = true;
                Excluir_btn.Enabled = true;
                /*
                DataGridViewRow row = ListaComps_dgv.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                Pesquisar_tbx.Text = row.Cells[1].Value.ToString();
                */
            }
        }

        private void DataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                /*
                DataGridViewRow row = ListaComps_dgv.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                Pesquisar_tbx.Text = row.Cells[1].Value.ToString();
                */
            }
        }

        /// botoes
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ಠ▃ಠ");
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show( ListaComps_dgv.CurrentCell.Value.ToString() );
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            MessageBox.Show( ListaComps_dgv.CurrentCell.Value.ToString() );

            //ComponenteDAO objCompDAO = new ComponenteDAO();
            //objCompDAO.Delete(int.Parse(textBox1.Text));
        }
    }
}

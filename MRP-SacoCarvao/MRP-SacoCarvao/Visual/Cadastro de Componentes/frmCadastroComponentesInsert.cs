using System.Windows.Forms;

namespace MRP_SacoCarvao.Cadastro_de_Componentes
{
    public partial class frmCadastroComponentesInsert : Form
    {
        public frmCadastroComponentesInsert()
        {
            InitializeComponent();
        }

        private void Tipo_cbb_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            Modelo_pnl.Visible = true;
            Especs_pnl.Visible = true;
        }

        private void Modelo_tbx_TextChanged(object sender, System.EventArgs e)
        {
            if (Modelo_tbx.Text != "")
            {
                OK_btn.Enabled = true;
            }
        }

        private void OK_btn_Click(object sender, System.EventArgs e)
        {
            Componente objComp = new Componente( 0, Tipo_cbb.Text, Modelo_tbx.Text );
            DialogResult confirmarInsert = MessageBox.Show(
                "( ﾉ ﾟｰﾟ)ﾉ " + objComp.modeloComponente + " ?!", "Confirmar Inserção",
                MessageBoxButtons.YesNo
            );
            if (confirmarInsert == DialogResult.Yes)
            {
                ComponenteDAO objCompDAO = new ComponenteDAO();
                objCompDAO.Insert(objComp);
            }
            this.Close();
        }

        private void Cancelar_btn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

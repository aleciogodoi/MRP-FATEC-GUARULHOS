using System.Windows.Forms;

namespace MRP_SacoCarvao.Cadastro_de_Componentes
{
    public partial class frmCadastroComponentesUpdate : Form
    {
        Componente objComp = new Componente();
        public frmCadastroComponentesUpdate( Componente paramComponente )
        {
            InitializeComponent();
            H1_lbl.Text = paramComponente.tipoComponente;
            Cod_lbl.Text = paramComponente.idComponente.ToString();
            Modelo_tbx.Text = paramComponente.modeloComponente;
            objComp = paramComponente;
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
            objComp.modeloComponente = Modelo_tbx.Text;
            DialogResult confirmarUpdate = MessageBox.Show(
                "◉_◉ " + objComp.modeloComponente + " ?!", "Confirmar Alteração",
                MessageBoxButtons.YesNo
            );
            if (confirmarUpdate == DialogResult.Yes)
            {
                ComponenteDAO objCompDAO = new ComponenteDAO();
                objCompDAO.Update(objComp);
            }
            this.Close();
        }

        private void Cancelar_btn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

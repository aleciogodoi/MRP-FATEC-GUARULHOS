using System.Windows.Forms;

namespace MRP_SacoCarvao.Compras
{
    public partial class frmComprasView : Form
    {
        //funcoes
        private void SetCampos(MovimentacaoEstoque paramMovi)
        {
            H1_lbl.Text = paramMovi.idMovimentacaoComponente.ToString();
            Data_dtp.Text = paramMovi.dataMovimentacao.ToString();
            TipoDoc_cbb.Text = paramMovi.tipoDocumento;
            Numero_tbx.Text = paramMovi.nrDocumento;
            TipoMov_cbb.Text = paramMovi.tipoMovimentacao.ToString();
            Qtde_tbx.Text = paramMovi.qtde.ToString();
            Componente_cbb.Text = paramMovi.idComponente.ToString();
        }

        // variaveis
        MovimentacaoEstoque objMovi = new MovimentacaoEstoque();

        // funcoes dos controles
        public frmComprasView( MovimentacaoEstoque paramMovimentacao )
        {
            objMovi = paramMovimentacao;

            InitializeComponent();
            SetCampos( paramMovimentacao );
        }

        private void OK_btn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}

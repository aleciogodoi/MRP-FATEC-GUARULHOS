using System;
using System.Windows.Forms;

namespace MRP_SacoCarvao.Compras
{
    public partial class frmComprasInsert : Form
    {
        // funcoes dos controles
        public frmComprasInsert()
        {
            InitializeComponent();
        }

        private void Required_TextChanged(object sender, System.EventArgs e)
        {
            if (Data_dtp.Text != "" &&
                TipoDoc_cbb.Text != "" && Numero_tbx.Text != "" &&
                TipoMov_cbb.Text != "" && Qtde_tbx.Text != "" &&
                Componente_cbb.Text != "")
            {
                OK_btn.Enabled = true;
            }
        }

        private void OK_btn_Click(object sender, System.EventArgs e)
        {
            MovimentacaoEstoque objMovi = new MovimentacaoEstoque(
                0, DateTime.Parse(Data_dtp.Text), TipoDoc_cbb.Text, Numero_tbx.Text,
                char.Parse(TipoMov_cbb.Text), Int32.Parse(Qtde_tbx.Text), Int32.Parse(Componente_cbb.Text)
            );

            // confirmando insercao
            DialogResult confirmarInsert = MessageBox.Show(
                "(⓿_⓿) " + objMovi.dataMovimentacao + objMovi.nrDocumento + " ?!", "Confirmar Inserção",
                MessageBoxButtons.YesNo
            );
            if (confirmarInsert == DialogResult.Yes)
            {
                MovimentacaoEstoqueDAO objMoviDAO = new MovimentacaoEstoqueDAO();
                objMoviDAO.Insert( objMovi );
                objMoviDAO.UpdateEstoque(objMovi);
            }
            this.Close();
        }

        private void Cancelar_btn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

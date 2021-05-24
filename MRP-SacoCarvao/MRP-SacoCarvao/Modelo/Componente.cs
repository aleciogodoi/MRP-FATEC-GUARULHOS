namespace MRP_SacoCarvao
{
    public class Componente
    {
        // Atributos
        public int idComponente { get; set; }
        public string tipoComponente { get; set; }
        public string modeloComponente { get; set; }
        public int qtdeMinEstoque { get; set; }
        public int qtdeMaxEstoque { get; set; }
        public int qtdeAtualEstoque { get; set; }
        public string especificacao { get; set; }

        // Construtores
        public Componente() {
            
        }

        public Componente(
            int idComp,
            string tipoComp, string modeloComp,
            int qtdeMinEst = 0, int qtdeMaxEst = 0, int qtdeAtualEst = 0,
            string espec = null
        ) {
            this.idComponente = idComp;
            this.tipoComponente = tipoComp;
            this.modeloComponente = modeloComp;
            this.qtdeMinEstoque = qtdeMinEst;
            this.qtdeMaxEstoque = qtdeMaxEst;
            this.qtdeAtualEstoque = qtdeAtualEst;
            this.especificacao = espec;
        }

    }
}

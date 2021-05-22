namespace MRP_SacoCarvao
{
    class Componente
    {
        // Atributos
        public int idComponente { get; set; }
        public string nomeComponente { get; set; }
        public string descrComponente { get; set; }
        public int qtdeMinEstoque { get; set; }
        public int qtdeMaxEstoque { get; set; }
        public int qtdeAtualEstoque { get; set; }
        public string especificacao { get; set; }

        // Construtores
        public Componente() {  }

        public Componente(
            int idComp, string nomeComp,
            string descrComp,
            int qtdeMinEst, int qtdeMaxEst, int qtdeAtualEst,
            string espec
        ) {
            this.idComponente = idComp;
            this.nomeComponente = nomeComp;
            this.descrComponente = descrComp;
            this.qtdeMinEstoque = qtdeMinEst;
            this.qtdeMaxEstoque = qtdeMaxEst;
            this.qtdeAtualEstoque = qtdeAtualEst;
            this.especificacao = espec;
        }

    }
}

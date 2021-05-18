using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP_SacoCarvao
{
    class Produto
    {
        // Atributos
        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public string descrProduto { get; set; }
        public int qtdeMinEstoque { get; set; }
        public int qtdeMaxEstoque { get; set; }
        public int qtdeAtualEstoque { get; set; }
        public float altura { get; set; }
        public float comprimento { get; set; }
        public float peso { get; set; }
        public string especificacao { get; set; }
        public Grupo grupo;

        // Construtores
        public Produto(){}

        public Produto(int idProduto, string nomeProduto, 
            string descrProduto, 
            int qtdeMinEstoque, int qtdeMaxEstoque, 
            int qtdeAtualEstoque, float altura, 
            float comprimento, float peso, string 
            especificacao, Grupo grupo)
        {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.descrProduto = descrProduto;
            this.qtdeMinEstoque = qtdeMinEstoque;
            this.qtdeMaxEstoque = qtdeMaxEstoque;
            this.qtdeAtualEstoque = qtdeAtualEstoque;
            this.altura = altura;
            this.comprimento = comprimento;
            this.peso = peso;
            this.especificacao = especificacao;
            this.grupo = grupo;
        }

    }
}

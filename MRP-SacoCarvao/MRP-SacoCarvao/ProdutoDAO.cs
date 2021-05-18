using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MRP_SacoCarvao
{
    class ProdutoDAO
    {
        public Boolean Insert(Grupo grupo)
        {
            return true;
        }

        public Boolean Update(Grupo grupo)
        {
            return true;
        }

        public Boolean Delete(int id)
        {
            return true;
        }

        public List<Produto> GetProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            Produto produto;
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "Select p.*, g.nomeGrupo From produto p Inner Join grupo g On (p.idGrupo = g.idGrupo)";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    produto = new Produto();
                    produto.idProduto = Convert.ToInt32(reader["idProduto"]);
                    produto.nomeProduto = (string)reader["nomeProduto"];
                    produto.descrProduto = (string)reader["descrProduto"];
                    produto.qtdeMinEstoque = Convert.ToInt32(reader["qtdeMinEstoque"]);
                    produto.qtdeMaxEstoque = Convert.ToInt32(reader["qtdeMaxEstoque"]);
                    produto.qtdeAtualEstoque = Convert.ToInt32(reader["qtdeAtualEstoque"]);
                    produto.altura = (reader["altura"] != DBNull.Value ? Convert.ToSingle(reader["altura"]) : 0);
                    produto.comprimento = (reader["comprimento"] != DBNull.Value ? Convert.ToSingle(reader["comprimento"]) : 0);
                    produto.peso = (reader["peso"] != DBNull.Value ? Convert.ToSingle(reader["peso"]) : 0);
                    produto.especificacao = (reader["especificacao"] != DBNull.Value ? (string)(reader["especificacao"]) : "");
                    produto.grupo = new Grupo (Convert.ToInt32(reader["idGrupo"]), (string)reader["nomeGrupo"]);

                    listaProdutos.Add(produto);
                }
            }
            catch (MySqlException e)
            {
            }
            conexao.CloseConexao();
            return listaProdutos;
        }

        public Produto Get(int id)
        {
            Produto produto = new Produto();
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "Select p.*, g.nomeGrupo From produto p Inner Join grupo g On (p.idGrupo = g.idGrupo) where idProduto = (@id)";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

                produto.idProduto = Convert.ToInt32(reader["idProduto"]);
                produto.nomeProduto = (string)reader["nomeProduto"];
                produto.descrProduto = (string)reader["descrProduto"];
                produto.qtdeMinEstoque = Convert.ToInt32(reader["qtdeMinEstoque"]);
                produto.qtdeMaxEstoque = Convert.ToInt32(reader["qtdeMaxEstoque"]);
                produto.qtdeAtualEstoque = Convert.ToInt32(reader["qtdeAtualEstoque"]);
                produto.altura = (float)reader["altura"];
                produto.comprimento = (float)(reader["comprimento"]);
                produto.peso = (float)(reader["peso"]);
                produto.especificacao = (string)(reader["especificacao"]);
                produto.grupo = new Grupo(Convert.ToInt32(reader["idGrupo"]), (string)reader["nomeGrupo"]);

            }
            catch (MySqlException e)
            {
                return null;
            }
            conexao.CloseConexao();
            return produto;
        }

    }    
}

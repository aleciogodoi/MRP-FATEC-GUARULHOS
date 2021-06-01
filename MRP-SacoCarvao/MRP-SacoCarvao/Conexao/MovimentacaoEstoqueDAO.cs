using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MRP_SacoCarvao
{
    class MovimentacaoEstoqueDAO
    {
        public Boolean Insert(MovimentacaoEstoque movi)
        {
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return false;
            }

            try
            {
                MySqlDataReader reader;
                string query = "INSERT INTO MOVIMENTACAOESTOQUECOMPONENTE ( " +
                    "dataMovimentacao, tipoDocumento, nrDocumento, tipoMovimentacao, qtde, idComponente " +
                    ") VALUES( @data, @tipoDoc, @nrDoc, @tipoMov, @qnt, @idComp ); ";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return false;
                }

                cmd.Parameters.AddWithValue("@data", movi.dataMovimentacao);
                cmd.Parameters.AddWithValue("@tipoDoc", movi.tipoDocumento);
                cmd.Parameters.AddWithValue("@nrDoc", movi.nrDocumento);
                cmd.Parameters.AddWithValue("@tipoMov", movi.tipoMovimentacao);
                cmd.Parameters.AddWithValue("@qnt", movi.qtde);
                cmd.Parameters.AddWithValue("@idComp", movi.idComponente);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

            }
            catch (MySqlException e)
            {
                return false;
            }
            conexao.CloseConexao();
            return true;
        }

        public Boolean UpdateEstoque(MovimentacaoEstoque movi)
        {
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return false;
            }

            try
            {
                MySqlDataReader reader;
                string query = "UPDATE COMPONENTE " +
                    "SET qtdeAtualEstoque = qtdeAtualEstoque + @qnt " +
                    "WHERE idComponente = @idComp ; ";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return false;
                }

                cmd.Parameters.AddWithValue("@idComp", movi.idComponente);
                cmd.Parameters.AddWithValue("@qntatual", movi.qtde);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

            }
            catch (MySqlException e)
            {
                return false;
            }
            conexao.CloseConexao();
            return true;
        }

        public List<MovimentacaoEstoque> GetMovimentacoes()
        {
            List<MovimentacaoEstoque> listaMovimentacoes = new List<MovimentacaoEstoque>();
            MovimentacaoEstoque objMovimentacao;
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT m.* FROM MOVIMENTACAOESTOQUECOMPONENTE m";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objMovimentacao = new MovimentacaoEstoque();

                    objMovimentacao.idMovimentacaoComponente = Convert.ToInt32(reader["idMovimentacaoComponente"]);
                    objMovimentacao.dataMovimentacao = (DateTime)reader["dataMovimentacao"];
                    objMovimentacao.tipoDocumento = (string)reader["tipoDocumento"];
                    objMovimentacao.nrDocumento = (string)reader["nrDocumento"];
                    objMovimentacao.tipoMovimentacao = (char)reader["tipoMovimentacao"];
                    objMovimentacao.qtde = Convert.ToInt32(reader["qtde"]);
                    objMovimentacao.idComponente = Convert.ToInt32(reader["idComponente"]);

                    listaMovimentacoes.Add(objMovimentacao);
                }
            }
            catch (MySqlException e)
            {
            }
            conexao.CloseConexao();
            return listaMovimentacoes;
        }

        public List<MovimentacaoEstoque> PesquisaMovimentacoes(string pesquisa)
        {
            List<MovimentacaoEstoque> listaMovimentacoes = new List<MovimentacaoEstoque>();
            MovimentacaoEstoque objMovimentacao;
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT * FROM MOVIMENTACAOESTOQUECOMPONENTE " +
                    "WHERE idMovimentacaoComponente LIKE @pesquisa " +
                    "OR dataMovimentacao LIKE @pesquisa " +
                    "OR nrDocumento LIKE @pesquisa " +
                    "OR tipoMovimentacao LIKE @pesquisa ;";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                cmd.Parameters.AddWithValue("@pesquisa", pesquisa);
                cmd.Prepare();
                Console.WriteLine(query);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objMovimentacao = new MovimentacaoEstoque();

                    objMovimentacao.idMovimentacaoComponente = Convert.ToInt32(reader["idMovimentacaoComponente"]);
                    objMovimentacao.dataMovimentacao = (DateTime)reader["dataMovimentacao"];
                    objMovimentacao.tipoDocumento = (string)reader["tipoDocumento"];
                    objMovimentacao.nrDocumento = (string)reader["nrDocumento"];
                    objMovimentacao.tipoMovimentacao = (char)reader["tipoMovimentacao"];
                    objMovimentacao.qtde = Convert.ToInt32(reader["qtde"]);
                    objMovimentacao.idComponente = Convert.ToInt32(reader["idComponente"]);

                    listaMovimentacoes.Add(objMovimentacao);
                }
            }
            catch (MySqlException e)
            {
            }
            conexao.CloseConexao();
            return listaMovimentacoes;
        }

        public MovimentacaoEstoque GetMovimentacao(int id)
        {
            MovimentacaoEstoque objMovimentacao = new MovimentacaoEstoque();
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT m.* FROM MOVIMENTACAOESTOQUECOMPONENTE m WHERE idMovimentacaoComponente = (@id)";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

                objMovimentacao.idMovimentacaoComponente = Convert.ToInt32(reader["idMovimentacaoComponente"]);
                objMovimentacao.dataMovimentacao = (DateTime)reader["dataMovimentacao"];
                objMovimentacao.tipoDocumento = (string)reader["tipoDocumento"];
                objMovimentacao.nrDocumento = (string)reader["nrDocumento"];
                objMovimentacao.tipoMovimentacao = (char)reader["tipoMovimentacao"];
                objMovimentacao.qtde = Convert.ToInt32(reader["qtde"]);
                objMovimentacao.idComponente = Convert.ToInt32(reader["idComponente"]);

            }
            catch (MySqlException e)
            {
                return null;
            }
            conexao.CloseConexao();
            return objMovimentacao;
        }

        public int GetQuantidadeAtual(int id)
        {
            int quantidade = 0;
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return quantidade;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT qtdeAtualEstoque FROM COMPONENTE WHERE idComponente = (@id)";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return quantidade;
                }

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

                quantidade = Convert.ToInt32(reader["qtdeAtualEstoque"]);

            }
            catch (MySqlException e)
            {
                return quantidade;
            }
            conexao.CloseConexao();
            return quantidade;
        }

    }
}

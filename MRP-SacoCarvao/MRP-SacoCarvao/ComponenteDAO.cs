using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MRP_SacoCarvao
{
    class ComponenteDAO
    {
        public Boolean Insert(Componente comp)
        {
            return true;
        }

        public Boolean Update(Componente comp)
        {
            return true;
        }

        public Boolean Delete(int id)
        {
            return true;
        }

        public List<Componente> GetComponentes()
        {
            List<Componente> listaComponentes = new List<Componente>();
            Componente objComponente;
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT c.* FROM componente c";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objComponente = new Componente();
                    objComponente.idComponente = Convert.ToInt32(reader["idComponente"]);
                    objComponente.nomeComponente = (string)reader["nomeComponente"];
                    objComponente.descrComponente = (string)reader["descrComponente"];
                    objComponente.qtdeMinEstoque = Convert.ToInt32(reader["qtdeMinEstoque"]);
                    objComponente.qtdeMaxEstoque = Convert.ToInt32(reader["qtdeMaxEstoque"]);
                    objComponente.qtdeAtualEstoque = Convert.ToInt32(reader["qtdeAtualEstoque"]);
                    objComponente.especificacao = (reader["especificacao"] != DBNull.Value ? (string)(reader["especificacao"]) : "");

                    listaComponentes.Add(objComponente);
                }
            }
            catch (MySqlException e)
            {
            }
            conexao.CloseConexao();
            return listaComponentes;
        }

        public Componente Get(int id)
        {
            Componente objComponente = new Componente();
            Conexao conexao = new Conexao();

            if (conexao.mErro.Length > 0)
            {
                return null;
            }

            try
            {
                MySqlDataReader reader;
                string query = "SELECT c.* FROM componente c WHERE idComponente = (@id)";
                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);
                if (!conexao.OpenConexao())
                {
                    return null;
                }

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();

                reader = cmd.ExecuteReader();
                reader.Read();

                objComponente.idComponente = Convert.ToInt32(reader["idComponente"]);
                objComponente.nomeComponente = (string)reader["nomeComponente"];
                objComponente.descrComponente = (string)reader["descrComponente"];
                objComponente.qtdeMinEstoque = Convert.ToInt32(reader["qtdeMinEstoque"]);
                objComponente.qtdeMaxEstoque = Convert.ToInt32(reader["qtdeMaxEstoque"]);
                objComponente.qtdeAtualEstoque = Convert.ToInt32(reader["qtdeAtualEstoque"]);
                objComponente.especificacao = (string)(reader["especificacao"]);

            }
            catch (MySqlException e)
            {
                return null;
            }
            conexao.CloseConexao();
            return objComponente;
        }

    }
}

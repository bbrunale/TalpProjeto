using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalpProjeto.DTL;

namespace TalpProjeto.DAL
{
    internal class MetaDAL
    {
        /// <summary>
        /// Insere uma meta no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean insertMeta(MetaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "INSERT INTO Meta (DescMeta,DataMeta,ValorMeta,IdUsuario) VALUES (@descMeta,@dataMeta,@valorMeta,@idUsuario)";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@idUsuario", dtl.idUsuario);
                    _command.Parameters.AddWithValue("@descMeta", dtl.descMeta);
                    _command.Parameters.AddWithValue("@dataMeta", dtl.dataMeta);
                    _command.Parameters.AddWithValue("@valorMeta", dtl.valorMeta);
                    _command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
        }
        /// <summary>
        /// Atualiza uma Meta no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean updateMeta(MetaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "UPDATE Meta SET DescMeta = @descMeta, DataMeta = @dataMeta, ValorMeta = @valorMeta WHERE IdMeta = @idMeta";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@idMeta", dtl.idMeta);
                    _command.Parameters.AddWithValue("@descMeta", dtl.descMeta);
                    _command.Parameters.AddWithValue("@dataMeta", dtl.dataMeta);
                    _command.Parameters.AddWithValue("@valorMeta", dtl.valorMeta);
                    _command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
        }
        /// <summary>
        /// Deleta uma Meta no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean deleteMeta(MetaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _delete = "DELETE FROM Meta WHERE IdMeta = @idMeta";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_delete, conn);
                    _command.Parameters.AddWithValue("@idMeta", dtl.idMeta);
                    _command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
        }
        /// <summary>
        /// Busca todas as Metas de um Usuario do bd
        /// </summary>
        /// <returns>Data table com as Metas encontradas</returns>
        internal DataTable buscarTodasMetas(MetaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT IdMeta, DescMeta, ValorMeta, DataMeta FROM Meta WHERE IdUsuario = @idUsuario ORDER BY ValorMeta";
                    SqlCommand command = new SqlCommand(_sql, conn);
                    command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idUsuario";
                    nomeParam.Value = dtl.idUsuario;
                    nomeParam.DbType = System.Data.DbType.Int32;
                    command.Parameters.Add(nomeParam);

                    DataSet dtSet = new DataSet();
                    SqlDataAdapter dtAdapter = new SqlDataAdapter(command);
                    dtAdapter.Fill(dtSet);
                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// buscar uma Meta a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarMetaId(MetaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT IdMeta, DescMeta, ValorMeta, DataMeta FROM Meta WHERE IdMeta = @idMEta ORDER BY ValorMeta";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idMeta";
                    nomeParam.Value = dtl.idMeta;
                    nomeParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(nomeParam);

                    DataSet dtSet = new DataSet();
                    SqlDataAdapter dtAdapter = new SqlDataAdapter(_command);
                    dtAdapter.Fill(dtSet);
                    return dtSet.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
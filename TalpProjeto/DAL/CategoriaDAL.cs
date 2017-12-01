using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalpProjeto.DTL;

namespace TalpProjeto.DAL
{
    internal class CategoriaDAL
    {
        /// <summary>
        /// Insere uma Categoria no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean insertCategoria(CategoriaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "INSERT INTO Categoria ([NomeCat],[TipoCat]) VALUES (@nomeCategoria,@tipoCategoria)";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@nomeCategoria", dtl.nomeCat);
                    _command.Parameters.AddWithValue("@tipoCategoria", dtl.tipoCat);
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
        /// Atualiza uma Categoria no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean updateCategoria(CategoriaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "UPDATE Categoria SET NomeCat = @nomeCategoria, TipoCat = @tipoCategoria WHERE IdCat = @idCategoria";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@idCategoria", dtl.idCat);
                    _command.Parameters.AddWithValue("@tipoCategoria", dtl.tipoCat);
                    _command.Parameters.AddWithValue("@nomeCategoria", dtl.nomeCat);
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
        /// Deleta uma Categoria no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean deleteCategoria(CategoriaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _delete = "DELETE FROM Categoria WHERE IdCat = @idCategoria";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_delete, conn);
                    _command.Parameters.AddWithValue("@idCategoria", dtl.idCat);
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
        /// Busca todas as Categorias do bd
        /// </summary>
        /// <returns>Data table com as vs encontradas</returns>
        internal DataTable buscarTodasCategorias()
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeCat, TipoCat FROM Categoria ORDER BY NomeCat";
                    SqlCommand command = new SqlCommand(_sql, conn);
                    command.CommandType = CommandType.Text;

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
        /// buscar Categoria a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarCategoriaId(CategoriaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeCat, TipoCat FROM Categoria WHERE IdCat = @idCat ORDER BY NomeCat";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idCat";
                    nomeParam.Value = dtl.idCat;
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
        /// <summary>
        /// buscar categorias a partir de um Tipo de categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarCategoriaTipo(CategoriaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeCat, TipoCat FROM Categoria WHERE TipoCat like @tipoCat ORDER BY NomeCat";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@tipoCat";
                    nomeParam.Value = dtl.tipoCat;
                    nomeParam.DbType = System.Data.DbType.String;
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
        /// <summary>
        /// buscar Categoria a partir de uma string
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarCategoriaNome(CategoriaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeCat, TipoCat FROM Categoria WHERE NomeCat like @nomeCat ORDER BY NomeCat";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@nomeCat";
                    nomeParam.Value = dtl.nomeCat;
                    nomeParam.DbType = System.Data.DbType.String;
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
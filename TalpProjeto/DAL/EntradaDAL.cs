using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalpProjeto.DTL;

namespace TalpProjeto.DAL
{
    public class EntradaDAL
    {
        /// <summary>
        /// Insere uma Entrada no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean insertEntrada(EntradaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "INSERT INTO Entrada ([NomeEntrada],[DescEntrada],[ValorEntrada],[DataEntrada],[IdCat],[IdUsuario]) VALUES (@nomeEntrada,@descEntrada,@valorEntrada,@dataEntrada,@idCat,@idUsuario)";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@nomeEntrada", dtl.nomeEntrada);
                    _command.Parameters.AddWithValue("@descEntrada", dtl.descEntrada);
                    _command.Parameters.AddWithValue("@valorEntrada", dtl.valorEntrada);
                    _command.Parameters.AddWithValue("@dataEntrada", dtl.dataEntrada);
                    _command.Parameters.AddWithValue("@idCat", dtl.idCat);
                    _command.Parameters.AddWithValue("@idUsuario", dtl.idUsuario);
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
        /// Atualiza um Entrada no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean updateEntrada(EntradaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "UPDATE Entrada SET NomeEntrada = @nomeEntrada, DescEntrada = @descEntrada, ValorEntrada = @valorEntrada, DataEntrada = @dataEntrada, IdCat = @idCat WHERE IdEntrada = @idEntrada";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@idCat", dtl.idCat);
                    _command.Parameters.AddWithValue("@nomeEntrada", dtl.nomeEntrada);
                    _command.Parameters.AddWithValue("@descEntrada", dtl.descEntrada);
                    _command.Parameters.AddWithValue("@valorEntrada", dtl.valorEntrada);
                    _command.Parameters.AddWithValue("@dataEntrada", dtl.dataEntrada);
                    _command.Parameters.AddWithValue("@idEntrada", dtl.idEntrada);
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
        /// Deleta um Entrada no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean deleteEntrada(EntradaDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _delete = "DELETE FROM entrada WHERE IdEntrada = @idEntrada";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_delete, conn);
                    _command.Parameters.AddWithValue("@idEntrada", dtl.idEntrada);
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
        /// Busca todas as entradas do bd
        /// </summary>
        /// <returns>Data table com as entradas encontradas</returns>
        internal DataTable buscarTodasEntradas(EntradaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT A.IdEntrada, A.NomeEntrada, A.DescEntrada, A.ValorEntrada, A.DataEntrada, E.NomeCat FROM Entrada AS A INNER JOIN Categoria AS E ON A.IdCat = E.IdCat WHERE IdUsuario = @idUsuario ORDER BY NomeEntrada";
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
        /// buscar Entrada a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarEntradaId(EntradaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT A.IdEntrada, A.NomeEntrada, A.DescEntrada, A.ValorEntrada, A.DataEntrada, E.NomeCat FROM Entrada AS A INNER JOIN Categoria AS E ON A.IdCat = E.IdCat WHERE A.IdUsuario = @idUsuario AND IdEntrada = @idEntrada ORDER BY NomeEntrada";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idUsuario";
                    nomeParam.Value = dtl.idUsuario;
                    nomeParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(nomeParam);
                    IDataParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@idEntrada";
                    IdParam.Value = dtl.idEntrada;
                    IdParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(IdParam);

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
        /// buscar Entrada a partir de uma Categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarEntradaCategoria(EntradaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT A.IdEntrada, A.NomeEntrada, A.DescEntrada, A.ValorEntrada, A.DataEntrada, E.NomeCat FROM Entrada AS A INNER JOIN Categoria AS E ON A.IdCat = E.IdCat WHERE A.IdUsuario = @idUsuario AND A.IdCat = @idCat ORDER BY NomeEntrada";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idUsuario";
                    nomeParam.Value = dtl.idUsuario;
                    nomeParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(nomeParam);
                    IDataParameter idParam = new SqlParameter();
                    idParam.ParameterName = "@idCat";
                    idParam.Value = dtl.idCat;
                    idParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(idParam);

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
        /// buscar Entrada a partir de uma string
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarEntradaNome(EntradaDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT A.IdEntrada, A.NomeEntrada, A.DescEntrada, A.ValorEntrada, A.DataEntrada, E.NomeCat FROM Entrada AS A INNER JOIN Categoria AS E ON A.IdCat = E.IdCat WHERE A.IdUsuario = @idUsuario AND A.NomeEntrada like @nomeEntrada ORDER BY NomeEntrada";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@nomeEntrada";
                    nomeParam.Value = dtl.nomeEntrada;
                    nomeParam.DbType = System.Data.DbType.String;
                    _command.Parameters.Add(nomeParam);
                    IDataParameter idParam = new SqlParameter();
                    idParam.ParameterName = "@idUsuario";
                    idParam.Value = dtl.idUsuario;
                    idParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(idParam);

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
        /// buscar Entrada a partir de um tipo de Categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <param name="tipoCat"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarEntradaTipoCat(EntradaDTL dtl, string tipoCat)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT A.IdEntrada, A.NomeEntrada, A.DescEntrada, A.ValorEntrada, A.DataEntrada, E.NomeCat FROM Entrada AS A INNER JOIN Categoria AS E ON A.IdCat = E.IdCat WHERE A.IdUsuario = @idUsuario AND E.TipoCat like @tipoCat ORDER BY NomeEntrada";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@tipoCat";
                    nomeParam.Value = tipoCat;
                    nomeParam.DbType = System.Data.DbType.String;
                    _command.Parameters.Add(nomeParam);
                    IDataParameter idParam = new SqlParameter();
                    idParam.ParameterName = "@idUsuario";
                    idParam.Value = dtl.idUsuario;
                    idParam.DbType = System.Data.DbType.Int32;
                    _command.Parameters.Add(idParam);

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
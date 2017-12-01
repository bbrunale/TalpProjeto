using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalpProjeto.DTL;

namespace TalpProjeto.DAL
{
    internal class UsuarioDAL
    {
        /// <summary>
        /// Insere um Usuario no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean insertUsuario(UsuarioDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "INSERT INTO Usuario ([NomeUsuario],[EmailUsuario],[SenhaUsuario]) VALUES (@nomeUsuario,@emailUsuario,@senhaUsuario)";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@nomeUsuario", dtl.nomeUsuario);
                    _command.Parameters.AddWithValue("@emailUsuario", dtl.emailUsuario);
                    _command.Parameters.AddWithValue("@senhaUsuario", dtl.senhaUsuario);
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
        /// Atualiza um Usuario no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean updateUsuario(UsuarioDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _insert = "UPDATE Usuario SET NomeUsuario = @nomeUsuario, EmailUsuario = @emailUsuario, SenhaUsuario = @senhaUsuario WHERE IdUsuario = @idUsuario";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_insert, conn);
                    _command.Parameters.AddWithValue("@idUsuario", dtl.idUsuario);
                    _command.Parameters.AddWithValue("@nomeUsuario", dtl.nomeUsuario);
                    _command.Parameters.AddWithValue("@emailUsuario", dtl.emailUsuario);
                    _command.Parameters.AddWithValue("@senhaUsuario", dtl.senhaUsuario);
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
        /// Deleta um Usuario no sistema
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        internal Boolean deleteUsuario(UsuarioDTL dtl)
        {

            var _strDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"];
            using (SqlConnection conn = new SqlConnection(_strDeConexao.ToString()))
                try
                {
                    //abre o banco de dados
                    conn.Open();
                    //prepara comando para enviar ao BD
                    var _delete = "DELETE FROM Usuario WHERE IdUsuario = @idUsuario";
                    //Utiliza o sqlCommand para enviar os dados ao banco
                    SqlCommand _command = new SqlCommand(_delete, conn);
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
        /// Busca todos os Usuarios do bd
        /// </summary>
        /// <returns>Data table com os Usuarios encontrados</returns>
        internal DataTable buscarTodosUsuarios()
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeUsuario, EmailUsuario, SenhaUsuario FROM Usuario ORDER BY NomeUsuario";
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
        /// buscar Usuario a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarUsuarioId(UsuarioDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeUsuario, EmailUsuario, SenhaUsuario FROM Usuario WHERE IdUsuario = @idUsuario ORDER BY NomeUsuario";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@idUsuario";
                    nomeParam.Value = dtl.idUsuario;
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
        /// buscar Usuario a partir de um Email
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarUsuarioEmail(UsuarioDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeUsuario, EmailUsuario, SenhaUsuario FROM Usuario WHERE EmailUsuario = @emailUsuario ORDER BY NomeUsuario";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@emailUsuario";
                    nomeParam.Value = dtl.emailUsuario;
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
        /// buscar Usuario a partir de um Email e senha
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarUsuarioEmailSenha(UsuarioDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT IdUsuario, NomeUsuario, EmailUsuario, SenhaUsuario FROM Usuario WHERE EmailUsuario = @emailUsuario AND SenhaUsuario = @senhaUsuario";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@emailUsuario";
                    nomeParam.Value = dtl.emailUsuario;
                    nomeParam.DbType = System.Data.DbType.String;
                    _command.Parameters.Add(nomeParam);
                    IDataParameter senhaParam = new SqlParameter();
                    senhaParam.ParameterName = "@senhaUsuario";
                    senhaParam.Value = dtl.senhaUsuario;
                    senhaParam.DbType = System.Data.DbType.String;
                    _command.Parameters.Add(senhaParam);

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
        /// buscar Usuario a partir de uma string
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns>data table com os resultados do select</returns>
        internal DataTable buscarUsuarioNome(UsuarioDTL dtl)
        {
            var _stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["MinhaConexao"].ToString();
            using (SqlConnection conn = new SqlConnection(_stringDeConexao))
            {
                try
                {
                    conn.Open();
                    var _sql = "SELECT NomeUsuario, EmailUsuario, SenhaUsuario FROM Usuario WHERE NomeUsuario like @nomeUsuario ORDER BY NomeUsuario";
                    SqlCommand _command = new SqlCommand(_sql, conn);
                    _command.CommandType = CommandType.Text;

                    IDataParameter nomeParam = new SqlParameter();
                    nomeParam.ParameterName = "@nomeUsuario";
                    nomeParam.Value = dtl.nomeUsuario;
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

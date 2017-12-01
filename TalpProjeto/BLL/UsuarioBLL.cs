using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalpProjeto.DAL;
using TalpProjeto.DTL;

namespace TalpProjeto.BLL
{
    public class UsuarioBLL
    {
        private new UsuarioDAL _usuarioDAL;

        /// <summary>
        /// Construtor da classe
        /// Se a instancia for null, gera uma nova instancia
        /// </summary>
        public UsuarioBLL()
        {
            if (_usuarioDAL == null)
                _usuarioDAL = new DAL.UsuarioDAL();
        }
        /// <summary>
        /// Método responsavel pela regra de negocio do Usuario
        /// No momento de inserir os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean insertUsuario(UsuarioDTL dtl)
        {
            DataTable data = _usuarioDAL.buscarUsuarioEmail(dtl);
            if (data == null)
            {
                try
                {
                    return _usuarioDAL.insertUsuario(dtl);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new Exception("Email enviado ja existe!");
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de deleta o Usuario desejado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean deleteUsuario(UsuarioDTL dtl)
        {
            try
            {
                return _usuarioDAL.deleteUsuario(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de retornar todos os Usuarios do bd
        /// </summary>
        /// <returns>dataTable com os Usuarios</returns>
        public DataTable buscarTodosUsuarios()
        {

            try
            {

                return _usuarioDAL.buscarTodosUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de retornar o resultado da busca
        /// de um Usuario no sistema a partir de um pedaço ou do nome completo
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioNome(UsuarioDTL dtl)
        {
            try
            {
                return _usuarioDAL.buscarUsuarioNome(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de retornar o resultado da busca
        /// de um Usuario no sistema a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioId(UsuarioDTL dtl)
        {
            try
            {
                return _usuarioDAL.buscarUsuarioId(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de retornar o resultado da busca
        /// de um Usuario no sistema a partir de um email
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioEmail(UsuarioDTL dtl)
        {
            try
            {
                return _usuarioDAL.buscarUsuarioEmail(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio do Usuario
        /// no momento de retornar o resultado da busca
        /// de um Usuario no sistema a partir de um Email e Senha
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioEmailSenha(UsuarioDTL dtl)
        {
            try
            {
                return _usuarioDAL.buscarUsuarioEmailSenha(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
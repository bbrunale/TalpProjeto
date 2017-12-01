using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalpProjeto.DAL;
using TalpProjeto.DTL;

namespace TalpProjeto.BLL
{
    public class EntradaBLL
    {
        private new EntradaDAL _entradaDAL;

        /// <summary>
        /// Construtor da classe
        /// Se a instancia for null, gera uma nova instancia
        /// </summary>
        public EntradaBLL()
        {
            if (_entradaDAL == null)
                _entradaDAL = new DAL.EntradaDAL();
        }
        /// <summary>
        /// Método responsavel pela regra de negocio da Entrada
        /// No momento de inserir os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean insertEntrada(EntradaDTL dto)
        {

            try
            {
                return _entradaDAL.insertEntrada(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método responsavel pela regra de negocio da Entrada
        /// No momento de atualizar os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean updateEntrada(EntradaDTL dto)
        {

            try
            {
                return _entradaDAL.updateEntrada(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de deleta a Entrada desejada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean deleteEntrada(EntradaDTL dto)
        {
            try
            {
                return _entradaDAL.deleteEntrada(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de retornar todas as Entradas do bd
        /// </summary>
        /// <returns>dataTable com as Entradas</returns>
        public DataTable buscarTodasEntradas(EntradaDTL dtl)
        {

            try
            {

                return _entradaDAL.buscarTodasEntradas(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de retornar o resultado da busca
        /// de uma Entrada no sistema a partir de um pedaço ou do nome completo
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarEntradaNome(EntradaDTL dtl)
        {
            try
            {
                return _entradaDAL.buscarEntradaNome(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de retornar o resultado da busca
        /// de uma Entrada no sistema a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarEntradaId(EntradaDTL dtl)
        {
            try
            {
                return _entradaDAL.buscarEntradaId(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de retornar o resultado da busca
        /// de uma Entrada no sistema a partir de um ID de categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarEntradaCategoria(EntradaDTL dtl)
        {
            try
            {
                return _entradaDAL.buscarEntradaCategoria(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Entrada
        /// no momento de retornar o resultado da busca
        /// de uma Entrada no sistema a partir de um Tipo de categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarEntradaTipoCat(EntradaDTL dtl, string tipoCat)
        {
            try
            {
                return _entradaDAL.buscarEntradaTipoCat(dtl,tipoCat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
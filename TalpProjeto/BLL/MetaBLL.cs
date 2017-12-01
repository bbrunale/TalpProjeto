using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalpProjeto.DAL;
using TalpProjeto.DTL;

namespace TalpProjeto.BLL
{
    public class MetaBLL
    {
        private new MetaDAL _metaDAL;

        /// <summary>
        /// Construtor da classe
        /// Se a instancia for null, gera uma nova instancia
        /// </summary>
        public MetaBLL()
        {
            if (_metaDAL == null)
                _metaDAL = new DAL.MetaDAL();
        }
        /// <summary>
        /// Método responsavel pela regra de negocio da meta
        /// No momento de inserir os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean insertMeta(MetaDTL dto)
        {

            try
            {
                return _metaDAL.insertMeta(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Método responsavel pela regra de negocio da meta
        /// No momento de atualizar os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean updateMeta(MetaDTL dto)
        {

            try
            {
                return _metaDAL.updateMeta(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da meta
        /// no momento de deleta a meta desejada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean deleteMeta(MetaDTL dto)
        {
            try
            {
                return _metaDAL.deleteMeta(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da meta
        /// no momento de retornar todas as metas do bd
        /// </summary>
        /// <returns>dataTable com as metas</returns>
        public DataTable buscarTodasMetas(MetaDTL dtl)
        {

            try
            {

                return _metaDAL.buscarTodasMetas(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da meta
        /// no momento de retornar o resultado da busca
        /// de uma meta no sistema a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarMetaId(MetaDTL dtl)
        {
            try
            {
                return _metaDAL.buscarMetaId(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
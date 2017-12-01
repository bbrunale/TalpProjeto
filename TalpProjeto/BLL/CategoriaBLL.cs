using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TalpProjeto.DAL;
using TalpProjeto.DTL;

namespace TalpProjeto.BLL
{
    public class CategoriaBLL
    {
        private new CategoriaDAL _categoriaDAL;

        /// <summary>
        /// Construtor da classe
        /// Se a instancia for null, gera uma nova instancia
        /// </summary>
        public CategoriaBLL()
        {
            if (_categoriaDAL == null)
                _categoriaDAL = new DAL.CategoriaDAL();
        }
        /// <summary>
        /// Método responsavel pela regra de negocio da Categoria
        /// No momento de inserir os valores
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean insertCategoria(CategoriaDTL dto)
        {

            try
            {
                return _categoriaDAL.insertCategoria(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Categoria
        /// no momento de deleta a Categoria desejada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true se obtiver exito, false se não</returns>
        public Boolean deleteCategoria(CategoriaDTL dto)
        {
            try
            {
                return _categoriaDAL.deleteCategoria(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Categoria
        /// no momento de retornar todas as Categorias do bd
        /// </summary>
        /// <returns>dataTable com as Categorias</returns>
        public DataTable buscarTodasCategorias()
        {

            try
            {

                return _categoriaDAL.buscarTodasCategorias();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Categoria
        /// no momento de retornar o resultado da busca
        /// de uma Categoria no sistema a partir de um pedaço ou do nome completo
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarCategoriaNome(CategoriaDTL dtl)
        {
            try
            {
                return _categoriaDAL.buscarCategoriaNome(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Categoria
        /// no momento de retornar o resultado da busca
        /// de uma Categoria no sistema a partir de um ID
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarCategoriaId(CategoriaDTL dtl)
        {
            try
            {
                return _categoriaDAL.buscarCategoriaId(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo responsavel pela regra de negocio da Categoria
        /// no momento de retornar o resultado da busca
        /// de uma Categoria no sistema a partir de um tipo de categoria
        /// </summary>
        /// <param name="dtl"></param>
        /// <returns></returns>
        public DataTable buscarCategoriaTipo(CategoriaDTL dtl)
        {
            try
            {
                return _categoriaDAL.buscarCategoriaTipo(dtl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
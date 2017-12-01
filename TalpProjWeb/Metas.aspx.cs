using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalpProjeto.BLL;
using TalpProjeto.DTL;

namespace TalpProjWeb
{
    public partial class Metas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["url"] != null)
            {
                Session["url"] = "Metas";
            }
            else
            {
                Session.Add("url", "Metas");
            }
            if (Session["Id"] == null)
            {
                if (!IsPostBack)
                {
                    Response.Redirect("LoginTeste");
                }
            }
            if (!IsPostBack)
            {
                CalMeta.SelectedDate = DateTime.Today;
            }
                
            preencherGrid();
        }
        /*----------------------------------------Grid-FIll-----------------------------------------*/
        private void preencherGrid()
        {
            MetaBLL meta = new MetaBLL();
            MetaDTL metaDTL = new MetaDTL();

            metaDTL.idUsuario = int.Parse(Session["Id"].ToString());
            GridMetas.DataSource = meta.buscarTodasMetas(metaDTL);
            GridMetas.DataBind();
        }
        /*---------------------------------------Button-Voltar--------------------------------------*/
        protected void BtnVoltarMetas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        /*---------------------------------------Button-Envia---------------------------------------*/
        protected void BtnEnviaMeta_Click(object sender, EventArgs e)
        {
            MetaBLL metasBLL = new MetaBLL();
            MetaDTL metas = new MetaDTL();

            metas.idUsuario = int.Parse(Session["Id"].ToString());
            metas.valorMeta = double.Parse(TbValorMeta.Text);
            metas.descMeta = TbDescMeta.Text;
            metas.dataMeta = CalMeta.SelectedDate;

            metasBLL.insertMeta(metas);
            preencherGrid();
        }
        /*-----------------------------------------Grid-Command---------------------------------------*/
        protected void GridMetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                //pegar index
                int _index = int.Parse((String)e.CommandArgument);
                //pegar a chave
                string _chave = GridMetas.DataKeys[_index]["IdMeta"].ToString();
                //deletar passando chave

                //gerar dto
                MetaDTL _dto = new MetaDTL();
                _dto.idUsuario = int.Parse(Session["Id"].ToString());
                if (!String.IsNullOrEmpty(_chave))
                    _dto.idMeta = int.Parse(_chave);
                 
                //acessa a build passando a dto
                MetaBLL _bll = new MetaBLL();
                if (_bll.deleteMeta(_dto))
                {
                    preencherGrid();
                }
            }
            
        }
        /*-----------------------------------------UPDATING----------------------------------------*/
        protected void GridMetas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridMetas.EditIndex = e.NewEditIndex;
            
            preencherGrid();
        }

        protected void GridMetas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //pegar index
            int _index = e.RowIndex;
            MetaDTL meta = new MetaDTL();
            string _chave = GridMetas.DataKeys[_index]["IdMeta"].ToString();

            GridViewRow row = GridMetas.Rows[_index];

            meta.idUsuario = int.Parse(Session["Id"].ToString());
            if (!String.IsNullOrEmpty(_chave))
                meta.idMeta = int.Parse(_chave);

            meta.descMeta = ((TextBox)(row.Cells[2].Controls[0])).Text;
            meta.valorMeta = double.Parse(((TextBox)(row.Cells[3].Controls[0])).Text);
            meta.dataMeta = (row.FindControl("CalGridMeta") as Calendar).SelectedDate;
            
            MetaBLL bll = new MetaBLL();
            bll.updateMeta(meta);
        }

        protected void GridMetas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridMetas.EditIndex = -1;
            preencherGrid();
        }
        /*----------------------------------------page-index-----------------------------------*/
        protected void GridMetas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMetas.PageIndex = e.NewPageIndex;
            preencherGrid();
        }

        protected void GridMetas_DataBound(object sender, EventArgs e)
        {
            decimal valor = 0;

            foreach (GridViewRow row in GridMetas.Rows)
            {
                    valor += decimal.Parse(row.Cells[3].Text);
            }
            GridViewRow footer = GridMetas.FooterRow;
            footer.Cells[0].ColumnSpan = 3;
            footer.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            //Remove as células não utilizadas
            footer.Cells.RemoveAt(2);
            footer.Cells.RemoveAt(1);
            footer.Cells.RemoveAt(3);
            //Adiciona um texto
            footer.Cells[0].Text = "Valor total: R$ " + valor;
        }
    }
}
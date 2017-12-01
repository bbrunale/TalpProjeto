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
    public partial class Entradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["url"] != null)
            {
                Session["url"] = "Entradas";
            }
            else
            {
                Session.Add("url", "Entradas");
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
                CalEnt.SelectedDate = DateTime.Today;
            }
                preencherGrid();
        }
        /*--------------------------------------GRID-FILL-------------------------------------------*/
        private void preencherGrid()
        {
            EntradaBLL entrada = new EntradaBLL();
            EntradaDTL entradaDTL = new EntradaDTL();

            entradaDTL.idUsuario = int.Parse(Session["Id"].ToString());
            GridEnt.DataSource = entrada.buscarTodasEntradas(entradaDTL);
            GridEnt.DataBind();
        }
        private void preencherGridNome(EntradaDTL dtl)
        {
            EntradaBLL entrada = new EntradaBLL();

            dtl.idUsuario = int.Parse(Session["Id"].ToString());
            GridEnt.DataSource = entrada.buscarEntradaNome(dtl);
            GridEnt.DataBind();
        }
        private void preencherGridTipoCategoria(EntradaDTL dtl, string tipo)
        {
            EntradaBLL entrada = new EntradaBLL();

            dtl.idUsuario = int.Parse(Session["Id"].ToString());
            GridEnt.DataSource = entrada.buscarEntradaTipoCat(dtl,tipo);
            GridEnt.DataBind();
        }
        /*--------------------------------------Visibility------------------------------------------*/
        private void addVisibility()
        {
            PnlAddEnt.Visible = true;

            LblTipoPesEnt.Visible = false;
            DdlTipoPesEnt.Visible = false;

            LblNomeEnt.Visible = true;
            TbNomeEnt.Visible = true;
            
            LblCatEnt.Visible = true;
            DdlCatEnt.Visible = true;
        }
        private void PesDefaultVisibility()
        {
            PnlAddEnt.Visible = false;

            LblTipoPesEnt.Visible = true;
            DdlTipoPesEnt.Visible = true;

            LblNomeEnt.Visible = false;
            TbNomeEnt.Visible = false;

            LblCatEnt.Visible = false;
            DdlCatEnt.Visible = false;
        }
        private void PesNomeVisibility()
        {
            PnlAddEnt.Visible = false;

            LblTipoPesEnt.Visible = true;
            DdlTipoPesEnt.Visible = true;

            LblNomeEnt.Visible = true;
            TbNomeEnt.Visible = true;

            LblCatEnt.Visible = false;
            DdlCatEnt.Visible = false;
        }
        private void PesCatVisibility()
        {
            PnlAddEnt.Visible = false;

            LblTipoPesEnt.Visible = true;
            DdlTipoPesEnt.Visible = true;

            LblNomeEnt.Visible = false;
            TbNomeEnt.Visible = false;

            LblCatEnt.Visible = true;
            DdlCatEnt.Visible = true;
        }
        /*--------------------------------------GRID-Events-----------------------------------------*/
        protected void GridEnt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EntradaDTL entradaDTL = new EntradaDTL();
            entradaDTL.idUsuario = int.Parse(Session["Id"].ToString());

            GridEnt.PageIndex = e.NewPageIndex;
            if (DdlTipoOpEnt.SelectedValue.Equals("add"))
            {
                preencherGrid();
            }
            else if(DdlTipoPesEnt.SelectedValue.Equals("all"))
            {
                preencherGrid();
            }
            else if (DdlTipoPesEnt.SelectedValue.Equals("nome"))
            {
                entradaDTL.nomeEntrada = TbNomeEnt.Text;
                preencherGridNome(entradaDTL);
            }
            else
            {
                preencherGridTipoCategoria(entradaDTL,DdlCatEnt.SelectedItem.Text);
            }
        }
        /*--------------------------------------Button-Voltar---------------------------------------*/
        protected void BtnVoltarEnt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        /*--------------------------------------Button-Enviar---------------------------------------*/
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            EntradaDTL dtl = new EntradaDTL();
            EntradaBLL bll = new EntradaBLL();

            dtl.idUsuario = int.Parse(Session["Id"].ToString());
            dtl.idCat = int.Parse(DdlCatEnt.SelectedValue);
            dtl.nomeEntrada = TbNomeEnt.Text;
            dtl.valorEntrada = double.Parse(TbValorEnt.Text);
            dtl.descEntrada = TbDescEnt.Text;
            dtl.dataEntrada = CalEnt.SelectedDate;
            string parcelas = TbParcEnt.Text;

            if (DdlTipoOpEnt.SelectedValue.Equals("add"))
            {
                
                if (!string.IsNullOrEmpty(parcelas))
                {
                    int parc = int.Parse(parcelas);
                    if (parc > 1)
                    {
                        dtl.valorEntrada = (dtl.valorEntrada / parc);
                        for (int i = 0; i < parc; i++)
                        {
                            bll.insertEntrada(dtl);
                            dtl.dataEntrada.AddMonths(1);
                            preencherGrid();
                        }

                    }
                    else if(parc <= 1)
                    {
                        bll.insertEntrada(dtl);
                        preencherGrid();
                    }
                    else
                    {
                        /*error treatment*/
                    }
                }
                else {
                    bll.insertEntrada(dtl);
                    preencherGrid();
                }
            }
            else if (DdlTipoPesEnt.SelectedValue.Equals("all"))
            {
                preencherGrid();
            }
            else if (DdlTipoPesEnt.SelectedValue.Equals("nome"))
            {
                preencherGridNome(dtl);
            }
            else
            {
                preencherGridTipoCategoria(dtl,DdlCatEnt.SelectedItem.Text);
            }
        }
        /*------------------------ddl-------------------------------*/
        protected void DdlTipoOpEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlTipoOpEnt.SelectedValue.Equals("add"))
            {
                addVisibility();
            }
            else
            {
                PesDefaultVisibility();
            }
        }

        protected void DdlTipoPesEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlTipoPesEnt.SelectedValue.Equals("nome"))
            {
                PesNomeVisibility();
            }
            else
            {
                PesCatVisibility();
            }
        }
        /*-----------------------------------------ROW-EDITING-----------------------------------------*/
        protected void GridEnt_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridEnt.EditIndex = e.NewEditIndex;
            preencherGrid();
        }

        protected void GridEnt_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int _index = e.RowIndex;
            string _chave = GridEnt.DataKeys[_index]["IdEntrada"].ToString();
            EntradaDTL entrada = new EntradaDTL();
            EntradaBLL entradaBLL = new EntradaBLL();

            GridViewRow row = GridEnt.Rows[_index];

            entrada.idUsuario = int.Parse(Session["Id"].ToString());

            if (!String.IsNullOrEmpty(_chave))
                entrada.idEntrada = int.Parse(_chave);

            entrada.nomeEntrada = ((TextBox)(row.Cells[2].Controls[0])).Text;
            entrada.valorEntrada = double.Parse(((TextBox)(row.Cells[3].Controls[0])).Text);
            entrada.dataEntrada = (GridEnt.Rows[_index].FindControl("CalGridEnt") as Calendar).SelectedDate;
            entrada.idCat = int.Parse((GridEnt.Rows[_index].FindControl("DdlGridCatEnt") as DropDownList).SelectedValue.ToString());
            entrada.descEntrada = ((TextBox)(row.Cells[6].Controls[0])).Text;

            entradaBLL.updateEntrada(entrada);

            GridEnt.EditIndex = -1;
            preencherGrid();
        }

        protected void GridEnt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridEnt.EditIndex = -1;
            preencherGrid();
        }
        /*---------------------------------------ROW-COMMAND--------------------------------------*/
        protected void GridEnt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Excluir"))
            {
                //pegar index
                int _index = int.Parse((String)e.CommandArgument);
                //pegar a chave
                string _chave = GridEnt.DataKeys[_index]["IdEntrada"].ToString();
                //deletar passando chave

                //gerar dto
                EntradaDTL _dto = new EntradaDTL();
                _dto.idUsuario = int.Parse(Session["Id"].ToString());
                if (!String.IsNullOrEmpty(_chave))
                    _dto.idEntrada = int.Parse(_chave);

                //acessa a build passando a dto
                EntradaBLL _bll = new EntradaBLL();
                if (_bll.deleteEntrada(_dto))
                {
                    preencherGrid();
                }
            }
        }

        protected void GridEnt_DataBound(object sender, EventArgs e)
        {
            decimal valor = 0;

            foreach(GridViewRow row in GridEnt.Rows)
            {
                if (row.Cells[4].Text.Equals("Despesa"))
                {
                    valor -= decimal.Parse(row.Cells[3].Text);
                }
                else
                {
                    valor += decimal.Parse(row.Cells[3].Text);
                }
            }
            GridViewRow footer = GridEnt.FooterRow;
            footer.Cells[0].ColumnSpan = 4;
            footer.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            //Remove as células não utilizadas
            footer.Cells.RemoveAt(2);
            footer.Cells.RemoveAt(1);
            footer.Cells.RemoveAt(3);
            footer.Cells.RemoveAt(4);
            //Adiciona um texto
            footer.Cells[0].Text = "Valor total: R$ " + valor;
        }
    }
}
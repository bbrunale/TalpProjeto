using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TalpProjeto.BLL;
using TalpProjeto.DTL;

namespace TalpProjWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EnviarCadastra(object sender, EventArgs e)
        {
            UsuarioDTL usuario = new UsuarioDTL();
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuario.senhaUsuario = Request.Form["txtSenhaCad"];
            if (usuario.senhaUsuario.Equals(Request.Form["txtSenha2Cad"]))
            {
                usuario.emailUsuario = Request.Form["txtEmailCad"];
                usuario.nomeUsuario = Request.Form["txtNomeCad"];

                usuarioBLL.insertUsuario(usuario);
            }
            else
            {

            }
            

        }
        protected void EnviarLogin(object sender, EventArgs e)
        {
            UsuarioDTL usuario = new UsuarioDTL();
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            DataTable data;

            usuario.emailUsuario = Request.Form["txtEmail"];
            usuario.senhaUsuario = Request.Form["txtSenha"];


            data = usuarioBLL.buscarUsuarioEmailSenha(usuario);
            if(data == null || data.Rows.Count == 0)
            {

            }
            else
            {
                Session.Add("Id",data.Rows[0]["IdUsuario"]);
                if (Session["url"] == null)
                {
                    Session.Add("url", "Default");
                }
                Response.Redirect(Session["url"].ToString());
            }
        }
    }
}
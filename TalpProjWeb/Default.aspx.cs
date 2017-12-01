using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TalpProjWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["url"] != null)
            {
                Session["url"] = "Default";
            }
            else
            {
                Session.Add("url", "Default");
            }
            if (Session["Id"] == null)
            {
                if (!IsPostBack)
                {
                    Response.Redirect("LoginTeste");
                }
            }
        }
    }
}
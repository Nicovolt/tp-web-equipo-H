using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPWinForm_equipo_h
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> articuloList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDB negocio = new ArticuloDB();
            articuloList = negocio.listar();

        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallesArticulo.aspx?id=");
        }
    }
}
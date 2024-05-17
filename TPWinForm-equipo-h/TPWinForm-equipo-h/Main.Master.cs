using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPWinForm_equipo_h
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                List<Articulo> carritoActual = (List<Articulo>)Session["CarritoCompras"];
                int cantArticulos = carritoActual != null ? carritoActual.Count : 0;

                
                ActualizarContadorCarrito(cantArticulos);
            }
        }

        public void ActualizarContadorCarrito(int contador)
        {
            Label1.Text = contador.ToString();
        }

    }
}
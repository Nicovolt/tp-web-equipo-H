using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_h
{
    public partial class CarritoCompras : System.Web.UI.Page
    {
        private ArticuloDB articuloDB = new ArticuloDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CarritoCompras"] == null)
            {
                List<Articulo> Newcarrito = new List<Articulo>();
                Session.Add("CarritoCompras", Newcarrito);
            }
            
            if(Request.QueryString["id"] == null)
            {
                List<Articulo> carrito;
                carrito = (List<Articulo>)Session["CarritoCompras"];
                repeaterCarrito.DataSource = carrito;
                repeaterCarrito.DataBind();
            }
            else
            {

            int id = int.Parse(Request.QueryString["id"]);


            Articulo articulo = new Articulo();
            articulo = articuloDB.buscarPorId(id);
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["CarritoCompras"];
            carrito.Add(articulo);

            repeaterCarrito.DataSource = carrito;
            
            repeaterCarrito.DataBind();
            }




        }
    }
}
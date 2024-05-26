using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            if (!IsPostBack)
            {
                if (Session["CarritoCompras"] == null)
                {
                    List<Articulo> Newcarrito = new List<Articulo>();
                    Session.Add("CarritoCompras", Newcarrito);
                }
            }       
            
            if(Request.QueryString["id"] == null)
            {
                List<Articulo> carrito;
                carrito = (List<Articulo>)Session["CarritoCompras"];
                cargarCarrito(carrito);
                List<Articulo> carritoActual = (List<Articulo>)Session["CarritoCompras"];
                int cantArticulos = carritoActual.Count;

               
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

            List<Articulo> carritoActual = (List<Articulo>)Session["CarritoCompras"];
            int cantArticulos = carritoActual.Count;


                Main masterPage = (Main)this.Master;
                masterPage.ActualizarContadorCarrito(cantArticulos);





            }

            List<Articulo> carritoAct = (List<Articulo>)Session["CarritoCompras"];
            decimal total = 0;
            foreach (Articulo art in carritoAct)
            {
                total += art.precio;
            }
            lblPrecioTotal.Text = total.ToString();

            

        }

        private void cargarCarrito(List<Articulo> carrito)
        {
            repeaterCarrito.DataSource = carrito;
            repeaterCarrito.DataBind();

        }

        private void EliminarArticulo(Articulo articulo)
        {
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["CarritoCompras"];

            for (int i = 0; i < carrito.Count; i++)
            {
                if (carrito[i].id == articulo.id)
                {
                    carrito.RemoveAt(i);
                    return;
                }
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            articulo = articuloDB.buscarPorId(id);
            List<Articulo> carrito = new List<Articulo>();
            carrito = (List<Articulo>)Session["CarritoCompras"];

            EliminarArticulo(articulo);

            cargarCarrito(carrito);
            List<Articulo> carritoActual = (List<Articulo>)Session["CarritoCompras"];
            int cantArticulos = carritoActual.Count;

            Main masterPage = (Main)this.Master;
            masterPage.ActualizarContadorCarrito(cantArticulos);
            Response.Redirect("CarritoCompras.aspx");


        }




    }
}
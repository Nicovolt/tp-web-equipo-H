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
                articulo.Cantidad = 1;
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

           

        }
            private void ActualizarPrecioTotal(List<Articulo> carritoAct)
            {
            
             
            decimal total = 0;
            int cantidad=0;
            foreach (RepeaterItem item in repeaterCarrito.Items)
            {
                System.Web.UI.WebControls.Label lblCantidad = (System.Web.UI.WebControls.Label)item.FindControl("lblCantidad");
                if (lblCantidad != null)
                {
                    cantidad = int.Parse(lblCantidad.Text);
                }

            }

            foreach (Articulo art in carritoAct)
            {

                total += art.precio * art.Cantidad;
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

        protected void btnAumentarCantidad_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            ModificarCantidad(id, 1); // Aumentar cantidad en 1
        }

        protected void btnDisminuirCantidad_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            ModificarCantidad(id, -1); // Disminuir cantidad en 1
        }

        private void ModificarCantidad(int idArticulo, int cantidadModificar)
        {
            List<Articulo> carrito = (List<Articulo>)Session["CarritoCompras"];

            // Buscar el artículo en el carrito
            Articulo articulo = carrito.Find(a => a.id == idArticulo);
            if (articulo != null)
            {
                // Aumentar o disminuir la cantidad según el parámetro proporcionado
                articulo.Cantidad += cantidadModificar;

                // Asegurarse de que la cantidad no sea menor que 0
                if (articulo.Cantidad < 0)
                {
                    articulo.Cantidad = 0;
                }

                // Actualizar el repeater y el precio total
                cargarCarrito(carrito);
                ActualizarPrecioTotal(carrito);
            }
        }


    }
}
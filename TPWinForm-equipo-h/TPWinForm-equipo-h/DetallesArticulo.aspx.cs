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
    public partial class DetallesArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ///string idArticulo= Request.QueryString["id"];
            
            List<Articulo> detalle;
            detalle = Session["detalle"] != null ? (List<Articulo>)Session["detalle"]: new List<Articulo>();

            int id = int.Parse(Request.QueryString["id"]);

            List<Articulo> detalleOrg = (List<Articulo>)Session["articulosList"];
            Articulo select = detalleOrg.Find(x=>x.id == id);
            lblNombreArticulo.Text = select.nombre;
            lblDescripcionArticulo.Text = select.descripcion;
            lblCategoriaArticulo.Text = select.Categoria.Descripcion;
            lblMarcaArticulo.Text = select.Marca.Descripcion;
            lblPrecioArticulo.Text = select.precio.ToString();
            ImagenDB imagen = new ImagenDB();
            string img = imagen.listarUna(id);
            /*detalle.Add(select);*/

            


            dgvArtDetalle.DataSource = detalle;
            dgvArtDetalle.DataBind();   
        }
    }
}
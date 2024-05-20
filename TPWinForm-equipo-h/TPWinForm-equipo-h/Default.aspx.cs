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

            Session.Add("articulosList", articuloList);

        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

            Response.Redirect("DetallesArticulo.aspx?id=");
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Articulo> articulos;

            string busqueda = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                Resultados.Text = "";
            }
            else
            {
       
                articulos = BuscarArticulosPorNombre(busqueda);
                MostrarResultados(articulos);
            }




        }
        private List<Articulo> BuscarArticulosPorNombre(string nombre)
        {
            ArticuloDB articuloDB = new ArticuloDB();
            return articuloDB.BuscarPorNombre(nombre);
        }

        private void MostrarResultados(List<Articulo> articulos)
        {
            if (articulos.Count > 0)
            {
                var imagenDB = new ImagenDB();
                string htmlString = "";

                foreach (Articulo articulo in articulos)
                {
                    string img = imagenDB.listarUna(articulo.id);
                    string imageUrl = string.IsNullOrEmpty(img) ? "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg" : img;

                    htmlString += $@"
                    <div class='col'>
                        <div class='card'>
                            <img src='{imageUrl}' class='card-img-top' alt='Imagen del artículo'>
                            <div class='card-body'>
                                <h5 class='card-title'>{articulo.nombre}</h5>
                                <p class='card-text'>Descripción: {articulo.descripcion}</p>
                                <p class='card-text'>Precio: {articulo.precio}</p>
                                <a href='DetallesArticulo.aspx?id={articulo.id}' class='btn btn-primary'>Ver detalle</a>
                                <a href='CarritoCompras.aspx?id={articulo.id}' class='btn btn-primary'>Agregar al carrito</a>
                            </div>
                        </div>
                    </div>";
                }
                Resultados.Text = htmlString;
            }
            else
            {
                string htmlString = "";
                htmlString += $@"
               <h2>No se encontraron productos que coincidan</h2>";
                Resultados.Text = htmlString;

               

            }
        }



    }
}
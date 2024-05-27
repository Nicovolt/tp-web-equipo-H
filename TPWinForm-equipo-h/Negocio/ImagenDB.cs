using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ImagenDB
    {
        public void agregar(Imagen imagen)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            try
            {
                connection.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into IMAGENES values ('" + imagen.idArticulo + "', '" + imagen.url + "')";
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
                // MessageBox.Show("La imagen " + imagen.url + " no se pudo cargar...");
            }
            finally { connection.Close(); }
        }


        public string listarUna(int idArticulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT TOP 1 * FROM IMAGENES WHERE IdArticulo = @idArticulo;";
                comando.Parameters.AddWithValue("@idArticulo", idArticulo);
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                Imagen imagen = new Imagen();
                while (lector.Read())
                {
                    imagen.id = lector.GetInt32(0);
                    imagen.idArticulo = lector.GetInt32(1);

                    if (!lector.IsDBNull(lector.GetOrdinal("ImagenUrl")))
                    {
                        imagen.url = lector.GetString(lector.GetOrdinal("ImagenUrl"));
                    }
                    else
                    {
                        imagen.url = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
                    }
                }


                conexion.Close();

                return imagen.url;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> listarTodas(int idArticulo)
        {
            List<string> urlsImagenes = new List<string>();

            try
            {
                // Establecer la conexión a la base de datos
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
                {
                    // Definir la consulta SQL para obtener todas las imágenes asociadas al artículo
                    string consulta = "SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo;";

                    // Crear el comando SQL con la consulta y los parámetros
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Agregar el parámetro del ID del artículo
                        comando.Parameters.AddWithValue("@idArticulo", idArticulo);

                        // Abrir la conexión a la base de datos
                        conexion.Open();

                        // Ejecutar la consulta y leer los resultados
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            // Leer todas las URLs de las imágenes y agregarlas a la lista
                            while (lector.Read())
                            {
                                if (!lector.IsDBNull(0))
                                {

                                   string urlImagen = lector.GetString(0);
                                    urlsImagenes.Add(urlImagen);
                                }
                                else
                                {
                                    urlsImagenes.Add("https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la recuperación de las imágenes
                // Por ejemplo, podrías registrar el error en un archivo de registro
                Console.WriteLine("Error al obtener las imágenes del artículo: " + ex.Message);
            }

            return urlsImagenes;
        }


    }
}

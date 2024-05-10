using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TPWinForm_equipo_h
{
    public class ImagenNegocio
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
                //MessageBox.Show("La imagen " + imagen.url + " no se pudo cargar...");
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
                string img = null;
                while (lector.Read())
                {
                    imagen.id = lector.GetInt32(0);
                    imagen.idArticulo = lector.GetInt32(1);
                    imagen.url = (string)lector["ImagenUrl"];


                }
                img = imagen.url;
                conexion.Close();
                return img;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWinForm_equipo_h
{
    public class Imagen
    {
        public string url { get; set; }
        public int id { get; set; }
        public int idArticulo { get; set; }

        public override string ToString()
        {
            return url;
        }
    }
}
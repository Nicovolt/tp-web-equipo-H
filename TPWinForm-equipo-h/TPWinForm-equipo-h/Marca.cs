using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWinForm_equipo_h
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public  string url { get; set; }
        public int id { get; set; }
        public int idArticulo { get; set; }

        public override string ToString()
        {
            return url;
        }
    }
}

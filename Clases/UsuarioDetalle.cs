using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Proyecto.Clases
{
    public class UsuarioDetalle
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int Documento { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
    }

}

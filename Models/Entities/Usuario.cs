using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Proyecto.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [DisplayName("Nombre Completo")]
        [Column("NombreUsuario", TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        public int Documento { get; set; }
        public int Cargo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Telefono { get; set; }

    }
}

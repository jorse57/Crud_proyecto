using CRUD_Proyecto.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRUD_Proyecto.Models.DAL
{
    public class DB_Context_P: DbContext
    {
        public DB_Context_P(DbContextOptions<DB_Context_P>options):base(options)
        {
                    
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CargoUsuario> CargoUsuarios { get; set; }


    }
}

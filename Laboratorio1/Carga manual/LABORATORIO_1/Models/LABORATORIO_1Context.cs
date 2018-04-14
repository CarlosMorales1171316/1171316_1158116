using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LABORATORIO_1.Models
{
    public class LABORATORIO_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LABORATORIO_1Context() : base("name=LABORATORIO_1Context")
        {
        }

        public System.Data.Entity.DbSet<LABORATORIO_1.Models.Jugadores> Jugadores { get; set; }

        public System.Data.Entity.DbSet<LABORATORIO_1.Models.Jugadores2> Jugadores2 { get; set; }
    }
}

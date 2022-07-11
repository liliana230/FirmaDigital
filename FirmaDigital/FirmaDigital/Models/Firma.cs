using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FirmaDigital.Models
{
   public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int  cod { get; set; }

        public String codimagen { get; set; }

        [MaxLength(100)]
        public String nombre { get; set; }

        [MaxLength(100)]
        public String descripcion { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}


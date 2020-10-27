using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Business.Entity
{
    public class Paste
    {
        public int Id { get; set; }

        //public int IdTipoSabor { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required, StringLength(250)]
        public string Descripcion { get; set; }
        public virtual TipoSabor TipoSabor { get; set; }
    }
}

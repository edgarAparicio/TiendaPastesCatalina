﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Business.Entity
{
    public class Paste
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }

        [Required, StringLength(250)]
        public string Descripcion { get; set; }
        public TipoSabor TipoSabor { get; set; }
    }
}

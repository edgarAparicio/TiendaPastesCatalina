using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Business.Entity
{
    public class Comentarios
    {
        public int Id { get; set; }

        [Required, StringLength(80, ErrorMessage = "El Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required, StringLength(80, ErrorMessage = "El Email es requerido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(250, ErrorMessage = "El mensaje es requerido.")]
        public string Mensaje { get; set; }
        public bool Contacto { get; set; }

    }
}

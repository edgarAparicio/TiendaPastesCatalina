using EdgarAparicio.PastesCatalina.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Data
{
    public class DataComentarios : IComentarios
    {
        private readonly DbContextPastesCatalina db;

        public DataComentarios(DbContextPastesCatalina contextPastesCatalina)
        {
            this.db = contextPastesCatalina;
        }

        public void EnviarComentarios(Comentarios comentarios)
        {
            db.Comentarios.Add(comentarios);
            db.SaveChanges();
        }

    }
}

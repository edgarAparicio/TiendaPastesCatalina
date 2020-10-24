using EdgarAparicio.PastesCatalina.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EdgarAparicio.PastesCatalina.Data
{
    public class DataPaste : IPaste
    {
        private readonly DbContextPastesCatalina db;

        public DataPaste(DbContextPastesCatalina dbContextPastesCatalina)
        {
            this.db = dbContextPastesCatalina;
        }

        public Paste ActualizarPaste(Paste pasteActualizado)
        {
            var pasteAEditar = db.Paste.Attach(pasteActualizado);
            pasteAEditar.State = EntityState.Modified;
            return pasteActualizado;
        }

        public IEnumerable<Paste> BuscarPastesPorNombre(string nombrePaste)
        {
            return from paste in db.Paste
                   where paste.Nombre.StartsWith(nombrePaste) || string.IsNullOrEmpty(nombrePaste)
                   select paste;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Paste CrearPaste(Paste pasteNuevo)
        {
            db.Add(pasteNuevo);
            return pasteNuevo;
        }

        public Paste EliminarPaste(int idPaste)
        {
            var pasteEliminado = ObtenerPastePorId(idPaste);
            if(pasteEliminado != null)
            {
                db.Paste.Remove(pasteEliminado);
            }
            return pasteEliminado;
        }

        public IEnumerable<Paste> ObtenerListaPastes()
        {
            return from paste in db.Paste
                   orderby paste.Nombre
                   select paste;
        }


        public Paste ObtenerPastePorId(int idPaste)
        {
            return db.Paste.Find(idPaste);
        }
    }
}

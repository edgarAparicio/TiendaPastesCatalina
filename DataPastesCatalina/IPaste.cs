using EdgarAparicio.PastesCatalina.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Data
{
    public interface IPaste
    {
        IEnumerable<Paste> ObtenerListaPastes();

        Paste ObtenerPastePorId(int idPaste);

        Paste ActualizarPaste(Paste pasteActualizado);

        Paste EliminarPaste(int idPaste);

        Paste CrearPaste(Paste pasteNuevo);

        IEnumerable<Paste> BuscarPastesPorNombre(string nombrePaste);

        int Commit();

    }
}

using EdgarAparicio.PastesCatalina.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EdgarAparicio.PastesCatalina.Data
{
    public class DataTipoSabor //: ITipoSabor
    {
        private readonly DbContextPastesCatalina db;

        public DataTipoSabor(DbContextPastesCatalina dbContextPastesCatalina)
        {
            this.db = dbContextPastesCatalina;
        }
        //public IEnumerable<TipoSabor> ObtenerListaTipoSabor()
        //{
        //    var ListaTipoSabor = from sabor in db.TipoSabor 
        //                         orderby sabor.Nombre
        //                         select sabor;
        //    return ListaTipoSabor;
        //}
    }
}

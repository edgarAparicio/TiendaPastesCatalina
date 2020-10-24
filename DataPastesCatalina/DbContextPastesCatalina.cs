using EdgarAparicio.PastesCatalina.Business.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Data
{
    public class DbContextPastesCatalina : DbContext
    {
        public DbContextPastesCatalina(DbContextOptions<DbContextPastesCatalina> options) : base(options)
        {

        }

        public DbSet<Paste> Paste { get; set; }

        public DbSet<TipoSabor> TipoSabor { get; set; }
    }
}

using EdgarAparicio.PastesCatalina.Business.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.PastesCatalina.Data
{
    //Clase Para un DbContext normal 
    //public class DbContextPastesCatalina : DbContext
    //{
    //    public DbContextPastesCatalina(DbContextOptions<DbContextPastesCatalina> options) : base(options)
    //    {

    //    }

    //    public DbSet<Paste> Paste { get; set; }

    //    public DbSet<Comentarios> Comentarios { get; set; }


    //}

    //Clase para involucrar Asp.Net Identity
    public class DbContextPastesCatalina : IdentityDbContext<IdentityUser>
    {
        public DbContextPastesCatalina(DbContextOptions<DbContextPastesCatalina> options) : base(options)
        {

        }

        public DbSet<Paste> Paste { get; set; }

        public DbSet<Comentarios> Comentarios { get; set; }
    }

}

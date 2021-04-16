using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mingrone.Lorenzo._5h.SecondaWeb.Models
{
    public class PrenotazioneContext : DbContext
    {
        public DbSet<Prenotazione> Prenotazioni {get;set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Database.db");
    }

    
}
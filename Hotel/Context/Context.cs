using Hotel.Configuration;
using Hotel.Entities;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Context
{
    public class Context:DbContext
    {


        public virtual DbSet<frontend> frontends { get; set; }
        public virtual DbSet<kitchen> kitchens { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
                optionsBuilder.UseSqlServer("Server=DESKTOP-RM9R44Q;Database=Hotel;Integrated Security=True;Trust Server Certificate=True;Encrypt=false");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///4. Configuration Class
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new FrontendConfiguration());
            modelBuilder.ApplyConfiguration(new KitchenConfiguration());



            base.OnModelCreating(modelBuilder);

        }



    }
}

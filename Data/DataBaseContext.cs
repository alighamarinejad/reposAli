using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection.Emit;

namespace Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }


  

        public Microsoft.EntityFrameworkCore.DbSet<Models.User> User { get; set; }


        public Microsoft.EntityFrameworkCore.DbSet<Models.PhoneBook> PhoneBook { get; set; }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
            modelBuilder.Entity<Models.PhoneBook>().ToTable("PhoneBook");
            modelBuilder.Entity<Models.User>().ToTable("User");

        }



    }
}

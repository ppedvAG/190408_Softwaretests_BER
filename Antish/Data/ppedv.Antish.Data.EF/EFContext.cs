using ppedv.Antish.Domain;
using System;
using System.Data.Entity;

namespace ppedv.Antish.Data.EF
{
    public class EFContext : DbContext
    {
        // Minimal-Version von EF
        //public EFContext() : this(@"Server=.;Database=Antish_ProduktionsDB;Trusted_Connection=true") { }
        public EFContext() : this(@"Server=(localDB)\MSSQLLocalDB;Database=Antish_ProduktionsDB;Trusted_Connection=true;AttachDbFileName=C:\temp\antish.mdf") { }
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}

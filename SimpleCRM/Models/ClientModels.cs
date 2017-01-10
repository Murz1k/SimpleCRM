using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SimpleCRM.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string City { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class CRMDBContext : DbContext
    {
        public CRMDBContext () : base(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ClientsDB.mdf;Database=ClientsDB;Trusted_Connection=Yes;")
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
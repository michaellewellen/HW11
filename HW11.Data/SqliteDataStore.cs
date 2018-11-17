using HW11.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW11.Data
{
    public class SqliteDataStore : IDataStore
    {
        private readonly FlashCardsContext context;
        private readonly string dbPath;

        public SqliteDataStore(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new FlashCardsContext(dbPath);
        }

        public void AddPerson(Person c)
        {
            context.People.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return context.People;
        }
    }

    class FlashCardsContext : DbContext
    {
        private static bool _created = false;
        private readonly string dbPath;

        public FlashCardsContext(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));

            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(c => c.FirstName);
        }

        public DbSet<Person> People { get; set; }
    }
}

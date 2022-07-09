using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Note.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }

        // нам нужно инициализировать свойство типа DbSet - инициализировать свойство значением типа Set<T>
            public DbSet<Note> Notes => Set<Note>();
    }
}


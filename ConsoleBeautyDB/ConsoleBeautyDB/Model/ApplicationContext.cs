using Microsoft.EntityFrameworkCore;

namespace ConsoleBeautyDB.Model
{
    public class ApplicationContext : DbContext // общий объединяющий класс (наша база данных)
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();// для автоматического создания сущностей на нашем сервере 
        }

        // когда мы будем создавать ApplicationContext, он должен будет подсоединиться
        // к базе данных, для этого нужно прописать строку подключения к нашему локальному
        // серверу
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = BeautyDB; Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = True");
        }

        // указываем, что в этом классе будут храниться наши 4 таблицы
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Master> Masters => Set<Master>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<MasterService> MasterServices => Set<MasterService>();
    }
}
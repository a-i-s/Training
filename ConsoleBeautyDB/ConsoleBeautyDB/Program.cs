using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBeautyDB.Model;

namespace ConsoleBeautyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var dataBase = new ApplicationContext();

            // Todo раскомментировать для добавления данных в БД
            /*var masters = new List<Master>()
            {
                new Master("Larisa", 12),
                new Master("Anna", 18),
                new Master("Oleg", 24)
            };

            var services = new List<Service>()
            {
                new Service("Детская стрижка", "Стрижки для мальчиков: полубокс, модельная стрижка. Стрижка для девочук: каре, лесенка, выравнивание кончиков", 700),
                new Service("Мужская стрижка", "Полубокс, модельная, выравнивание кончиков, под бритву", 1200),
                new Service("Женская стрижка", "Каре, лесенка, выравнивание кончиков, горячие ножницы", 2000)
            };

            var bookings = new List<Booking>()
            {
                new Booking(1, 1, 18),
                new Booking(1, 2, 19),
                new Booking(2, 2, 19),
                new Booking(3, 3, 20)
            };
            
            dataBase.Bookings.AddRange(bookings);
            dataBase.Masters.AddRange(masters);
            dataBase.Services.AddRange(services);
            dataBase.SaveChanges();*/

            //var bookings = dataBase.Bookings.ToList(); - Все бронирования
            // для мастера 1 находим информацию о всех его бронированиях
            List<Booking>? bookings = dataBase.Bookings.Where(booking => booking.IdMaster == 1).ToList();
            foreach (var booking in bookings)
            {
                Master? master = dataBase.Masters.Find(booking.IdMaster);
                // с услуг первое совпадение, когда id услуги будет равен брони услуги
                Service? service = dataBase.Services.FirstOrDefault(service => service.Id == booking.IdService);
                Console.WriteLine($"Мастер - {master.Name}, Услуга - {service.Name}, Время: {booking.Time}");
            }
            
            // ищем услугу с Id = 2
            // Service? serv = dataBase.Services.Find(2); - можно и так, но будет брошено исключение, если не найдет
            Service? serv = dataBase.Services.FirstOrDefault(service => service.Id == 2);
            Console.WriteLine($"Информация о бронировании услуги - {serv.Name} ");
            // ищем все бронирования для услуги с Id 2
            bookings = dataBase.Bookings.Where(booking => booking.IdService == 2).ToList();
            foreach (Booking? booking in bookings)
            {
                Master? master = dataBase.Masters.Find(booking.IdMaster);
                Console.WriteLine($"Мастер - {master.Name}, Время: {booking.Time}");
            }
        }
    }
}
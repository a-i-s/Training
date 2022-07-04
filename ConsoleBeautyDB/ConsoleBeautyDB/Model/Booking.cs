using System.ComponentModel.DataAnnotations;

namespace ConsoleBeautyDB.Model
{
    public class Booking // бронирование
    {
        public Booking(int idMaster, int idService, int time)
        {
            IdMaster = idMaster;
            IdService = idService;
            Time = time;
        }

        [Key] // первичный ключ
        public int Id { set; get; }
        public int Time { set; get; }
        public int IdMaster { set; get; }
        public int IdService { set; get; }
        
    }
}
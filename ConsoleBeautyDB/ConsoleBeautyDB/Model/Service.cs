using System.ComponentModel.DataAnnotations;

namespace ConsoleBeautyDB.Model
{
    public class Service //услуга
    {
        [Key] // первичный ключ
        public int Id { set; get; }

        public string Name { set; get; } = null!;
        public string Description { set; get; } = null!; // описание услуги
        public int Cost { set; get; } // стоимость услуги

        public Service(string name, string description, int cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
}
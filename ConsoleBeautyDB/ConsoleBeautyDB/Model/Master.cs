using System.ComponentModel.DataAnnotations;

namespace ConsoleBeautyDB.Model
{
    public class Master
    {
        [Key] // первичный ключ
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public int Quantity { set; get; } // количество клиентов

        public Master(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
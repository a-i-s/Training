using System.ComponentModel.DataAnnotations;

namespace ConsoleBeautyDB.Model
{
    public class MasterService
    {
        public MasterService(int idMaster, int idService)
        {
            IdMaster = idMaster;
            IdService = idService;
        }

        [Key] // первичный ключ
        public int Id { set; get; }
        public int IdMaster { set; get; }
        public int IdService { set; get; }
    }
}
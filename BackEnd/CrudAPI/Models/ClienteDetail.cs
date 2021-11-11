using System.ComponentModel.DataAnnotations;

namespace CrudAPI.Models
{
    public class ClienteDetail
    {   
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string contato { get; set; }
    }
}

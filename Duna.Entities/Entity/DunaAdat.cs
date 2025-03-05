using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Duna.Entities.Entity
{
    public class DunaAdat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //[StringLength(10)]
        //public string Date { get; set; } = "";

        public DateTime Date { get; set; }

        public int Value { get; set; }
    }
}

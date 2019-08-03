using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            State = States.New;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public enum States { New, Deleted, Modified, Unmodified }
        [NotMapped]
        public States State { get; set; }


    }
}

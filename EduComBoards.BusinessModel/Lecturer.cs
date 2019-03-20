using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses
{
    [Table("Lecturers")]
    public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Comments> comments { get; set; }
        public virtual ICollection<DiscussionBoard> discussions { get; set; }
        // public virtual ICollection<PrivateDiscussionBoards> privateDiscussions { get; set; }
    }
}

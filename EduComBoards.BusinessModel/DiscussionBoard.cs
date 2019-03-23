using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebAPI.Models;

namespace DataClasses
{
    [Table("DiscussionBoards")]
    public class DiscussionBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

       // [ForeignKey("user")]
       // public string CreatedBy { get; set; }

       // public virtual ICollection<Comments> comments { get; set; }
        //public virtual ApplicationUser user { get; set; }
    }
}

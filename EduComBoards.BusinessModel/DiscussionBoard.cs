using EduComBoards.BusinessModel;
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

    // A DiscussionBoard is a Topic, which has posts and 
    //is created by a User if the user is a "contributor"
    [Table("DiscussionBoards")]
    public class DiscussionBoard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("user")]
        public int MemberID { get; set; }

        public virtual Member user { get; set; }
        public virtual ICollection<Post> posts { get; set; }
    }
}

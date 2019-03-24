using DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
    // A Discussion Topic can have many posts
    // ASP Users with the role of "Contributor" can create posts
    // Posts would include a Title like "Can I get some help with... "
    // and content with a longer description
    [Table("Posts")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("member")]
        public int MemberID { get; set; }

        // post associated with a member
        public virtual Member member { get; set; }
    }
}
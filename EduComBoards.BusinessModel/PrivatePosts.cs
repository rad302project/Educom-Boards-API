using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
    [Table("PrivatePosts")]
    public class PrivatePost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("member")]
        public int MemberID { get; set; }
        public virtual Member member { get; set; }
        public int BoardID { get; set; }
    }
}

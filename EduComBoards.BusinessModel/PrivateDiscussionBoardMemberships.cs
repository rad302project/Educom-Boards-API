using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
    [Table("PrivateDiscussionBoardMemberships")]
    public class PrivateDiscussionBoardMemberships
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int BoardID { get; set; }
    }
}

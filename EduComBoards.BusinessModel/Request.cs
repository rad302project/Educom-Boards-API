using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
    [Table("Requests")]
    public class Request
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }
        public int MemberID { get; set; }
        public string RequestedRole { get; set; }
        public string RequestedTitle { get; set; }
        public bool Reviewed { get; set; }
        public bool Granted { get; set; }

    }
}

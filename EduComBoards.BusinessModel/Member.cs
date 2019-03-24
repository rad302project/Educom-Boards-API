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
    [Table("Members")]
    // Anyone who signs up is created as a member
    // Then created as an ASP User with the role "member"
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        public string MemberName { get; set; }   
        public string UserID { get; set; }
    }
}

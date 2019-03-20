﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebAPI.Models;

namespace DataClasses
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("discussion")]
        public int DiscussionID { get; set; }

        //[ForeignKey("user")]
        public string UserID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual DiscussionBoard discussion { get; set; }
        //public virtual ApplicationUser user { get; set; }
    }
}

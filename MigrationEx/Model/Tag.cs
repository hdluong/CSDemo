using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MigrationEx
{
    [Table("Tag")]
    public class Tag
    {
        //[Key]
        //[StringLength(20)]
        //public int TagId { get; set; }

        [Key]
        public int TagId { get; set; }

        [Column(TypeName="ntext")]
        public string Content { get; set; }
    }
}

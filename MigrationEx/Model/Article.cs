﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MigrationEx
{
    [Table("article")]
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}

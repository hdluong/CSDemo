using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MigrationEx
{
    public class ArticleTag
    {
        public int ArticleTagId { get; set; }

        public int TagId { get; set; } //FK

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        public int ArticleId { get; set; } //FK

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
    }
}

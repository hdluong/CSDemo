﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TestScaffold.Models
{
    public partial class Shipper
    {
        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [StringLength(255)]
        public string Hoten { get; set; }
        [StringLength(255)]
        public string Sodienthoai { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Images")]
    public class Tags
    {
        [Key]
        public long id { get; set; }

        public long? parent_id { get; set; }

        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string slug { get; set; }

        public int? used { get; set; }

        public int created_at { get; set; }

        public int? updated_at { get; set; }

        public byte type { get; set; }

        public bool? show_athome { get; set; }

        public byte? index_athome { get; set; }

        public byte? col_athome { get; set; }

    }
}

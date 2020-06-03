using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Images")]
    public class TagTypes
    {
        [Key]
        public short id { get; set; }
        [StringLength(150)]
        public string name { get; set; }
    }
}

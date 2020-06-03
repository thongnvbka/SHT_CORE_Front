using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Modules")]
    public partial class Modules
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string JsonData { get; set; }
        public Nullable<int> UnitID { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("ModuleTypes")]
    public class ModuleTypes
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
    }
}

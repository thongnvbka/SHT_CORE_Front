using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("ConfigUnitDisplay")]
    public partial class ConfigUnitDisplay
    {
        [Key]
        public int UnitId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string ConfigHeaderJson { get; set; }
        public string ConfigFooterJson { get; set; }
        public string ConfigTextRunJson { get; set; }
        public int ThemeId { get; set; }
        public string CssName { get; set; }
    }
}
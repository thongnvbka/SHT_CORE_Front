using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Themes")]
    public partial class Themes
    {
        [Key]
        public int Id { get; set; }
        public string CssName { get; set; }
        public string Name { get; set; }
        public string ImagePreview { get; set; }
        public bool Active { get; set; }
        public string LayoutView { get; set; }
    }
}

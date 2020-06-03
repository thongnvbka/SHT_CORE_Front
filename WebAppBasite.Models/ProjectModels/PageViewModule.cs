using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("PageViewModule")]
    public partial class PageViewModule
    {
        [Key]
        public int Id { get; set; }
        public int IdPage { get; set; }
        public int IdModule { get; set; }
        public int IdUnit { get; set; }
        public string JsonData { get; set; }
        public string CssClass { get; set; }
        public Nullable<short> Position { get; set; }
        public Nullable<short> OrderView { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string Note { get; set; }
        public string PageName { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
    }
}

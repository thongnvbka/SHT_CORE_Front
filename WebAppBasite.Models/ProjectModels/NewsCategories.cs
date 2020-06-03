using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("NewsCategories")]
    public partial class NewsCategories
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitID { get; set; }
        public Nullable<int> OrderView { get; set; }
        public byte Type { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte AccessType { get; set; }
        public string TypeName { get; set; }
    }
}

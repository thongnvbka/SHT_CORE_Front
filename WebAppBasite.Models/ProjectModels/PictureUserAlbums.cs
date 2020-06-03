using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("PictureUserAlbum")]
    public partial class PictureUserAlbum
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdUnit { get; set; }
        public string IdUser { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? OrderView { get; set; }
        public bool? Active { get; set; }
    }
}

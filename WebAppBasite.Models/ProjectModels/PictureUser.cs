using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("PictureUser")]
    public partial class PictureUser
    {
        [Key]
        public int Id { get; set; }
        public int IdAlbum { get; set; }
        public int IdUnit { get; set; }
        public string PictureUrl { get; set; }
        public string PictureName { get; set; }
        public string PictureInfo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

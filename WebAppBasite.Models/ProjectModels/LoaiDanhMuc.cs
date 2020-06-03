using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("LoaiDanhMuc")]
    public partial class LoaiDanhMuc
    {
        [Key]
        public int id { get; set; }
        public string maLoaiDm { get; set; }
        public string tenLoaiDm { get; set; }
        public string tenNganMenu { get; set; }
        public Nullable<int> soThuTu { get; set; }
        public string moTa { get; set; }
        public string tieuDe { get; set; }
        public Nullable<byte> status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("DanhMucChung")]

    public partial class DanhMucChung
    {
        [Key]
        public long id { get; set; }
        public string TenDanhMuc { get; set; }
        public string MaDanhMuc { get; set; }
        public short LoaiDanhMuc { get; set; }
        public short SoThuTu { get; set; }
        public bool TrangThai { get; set; }
        public long? idDanhMucCha { get; set; }
        public Nullable<int> created_at { get; set; }
        public Nullable<int> updated_at { get; set; }
        public int Type { get; set; }
        public string Path { get; set; }

        public string Thumbnail { set; get; }

        public int ShowHome { set; get; }

        public string Url { set; get; }
        public string Template { set; get; }
    }
}

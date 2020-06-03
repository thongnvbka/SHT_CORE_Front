using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("News")]
    public class News
    {
        [Key]
        public int Id { get; set; }
      
        [StringLength(250)]
        public string Slug { get; set; }

       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitId { get; set; }

  
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Thumbnail { get; set; }

        [StringLength(1000)]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "ntext")]
        public string FullContent { get; set; }

        [StringLength(45)]
        public string related_news { get; set; }

        [StringLength(1000)]
        public int CatesId { get; set; }
        public int cate_id { get; set; }
        public int RANK { get; set; }
        public string cate_name { get; set; }
        public string cate_slug { get; set; }

        public string TenDanhMuc { set; get; }
        public int LoaiDanhMuc { set; get; }
        [StringLength(1000)]
        public string Tags { get; set; }

        public byte? Type { get; set; }

        public byte? Status { get; set; }


        public int? Read { get; set; }

        public int SoThuTu { set; get; }


        [Key]
        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreatedAt { get; set; }

        public int? UpdatedAt { get; set; }

        [Key]
        [System.ComponentModel.DataAnnotations.Schema.Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? PublishAt { get; set; }

        [StringLength(250)]
        public string meta_keywords { get; set; }

        [StringLength(550)]
        public string meta_descriptions { get; set; }

        public bool? show_athome { get; set; }

        public long? view_total { get; set; }

        public int? view_temp { get; set; }

        public int? last_visisted { get; set; }

        public int? last_sync_time { get; set; }

        public int? vb_coquan { get; set; }

        public int? vb_loaivb { get; set; }

        public int? vb_linhvuc { get; set; }

        public int? vb_tinhtrang { get; set; }

        [StringLength(150)]
        public string vb_sovb { get; set; }

        [StringLength(150)]
        public string vb_kyhieu { get; set; }

        public int? vb_ngaybanhanh { get; set; }

        [StringLength(250)]
        public string vb_nguoiky { get; set; }

        public int top_hot { set; get; }

        public string Tag_slug { set; get; }

        public string TagName { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
  public  class Videos
    {
        [Key]
        public int id { get; set; }

        public byte? page_kind_appear { get; set; }

        public short? position_inpage { get; set; }

        public short? type { get; set; }

        public short? order_inpage { get; set; }

        [StringLength(2500)]
        public string main_content { get; set; }
        public string thumb { get; set; }


        [StringLength(2500)]
        public string alter_content { get; set; }

        [StringLength(2500)]
        public string url { get; set; }

        [StringLength(450)]
        public string tooltip { get; set; }

        [StringLength(16)]
        public string display_weekday { get; set; }

        public short? display_time_on { get; set; }

        public short? display_time_off { get; set; }

        public int? created_at { get; set; }

        public int? updated_at { get; set; }

        public int AlbumId { set; get; }
    }
}

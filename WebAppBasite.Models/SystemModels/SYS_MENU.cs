using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.SystemModels
{
    [Table("SYS_MENU")]
    public partial class SYS_MENU
    {
        public int ID_SYS_MENU { get; set; }
        public string TENDANHMUC { get; set; }
        public byte? CAPDO { get; set; }
        public int? DANHMUCCHA { get; set; }
        public byte? DANHMUCCON { get; set; }
        public string CHITIET { get; set; }
        public string GHICHU { get; set; }
        public string CLASS { get; set; }
        public string CLASS_MAIN { get; set; }
        public DateTime? CREATEDATE { get; set; }
        public DateTime? UPDATEAT { get; set; }
        public string ACTION { get; set; }
        public string CONTROLLER { get; set; }
        public Nullable<byte> ORDERVIEW { get; set; }
        public bool Status { get; set; }
        public string ACCESS_RIGHT { get; set; }
    }
}

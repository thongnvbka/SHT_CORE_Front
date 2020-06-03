using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.SystemModels
{
    [Table("SYS_MENU_ROLE")]
    public class SYS_MENU_ROLE
    {
        public int ID { get; set; }
        public int ID_SYS_MENU { get; set; }
        public string ID_ROLE { get; set; }
        public string ACCESS_RIGHT { get; set; }
        public string TenDanhMuc { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Class { get; set; }
        public string CLASS_MAIN { get; set; }
        public byte? CAPDO { get; set; }
        public int? DANHMUCCHA { get; set; }
        public byte? DANHMUCCON { get; set; }
    }
}

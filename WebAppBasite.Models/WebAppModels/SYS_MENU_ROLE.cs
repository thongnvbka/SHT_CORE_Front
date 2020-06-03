using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppBasite.Models.WebAppModels
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
        public int CAPDO { get; set; }
        public int DANHMUCCHA { get; set; }
        public int DANHMUCCON { get; set; }
        public int Order { get; set; }
    }
}
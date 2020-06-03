namespace WebAppBasite.Models.WebAppModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SYS_MENU")]
    public partial class SYS_MENU
    {
        public int ID_SYS_MENU { get; set; }
        public string TENDANHMUC { get; set; }
        public int CAPDO { get; set; }
        public int DANHMUCCHA { get; set; }
        public int DANHMUCCON { get; set; }
        public string CHITIET { get; set; }
        public string GHICHU { get; set; }
        public string CLASS { get; set; }
        public string CLASS_MAIN { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> UPDATEAT { get; set; }
        public string ACTION { get; set; }
        public string CONTROLLER { get; set; }
        public int ORDERVIEW { get; set; }
        public string ACCESS_RIGHT { get; set; }
    }
}

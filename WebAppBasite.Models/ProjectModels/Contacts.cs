using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Contact")]
    public class Contacts
    {
        [Key]
        public int Id { set; get; }
        [StringLength(50)]
        public string Name { set; get; }
        [StringLength(50)]

        public string Phone { set; get; }
        [StringLength(50)]

        public string Email { set; get; }
        [StringLength(250)]
        public string Address { set; get; }
        [StringLength(2500)]
        public string GoogleMap { set; get; }

        public string Description { set; get; }
        public string MetaTitle { set; get; }
        public string Meta_Keyword { set; get; }
        public string Meta_Description { set; get; }
        public string OgUrl { set; get; }
        public string OgTitle { set; get; }
        public string OgDescription { set; get; }
        public string OgImage { set; get; }
        public int OgImgWidth { set; get; }
        public int OgImgheight { set; get; }

        [StringLength(2500)]
        public string Facebook { set; get; }
        [StringLength(2500)]
        public string Twitter { set; get; }
        [StringLength(2500)]
        public string Instagram { set; get; }
        [StringLength(16)]

        public string display_weekday { set; get; }
        public int StyleMenu { get; set; }
        public bool status { set; get; }


    }
}

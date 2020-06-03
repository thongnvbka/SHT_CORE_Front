using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Comment")]

    public  class Comments
    {
        [Key]
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }

    }
}

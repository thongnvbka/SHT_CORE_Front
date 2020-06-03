using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("UnitWorkCalendar")]
    public partial class UnitWorkCalendar
    {
        [Key]
        public int Id { get; set; }
        public int UnitId { get; set; }
        public DateTime DayWorkCalendar { get; set; }
        public short Status { get; set; }
        public string MorningNote { get; set; }
        public string AfternoonNote { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? PublishedAt { get; set; }

        public string CreatedByName { get; set; }
        public string PublishedByName { get; set; }
    }
}

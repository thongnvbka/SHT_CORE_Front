using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("UnitReport")]
    public partial class UnitReport
    {
        [Key]
        public int Id { get; set; }
        public DateTime DayReport { get; set; }
        public int TotalPeople { get; set; }
        public int PeopleInMisson { get; set; }
        public int PeopleInStudy { get; set; }
        public int PeopleInVacation { get; set; }
        public int PeopleInSick { get; set; }
        public int PeopleInOtherReason { get; set; }
        public string ReasonNote { get; set; }
        public string Title { get; set; }
        public int UnitId { get; set; }
        public string GroupId { get; set; }
        public short Status { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PublishedBy { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}

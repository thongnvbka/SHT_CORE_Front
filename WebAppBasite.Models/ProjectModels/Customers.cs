using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAppBasite.Models.ProjectModels
{
    [Table("Customers")]
  public  class Customers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Avatar { get; set; }
        public int Gender { get; set; }
        public string CMND { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Định dạng email không đúng!")]
        [Required]
        public string Email { get; set; }

        public int ID_tinh { get; set; }
        public int ID_huyen { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime BirthDay { get; set; }
        public string strBirthDay { get; set; }
        public int CreatedAt { get; set; }
        public int UpdatedAt { get; set; }
        public int VoucherNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Status { get; set; }
        public int CountService { get; set; }
        public string Note { get; set; }
        public int ACCPoint { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string xephang { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }
}

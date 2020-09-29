using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaTech.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        [Required]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }

        public List<UserViewModel> ListUser { get; set; }

        public string StringRole { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DAL_Class.Models
{
    public partial class TblUserDetail
    {
        public int UserId { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? IsDeleted { get; set; }
    }
}

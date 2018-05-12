using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplesOrdering.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeli { get; set; }
        public bool IsBakery { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int SystemId { get; set; }
    }
}
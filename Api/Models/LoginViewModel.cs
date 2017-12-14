using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Api.Models
{
    public class LoginViewModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
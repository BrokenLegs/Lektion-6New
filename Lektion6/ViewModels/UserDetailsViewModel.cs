using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion6.Models.Entities;

namespace Lektion6.ViewModels
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
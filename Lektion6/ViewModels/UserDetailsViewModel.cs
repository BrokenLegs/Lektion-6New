using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion6.Models.Entities;

namespace Lektion6.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(User us, List<Post> posts) {
            user = us;
            latestPosts = posts;
        }
        public User user;
        public List<Post> latestPosts;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion6.Models.Entities.Abstract;
using Lektion6.Utils;
using System.ComponentModel;

namespace Lektion6.Models.Entities
{
    public class User : IEntity
    {
        public User() { ID = Guid.NewGuid(); }
        public User(string name, UserType type)
        {
            ID = Guid.NewGuid();
            UserName = name;
            Type = type;
        }

        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { 
            get 
            {
                return Helpers.CreateHash(UserName);
            } 
        }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return "NoName";
                else if (string.IsNullOrEmpty(FirstName))
                    return LastName;
                /*
                else if (string.IsNullOrEmpty(LastName))
                    return FirstName;
                */
                else
                    return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public UserType Type { get; set; }

        public string ToString(bool ShortFormat = true)
        {
            string userString = string.Format("\tFullName: '{0}' - UserID: '{1}'", FullName, ID);
            if (!ShortFormat)
                userString += string.Format("\n\t\tUserName: '{0}' - UserType: '{1}'", UserName, Type);
            return userString;
        }

        public enum UserType
        {
            User,
            Admin,
            SuperUser
        }
    }
}

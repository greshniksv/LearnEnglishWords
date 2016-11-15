using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnEnglishWords.Database.Entities
{
    public class Settings
    {
        private User _user;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Type
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
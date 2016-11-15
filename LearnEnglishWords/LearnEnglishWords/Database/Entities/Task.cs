using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnEnglishWords.Database.Entities
{
    public class Task
    {
        private User _user;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual int Type
        {
            get;
            set;
        }


        public virtual int Status
        {
            get;
            set;
        }


        public virtual string Name
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
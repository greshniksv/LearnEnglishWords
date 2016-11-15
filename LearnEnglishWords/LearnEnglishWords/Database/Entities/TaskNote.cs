using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnEnglishWords.Database.Entities
{
    public class TaskNote
    {
        private User _user;
        private Task _task;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual DateTime DateTime
        {
            get;
            set;
        }

        public virtual string Message
        {
            get;
            set;
        }

        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public virtual Task Task
        {
            get { return _task; }
            set { _task = value; }
        }

    }
}
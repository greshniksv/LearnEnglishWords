using System;
using System.Collections.Generic;

namespace LearnEnglishWords.Database.Entities
{
    public class User
    {
        IList<Progress> _progress = new List<Progress>();
        IList<Settings> _settings = new List<Settings>();
        IList<Task> _task = new List<Task>();
        IList<TaskNote> _taskNote = new List<TaskNote>();
        IList<Dictionary> _dictionary = new List<Dictionary>();

        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string Name
        {
            get;
            set;
        }
        public virtual string Login
        {
            get;
            set;
        }
        public virtual string Password
        {
            get;
            set;
        }
        public virtual string Words
        {
            get;
            set;
        }
        public virtual string Email
        {
            get;
            set;
        }
        public virtual int LoginCount
        {
            get;
            set;
        }
        public virtual DateTime LastLogin
        {
            get;
            set;
        }

        public virtual IList<Dictionary> Dictionaries
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }

        public virtual IList<Settings> Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        public virtual IList<Progress> Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }

        public virtual IList<TaskNote> TaskNotes
        {
            get { return _taskNote; }
            set { _taskNote = value; }
        }

        public virtual IList<Task> Tasks
        {
            get { return _task; }
            set { _task = value; }
        }
    }
}
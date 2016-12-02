using System.Collections.Generic;

namespace LearnEnglishWords.Database.Entities
{
    public class Task
    {
        private User _user;
        IList<TaskNote> _taskNotes = new List<TaskNote>();

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

        public virtual IList<TaskNote> TaskNotes
        {
            get { return _taskNotes; }
            set { _taskNotes = value; }
        }
    }
}
using System.Collections.Generic;

namespace LearnEnglishWords.Database.Entities
{
    public class Dictionary
    {
        IList<Word> _words = new List<Word>();
        private User _user;

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual IList<Word> Words
        {
            get { return _words; }
            set { _words = value; }
        }
        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
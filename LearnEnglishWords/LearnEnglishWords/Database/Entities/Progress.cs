using System;

namespace LearnEnglishWords.Database.Entities
{
    public class Progress
    {
        private User _user;
        private Word _word;

        public virtual Guid Id
        {
            get;
            set;
        }

        public virtual int HitsCount
        {
            get;
            set;
        }

        public virtual User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public virtual Word Word
        {
            get { return _word; }
            set { _word = value; }
        }

    }
}
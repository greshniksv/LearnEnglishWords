using System.Collections.Generic;

namespace LearnEnglishWords.Database.Entities
{
    public class Word
    {
        IList<Progress> _progress = new List<Progress>();

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string WordItem
        {
            get;
            set;
        }

        public virtual string Translation
        {
            get;
            set;
        }

        public virtual IList<Progress> Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }
    }
}
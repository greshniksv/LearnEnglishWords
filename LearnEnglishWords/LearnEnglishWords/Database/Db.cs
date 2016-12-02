using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NHibernate.Tool.hbm2ddl;
using LearnEnglishWords.Database.Entities;

namespace LearnEnglishWords.Database
{
    public static class Db
    {
        
        #region Private

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(User).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        #endregion

        public static ISession Session => SessionFactory.OpenSession();


        public static void CreateDb()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(User).Assembly);
            var schemaExport = new SchemaExport(configuration);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);

            InsertTestData();
        }

        private static void InsertTestData()
        {
            var user = new User
            {
                Name = "admin",
                Login = "admin",
                Password = "123456",
                LastLogin = DateTime.Now
            };

            var dict = new Dictionary()
            {
                Name = "Base",
                User = user
            };
            user.Dictionaries.Add(dict);

            var word1 = new Word()
            {
                WordItem = "Car",
                Translation = "Машина",
                Dictionary = dict
            };

            var word2 = new Word()
            {
                WordItem = "Door",
                Translation = "Дверь",
                Dictionary = dict
            };

            var progress = new Progress()
            {
                User = user,
                HitsCount = 0,
                Word = word1
            };
            word1.Progress.Add(progress);
            word2.Progress.Add(progress);

            var task = new Task()
            {
                User = user,
                Name = "Test",
                Status = 0,
                Type = 1
            };

            TaskNote taskNote = new TaskNote()
            {
                User = user,
                Task = task,
                DateTime = DateTime.Now,
                Message = "bla bla"
            };
            task.TaskNotes.Add(taskNote);

            Entities.Settings settings = new Entities.Settings()
            {
                User = user,
                Name = "fdgfxg",
                Value = "11",
                Type = "Test.test"
            };

            using (var session = Session)
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(user);
                session.Save(dict);
                session.Save(word1);
                session.Save(word2);
                session.Save(progress);
                session.Save(task);
                session.Save(taskNote);
                session.Save(settings);

                transaction.Commit();
            }
        }
    }
}
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
            Random random = new Random();

            var user = new User
            {
                Name = "admin",
                Login = "admin",
                Password = "123456",
            };

            var lenkaUser = new User
            {
                Name = "Ленка",
                Login = "lenka",
                Password = "123456",
            };

            var sergUser = new User
            {
                Name = "Серж",
                Login = "serg",
                Password = "123456",
            };
        }
    }
}
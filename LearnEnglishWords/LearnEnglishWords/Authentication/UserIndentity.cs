﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using NHibernate;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Exceptions;

namespace LearnEnglishWords.Authentication
{
    public class UserIndentity : IIdentity
    {
        public User User { get; set; }

        public string AuthenticationType => typeof(User).ToString();

        public bool IsAuthenticated => User != null;

        public Guid Id => User.Id;

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Name;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string id, ISession session)
        {
            if (!string.IsNullOrEmpty(id))
            {
                IList<User> matchingObjects = 
                    session.QueryOver<User>().Where(x => x.Id == new Guid(id)).List<User>();

                if (!matchingObjects.Any())
                {
                    throw new UserNotFoundException($"Not found user with id: {id}");
                }

                User = matchingObjects.First();
            }
        }
    }
}
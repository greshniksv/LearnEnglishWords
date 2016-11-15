using System.Collections.Generic;
using MediatR;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;

namespace LearnEnglishWords.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserModel>>
    {
        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<UserModel> Handle(GetUsersQuery message)
        {
            IList<UserModel> userModels;
            using (var session = Db.Session)
            {
                var users = session.QueryOver<User>();
                if (message.UsersId != null)
                {
                    users.Where(x => message.UsersId.Contains(x.Id));
                }
                else if(message.Logins != null)
                {
                    users.Where(x => message.Logins.Contains(x.Login));
                }
                else if (message.Emails != null)
                {
                    users.Where(x => message.Emails.Contains(x.Email));
                }

                userModels = AutoMapperConfig.Mapper.Map<IList<UserModel>>(users.List());
            }

            return userModels;
        }
    }
}
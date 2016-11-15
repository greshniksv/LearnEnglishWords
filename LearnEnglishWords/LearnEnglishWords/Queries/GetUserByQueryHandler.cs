using System;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetUserByQueryHandler : IRequestHandler<GetUserByQuery, UserModel>
    {
        public UserModel Handle(GetUserByQuery message)
        {
            using (var session = Db.Session)
            {
                var users = session.QueryOver<User>();

                if (message.UserId != Guid.Empty)
                {
                    users.Where(x => x.Id == message.UserId);
                }
                else if (!string.IsNullOrEmpty(message.Login))
                {
                    users.Where(x => x.Login == message.Login);
                }
                else if (!string.IsNullOrEmpty(message.Email))
                {
                    users.Where(x => x.Email == message.Email);
                }

                return AutoMapperConfig.Mapper.Map<UserModel>(users.List().FirstOrDefault());
            }
        }
    }
}
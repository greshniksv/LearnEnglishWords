using System;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {
        public bool Handle(AddUserCommand message)
        {
            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                var user = new User();
                AutoMapperConfig.Mapper.Map(message.UserModel, user);
                session.Save(user);
                transaction.Commit();
            }

            return true;
        }
    }
}
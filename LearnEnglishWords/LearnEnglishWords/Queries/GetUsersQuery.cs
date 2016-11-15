using System;
using System.Collections.Generic;
using MediatR;
using LearnEnglishWords.Models;

namespace LearnEnglishWords.Queries
{
    public class GetUsersQuery : IRequest<IList<UserModel>>
    {
        public IList<Guid> UsersId { get; set; }
        public IList<string> Logins { get; set; }
        public IList<string> Emails { get; set; }
    }
}
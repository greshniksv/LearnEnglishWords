using System;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Queries
{
    public class GetUserByQuery : IRequest<UserModel>
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
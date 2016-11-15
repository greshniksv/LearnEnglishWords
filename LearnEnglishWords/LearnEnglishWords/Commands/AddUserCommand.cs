using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearnEnglishWords.Models;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
        public UserModel UserModel { get; set; }
    }
}
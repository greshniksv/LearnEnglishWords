using System;
using System.Configuration;
using System.Linq;
using LearnEnglishWords.Database;
using LearnEnglishWords.Database.Entities;
using LearnEnglishWords.Exceptions;
using LearnEnglishWords.Queries;
using System.Collections.Generic;
using MediatR;

namespace LearnEnglishWords.Commands
{
    public class RestorePasswordCommandHandler : IRequestHandler<RestorePasswordCommand, bool>
    {
        private readonly IMediator _mediator;

        public RestorePasswordCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool Handle(RestorePasswordCommand message)
        {
            var passwordLength = ConfigurationManager.AppSettings["PasswordLength"];
            var newPassword = _mediator.Send(new GeneratePasswordQuery() {Length = Int32.Parse(passwordLength) });
            string userName;

            // Update use password
            using (var session = Db.Session)
            using (var transaction = session.BeginTransaction())
            {
                var user = session.QueryOver<User>().Where(x => x.Email == message.Email).List().FirstOrDefault();

                if (user == null)
                {
                    throw new UserNotFoundException($"Email: {message.Email}");
                }
                userName = user.Name;
                user.Password = newPassword;
                session.Save(user);
                transaction.Commit();
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "Password", newPassword },
                { "Name", userName }
            };

            // Send email
            _mediator.Send(new SendEmailCommand()
            {
                Email = message.Email,
                TempateName = "ForgotPassword",
                Parameters = dictionary
            });

            return true;
        }
    }
}
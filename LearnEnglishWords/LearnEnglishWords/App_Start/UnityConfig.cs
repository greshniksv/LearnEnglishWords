using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.Practices.Unity;
using LearnEnglishWords.Authentication;
using LearnEnglishWords.Commands;
using LearnEnglishWords.Unility;
using LearnEnglishWords.Unility.Interfaces;

namespace LearnEnglishWords
{
    public class UnityConfig
    {
        private static readonly IEnumerable<Type> MediatorTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IAsyncRequestHandler<,>)
        };

        public static void RegisterTypes(UnityContainer container)
        {
            container
                .RegisterType<IHashCalculator, Md5HashCalculator>()
                .RegisterType<IAuthentication, CustomAuthentication>();


            // MediatR
            container.RegisterType<IMediator, Mediator>();

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(AddUserCommand).Assembly)
                    .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                            MediatorTypes.Contains(i.GetGenericTypeDefinition()))),
                WithMappings.FromAllInterfaces);

            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
        }

    }
}
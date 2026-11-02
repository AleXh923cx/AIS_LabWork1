using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Модуль Ninject для базовой конфигурации
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<CharacterService>().ToSelf().InSingletonScope();
            Bind<ICharacterService>().ToMethod(ctx => ctx.Kernel.Get<CharacterService>());
            Bind<ICharacterRead>().ToMethod(ctx => ctx.Kernel.Get<CharacterService>());
            Bind<ICharacterWrite>().ToMethod(ctx => ctx.Kernel.Get<CharacterService>());
            Bind<ICharacterSort>().ToMethod(ctx => ctx.Kernel.Get<CharacterService>());
            Bind<ICharacterFilter>().ToMethod(ctx => ctx.Kernel.Get<CharacterService>());

            // Читаем настройку из App.config
            string repositoryType = ConfigurationManager.AppSettings["RepositoryType"] ?? "entity";

            switch (repositoryType.ToLower().Trim())
            {
                case "dapper":
                    Bind<IRepository<Character>>().To<DapperRepository<Character>>().InSingletonScope();
                    break;
                case "entity":
                default:
                    Bind<IRepository<Character>>().To<EntityRepository<Character>>().InSingletonScope();
                    break;
            }
        }
    }
}

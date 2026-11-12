using DataAccessLayer;
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
            Bind<ICharacterRead>().To<CharacterReader>().InSingletonScope();
            Bind<ICharacterWrite>().To<CharacterWriter>().InSingletonScope();
            Bind<ICharacterFilter>().To<CharacterFilter>().InSingletonScope();
            Bind<ICharacterSort>().To<CharacterSorter>().InSingletonScope();
            Bind<ICharacterQueryService>().To<CharacterQueryService>().InSingletonScope();

            // Читаем настройку из App.config
            string repositoryType = ConfigurationManager.AppSettings["RepositoryType"] ?? "entity";

            switch (repositoryType.ToLower().Trim())
            {
                case "dapper":
                    Bind<DapperRepository<Character>>().ToSelf().InSingletonScope();
                    Bind<IRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<DapperRepository<Character>>());
                    Bind<IReadRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<DapperRepository<Character>>());
                    Bind<IWriteRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<DapperRepository<Character>>());
                    break;
                case "entity":
                default:
                    Bind<EntityRepository<Character>>().ToSelf().InSingletonScope();
                    Bind<IRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<EntityRepository<Character>>());
                    Bind<IReadRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<EntityRepository<Character>>());
                    Bind<IWriteRepository<Character>>().ToMethod(ctx => ctx.Kernel.Get<EntityRepository<Character>>());
                    break;
            }
        }
    }
}

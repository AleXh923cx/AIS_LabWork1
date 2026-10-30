using DataAccessLayer;
using Model;
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
            Bind<ICharacterService>().To<CharacterService>().InSingletonScope();
            Bind<ICharacterRead>().To<CharacterService>().InSingletonScope();
            Bind<ICharacterWrite>().To<CharacterService>().InSingletonScope();
            Bind<ICharacterSort>().To<CharacterService>().InSingletonScope();
            Bind<ICharacterFilter>().To<CharacterService>().InSingletonScope();

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

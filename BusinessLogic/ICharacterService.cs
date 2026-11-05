using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс службы персонажа (фасад четырёх узких интерфейсов)
    /// </summary>
    public interface ICharacterService : 
        ICharacterRead, ICharacterWrite, ICharacterFilter, ICharacterSort
    {
    }
}

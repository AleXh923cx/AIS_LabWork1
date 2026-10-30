using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICharacterService : 
        ICharacterRead, ICharacterWrite, ICharacterFilter, ICharacterSort

    {
        void SeedIfEmpty();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public interface ICharacterRead
    {
        Character? GetCharacterById(int id);
        IEnumerable<Character> GetAllCharacters();
    }
}

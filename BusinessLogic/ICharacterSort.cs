using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICharacterSort
    {
        IEnumerable<Character> Sort(IEnumerable<Character> characters, bool sortByGenus);
    }
}

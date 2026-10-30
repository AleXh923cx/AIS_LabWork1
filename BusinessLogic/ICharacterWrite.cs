using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICharacterWrite
    {
        bool AddCharacter(string name, string genus, int age);
        bool DeleteCharacter(int id);
        bool UpdateCharacter(int id, string name, string genus, int age);
    }
}

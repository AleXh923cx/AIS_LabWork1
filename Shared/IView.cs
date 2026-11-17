using System;

namespace Shared
{
    public interface IView
    {
        event EventHandler<CharacterDto> RequestAdd;
        event EventHandler<CharacterDto> RequestUpdate;
        event EventHandler<int> RequestDelete;
    }
}

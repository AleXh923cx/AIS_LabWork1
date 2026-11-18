using System;

namespace Shared
{
    /// <summary>
    /// 
    /// </summary>
    public interface IView
    {
        event EventHandler<CharacterDto> RequestAdd;
        event EventHandler<CharacterDto> RequestUpdate;
        event EventHandler<int> RequestDelete;
        event EventHandler<int?> RequestFilter;

        void ShowList(List<CharacterDto> characters);
        void ShowMessage(string message);
    }
}

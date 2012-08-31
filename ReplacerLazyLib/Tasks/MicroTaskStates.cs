using System;

namespace Dem0n13.Replacer.Library.Tasks
{
    [Flags]
    public enum MicroTaskStates
    {
        None = 0x0,
        Reading = 0x1,
        Searching = 0x4 | Reading, // поиск совпадений
        Replacing = 0x8 | Searching, // замена совпадений
        BuildingResult = 0x10 | Replacing,
        SavingResult = 0x20 | BuildingResult,
        Complete = 0x40 | SavingResult // результат сохранен
    }
}
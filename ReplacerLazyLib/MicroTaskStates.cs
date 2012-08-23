using System;

namespace Dem0n13.Replacer.Library
{
    [Flags]
    public enum MicroTaskStates
    {
        None = 0x0,
        Reading = 0x1,
        Searching = 0x4 | Reading,
        Replacing = 0x8 | Searching,
        BuildingResult = 0x10 | Replacing,
        SavingResult = 0x20 | BuildingResult,
        Complete = 0x40 | SavingResult,
        //Immutable = 0x80 | Complete
    }
}
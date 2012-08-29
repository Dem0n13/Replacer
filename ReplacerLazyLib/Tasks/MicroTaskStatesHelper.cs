using System;
using System.Linq;

namespace Dem0n13.Replacer.Library.Tasks
{
    public static class MicroTaskStatesHelper
    {
        public static readonly MicroTaskStates[] StatesArray =
            Enum.GetValues(typeof(MicroTaskStates)).Cast<MicroTaskStates>().ToArray();
    }
}

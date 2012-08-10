using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dem0n13.Replacer.Library
{
    public interface INotifyLengthChanged
    {
        event EventHandler<LengthChangedEventArgs> LengthChanged;
    }
}

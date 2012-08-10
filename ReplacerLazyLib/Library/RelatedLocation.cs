using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dem0n13.Replacer.Library
{
    public class RelatedLocation
    {
        public int StartIndex { get; set; }
        public int Length { get; set; }
        
        public void SetOwner(INotifyLengthChanged owner)
        {
            owner.LengthChanged += Correct;
        }

        private void Correct(object sender, LengthChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}

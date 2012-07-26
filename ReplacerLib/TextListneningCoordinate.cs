using System.Diagnostics;

namespace Dem0n13.Replacer.Lib
{
    public class TextListneningCoordinate
    {
        public int Index { get; private set; }
        public bool Valid { get; private set; }

        public TextListneningCoordinate(int index, Text text)
        {
            Index = index;
            if (text.PlainText.Length > index)
                Valid = true;
            text.LengthChanged += CorrectIndex;
        }

        private void CorrectIndex(object sender, LengthChangedEventArgs e)
        {
            Debug.WriteLineIf(e.StartChangingIndex <= Index, e.Delta);
            if (e.StartChangingIndex <= Index) 
                Index += e.Delta;
            if (e.CurrentLength <= Index)
                Valid = false;
        }

        public new string ToString()
        {
            return Valid ? Index.ToString() : "Invalid coordinate";
        }
    }
}

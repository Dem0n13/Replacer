namespace Dem0n13.Replacer.Library.Utils
{
    public class RelatedLocation
    {
        private Boxed<int> _totalLegthCorrection;
        private int _startIndex;

        public int StartIndex
        {
            get { return _startIndex + (_totalLegthCorrection ?? 0); } //TODO cleanup
            set { _startIndex = value; }
        }

        public int Length { get; set; }
        
        public void SetOwner(TextLengthChanger owner)
        {
            _totalLegthCorrection = owner.TotalLegthCorrection;
        }
    }
}

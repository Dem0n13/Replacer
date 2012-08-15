namespace Dem0n13.Replacer.Library.Utils
{
    public class Boxed<T> where T: struct
    {
        public T Value;

        public Boxed(T value)
        {
            Value = value;
        }

        public Boxed()
        {
        }

        public static implicit operator T(Boxed<T> boxedValue)
        {
            return boxedValue.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

namespace EnumExtensions
{
    public static class EnumExtensions
    {
        public static bool IsBitSet<T>(this T value, int pos) where T : System.Enum
        {
            // Kind of an ugly way to do it, but it works
            return (((int)(object)value) & (1 << pos)) != 0;
        }
    }
}
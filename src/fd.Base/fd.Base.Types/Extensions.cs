namespace fd.Base.Types
{
    /// <summary>Provides extension methods for the types defined in this assembly.</summary>
    public static class Extensions
    {
        /// <summary>Converts the <paramref name="value"/> to a <see cref="Percentage" /> instance.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Percentage" /> value.</returns>
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0);
        }
    }
}

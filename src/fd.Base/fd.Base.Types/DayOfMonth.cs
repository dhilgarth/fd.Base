namespace fd.Base.Types
{
    /// <summary>A day of a month.</summary>
    public class DayOfMonth : Constrained<int>
    {
        /// <summary>Initializes a new instance of the <see cref="DayOfMonth" /> class.</summary>
        public DayOfMonth()
            : base(Constraint)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DayOfMonth" /> class.</summary>
        /// <param name="value">The value.</param>
        public DayOfMonth(int value)
            : base(Constraint, value)
        {
        }

        /// <summary>Performs an <see langword="implicit" /> conversion from <see cref="System.Int32" /> to <see cref="DayOfMonth" /> .</summary>
        /// <param name="value">The value representing the day of month.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DayOfMonth(int value)
        {
            return new DayOfMonth(value);
        }

        /// <summary>Checks whether the specified <paramref name="value" /> represents a valid day of month.</summary>
        /// <param name="value">The value to be <see langword="checked" /> against the constraint.</param>
        /// <returns><c>true</c> if the supplied <paramref name="value" /> represents a valid day of month; otherwise, <c>false</c> .</returns>
        private static bool Constraint(int value)
        {
            return value >= 1 && value <= 31;
        }
    }
}

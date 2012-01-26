namespace fd.Base.Types
{
    /// <summary>Represents a month.</summary>
    public class Month : Constrained<int>
    {
        /// <summary>Initializes a new instance of the <see cref="Month" /> class.</summary>
        public Month()
            : base(Constraint)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Month" /> class.</summary>
        /// <param name="value">The value.</param>
        public Month(int value)
            : base(Constraint, value)
        {
        }

        /// <summary>Performs an <see langword="implicit"/> conversion from <see cref="int" /> to <see cref="Month" /> .</summary>
        /// <param name="value">The value representing the month.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Month(int value)
        {
            return new Month(value);
        }

        /// <summary>Checks whether the specified <paramref name="value"/> represents a valid month.</summary>
        /// <param name="value">The value to be <see langword="checked"/> against the constraint.</param>
        /// <returns><c>true</c> if the supplied <paramref name="value"/> represents a valid month; otherwise, <c>false</c> .</returns>
        private static bool Constraint(int value)
        {
            return value >= 1 && value <= 12;
        }
    }
}

namespace fd.Base.Types
{
    /// <summary>Represents a digit.</summary>
    public class Digit : Constrained<int>
    {
        /// <summary>Initializes a new instance of the <see cref="Digit" /> class.</summary>
        /// <param name="value">The value.</param>
        public Digit(int value)
            : base(Constraint, value)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Digit" /> class.</summary>
        public Digit()
            : base(Constraint)
        {
        }

        /// <summary>Performs an <see langword="implicit"/> conversion from <see cref="System.Int32" /> to <see cref="Digit" /> .</summary>
        /// <param name="value">The value representing the digit.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Digit(int value)
        {
            return new Digit(value);
        }

        /// <summary>Checks whether the specified <paramref name="value"/> represents a valid digit.</summary>
        /// <param name="value">The value to be <see langword="checked"/> against the constraint.</param>
        /// <returns><c>true</c> if the supplied <paramref name="value"/> represents a valid digit; otherwise, <c>false</c> .</returns>
        private static bool Constraint(int value)
        {
            return value >= 0 && value <= 9;
        }
    }
}
